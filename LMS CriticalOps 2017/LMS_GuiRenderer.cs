using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiRenderer : MonoBehaviour
{
    LMS_DoubleBuffer<string, Texture2D> m_BlendingTasks = new LMS_DoubleBuffer<string, Texture2D>();
    int m_LastBlend;
    Blend blendComp = new Blend();
    static Color DEFAULT_BUTTON_DOWN_TEX_COL = new Color(200f / 255f, 220f / 255f, 35f / 255f, 1f);
    static Color DEFAULT_BUTTON_IDLE_TEX_COL = Color.clear;
    public int ColorThreadCount;
    public LMS_ColorThread MainColorHandle;

    void OnGUI()
    {
        foreach (KeyValuePair<string, Texture2D> kv in m_BlendingTasks[-1])
        {
            switch (kv.Key)
            {
                case "a":
                    bool a = m_LastBlend == 1;
                    blendComp.f += Time.deltaTime / 2f;
                    Color c = DEFAULT_BUTTON_IDLE_TEX_COL, c2 = DEFAULT_BUTTON_DOWN_TEX_COL, target = a ? c2 : c;
                    blendComp.c = Color.Lerp(a ? c : c2, target, blendComp.f);
                    if (blendComp.c == target)
                    {
                        blendComp.f = 0f;
                        m_LastBlend = m_LastBlend == 0 ? 1 : 0;
                    }
                    m_BlendingTasks["a"] = new Texture2D(1, 1).Modify((tex) => { tex.SetPixel(0, 0, blendComp.c); tex.Apply(); });
                    break;
            }
        }
    }
    public Texture2D GetTexture(string type)
    {
        return m_BlendingTasks[type];
    }
    public void Register(string s)
    {
        m_BlendingTasks.Push(s, null);
    }
    public void PopAll()
    {
        while (m_BlendingTasks.AvailableSize > 0)
            m_BlendingTasks.Pop();
    }
}
