using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_MainThread : MonoBehaviour
{
    LMS_DoubleBuffer<string, LMS_GuiScreen> Screens;
    float m_LastGCCleanTime;
    const float GC_CLEAN_INTERVAL = 20f;
    LMS_GuiBaseProgressBar InitBar;
    LMS_GuiBaseLabel StateLabel;
    LMS_GuiBaseBox2D SplashImage;

    public static LMS_MainThread Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        Screens = new LMS_DoubleBuffer<string, LMS_GuiScreen>();
    }
    public void RegisterScreen<Scr>(Scr screen, string scrName) where Scr : LMS_GuiScreen
    {
        if (Screens.ContainsKL(scrName))
        {
            throw new LMS_DuplicateScreenException(scrName);
        }
        Screens.Push(scrName, screen);
        screen.HideScreen();
    }
    public void ShowPopup(string name, string txt, string caption, string col, PopupHandler hnd)
    {
        LMS_GuiScreen scr = Screens[name];
        if (scr.IsPopup)
        {
            LMS_GuiPopup p = scr as LMS_GuiPopup;
            LMS_GuiBaseUtils.PreparePopup(p, txt, caption, LMS_GuiBaseUtils.StringToColor(col), hnd);
            p.ShowScreen();
        }
    }
    public void ShowScreen(string name)
    {
        try
        {
            Screens[name].ShowScreen();
        }
        catch { }
    }
    public T GetScreenInstance<T>(string name) where T : LMS_GuiScreen
    {
        if (Screens[name] != null)
        {
            return (T)Screens[name];
        }
        return null;
    }
    void Update()
    {
        CheckRes();
        GCUpdate();
    }
    void CheckRes()
    {
        if (Screen.width != 1280 || Screen.height != 720)
            Screen.SetResolution(1280, 720, true);
    }
    void GCUpdate()
    {
        if (Time.timeSinceLevelLoad > m_LastGCCleanTime + GC_CLEAN_INTERVAL)
        {
            GC.Collect();
            m_LastGCCleanTime = Time.timeSinceLevelLoad;
        }
    }
    void Start()
    {
        InitBar = LMS_GuiBaseUtils._InstantiateGUIElement<LMS_GuiBaseProgressBar>(new LMS_GuiConfig
        {
            Rect = new Rect(0f, 700f, 1280f, 20f)
        }, 928, new GameObject("Init"));
        InitBar.realProg = 100f;
        InitBar.ReloadRenderer = true;
        InitBar.canRender = true;
        InitBar.Speed = 1.5f;
        InitBar.Color = "(0.5803921568627451,0,0.8274509803921569)";
        SplashImage = LMS_GuiBaseUtils._InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig
        {
            Rect = new Rect(240f, 110f, 800f, 500f)
        }, 213, GameObject.Find("Init"));
        SplashImage.UseRelativeRect = false;
        LMS_ModifiedTexture test;
        LMS_GuiBaseUtils.ModifiedTexture("test", out test);
        SplashImage.SetTexture((int)E_Texture.IDLE, test.MainTexture);
        LMS_GuiParser.Parse(LitJson.JsonMapper.ToJson(SplashImage.GetParserOptions()));
    }
    public void RegisterTexture(string name, LMS_Txt txt)
    {
        Texture2D tex;
        LMS_GuiTexureLoader.LoadTexture(txt.GetRawText(), out tex);
        LMS_Textures.AddCache(name, tex);
    }
}

public class LMS_DuplicateScreenException : Exception
{
    string ScrName;
    public override string Message { get { return string.Format("Screen {0} already exists!", ScrName); } }
    public string ScreenName { get { return ScrName; } }

    public LMS_DuplicateScreenException(string screenName)
    {
        ScrName = screenName;
    }
}

public sealed class LMS_Txt
{
    public string m_Txt = "", m_RawTxt = "", recTxt;
    static LMS_DoubleBuffer<string, LMS_Txt> TxtBuffer = new LMS_DoubleBuffer<string, LMS_Txt>();

    public static LMS_Txt Resolve(string lmsTxtF)
    {
        return TxtBuffer.ContainsKL(lmsTxtF) ? TxtBuffer[lmsTxtF] : new LMS_Txt(lmsTxtF);
    }

    public LMS_Txt(string txt)
    {
        recTxt = txt;
        TxtBuffer.Push(txt, this);
    }
    public LMS_Txt()
    {
        LMS_TaskManager.RunTaskLater(2, () => { TxtBuffer.Push(recTxt, this); }, LMS_MainThread.Instance);
    }

    public string GetText()
    {
        if (m_Txt == null || m_Txt == "")
        {
            if (!recTxt.StartsWith("<LMS>"))
            {
                m_Txt = Inverse();
                return m_Txt;
            }
            else m_Txt = recTxt;
        }
        return m_Txt;
    }
    string Inverse()
    {
        if (recTxt.StartsWith("<LMS>"))
        {
            string inv = "";
            foreach (char c in recTxt.Replace("<LMS>", ""))
            {
                char c1 = (char)(c ^ 'S');
                char c2 = (char)(c1 ^ 'M');
                char c3 = (char)(c2 ^ 'L');
                inv += c3;
            }
            return inv;
        }
        else
        {
            string inv = "<LMS>";
            foreach (char c in recTxt)
            {
                char c1 = (char)(c ^ 'L');
                char c2 = (char)(c1 ^ 'M');
                char c3 = (char)(c2 ^ 'S');
                inv += c3;
            }
            return inv;
        }
    }
    public string GetRawText()
    {
        if (m_RawTxt == null || m_RawTxt == "")
        {
            if (recTxt.StartsWith("<LMS>"))
            {
                m_RawTxt = Inverse();
                return m_RawTxt;
            }
            else m_RawTxt = recTxt;
        }
        return m_RawTxt;
    }
    public override string ToString()
    {
        return string.Format("Raw Text: {0}\nLMS TXT: {1}", GetRawText(), GetText());
    }
}