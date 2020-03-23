using UnityEngine;
using System.Collections.Generic;

public class LMS_FontSelector : MonoBehaviour
{
    Dictionary<string, GUIStyle> Styles;
    Vector2 m_ScrollPos;
    Texture2D m_Area;
    GUIStyle m_AreaStyle;

    void Start()
    {
        m_Area = plainTex(Color.black.AlterAlpha(0.7f));
    }
    void OnGUI()
    {
        if (Styles == null)
            CacheStyles();
        if (m_AreaStyle == null)
            m_AreaStyle = new GUIStyle
            {
                normal =
                {
                    background = m_Area
                }
            };
        GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height), m_AreaStyle);
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("Please choose a font");
        GUILayout.FlexibleSpace();
        m_ScrollPos = GUILayout.BeginScrollView(m_ScrollPos);
        foreach (KeyValuePair<string, GUIStyle> gs in Styles)
        {
            if (GUILayout.Button(gs.Key, gs.Value, GUILayout.MinHeight(30f)))
            {
                LMS_Meta.setMetaValue("LAB_FONT", gs.Key);
                Destroy(gameObject);
            }
        }
        GUILayout.EndScrollView();
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }
    void CacheStyles()
    {
        Styles = new Dictionary<string, GUIStyle>();
        foreach (string s in Font.GetOSInstalledFontNames())
        {
            GUIStyle gs = new GUIStyle(GUI.skin.button)
            {
                font = Font.CreateDynamicFontFromOSFont(s, 13),
                alignment = TextAnchor.MiddleCenter
            };
            Styles[s] = gs;
        }
    }
    Texture2D plainTex(Color c)
    {
        Texture2D t = new Texture2D(1, 1);
        t.SetPixel(0, 0, c);
        t.Apply();
        return t;
    }
}