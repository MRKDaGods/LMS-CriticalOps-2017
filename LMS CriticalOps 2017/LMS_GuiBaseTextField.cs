using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text.RegularExpressions;

public enum E_Validation
{
    ALPHA_NUMERIC = 0,
    NUMBERS = 4
}

public delegate void TextFieldTextChanged(string s);

public class LMS_GuiBaseTextField : LMS_GuiBaseCallback
{
    [SerializeField]
    public Texture2D m_IdleTex, m_DownTex;
    public string TextToRender = "";
    E_Validation m_Valid;
    bool m_Focused;
    public bool Password;
    string RealText = "", m_LastReadText;
    public string Text { get { return RealText; }
        set { RealText = value; }
    }
    public TextFieldTextChanged OnTextChanged;

    public override void SetTexture(int t, Texture2D tex)
    {
        if (t == (int)E_Texture.IDLE)
            m_IdleTex = tex;
        else Debug.LogWarning("Attempting to register an unsupported texture :: LMS_GuiBaseTextField");
    }
    void Start()
    {
        m_DownTex = GeneratePlainTexture(Color.black.AlterAlpha(0.4f));
        ReloadRenderer = true;
    }
    void OnGUI()
    {
        if (Hidden)
            return;
        if (ReloadRenderer)
        {
            Config.RenderStyle = new GUIStyle(GUI.skin.textField)
            {
                normal =
                {
                    background = m_IdleTex,
                    textColor = Color.clear
                },
                focused =
                {
                    background = m_DownTex,
                    textColor = Color.clear
                },
                hover =
                {
                    background = m_DownTex,
                    textColor = Color.clear
                },
                fontSize = 19,
                alignment = TextAnchor.MiddleCenter
            };
            ReloadRenderer = false;
        }
        RealText = GUI.TextField(QuickRect(), RealText, Config.RenderStyle);
        if (Password)
            TextToRender = new string('*', RealText.Length);
        else
        {
            TextToRender = RealText;
            if (m_Valid == E_Validation.NUMBERS)
                RealText = Regex.Replace(RealText, @"[^\d]", "");
        }
        if (m_LastReadText != RealText)
        {
            if (OnTextChanged != null)
                OnTextChanged(RealText);
            m_LastReadText = RealText;
        }
        /*
        GUI.DrawTexture(QuickRect(), m_Focused ? m_DownTex : m_IdleTex);
        if (IsGUIEditorActive)
            return;
        Event e = Event.current;
        if (e.type == EventType.mouseDown)
        {
            if (QuickRect().Contains(e.mousePosition))
            {
#if !UNITY_EDITOR && UNITY_ANDROID
                TouchScreenKeyboard.Open(TextToRender, (TouchScreenKeyboardType)(int)m_Valid);
#else
                m_Focused = true;
#endif
            }
            else m_Focused = false;
        }
#if UNITY_EDITOR || UNITY_STANDALONE
        if (e.type == EventType.keyDown)
        {
            if (m_Focused)
            {
                if (e.keyCode == KeyCode.Backspace)
                {
                    if (TextToRender.Length > 0)
                    {
                        TextToRender = TextToRender.Substring(0, TextToRender.Length - 1);
                        RealText = RealText.Substring(0, RealText.Length - 1);
                        if (OnTextChanged != null)
                            OnTextChanged(TextToRender);
                    }
                    return;
                }
                bool di = char.IsDigit(e.character);
                if (m_Valid == E_Validation.NUMBERS && di)
                {
                    TextToRender += Password ? '*' : e.character;
                    RealText += e.character;
                    if (OnTextChanged != null)
                        OnTextChanged(TextToRender);
                }
                else
                {
                    TextToRender += Password ? '*' : e.character; RealText += e.character;
                    if (OnTextChanged != null)
                        OnTextChanged(TextToRender);
                }
            }
        }
#endif*/
    }
    public void SetValidation(E_Validation v)
    {
        m_Valid = v;
    }
    public override string ComponentName()
    {
        return "TEXT_FIELD";
    }
}
