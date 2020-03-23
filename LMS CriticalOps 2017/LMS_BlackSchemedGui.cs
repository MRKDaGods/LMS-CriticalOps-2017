using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_BlackSchemedGui : MonoBehaviour
{
    IContextMenu TargetContext;
    IPopupContext TargetPopupContext;
    LMS_DoubleBuffer<IContextMenu, bool> ContextBuffer;
    float x = 0f, y = 0f, width = 0f, height = 0f;
    GUISkin m_skin;

    void Start()
    {
        InitContexts();
        m_skin = new GUISkin();
        m_skin.window.normal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        m_skin.window.onNormal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        m_skin.window.active.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        m_skin.window.onActive.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        m_skin.button.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        m_skin.button.onNormal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        m_skin.button.active.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        m_skin.button.onActive.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        m_skin.button.fontSize = 16;
        m_skin.button.alignment = TextAnchor.MiddleCenter;
        m_skin.button.fixedHeight = 25f;
        m_skin.button.normal.textColor = Color.white;
        m_skin.label.normal.textColor = Color.white;
        m_skin.label.fontStyle = FontStyle.Bold;
        m_skin.label.alignment = TextAnchor.MiddleCenter;
        m_skin.horizontalSlider.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        m_skin.horizontalSliderThumb.normal.background = GeneratePlainTexture(0f, 0f, 1f, 0.6f);
        m_skin.horizontalSlider.alignment = TextAnchor.MiddleCenter;
        m_skin.horizontalSlider.fixedHeight = 10f;
        m_skin.horizontalSliderThumb.fixedWidth = 15f;
        m_skin.horizontalSliderThumb.fixedHeight = 9f;
    }
    void InitContexts()
    {

    }
    bool Toggle(ref bool b)
    {
        return (b = !b);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
            ContextBuffer[TargetContext] = !ContextBuffer[TargetContext];
    }
    void OnGUI()
    {
        if (TargetPopupContext != null)
            return;
        GUI.skin = m_skin;
        GUI.Window(0, new Rect(x, y, width, height), (id) => { }, "");
        x = GUI.HorizontalSlider(new Rect(0f, 100f, 200f, 30f), x, 0f, 1000f);
        y = GUI.HorizontalSlider(new Rect(0f, 150f, 200f, 30f), y, 0f, 1000f);
        width = GUI.HorizontalSlider(new Rect(0f, 200f, 200f, 30f), width, 0f, 1000f);
        height = GUI.HorizontalSlider(new Rect(0f, 250f, 200f, 30f), height, 0f, 1000f);
        GUILayout.Label(string.Concat("x", x, "y", y, "w", width, "h", height));
    }
    Texture2D GeneratePlainTexture(float r, float g, float b, float a, int w = 1, int h = 1)
    {
        Texture2D t = new Texture2D(w, h);
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                t.SetPixel(i, j, new Color(r, g, b, a));
            }
        }
        t.Apply();
        return t;
    }
}
public class AimbotContext : IContextMenu
{
    public void DescContext()
    {
        throw new NotImplementedException();
    }
    public void MainContext()
    {
        throw new NotImplementedException();
    }
}
public interface IContextMenu
{
    void MainContext();
    void DescContext();
}
public interface IPopupContext
{
    void MainContext();
}