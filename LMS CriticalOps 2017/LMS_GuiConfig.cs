using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class LMS_GuiConfig
{
    public string Text;
    public Rect Rect;
    public GUIStyle RenderStyle;
    LMS_CustomExecutor MonoOverrider;
    Blend m_Blend = new Blend();
    Color m_LastRequestedColor;
    float m_LastRequestedX;
    string m_LastRequestedText;
    int m_InstanceID;
    int m_CharIndex;
    string m_OutPut;
    bool m_CorRun;
    static int instanceModifier = 1;

    public LMS_GuiConfig()
    {
        instanceModifier++;
        m_InstanceID = instanceModifier * 2;
        m_CharIndex = 0;
    }
    public void Inst()
    {
        Text = "";
        Rect = new Rect(0f, 0f, 10f, 10f);
        RenderStyle = GUI.skin.label;
    }
    public void SetColor(Color inCol)
    {
        if (RenderStyle == null)
        {
            Debug.LogWarning("Attempting to set color on a non referenced render style");
            return;
        }
        if (inCol != m_LastRequestedColor)
            LMS_CustomExecutor.Instance.Handle(() =>
            {
                RenderStyle.normal.textColor = Color.Lerp(m_Blend.c, inCol, m_Blend.f);
                m_Blend.f += Time.deltaTime / 2f;
                m_Blend.c = RenderStyle.normal.textColor;
            }, () =>
            {
                return m_Blend.c == inCol || LMS_CustomExecutor.Instance.IsInterrupted("#CONFIG_CALLER_COLOR" + m_InstanceID);
            }, "#CONFIG_CALLER_COLOR" + m_InstanceID,
            () =>
            {
                m_Blend.f = 0f;
            });
        m_LastRequestedColor = inCol;
    }
    public void SetX(float newX)
    {
        if (newX != m_LastRequestedX)
            LMS_CustomExecutor.Instance.Handle(() =>
            {
                Rect.x = Mathf.MoveTowards(Rect.x, newX, 1.5f);
            }, () =>
            {
                return Rect.x == newX || LMS_CustomExecutor.Instance.IsInterrupted("#CONFIG_CALLER_X" + m_InstanceID);
            }, "#CONFIG_CALLER_X" + m_InstanceID, 
            () =>
            {
                
            });
        m_LastRequestedX = newX;
    }
    public void SetText(string intext)
    {
        if (intext != m_LastRequestedText)
            LMS_CustomExecutor.Instance.Handle(() =>
            {
                if (!m_CorRun)
                    LMS_CustomExecutor.Instance.StartCoroutine(RChars(intext.Length, intext));
            }, () =>
            {
                return m_OutPut == intext || LMS_CustomExecutor.Instance.IsInterrupted("#CONFIG_CALLER_CHAR" + m_InstanceID);
            }, "#CONFIG_CALLER_CHAR" + m_InstanceID,
            () =>
            {
                m_CharIndex = 0;
                Text = intext;
            });
        m_LastRequestedText = intext;
    }
    IEnumerator<WaitForSeconds> RChars(int length, string real)
    {
        m_CorRun = true;
        for (int i = 0; i < 5; i++)
        {
            Text = LMS_GuiBaseLabelBoundaries.Rand(length);
            yield return new WaitForSeconds(0.002f);
        }
        m_OutPut = real;
        Text = real;
        m_CorRun = false;
    }
}
