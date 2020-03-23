using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_ColorThread : MonoBehaviour
{ 
    Color[] ColorSequence;
    float Interval;
    float deltatime;
    Color m_LastRenderedCol;
    LMS_GuiBaseCallback Owner;
    public bool Render;
    public bool IgnoreOwner;
    bool m_DefRet;

    void Awake()
    {
        LMS_GuiRenderer rn = LMS_Main.Instance.GUIRenderer;
        if (rn.ColorThreadCount + 1 > 1)
        {
            enabled = false;
            m_DefRet = true;
            return;
        }
        rn.ColorThreadCount++;
        rn.MainColorHandle = this;
        ColorSequence = new Color[] { new Color(1f, 0f, 0f),
                              new Color(1f, 1f, 0f),
                              new Color(0f, 1f, 0f),
                              new Color(0f, 1f, 1f),
                              new Color(0f, 0f, 1f),
                              new Color(1f, 0f, 1f) };
    }
    public string Value()
    {
        if (m_DefRet)
            return LMS_Main.Instance.GUIRenderer.MainColorHandle.Value();
        return Owner.HexColor(m_LastRenderedCol);
    }
    public Color RawValue()
    {
        if (m_DefRet)
            return LMS_Main.Instance.GUIRenderer.MainColorHandle.RawValue();
        return m_LastRenderedCol;
    }
    void OnGUI()
    {
        if (!IgnoreOwner && Owner == null)
            return;
        if (!Render)
            return;
        deltatime = (deltatime + Time.deltaTime * Interval) % ColorSequence.Length;
        int ilow = Mathf.FloorToInt(deltatime);
        int ihigh = (ilow + 1) % ColorSequence.Length;
        m_LastRenderedCol = Color.Lerp(ColorSequence[ilow], ColorSequence[ihigh], deltatime % 1f);
    }
    public void SetInterval(float num)
    {
        Interval = num;
    }
    public void SetOwner(LMS_GuiBaseCallback owner)
    {
        Owner = owner;
    }
}
