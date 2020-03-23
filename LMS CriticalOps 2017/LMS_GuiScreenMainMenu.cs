using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenMainMenu : LMS_GuiScreen
{
    LMS_GuiBaseButton Automation;
    LMS_GuiBaseLabel AutomationLabel;
    LMS_GuiBaseButton Esp;
    LMS_GuiBaseLabel EspLabel;
    LMS_GuiBaseLabel Creditslabel;
    LMS_GuiBaseBox2D CopsLogo;
    LMS_GuiBaseButton Misc;
    LMS_GuiBaseLabel MiscLabel;
    LMS_GuiBaseBox2D OptionsWindow;
    LMS_GuiBaseLabel Version;
    LMS_GuiBaseTouchBar TouchBar;
    LMS_GuiBaseButton Movement;
    LMS_GuiBaseLabel MovementLabel;
    LMS_GuiBaseButton Fun;
    LMS_GuiBaseLabel FunLabel;
    LMS_GuiBaseButton GUIEditor;
    LMS_GuiBaseLabel GUIEditorLabel;
    LMS_GuiBaseButton Updater;
    LMS_GuiBaseLabel UpdaterLabel;
    LMS_GuiBaseButton Credits;
    LMS_GuiBaseLabel _CreditsLabel;
    LMS_GuiBaseLabel OptTitle;
    LMS_GuiBaseLabel OptText;
    int selectedIndex;

    /* @RENDER ORDER!
     * 1 LABEL
     * 2 BUTTON
     * 3 BOX
     */

    void Awake()
    {
        InitLabels();
        InitButtons();
        InitOverlays();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(100f, 100f, 800f, 500f)
        }, 2000, null);
        Owner.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("MAIN_MENU_TEX"));
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(AutomationLabel);
        Owner.AddChild(EspLabel);
        Owner.AddChild(Automation);
        Owner.AddChild(Esp);
        Owner.AddChild(Creditslabel);
        Owner.AddChild(CopsLogo);
        Owner.AddChild(Misc);
        Owner.AddChild(MiscLabel);
        Owner.AddChild(OptionsWindow);
        Owner.AddChild(Version);
        Owner.AddChild(MovementLabel);
        Owner.AddChild(Movement);
        Owner.AddChild(Fun);
        Owner.AddChild(FunLabel);
        Owner.AddChild(GUIEditor);
        Owner.AddChild(GUIEditorLabel);
        Owner.AddChild(Updater);
        Owner.AddChild(UpdaterLabel);
        Owner.AddChild(Credits);
        Owner.AddChild(_CreditsLabel);
        Owner.AddChild(OptTitle);
        Owner.AddChild(OptText);
    }
    public override void HideScreen()
    {
        base.HideScreen();
    }
    public override void ShowScreen()
    {
        base.ShowScreen();
    }
    void InitButtonDefault(LMS_GuiBaseButton b, string text, string title, LMS_GuiBaseButton.ClickCallbackDelegate onClick = null)
    {
        b.SetTexture((int)E_Texture.DOWN, LMS_Textures.GetCache("BUTTON_TEX"));
        b.SetTexture((int)E_Texture.IDLE, b.GeneratePlainTexture(Color.clear));
        b.BlendMode = E_BlendMode.BLENDED;
        if (onClick != null)
            b.OnClick += onClick;
        LMS_GuiViewSelection sel = new LMS_GuiViewSelection
        {
            Text = text,
            Title = title,
            CollectionIndex = SelectionIndex.Values.Count
        };
        SelectionIndex[sel.CollectionIndex] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(sel, b);
    }
    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.CHROMATIMED);
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedIndex + 1 == SelectionIndex.Count)
                selectedIndex = 0;
            else selectedIndex++;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedIndex - 1 == -1)
                selectedIndex = SelectionIndex.Count - 1;
            else selectedIndex--;
        }
#endif
        for (int i = 0; i < SelectionIndex.Values.Count; i++)
        {
            LMS_GuiViewSelection view = SelectionIndex[i].Key as LMS_GuiViewSelection;
            SelectionIndex[i].Value.ForceDownState(i == selectedIndex);
            if (i != selectedIndex)
                continue;
            OptTitle.Config.Text = view.Title;
            OptText.Config.Text = view.Text;
        }
    }
    void InitLabels()
    {
        Creditslabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(330f, 173f, 431f, 150f),
            Text = "Hacks Made By\n\nLercio12\nMRKDaGods\nxXxShanGoxXx",
            RenderStyle = new GUIStyle
            {
                fontSize = 25,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 3);
        AutomationLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f),
            Text = "Automation Hacks",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 1);
        EspLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f),
            Text = "Esp Hacks",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 2);
        MiscLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f),
            Text = "Misc Hacks",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 4);
        MovementLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f),
            Text = "Movement Hacks",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 6);
        FunLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f),
            Text = "Fun Hacks",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 7);
        GUIEditorLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 205f, 431f, 150f),
            Text = "GUI Editor",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 8);
        UpdaterLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 240f, 431f, 150f),
            Text = "Update",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 9);
        _CreditsLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 275f, 431f, 150f),
            Text = "Credits",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 10);
        OptTitle = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(168f, 25f, 431f, 150f),
            Text = "TITLE",
            RenderStyle = new GUIStyle
            {
                fontSize = 22,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 11);
        OptText = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(168f, 118f, 431f, 150f),
            Text = "TEXT",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 12);
        Version = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(382f, 284f, 238f, 152f),
            Text = "V" + LMS_Meta.getMetaValue("VER"),
            RenderStyle = new GUIStyle
            {
                fontSize = 25,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 5);
        InitLabelDefault(AutomationLabel);
        InitLabelDefault(EspLabel);
        InitLabelDefault(Creditslabel);
        InitLabelDefault(MiscLabel);
        InitLabelDefault(Version);
        InitLabelDefault(MovementLabel);
        InitLabelDefault(FunLabel);
        InitLabelDefault(GUIEditorLabel);
        InitLabelDefault(UpdaterLabel);
        InitLabelDefault(_CreditsLabel);
        InitLabelDefault(OptText);
        InitLabelDefault(OptTitle);
        Creditslabel.SetFlags("EXTRUDE", "OUTLINE");
        Version.SetFlags("OUTLINE");
        Creditslabel.SetRenderMode(E_ColorFlags.FIXED);
        Version.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetRenderMode(E_ColorFlags.FIXED);
        OptTitle.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetFlags("NONE");
        OptTitle.SetFlags("NONE");
    }
    void InitButtons()
    {
        Automation = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 3000);
        Esp = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 4000);
        Misc = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 5000);
        Movement = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 6000);
        Fun = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 7000);
        GUIEditor = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 205f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 8000);
        Updater = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 240f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 9000);
        Credits = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 275f, 431f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 10000);
        InitButtonDefault(Automation, LMS_GuiBaseLabelBoundaries.WrapText("Combat Hacks, such as: Aimbot, Triggerbot, etc", 19, 200f), "Automation", () => { LMS_Main.Instance.ShowScreen(1); });
        InitButtonDefault(Esp, LMS_GuiBaseLabelBoundaries.WrapText("Overlay/Render hacks, which give you more advantage ;D", 19, 100f), "ESP/Overlay", () => { LMS_Main.Instance.ShowScreen(2); });
        InitButtonDefault(Misc, LMS_GuiBaseLabelBoundaries.WrapText("Miscellaneous hacks, more like exploits and random hacks", 19, 200f), "Misc", () => { LMS_Main.Instance.ShowScreen(4); });
        InitButtonDefault(Movement, LMS_GuiBaseLabelBoundaries.WrapText("Movement hacks, are hacks which control movement, such as: Fly and Wall hack", 19, 200f), "Movement/Physics");
        InitButtonDefault(Fun, LMS_GuiBaseLabelBoundaries.WrapText("Fun hacks, they are fun :p", 19, 200f), "Fun");
        InitButtonDefault(GUIEditor, LMS_GuiBaseLabelBoundaries.WrapText("More than just changing colors", 19, 200f), "GUI Editor", () => { LMS_Main.Instance.ShowScreen(5); });
        InitButtonDefault(Updater, LMS_GuiBaseLabelBoundaries.WrapText("Check for latest releases!", 19, 200f), "Updater");
        InitButtonDefault(Credits, LMS_GuiBaseLabelBoundaries.WrapText("Get to know us, the developers. Not Critical Force..", 19, 200f), "Credits");
    }
    void InitOverlays()
    {
        CopsLogo = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(339f, 47f, 413f, 233f)
        }, 100000);
        CopsLogo.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("COPS_LOGO_TEX"));
        OptionsWindow = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(163f, 12f, 445f, 484f)
        }, 200000);
        //OptionsWindow.SetTexture((int)E_Texture.IDLE, OptionsWindow.GeneratePlainTexture(Color.black.AlterAlpha(206f / 255f)));
        TouchBar = InstantiateChild<LMS_GuiBaseTouchBar>(new LMS_GuiConfig()
        {
            Rect = new Rect(0f, 0f, Screen.width, Screen.height)
        }, 300000);
        TouchBar.SetTexture((int)E_Texture.IDLE, OptionsWindow.GeneratePlainTexture(Color.clear));
        TouchBar.onSwipe += (swipe) => 
        {
            if (Owner.Down)
                return;
            if (swipe == E_Swipe.DOWN)
            {
                if (selectedIndex + 1 == SelectionIndex.Count)
                    selectedIndex = 0;
                else selectedIndex++;
            }
            else if (swipe == E_Swipe.UP)
            {
                if (selectedIndex - 1 == -1)

                    selectedIndex = SelectionIndex.Count - 1;
                else selectedIndex--;
            }
            else 
            {
                LMS_GuiBaseButton b = SelectionIndex[selectedIndex].Value;
                if (b.OnClick != null)
                    b.OnClick();
            }
        };
    }
    public override string ScreenName()
    {
        return "Main";
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.MainMenu;
    }
}
