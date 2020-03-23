#undef DEBUG_TITLEPOS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenDarkMainMenu : LMS_GuiScreen
{
    GUISkin m_Skin;
    LMS_GuiBaseLabel TitleLabel, ActiveHierarchyLabel;
    LMS_GuiBaseBox2D LeftPanel, RightPanel;
    LMS_GuiBaseButton AutomationButton;
    LMS_GuiBaseLabel MenuDescriptionLabel;
    LMS_GuiBaseLabel AutomationLabel;
    LMS_GuiBaseButton ESPButton;
    LMS_GuiBaseLabel ESPLabel;
    LMS_GuiBaseButton MiscButton;
    LMS_GuiBaseLabel MiscLabel;
    int selectedIndex;

    //x=80,y=30,w=870,h=720
    void Awake()
    {
        m_Skin = LMS_GuiBaseUtils.GetDarkSkin();
        InitLabels();
        InitButtons();
        InitOverlays();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig
        {
            Rect = new Rect(50f, 30f, 870f, 620f)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, m_Skin.box.normal.background);
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(TitleLabel);
        Owner.AddChild(MenuDescriptionLabel);
        Owner.AddChild(LeftPanel);
        Owner.AddChild(RightPanel);
        Owner.AddChild(AutomationButton);
        Owner.AddChild(AutomationLabel);
        Owner.AddChild(ActiveHierarchyLabel);
        Owner.AddChild(ESPButton);
        Owner.AddChild(ESPLabel);
        Owner.AddChild(MiscButton);
        Owner.AddChild(MiscLabel);
    }

    void InitLabels()
    {
        TitleLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(220f, 4f, 431f, 150f),
            Text = string.Format("<b>LMS {0} [<color=#83b6ef>Critical OPS</color></b>] - Main Menu", LMS_Meta.getMetaValue("VER")),
            RenderStyle = new GUIStyle
            {
                fontSize = 23,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        MenuDescriptionLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(315f, 65f, 431f, 150f),
            Text = "Combat hacks such as Aimbot, TriggerBot, etc",
            RenderStyle = new GUIStyle
            {
                fontSize = 21,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        AutomationLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 55f, 474f, 185f),
            Text = "Automation",
            RenderStyle = new GUIStyle
            {
                fontSize = 21,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        ActiveHierarchyLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(306f, 35f, 481f, 168f),
            Text = "Active Hierarchy\nIf you see this then contact Lercio or MRK",
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        ESPLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 100f, 474f, 227f),
            Text = "Esp",
            RenderStyle = new GUIStyle
            {
                fontSize = 21,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        MiscLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 160f, 474f, 227f),
            Text = "Misc",
            RenderStyle = new GUIStyle
            {
                fontSize = 21,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        InitLabelDefault(TitleLabel);
        InitLabelDefault(MenuDescriptionLabel);
        InitLabelDefault(AutomationLabel);
        InitLabelDefault(ActiveHierarchyLabel);
        InitLabelDefault(ESPLabel);
        InitLabelDefault(MiscLabel);
    }

    void Update()
    {
        for (int i = 0; i < SelectionIndex.Values.Count; i++)
        {
            LMS_GuiViewSelection view = SelectionIndex[i].Key as LMS_GuiViewSelection;
            SelectionIndex[i].Value.ForceDownState(i == selectedIndex);
            if (i != selectedIndex)
                continue;
            ActiveHierarchyLabel.Config.Text = view.Title;
            //OptText.Config.Text = view.Text;
        }
    }

    void OnGUI()
    {
#if DEBUG_TITLEPOS
        GLCanvas.DrawBox(TitleLabel.QuickRect(), Color.blue, 2f);
#endif
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
            HitTest(e.mousePosition);

    }

    void InitButtons()
    {
        AutomationButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 55f, 474f, 185f),
        }, 2);
        ESPButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 115f, 474f, 185f),
        }, 2);
        MiscButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12.5f, 175f, 474f, 185f),
        }, 2);
        InitButtonDefault(AutomationButton, "", "Automation", 25, () => { selectedIndex = 0; MenuDescriptionLabel.Config.SetText("Combat hacks such as Aimbot, TriggerBot, etc"); });
        InitButtonDefault(ESPButton, "", "ESP", 25, () => { selectedIndex = 1; MenuDescriptionLabel.Config.SetText("Render hacks, which give you more advantage"); });
        InitButtonDefault(MiscButton, "", "Misc", 25, () => { selectedIndex = 2; MenuDescriptionLabel.Config.SetText("Misc hacks, more like exploits and random hacks"); });

    }

    public override bool HitTest(Vector2 evt)
    {
        if (AutomationButton.QuickRect().Contains(evt))
            AutomationButton.OnClick();
        if (ESPButton.QuickRect().Contains(evt))
            ESPButton.OnClick();
        if (MiscButton.QuickRect().Contains(evt))
            MiscButton.OnClick();
        return base.HitTest(evt);
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

    void InitOverlays()
    {
        LeftPanel = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(8f, 41f, 486f, 587f)
        }, 100000);
        LeftPanel.SetTexture((int)E_Texture.IDLE, LMS_GuiBaseUtils.NextGrade(m_Skin.box.normal.background));
        RightPanel = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(197f, 41f, 705f, 587f)
        }, 100000);
        RightPanel.SetTexture((int)E_Texture.IDLE, LMS_GuiBaseUtils.NextGrade(m_Skin.box.normal.background));
    }

    public override string ScreenName()
    {
        return "MainMenu";
    }

    public override E_Screen ScreenType()
    {
        return E_Screen.MainMenu;
    }
}
