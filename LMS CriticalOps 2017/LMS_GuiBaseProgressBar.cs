using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiBaseProgressBar : LMS_GuiBaseCallback
{
    GUIStyle backStyle;
    public float Progress;
    float width;
    LMS_OnProgressBarFull m_Handle;
    bool forceHandle;
    public float realProg;
    public float Speed = 2f;
    string m_Color = "Default";
    public string Color { get { return m_Color; } set { m_Color = value; ReloadRenderer = true; } }

    void Awake()
    {
        Progress = 0f;
    }
    void OnGUI()
    {
        if (Hidden)
            return;
        if (!canRender)
            return;
        if (ReloadRenderer)
        {
            Config.RenderStyle = new GUIStyle(GUI.skin.box)
            {
                normal =
                {
                    background = GeneratePlainTexture(Color == "Default" ? new Color(50f / 255f, 80f / 255f, 50f / 255f, 1f) : LMS_GuiBaseUtils.StringToColor(Color))
                }
            };
            backStyle = new GUIStyle(GUI.skin.box)
            {
                normal =
                {
                    background = GeneratePlainTexture(new Color(30f / 255f, 30f / 255f, 30f / 255f, 1f))
                }
            };
            ReloadRenderer = false;
        }
        GUI.Box(QuickRect(), "", backStyle);
        width = Mathf.MoveTowards(width, QuickRect().width * Progress, 1f);
        GUI.Box(new Rect(QuickRect().x, QuickRect().y, width, QuickRect().height), "", Config.RenderStyle);
        if (forceHandle)
            if (m_Handle != null)
            {
                m_Handle(this);
                forceHandle = false;
            }
    }
    void Update()
    {
        if (realProg != -1f && Progress != realProg)
        {
            Progress = Mathf.MoveTowards(Progress, realProg, Speed);
        }
    }
    public void SetHandle(LMS_OnProgressBarFull handle)
    {
        m_Handle = handle;
    }
    public void DestroyN()
    {
        forceHandle = true;
    }
    public override void SetTexture(int t, Texture2D tex)
    {
    }
    public override string ComponentName()
    {
        return "PROGRESS_BAR";
    }
}
