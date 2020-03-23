using UnityEngine;

public enum E_ColorFlags
{
    CHROMA,
    CHROMATIMED,
    FIXED
}
public class LMS_GuiBaseLabel : LMS_GuiBaseCallback
{
    [SerializeField]
    E_ColorFlags m_RenderMode = E_ColorFlags.FIXED;
    float m_Interval;
    string m_LastRenderColor;
    LMS_ColorThread m_ColThread;
    string[] m_ExtraFlags;
    public bool Disable;
    public string UnderliningString;

    void OnGUI()
    {
        if (Hidden)
            return;
        if (!canRender)
            return;
        //GUILayout.BeginArea(QuickRect());
        //GUILayout.FlexibleSpace();
        switch (m_RenderMode)
        {
            case E_ColorFlags.CHROMA: //rapid flashing
                m_LastRenderColor = HexColor(new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f)));
                break;
            case E_ColorFlags.CHROMATIMED:
                if (!m_ColThread.Render)
                    m_ColThread.Render = true;
                m_LastRenderColor = m_ColThread.Value();
                break;
            default:
            case E_ColorFlags.FIXED:
                m_LastRenderColor = HexColor(Config.RenderStyle.normal.textColor);
                break;
        }
        if (Config.RenderStyle.font == null)
            Config.RenderStyle.font = Font.CreateDynamicFontFromOSFont(LMS_Meta.getMetaValue("LAB_FONT"), Config.RenderStyle.fontSize);
        if (Disable)
            m_LastRenderColor = HexColor(Color.gray);
        if (m_ExtraFlags != null)
        {
            foreach (string s in m_ExtraFlags)
            {
                switch (s)
                {
                    case "NONE":
                        break;
                    case "EXTRUDE":
                        GUI.Label(new Rect(QuickRect().position + new Vector2(1f, 1f), QuickRect().size), string.Format("<color=#{0}>{1}</color>", HexColor(Color.black), Config.Text), Config.RenderStyle);
                        break;
                    case "UNDERLINE":
                        GUI.Label(new Rect(QuickRect().position + new Vector2(0f, 2f), QuickRect().size), string.Format("<color=#{0}>{1}</color>", m_LastRenderColor, UnderliningString), Config.RenderStyle);
                        break;
                    case "OUTLINE":
                        GUI.Label(new Rect(QuickRect().position + new Vector2(1f, 0f), QuickRect().size), string.Format("<color=#{0}>{1}</color>", HexColor(Color.black), Config.Text), Config.RenderStyle);
                        GUI.Label(new Rect(QuickRect().position + new Vector2(0f, 1f), QuickRect().size), string.Format("<color=#{0}>{1}</color>", HexColor(Color.black), Config.Text), Config.RenderStyle);
                        GUI.Label(new Rect(QuickRect().position - new Vector2(0f, 1f), QuickRect().size), string.Format("<color=#{0}>{1}</color>", HexColor(Color.black), Config.Text), Config.RenderStyle);
                        break;
                }
            }
        }
        GUI.Label(QuickRect(), string.Format("<color=#{0}>{1}</color>", m_LastRenderColor, Config.Text), Config.RenderStyle);
       // GUILayout.FlexibleSpace();
        //GUILayout.EndArea();
    }
    void Awake()
    {
        m_ColThread = gameObject.AddComponent<LMS_ColorThread>();
        m_ColThread.SetOwner(this);
    }
    public override void SetTexture(int t, Texture2D tex)
    {
    }
    public void SetInterval(string inStr)
    {
        float f = 0f;
        foreach (string s in inStr.Split(' '))
        {
            float t;
            if (float.TryParse(s, out t))
                f += t;
        }
        m_Interval = f;
        m_ColThread.SetInterval(m_Interval);
        Debug.Log("LMS_GuiBaseLabel:: Updated Interval!");
    }
    public void SetRenderMode(E_ColorFlags mode)
    {
        m_RenderMode = mode;
    }
    public void SetFlags(params string[] flags)
    {
        m_ExtraFlags = flags;
        if (flags.Length == 0)
            return;
        if (flags[0] == "UNDERLINE")
            UnderliningString = flags[1];
    }
    public override string ComponentName()
    {
        return "LABEL";
    }
}
