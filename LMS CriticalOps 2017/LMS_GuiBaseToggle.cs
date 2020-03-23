using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public delegate void OnToggleValueChanged(bool val);

public class LMS_GuiBaseToggle : LMS_GuiBaseCallback
{
    [SerializeField]
    Texture2D m_IdleTex, m_DownTex, activeTex;
    bool m_Value;
    public bool Value { get { return m_Value; } set { m_Value = value; } }
    E_BlendMode m_BlendMode;
    Blend blendComp;
    int m_LastBlend;
    public OnToggleValueChanged OnToggleChanged;

    public override void SetTexture(int t, Texture2D tex)
    {
        if (t == (int)E_Texture.DOWN)
            m_DownTex = tex;
        else m_IdleTex = tex;
    }
    void Start()
    {
        blendComp = new Blend();
        activeTex = Value ? m_DownTex : m_IdleTex;
    }
    void OnGUI()
    {
        if (Hidden)
            return;
        try {
            if (m_BlendMode == E_BlendMode.BLENDED)
            {
                bool a = m_LastBlend == 1;
                blendComp.f += Time.deltaTime / 3f;
                Color c = (Value ? m_DownTex : m_IdleTex).GetPixel(0, 0), c2 = Color.clear, target = a ? c2 : c;
                blendComp.c = Color.Lerp(a ? c : c2, target, blendComp.f);
                if (blendComp.c == target)
                {
                    blendComp.f = 0f;
                    m_LastBlend = m_LastBlend == 0 ? 1 : 0;
                }
                activeTex = GeneratePlainTexture(blendComp.c);
            } else activeTex = Value ? m_DownTex : m_IdleTex;
        }
        catch
        {
            activeTex = GeneratePlainTexture(Color.clear);
        }
        if (activeTex != null)
            GUI.DrawTexture(QuickRect(), activeTex);
        if (IsGUIEditorActive)
            return;
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            if (QuickRect().Contains(e.mousePosition))
            {
                Value = !Value;
                if (OnToggleChanged != null)
                    OnToggleChanged(Value);
            }
        }
    }
    public void SetBlendMode(E_BlendMode inblend)
    {
        m_BlendMode = inblend;
    }
    public override string ComponentName()
    {
        return "TOGGLE";
    }
}
