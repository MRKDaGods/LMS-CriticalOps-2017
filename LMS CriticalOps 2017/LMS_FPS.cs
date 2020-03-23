using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_FPS : MonoBehaviour
{
    int frameCount;
    float dt;
    float fps;
    float updateRate = 4f;
    LMS_GuiBaseLabel m_FPSLabel;

    void Update()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1f / updateRate;
        }
    }
    void Awake()
    {
        m_FPSLabel = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Rect = new Rect(0f, 0f, 200f, 150f),
            Text = "0 FPS",
            RenderStyle = new GUIStyle
            {
                fontSize = 23,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 92);
        m_FPSLabel.SetRenderMode(E_ColorFlags.CHROMATIMED);
        m_FPSLabel.RegisterClientViewTick((view) => { m_FPSLabel.Config.Text = ((int)fps).ToString() + "FPS"; }, null);
        m_FPSLabel.UseRelativeRect = true;
        m_FPSLabel.SetInterval("0.5 + 0.5");
    }
}
