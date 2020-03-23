using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenMisc : LMS_GuiScreen
{
    LMS_GuiBaseLabel Creditslabel;
    LMS_GuiBaseBox2D CopsLogo;
    LMS_GuiBaseBox2D OptionsWindow;
    LMS_GuiBaseLabel Version;
    LMS_GuiBaseTouchBar TouchBar;
    LMS_GuiBaseLabel OptTitle;
    LMS_GuiBaseLabel OptText;
    int selectedIndex;
    LMS_GuiBaseButton Weapon, ScreenB, Camera, Player, msGUI;
    LMS_GuiBaseLabel WeaponLabel, ScreenLabel, CameraLabel, PlayerLabel, msGUILabel;
    #region WEAPON
    LMS_GuiBaseVerticalScroller OptWeaponScroller;
    LMS_GuiBaseLabel OptInvisibleWeaponLabel, OptInvisibleWeaponToggleLabel;
    #endregion
    void Awake()
    {
        InitLabels();
        InitToggles();
        InitOverlays();
        InitButtons();
        InitScrollers();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig
        {
            Rect = new Rect(100f, 100f, 800f, 500f)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("MAIN_MENU_TEX"));
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(Creditslabel);
        Owner.AddChild(CopsLogo);
        Owner.AddChild(OptionsWindow);
        Owner.AddChild(Version);
        Owner.AddChild(OptTitle);
        Owner.AddChild(OptText);
        Owner.AddChild(Weapon);
        Owner.AddChild(ScreenB);
        Owner.AddChild(Camera);
        Owner.AddChild(Player);
        Owner.AddChild(msGUI);
        Owner.AddChild(WeaponLabel);
        Owner.AddChild(ScreenLabel);
        Owner.AddChild(CameraLabel);
        Owner.AddChild(PlayerLabel);
        Owner.AddChild(msGUILabel);
        Owner.AddChild(OptWeaponScroller);
        Owner.AddChild(OptInvisibleWeaponLabel);
        Owner.AddChild(OptInvisibleWeaponToggleLabel);
    }
    void InitButtonDefault(LMS_GuiBaseButton b, LMS_GuiView Details = null, LMS_GuiBaseButton.ClickCallbackDelegate onClick = null, bool ignoreindexing = false)
    {
        if (onClick != null)
            b.OnClick += onClick;
        b.SetTexture((int)E_Texture.DOWN, b.GeneratePlainTexture(new Color(200f / 255f, 220f / 255f, 35f / 255f, 1f)));
        b.SetTexture((int)E_Texture.IDLE, b.GeneratePlainTexture(Color.clear));
        b.BlendMode = E_BlendMode.BLENDED;
        if (!ignoreindexing)
            SelectionIndex[SelectionIndex.Values.Count] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(Details, b);
    }
    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.CHROMATIMED);
    }
    void InitButtons()
    {
        Weapon = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f)
        }, 50);
        ScreenB = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f)
        }, 50);
        Camera = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f)
        }, 50);
        Player = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f)
        }, 50);
        msGUI = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f)
        }, 50);
        InitButtonDefault(Weapon, CreateDetails("Weapon Hacks", "memz", KeyValuePairUtil.b(OptWeaponScroller), KeyValuePairUtil.b(OptInvisibleWeaponLabel), KeyValuePairUtil.b(OptInvisibleWeaponToggleLabel)));
        InitButtonDefault(ScreenB);
        InitButtonDefault(Camera);
        InitButtonDefault(Player);
        InitButtonDefault(msGUI);
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
        }, 13);
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
        }, 14);
        OptText = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(168f, 90f, 431f, 150f),
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
        }, 15);
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
        }, 16);
        WeaponLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f),
            Text = "Weapon",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 13);
        ScreenLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f),
            Text = "Screen",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 13);
        CameraLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f),
            Text = "Camera",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 13);
        PlayerLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f),
            Text = "Player",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 13);
        msGUILabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f),
            Text = "GUI",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = new Color(190f / 255f, 211f / 255f, 33f / 255f)
                }
            }
        }, 13);
        OptInvisibleWeaponLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Invisible\nWeapon",
            Rect = new Rect(142f, 151f, 430f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptInvisibleWeaponToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Y",
            Rect = new Rect(247f, 151f, 200f, 146f),
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        InitLabelDefault(Creditslabel);
        InitLabelDefault(Version);
        InitLabelDefault(OptText);
        InitLabelDefault(OptTitle);
        InitLabelDefault(WeaponLabel);
        InitLabelDefault(ScreenLabel);
        InitLabelDefault(CameraLabel);
        InitLabelDefault(PlayerLabel);
        InitLabelDefault(msGUILabel);
        InitLabelDefault(OptInvisibleWeaponLabel);
        InitLabelDefault(OptInvisibleWeaponToggleLabel);
        Creditslabel.SetFlags("EXTRUDE", "OUTLINE");
        Version.SetFlags("OUTLINE");
        Creditslabel.SetRenderMode(E_ColorFlags.FIXED);
        Version.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetRenderMode(E_ColorFlags.FIXED);
        OptTitle.SetRenderMode(E_ColorFlags.FIXED);
        OptInvisibleWeaponToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptInvisibleWeaponLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetFlags("NONE");
        OptTitle.SetFlags("NONE");
    }
    void InitOverlays()
    {
        CopsLogo = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(339f, 47f, 413f, 233f)
        }, 1000000);
        CopsLogo.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("COPS_LOGO_TEX"));
        OptionsWindow = InstantiateChild<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(163f, 12f, 445f, 484f)
        }, 2000000);
        OptionsWindow.SetTexture((int)E_Texture.IDLE, OptionsWindow.GeneratePlainTexture(Color.black.AlterAlpha(206f / 255f)));
        TouchBar = InstantiateChild<LMS_GuiBaseTouchBar>(new LMS_GuiConfig()
        {
            Rect = new Rect(0f, 0f, Screen.width, Screen.height)
        }, 3000000);
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
                if (SelectionIndex.Keys.Count == 0)
                    return;
                LMS_GuiBaseButton b = SelectionIndex[selectedIndex].Value;
                if (b.OnClick != null)
                    b.OnClick();
            }
        };
    }
    void InitScrollers()
    {
        OptWeaponScroller = InstantiateChild<LMS_GuiBaseVerticalScroller>(new LMS_GuiConfig
        {
            Rect = new Rect(301f, 16f, 148f, 481f)
        }, 72);
        OptWeaponScroller.SetTexture((int)E_Texture.DOWN, OptWeaponScroller.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptWeaponScroller.SetTexture((int)E_Texture.IDLE, OptWeaponScroller.GeneratePlainTexture(Color.green.AlterAlpha(0.7f)));
        OptWeaponScroller.SetTexture((int)E_Texture.OTHER, OptWeaponScroller.GeneratePlainTexture(Color.black.AlterAlpha(0.7f)));
        OptWeaponScroller.UseRelativeRect = true;
        OptWeaponScroller.AddSibling(OptInvisibleWeaponLabel);
        OptWeaponScroller.AddSibling(OptInvisibleWeaponToggleLabel);
    }
    void InitToggles()
    {

    }
    void Update()
    {
        if (!Visible)
            return;
        for (int i = 0; i < SelectionIndex.Values.Count; i++)
        {
            LMS_GuiViewDetail view = SelectionIndex[i].Key as LMS_GuiViewDetail;
            SelectionIndex[i].Value.ForceDownState(i == selectedIndex);
            if (i != selectedIndex)
                try
                {
                    view.callback.Loop((curr) => { curr.Key.Hidden = true; });
                }
                catch { continue; }
            else
                try
                {
                    OptTitle.Config.Text = view.Text;
                    OptText.Config.Text = view.Text2;
                    view.callback.Loop((curr) => { curr.Key.Hidden = false; });
                }
                catch
                {
                    OptTitle.Config.Text = "";
                    OptText.Config.Text = "";
                }
        }
    }
    LMS_GuiViewDetail CreateDetails(string text, string text2, params TripleValPair<LMS_GuiBaseCallback, int, GuiViewClientTick>[] keys)
    {
        KeyValuePair<LMS_GuiBaseCallback, int>[] cb;
        keys.ArraySuppressTriplet(out cb);
        LMS_GuiViewDetail l = new LMS_GuiViewDetail(cb, text, text2);
        foreach (TripleValPair<LMS_GuiBaseCallback, int, GuiViewClientTick> pair in keys)
        {
            if (pair.Triple != null)
                l.RegisterTickCallback(pair.Triple);
        }
        return l;
    }
    T InstantiateOptionWindowChild<T>(LMS_GuiConfig c) where T : LMS_GuiBaseCallback
    {
        return InstantiateChild<T>(c, 72);
    }
    public override string ScreenName()
    {
        return "Misc";
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Misc;
    }
}
