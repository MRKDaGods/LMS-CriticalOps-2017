using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenDarkAutomation : LMS_GuiScreenDarkMainMenu
{
    GUISkin m_Skin;
    LMS_GuiBaseButton AimbotButton;
    

    void Awake()
    {
        m_Skin = LMS_GuiBaseUtils.GetDarkSkin();
        InitLabels();
        InitButtons();
        Owner.AddChild(AimbotButton);
    }

    void InitLabels()
    {

    }

    void InitButtons()
    {
        AimbotButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(360f, 55f, 474f, 185f),
        }, 2);
        InitButtonDefault(AimbotButton, "", "Automation", 25, () => { });
    }

    void InitButtonDefault(LMS_GuiBaseButton b, string text, string title, int textSize = 15, LMS_GuiBaseButton.ClickCallbackDelegate onClick = null)
    {
        b.SetTexture((int)E_Texture.DOWN, m_Skin.button.active.background);
        b.SetTexture((int)E_Texture.IDLE, LMS_GuiBaseUtils.NextGrade(m_Skin.button.normal.background));
        b.BlendMode = E_BlendMode.NORMAL;
        if (onClick != null)
            b.OnClick += onClick;
        LMS_GuiViewSelection sel = new LMS_GuiViewSelection
        {
            Text = text,
            Title = "<size=" + textSize + ">" + title + "</size>",
            CollectionIndex = SelectionIndex.Values.Count
        };
        SelectionIndex[sel.CollectionIndex] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(sel, b);
    }

    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.FIXED);
    }

    public override string ScreenName()
    {
        return "Automation";
    }

    public override E_Screen ScreenType()
    {
        return E_Screen.Automation;
    }
}
