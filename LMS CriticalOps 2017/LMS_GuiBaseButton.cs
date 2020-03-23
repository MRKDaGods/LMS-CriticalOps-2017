using System;
using System.Collections.Generic;
using UnityEngine;

public enum E_BlendMode
{
    NORMAL,
    BLENDED
}
public struct Blend
{
    public Color c;
    public float f;
}

public class LMS_GuiBaseButton : LMS_GuiBaseCallback
{
    public Texture2D m_IdleTex;
    [SerializeField]
    Texture2D m_DownTex;
    Texture2D activeTex;
    int ticks;
    public delegate void ClickCallbackDelegate();
    public ClickCallbackDelegate OnClick;
    bool forceDown;
    public bool AllowInput;
    public E_BlendMode BlendMode;
    bool m_StartBlend;
    int m_LastBlend;
    Blend blendComp;
    Vector2 m_MouseDownPos, m_NewOrigin;
    bool m_MouseDown;

    void Start()
    {
        activeTex = m_IdleTex;
        blendComp = new Blend();
    }
    void OnGUI()
    {
        if (Hidden)
            return;
        if (!canRender)
            return;
        GUI.DrawTexture(QuickRect(), activeTex);
        //RenderText();
        if (forceDown)
        {
            if (BlendMode == E_BlendMode.BLENDED && m_StartBlend)
                activeTex = LMS_Main.Instance.GUIRenderer.GetTexture("a");
            else activeTex = m_DownTex;
            return;
        }
        else
        {
            if (!AllowInput)
            {
                activeTex = m_IdleTex;
                return;
            }
            Event e = Event.current;
            if (e.type == EventType.MouseDown && QuickRect().Contains(e.mousePosition))
            {
                if (Draggable)
                {
                    m_MouseDown = true;
                    m_MouseDownPos = e.mousePosition;
                }
                else activeTex = m_DownTex;
            }
            if (Draggable)
            {
                if (e.type == EventType.MouseDrag && m_MouseDown)
                {
                    m_NewOrigin = e.mousePosition;
                    Config.Rect.x += e.delta.x;
                    if (Application.platform == RuntimePlatform.Android)
                        Config.Rect.y -= e.delta.y;
                    else Config.Rect.y += e.delta.y;
                }
                if (e.type == EventType.MouseUp)
                {
                    if (m_MouseDown && m_NewOrigin == Vector2.zero)
                        activeTex = m_DownTex;
                    m_NewOrigin = Vector2.zero;
                    m_MouseDown = false;
                    m_MouseDownPos = Vector2.zero;
                }
            }
            if (activeTex == m_DownTex && !forceDown)
                ticks++;
            if (ticks > 30)
            {
                activeTex = m_IdleTex;
                ticks = 0;
                if (OnClick != null)
                    OnClick();
            }
        }
    }
    void RenderText()
    {
        GUILayout.BeginArea(QuickRect());
        GUILayout.FlexibleSpace();
        GUILayout.Label(Config.Text, Config.RenderStyle);
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }
    public override void SetTexture(int t, Texture2D tex)
    {
        switch (t)
        {
            case (int)E_Texture.IDLE:
                m_IdleTex = tex;
                break;
            case (int)E_Texture.DOWN:
                m_DownTex = tex;
                break;
            default:
                Debug.Log("Attemping to register an unsupported texture, ID:" + t);
                break;
        }
    }
    public void ForceDownState(bool inState)
    {
        if (inState)
        {
            if (!forceDown)
                if (BlendMode == E_BlendMode.BLENDED)
                {
                    m_StartBlend = true;
                    m_LastBlend = 0;
                }
        } else 
        {
            m_StartBlend = false;
            m_LastBlend = 0;
        }
        forceDown = inState;
    }
    public override string ComponentName()
    {
        return "BUTTON";
    }
}
