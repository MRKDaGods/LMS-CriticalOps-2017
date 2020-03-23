using System;
using System.Collections.Generic;
using UnityEngine;

public class LMS_GuiScreenAutomation : LMS_GuiScreen
{
    LMS_GuiBaseLabel Creditslabel;
    LMS_GuiBaseBox2D CopsLogo;
    LMS_GuiBaseBox2D OptionsWindow;
    LMS_GuiBaseLabel Version;
    LMS_GuiBaseTouchBar TouchBar;
    LMS_GuiBaseLabel OptTitle;
    LMS_GuiBaseLabel OptText;
    LMS_GuiBaseButton Aimbot, Triggerbot, SilentAimbot, InvisbleAimbot, AutoMelee, ShootBot, Back;
    LMS_GuiBaseLabel AimbotLabel, TriggerbotLabel, SilentAimbotLabel, InvisbleAimbotLabel, AutoMeleeLabel, OptAimbotToggleLabel, ShootBotLabel, BackLabel;
    LMS_GuiBaseToggle OptAimbotToggle;
    LMS_GuiBaseLabel OptAimbotToggleTickLabel;
    LMS_GuiBaseButton OptAimbotBoneLeft, OptAimbotBoneRight;
    LMS_GuiBaseLabel OptAimbotBoneLeftLabel, OptAimbotBoneRightLabel, OptAimbotSelectedBoneLabel, OptAimbotMaxDistTextFieldRenderer, OptAimbotMaxDistLabel;
    LMS_GuiBaseTextField OptAimbotMaxDistTextField;
    #region TRIGGERBOT
    LMS_GuiBaseLabel OptTriggerbotToggleLabel, OptTriggerbotToggleTickLabel;
    LMS_GuiBaseToggle OptTriggerbotToggle;
    LMS_GuiBaseLabel OptTriggerbotBoneLeftLabel, OptTriggerbotBoneRightLabel, OptTriggerbotSelectedBoneLabel, OptTriggerbotMaxDistTextFieldRenderer, OptTriggerbotMaxDistLabel;
    LMS_GuiBaseTextField OptTriggerbotMaxDistTextField;
    LMS_GuiBaseButton OptTriggerbotBoneLeft, OptTriggerbotBoneRight;
    #endregion
    #region SILENTAIMBOT
    LMS_GuiBaseLabel OptSaimbotToggleLabel, OptSaimbotToggleTickLabel;
    LMS_GuiBaseToggle OptSaimbotToggle;
    LMS_GuiBaseLabel OptSaimbotBoneLeftLabel, OptSaimbotBoneRightLabel, OptSaimbotSelectedBoneLabel, OptSaimbotMaxDistTextFieldRenderer, OptSaimbotMaxDistLabel;
    LMS_GuiBaseTextField OptSaimbotMaxDistTextField;
    LMS_GuiBaseButton OptSaimbotBoneLeft, OptSaimbotBoneRight;
    #endregion
    #region INVISAIMBOT
    LMS_GuiBaseLabel OptInvisAimbotToggleLabel, OptInvisAimbotToggleTickLabel;
    LMS_GuiBaseToggle OptInvisAimbotToggle;
    LMS_GuiBaseLabel OptInvisAimbotBoneLeftLabel, OptInvisAimbotBoneRightLabel, OptInvisAimbotSelectedBoneLabel, OptInvisAimbotMaxDistTextFieldRenderer, OptInvisAimbotMaxDistLabel;
    LMS_GuiBaseTextField OptInvisAimbotMaxDistTextField;
    LMS_GuiBaseButton OptInvisAimbotBoneLeft, OptInvisAimbotBoneRight;
    #endregion
    #region AUTOMELEE
    LMS_GuiBaseLabel OptMeleeToggleLabel, OptMeleeToggleTickLabel;
    LMS_GuiBaseToggle OptMeleeToggle;
    LMS_GuiBaseLabel OptMeleeBoneLeftLabel, OptMeleeBoneRightLabel, OptMeleeSelectedBoneLabel, OptMeleeMaxDistTextFieldRenderer, OptMeleeMaxDistLabel;
    LMS_GuiBaseTextField OptMeleeMaxDistTextField;
    LMS_GuiBaseButton OptMeleeBoneLeft, OptMeleeBoneRight;
    #endregion
    #region SHOOTBOT
    LMS_GuiBaseLabel OptSBToggleLabel, OptSBToggleTickLabel;
    LMS_GuiBaseToggle OptSBToggle;
    LMS_GuiBaseLabel OptSBBoneLeftLabel, OptSBBoneRightLabel, OptSBSelectedBoneLabel, OptSBMaxDistTextFieldRenderer, OptSBMaxDistLabel;
    LMS_GuiBaseTextField OptSBMaxDistTextField;
    LMS_GuiBaseButton OptSBBoneLeft, OptSBBoneRight;
    #endregion
    int selectedIndex, selectedAimbotBoneIndex, selectedTriggerbotBoneIndex, selectedSilentAimbotBoneIndex, selectedInvisAimbotBoneIndex, selectedAutoMeleeBoneIndex, selectedShootBotBoneIndex;
    
    void Awake()
    {
        InitLabels();
        InitToggles();
        InitOverlays();
        InitButtons();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
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
        Owner.AddChild(Aimbot);
        Owner.AddChild(Triggerbot);
        Owner.AddChild(SilentAimbot);
        Owner.AddChild(InvisbleAimbot);
        Owner.AddChild(AutoMelee);
        Owner.AddChild(AimbotLabel);
        Owner.AddChild(TriggerbotLabel);
        Owner.AddChild(SilentAimbotLabel);
        Owner.AddChild(InvisbleAimbotLabel);
        Owner.AddChild(AutoMeleeLabel);
        Owner.AddChild(OptAimbotToggleLabel);
        Owner.AddChild(OptAimbotToggle);
        Owner.AddChild(OptAimbotToggleTickLabel);
        Owner.AddChild(OptAimbotBoneLeft);
        Owner.AddChild(OptAimbotBoneRight);
        Owner.AddChild(OptAimbotBoneLeftLabel);
        Owner.AddChild(OptAimbotBoneRightLabel);
        Owner.AddChild(OptAimbotSelectedBoneLabel);
        Owner.AddChild(OptAimbotMaxDistTextField);
        Owner.AddChild(OptAimbotMaxDistTextFieldRenderer);
        Owner.AddChild(OptAimbotMaxDistLabel);
        Owner.AddChild(OptTriggerbotToggleLabel);
        Owner.AddChild(OptTriggerbotToggle);
        Owner.AddChild(OptTriggerbotToggleTickLabel);
        Owner.AddChild(OptTriggerbotBoneLeft);
        Owner.AddChild(OptTriggerbotBoneRight);
        Owner.AddChild(OptTriggerbotBoneLeftLabel);
        Owner.AddChild(OptTriggerbotBoneRightLabel);
        Owner.AddChild(OptTriggerbotSelectedBoneLabel);
        Owner.AddChild(OptTriggerbotMaxDistTextField);
        Owner.AddChild(OptTriggerbotMaxDistTextFieldRenderer);
        Owner.AddChild(OptTriggerbotMaxDistLabel);
        Owner.AddChild(OptSaimbotToggleLabel);
        Owner.AddChild(OptSaimbotToggle);
        Owner.AddChild(OptSaimbotToggleTickLabel);
        Owner.AddChild(OptSaimbotBoneLeft);
        Owner.AddChild(OptSaimbotBoneRight);
        Owner.AddChild(OptSaimbotBoneLeftLabel);
        Owner.AddChild(OptSaimbotBoneRightLabel);
        Owner.AddChild(OptSaimbotSelectedBoneLabel);
        Owner.AddChild(OptSaimbotMaxDistTextField);
        Owner.AddChild(OptSaimbotMaxDistTextFieldRenderer);
        Owner.AddChild(OptSaimbotMaxDistLabel);
        Owner.AddChild(OptInvisAimbotToggleLabel);
        Owner.AddChild(OptInvisAimbotToggle);
        Owner.AddChild(OptInvisAimbotToggleTickLabel);
        Owner.AddChild(OptInvisAimbotBoneLeft);
        Owner.AddChild(OptInvisAimbotBoneRight);
        Owner.AddChild(OptInvisAimbotBoneLeftLabel);
        Owner.AddChild(OptInvisAimbotBoneRightLabel);
        Owner.AddChild(OptInvisAimbotSelectedBoneLabel);
        Owner.AddChild(OptInvisAimbotMaxDistTextField);
        Owner.AddChild(OptInvisAimbotMaxDistTextFieldRenderer);
        Owner.AddChild(OptInvisAimbotMaxDistLabel);
        Owner.AddChild(ShootBot);
        Owner.AddChild(ShootBotLabel);
        Owner.AddChild(OptMeleeToggleLabel);
        Owner.AddChild(OptMeleeToggle);
        Owner.AddChild(OptMeleeToggleTickLabel);
        Owner.AddChild(OptMeleeBoneLeft);
        Owner.AddChild(OptMeleeBoneRight);
        Owner.AddChild(OptMeleeBoneLeftLabel);
        Owner.AddChild(OptMeleeBoneRightLabel);
        Owner.AddChild(OptMeleeSelectedBoneLabel);
        Owner.AddChild(OptMeleeMaxDistTextField);
        Owner.AddChild(OptMeleeMaxDistTextFieldRenderer);
        Owner.AddChild(OptMeleeMaxDistLabel);
        Owner.AddChild(OptSBToggleLabel);
        Owner.AddChild(OptSBToggle);
        Owner.AddChild(OptSBToggleTickLabel);
        Owner.AddChild(OptSBBoneLeft);
        Owner.AddChild(OptSBBoneRight);
        Owner.AddChild(OptSBBoneLeftLabel);
        Owner.AddChild(OptSBBoneRightLabel);
        Owner.AddChild(OptSBSelectedBoneLabel);
        Owner.AddChild(OptSBMaxDistTextField);
        Owner.AddChild(OptSBMaxDistTextFieldRenderer);
        Owner.AddChild(OptSBMaxDistLabel);
        Owner.AddChild(Back);
        Owner.AddChild(BackLabel);
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
    void InitOverlays()
    {
        OptAimbotMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
        OptTriggerbotMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
        OptSaimbotMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
        OptInvisAimbotMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
        OptMeleeMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
        OptSBMaxDistTextField = InstantiateOptionWindowChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(254f, 247f, 275f, 129f)
        });
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
            } else
            {
                LMS_GuiBaseButton b = SelectionIndex[selectedIndex].Value;
                if (b.OnClick != null)
                    b.OnClick();
            }
        };
        OptAimbotMaxDistTextField.UseRelativeRect = true;
        OptAimbotMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptAimbotMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptAimbotMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptAimbotMaxDistTextField.RegisterClientViewTick((view) => { OptAimbotMaxDistTextFieldRenderer.Config.Text = OptAimbotMaxDistTextField.TextToRender; }, null);
        OptAimbotMaxDistTextField.TextToRender = "30";
        OptAimbotMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.AIMBOT, 2, tex); };
        OptTriggerbotMaxDistTextField.UseRelativeRect = true;
        OptTriggerbotMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptTriggerbotMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptTriggerbotMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptTriggerbotMaxDistTextField.RegisterClientViewTick((view) => { OptTriggerbotMaxDistTextFieldRenderer.Config.Text = OptTriggerbotMaxDistTextField.TextToRender; }, null);
        OptTriggerbotMaxDistTextField.TextToRender = "30";
        OptTriggerbotMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.TRIGGERBOT, 2, tex); };
        OptSaimbotMaxDistTextField.UseRelativeRect = true;
        OptSaimbotMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptSaimbotMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptSaimbotMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptSaimbotMaxDistTextField.RegisterClientViewTick((view) => { OptSaimbotMaxDistTextFieldRenderer.Config.Text = OptSaimbotMaxDistTextField.TextToRender; }, null);
        OptSaimbotMaxDistTextField.TextToRender = "30";
        OptSaimbotMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.SILENT_AIMBOT, 2, tex); };
        OptInvisAimbotMaxDistTextField.UseRelativeRect = true;
        OptInvisAimbotMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptInvisAimbotMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptInvisAimbotMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptInvisAimbotMaxDistTextField.RegisterClientViewTick((view) => { OptInvisAimbotMaxDistTextFieldRenderer.Config.Text = OptInvisAimbotMaxDistTextField.TextToRender; }, null);
        OptInvisAimbotMaxDistTextField.TextToRender = "30";
        OptInvisAimbotMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.INVISIBLE_AIMBOT, 2, tex); };
        OptMeleeMaxDistTextField.UseRelativeRect = true;
        OptMeleeMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptMeleeMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptMeleeMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptMeleeMaxDistTextField.RegisterClientViewTick((view) => { OptMeleeMaxDistTextFieldRenderer.Config.Text = OptMeleeMaxDistTextField.TextToRender; }, null);
        OptMeleeMaxDistTextField.TextToRender = "30";
        OptMeleeMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.AUTO_MELEE, 2, tex); };
        OptSBMaxDistTextField.UseRelativeRect = true;
        OptSBMaxDistTextField.SetValidation(E_Validation.NUMBERS);
        OptSBMaxDistTextField.SetTexture((int)E_Texture.IDLE, OptSBMaxDistTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        OptSBMaxDistTextField.RegisterClientViewTick((view) => { OptSBMaxDistTextFieldRenderer.Config.Text = OptSBMaxDistTextField.TextToRender; }, null);
        OptSBMaxDistTextField.TextToRender = "30";
        OptSBMaxDistTextField.OnTextChanged += (tex) => { float text; if (float.TryParse(tex, out text)) LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.SHOOT_BOT, 2, tex); };
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
        AimbotLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f),
            Text = "Aimbot",
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
        }, 17);
        TriggerbotLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f),
            Text = "Triggerbot",
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
        }, 18);
        SilentAimbotLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f),
            Text = "Silent Aimbot",
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
        }, 19);
        InvisbleAimbotLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f),
            Text = "Invisible Aimbot",
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
        }, 20);
        AutoMeleeLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f),
            Text = "Auto Melee",
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
        }, 21);
        ShootBotLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 205f, 431f, 150f),
            Text = "Shoot Bot",
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
        }, 21);
        BackLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 240f, 431f, 150f),
            Text = "Back",
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
        }, 21);
        OptAimbotToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptAimbotToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptAimbotBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptAimbotBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptAimbotSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptAimbotMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "30",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptAimbotMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        OptTriggerbotToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptTriggerbotToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptTriggerbotBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptTriggerbotBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptTriggerbotSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptTriggerbotMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "30",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptTriggerbotMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        OptSaimbotToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptSaimbotToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptSaimbotBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptSaimbotBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptSaimbotSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptSaimbotMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "30",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptSaimbotMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        OptInvisAimbotToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptInvisAimbotToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptInvisAimbotBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptInvisAimbotBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptInvisAimbotSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptInvisAimbotMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "30",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptInvisAimbotMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        OptMeleeToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptMeleeToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptMeleeBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptMeleeBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptMeleeSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptMeleeMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "20",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptMeleeMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        OptSBToggleLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Enabled",
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
        OptSBToggleTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
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
        OptSBBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 190f, 167f, 150f),
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
        OptSBBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 190f, 167f, 150f),
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
        OptSBSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 190f, 430f, 150f),
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
        OptSBMaxDistTextFieldRenderer = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "20",
            Rect = new Rect(254f, 245f, 275f, 129f),
            RenderStyle = new GUIStyle
            {
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.green
                }
            }
        });
        OptSBMaxDistLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Max Distance",
            Rect = new Rect(171f, 243f, 312f, 129f),
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
        InitLabelDefault(Creditslabel);
        InitLabelDefault(Version);
        InitLabelDefault(OptText);
        InitLabelDefault(OptTitle);
        InitLabelDefault(AimbotLabel);
        InitLabelDefault(TriggerbotLabel);
        InitLabelDefault(SilentAimbotLabel);
        InitLabelDefault(AutoMeleeLabel);
        InitLabelDefault(InvisbleAimbotLabel);
        InitLabelDefault(OptAimbotToggleLabel);
        InitLabelDefault(OptAimbotToggleTickLabel);
        InitLabelDefault(OptAimbotBoneLeftLabel);
        InitLabelDefault(OptAimbotBoneRightLabel);
        InitLabelDefault(OptAimbotSelectedBoneLabel);
        InitLabelDefault(OptAimbotMaxDistTextFieldRenderer);
        InitLabelDefault(OptAimbotMaxDistLabel);
        InitLabelDefault(OptTriggerbotToggleLabel);
        InitLabelDefault(OptTriggerbotToggleTickLabel);
        InitLabelDefault(OptTriggerbotBoneLeftLabel);
        InitLabelDefault(OptTriggerbotBoneRightLabel);
        InitLabelDefault(OptTriggerbotSelectedBoneLabel);
        InitLabelDefault(OptTriggerbotMaxDistTextFieldRenderer);
        InitLabelDefault(OptTriggerbotMaxDistLabel);
        InitLabelDefault(OptSaimbotToggleLabel);
        InitLabelDefault(OptSaimbotToggleTickLabel);
        InitLabelDefault(OptSaimbotBoneLeftLabel);
        InitLabelDefault(OptSaimbotBoneRightLabel);
        InitLabelDefault(OptSaimbotSelectedBoneLabel);
        InitLabelDefault(OptSaimbotMaxDistTextFieldRenderer);
        InitLabelDefault(OptSaimbotMaxDistLabel);
        InitLabelDefault(OptInvisAimbotToggleLabel);
        InitLabelDefault(OptInvisAimbotToggleTickLabel);
        InitLabelDefault(OptInvisAimbotBoneLeftLabel);
        InitLabelDefault(OptInvisAimbotBoneRightLabel);
        InitLabelDefault(OptInvisAimbotSelectedBoneLabel);
        InitLabelDefault(OptInvisAimbotMaxDistTextFieldRenderer);
        InitLabelDefault(OptInvisAimbotMaxDistLabel);
        InitLabelDefault(OptMeleeToggleLabel);
        InitLabelDefault(OptMeleeToggleTickLabel);
        InitLabelDefault(OptMeleeBoneLeftLabel);
        InitLabelDefault(OptMeleeBoneRightLabel);
        InitLabelDefault(OptMeleeSelectedBoneLabel);
        InitLabelDefault(OptMeleeMaxDistTextFieldRenderer);
        InitLabelDefault(OptMeleeMaxDistLabel);
        InitLabelDefault(OptSBToggleLabel);
        InitLabelDefault(OptSBToggleTickLabel);
        InitLabelDefault(OptSBBoneLeftLabel);
        InitLabelDefault(OptSBBoneRightLabel);
        InitLabelDefault(OptSBSelectedBoneLabel);
        InitLabelDefault(OptSBMaxDistTextFieldRenderer);
        InitLabelDefault(OptSBMaxDistLabel);
        InitLabelDefault(ShootBotLabel);
        InitLabelDefault(BackLabel);
        Creditslabel.SetFlags("EXTRUDE", "OUTLINE");
        Version.SetFlags("OUTLINE");
        Creditslabel.SetRenderMode(E_ColorFlags.FIXED);
        Version.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetRenderMode(E_ColorFlags.FIXED);
        OptTitle.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetFlags("NONE");
        OptTitle.SetFlags("NONE");
        OptAimbotToggleLabel.SetFlags("NONE");
        OptAimbotToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptAimbotToggleTickLabel.SetFlags("NONE");
        OptAimbotToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptTriggerbotToggleLabel.SetFlags("NONE");
        OptTriggerbotToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptTriggerbotToggleTickLabel.SetFlags("NONE");
        OptTriggerbotToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptSaimbotToggleLabel.SetFlags("NONE");
        OptSaimbotToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptSaimbotToggleTickLabel.SetFlags("NONE");
        OptSaimbotToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptInvisAimbotToggleLabel.SetFlags("NONE");
        OptInvisAimbotToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptInvisAimbotToggleTickLabel.SetFlags("NONE");
        OptInvisAimbotToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptMeleeToggleLabel.SetFlags("NONE");
        OptMeleeToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptMeleeToggleTickLabel.SetFlags("NONE");
        OptMeleeToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptSBToggleLabel.SetFlags("NONE");
        OptSBToggleLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptSBToggleTickLabel.SetFlags("NONE");
        OptSBToggleTickLabel.SetRenderMode(E_ColorFlags.FIXED);
    }
    void InitButtons()
    {
        Aimbot = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 50);
        Triggerbot = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 51);
        SilentAimbot = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 52);
        InvisbleAimbot = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 53);
        AutoMelee = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 54);
        ShootBot = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 54);
        Back = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
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
        }, 54);
        OptAimbotBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptAimbotBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        { 
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        OptTriggerbotBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptTriggerbotBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        OptSaimbotBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptSaimbotBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        OptInvisAimbotBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptInvisAimbotBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        OptMeleeBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptMeleeBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        OptSBBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 190f, 167f, 150f)
        });
        OptSBBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 190f, 167f, 150f)
        });
        InitButtonDefault(Aimbot, CreateDetails("Aimbot", LMS_GuiBaseLabelBoundaries.WrapText("Auto aim at an enemy", 19, 200f), KeyValuePairUtil.b(OptAimbotToggleLabel, (view) => { OptAimbotToggleLabel.Config.SetColor(OptAimbotToggle.Value ? Color.green : Color.red); OptAimbotToggleTickLabel.Config.SetColor(OptAimbotToggle.Value ? Color.green : Color.red); OptAimbotToggleTickLabel.Config.SetText(OptAimbotToggle.Value ? "Y" : "X"); OptAimbotToggleLabel.Config.SetText(OptAimbotToggle.Value ? "Enabled" : "Disabled"); OptAimbotToggleTickLabel.Config.SetX(OptAimbotToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptAimbotToggle), KeyValuePairUtil.b(OptAimbotToggleTickLabel), KeyValuePairUtil.b(OptAimbotBoneLeft), KeyValuePairUtil.b(OptAimbotBoneLeftLabel), KeyValuePairUtil.b(OptAimbotBoneRight), KeyValuePairUtil.b(OptAimbotBoneRightLabel), KeyValuePairUtil.b(OptAimbotMaxDistTextField), KeyValuePairUtil.b(OptAimbotMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptAimbotSelectedBoneLabel), KeyValuePairUtil.b(OptAimbotMaxDistLabel)));
        InitButtonDefault(Triggerbot, CreateDetails("Triggerbot", LMS_GuiBaseLabelBoundaries.WrapText("Auto shoot at an enemy if visible", 19, 200f), KeyValuePairUtil.b(OptTriggerbotToggleLabel, (view) => { OptTriggerbotToggleLabel.Config.SetColor(OptTriggerbotToggle.Value ? Color.green : Color.red); OptTriggerbotToggleTickLabel.Config.SetColor(OptTriggerbotToggle.Value ? Color.green : Color.red); OptTriggerbotToggleTickLabel.Config.SetText(OptTriggerbotToggle.Value ? "Y" : "X"); OptTriggerbotToggleLabel.Config.SetText(OptTriggerbotToggle.Value ? "Enabled" : "Disabled"); OptTriggerbotToggleTickLabel.Config.SetX(OptTriggerbotToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptTriggerbotToggle), KeyValuePairUtil.b(OptTriggerbotToggleTickLabel), KeyValuePairUtil.b(OptTriggerbotBoneLeft), KeyValuePairUtil.b(OptTriggerbotBoneLeftLabel), KeyValuePairUtil.b(OptTriggerbotBoneRight), KeyValuePairUtil.b(OptTriggerbotBoneRightLabel), KeyValuePairUtil.b(OptTriggerbotMaxDistTextField), KeyValuePairUtil.b(OptTriggerbotMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptTriggerbotSelectedBoneLabel), KeyValuePairUtil.b(OptTriggerbotMaxDistLabel)));
        InitButtonDefault(SilentAimbot, CreateDetails("Silent Aimbot", LMS_GuiBaseLabelBoundaries.WrapText("All bullets shot hit enemies", 19, 200f), KeyValuePairUtil.b(OptSaimbotToggleLabel, (view) => { OptSaimbotToggleLabel.Config.SetColor(OptSaimbotToggle.Value ? Color.green : Color.red); OptSaimbotToggleTickLabel.Config.SetColor(OptSaimbotToggle.Value ? Color.green : Color.red); OptSaimbotToggleTickLabel.Config.SetText(OptSaimbotToggle.Value ? "Y" : "X"); OptSaimbotToggleLabel.Config.SetText(OptSaimbotToggle.Value ? "Enabled" : "Disabled"); OptSaimbotToggleTickLabel.Config.SetX(OptSaimbotToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptSaimbotToggle), KeyValuePairUtil.b(OptSaimbotToggleTickLabel), KeyValuePairUtil.b(OptSaimbotBoneLeft), KeyValuePairUtil.b(OptSaimbotBoneLeftLabel), KeyValuePairUtil.b(OptSaimbotBoneRight), KeyValuePairUtil.b(OptSaimbotBoneRightLabel), KeyValuePairUtil.b(OptSaimbotMaxDistTextField), KeyValuePairUtil.b(OptSaimbotMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptSaimbotSelectedBoneLabel), KeyValuePairUtil.b(OptSaimbotMaxDistLabel)));
        InitButtonDefault(InvisbleAimbot, CreateDetails("Invisible Aimbot", LMS_GuiBaseLabelBoundaries.WrapText("Auto aim at non visible enemies and bullets could hit them", 19, 200f), KeyValuePairUtil.b(OptInvisAimbotToggleLabel, (view) => { OptInvisAimbotToggleLabel.Config.SetColor(OptInvisAimbotToggle.Value ? Color.green : Color.red); OptInvisAimbotToggleTickLabel.Config.SetColor(OptInvisAimbotToggle.Value ? Color.green : Color.red); OptInvisAimbotToggleTickLabel.Config.SetText(OptInvisAimbotToggle.Value ? "Y" : "X"); OptInvisAimbotToggleLabel.Config.SetText(OptInvisAimbotToggle.Value ? "Enabled" : "Disabled"); OptInvisAimbotToggleTickLabel.Config.SetX(OptInvisAimbotToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptInvisAimbotToggle), KeyValuePairUtil.b(OptInvisAimbotToggleTickLabel), KeyValuePairUtil.b(OptInvisAimbotBoneLeft), KeyValuePairUtil.b(OptInvisAimbotBoneLeftLabel), KeyValuePairUtil.b(OptInvisAimbotBoneRight), KeyValuePairUtil.b(OptInvisAimbotBoneRightLabel), KeyValuePairUtil.b(OptInvisAimbotMaxDistTextField), KeyValuePairUtil.b(OptInvisAimbotMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptInvisAimbotSelectedBoneLabel), KeyValuePairUtil.b(OptInvisAimbotMaxDistLabel)));
        InitButtonDefault(AutoMelee, CreateDetails("Auto Melee", LMS_GuiBaseLabelBoundaries.WrapText("While holding a knife, any enemy visible within the max range will get meleed", 19, 200f), KeyValuePairUtil.b(OptMeleeToggleLabel, (view) => { OptMeleeToggleLabel.Config.SetColor(OptMeleeToggle.Value ? Color.green : Color.red); OptMeleeToggleTickLabel.Config.SetColor(OptMeleeToggle.Value ? Color.green : Color.red); OptMeleeToggleTickLabel.Config.SetText(OptMeleeToggle.Value ? "Y" : "X"); OptMeleeToggleLabel.Config.SetText(OptMeleeToggle.Value ? "Enabled" : "Disabled"); OptMeleeToggleTickLabel.Config.SetX(OptMeleeToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptMeleeToggle), KeyValuePairUtil.b(OptMeleeToggleTickLabel), KeyValuePairUtil.b(OptMeleeBoneLeft), KeyValuePairUtil.b(OptMeleeBoneLeftLabel), KeyValuePairUtil.b(OptMeleeBoneRight), KeyValuePairUtil.b(OptMeleeBoneRightLabel), KeyValuePairUtil.b(OptMeleeMaxDistTextField), KeyValuePairUtil.b(OptMeleeMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptMeleeSelectedBoneLabel), KeyValuePairUtil.b(OptMeleeMaxDistLabel)));
        InitButtonDefault(ShootBot, CreateDetails("Shoot Bot", LMS_GuiBaseLabelBoundaries.WrapText("Auto shoot and aim at all enemies within the max distance", 19, 200f), KeyValuePairUtil.b(OptSBToggleLabel, (view) => { OptSBToggleLabel.Config.SetColor(OptSBToggle.Value ? Color.green : Color.red); OptSBToggleTickLabel.Config.SetColor(OptSBToggle.Value ? Color.green : Color.red); OptSBToggleTickLabel.Config.SetText(OptSBToggle.Value ? "Y" : "X"); OptSBToggleLabel.Config.SetText(OptSBToggle.Value ? "Enabled" : "Disabled"); OptSBToggleTickLabel.Config.SetX(OptSBToggle.Value ? 263f : 247f); }), KeyValuePairUtil.b(OptSBToggle), KeyValuePairUtil.b(OptSBToggleTickLabel), KeyValuePairUtil.b(OptSBBoneLeft), KeyValuePairUtil.b(OptSBBoneLeftLabel), KeyValuePairUtil.b(OptSBBoneRight), KeyValuePairUtil.b(OptSBBoneRightLabel), KeyValuePairUtil.b(OptSBMaxDistTextField), KeyValuePairUtil.b(OptSBMaxDistTextFieldRenderer), KeyValuePairUtil.b(OptSBSelectedBoneLabel), KeyValuePairUtil.b(OptSBMaxDistLabel)));
        InitButtonDefault(Back, CreateDetails("Back", LMS_GuiBaseLabelBoundaries.WrapText("Return to the Main Menu", 19, 200f)), () => { LMS_Main.Instance.ShowScreen(0); });
        InitButtonDefault(OptAimbotBoneLeft, null, () => 
        {
            if (selectedAimbotBoneIndex - 1 == -1)
                selectedAimbotBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedAimbotBoneIndex--;
            LMS_Meta.ModifyHackRecord("AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedAimbotBoneIndex]);
        }, true);
        InitButtonDefault(OptAimbotBoneRight, null, () =>
        {
            if (selectedAimbotBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedAimbotBoneIndex = 0;
            else selectedAimbotBoneIndex++;
            LMS_Meta.ModifyHackRecord("AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedAimbotBoneIndex]);
        }, true);
        OptAimbotBoneLeft.AllowInput = true;
        OptAimbotBoneLeft.SetTexture((int)E_Texture.IDLE, OptAimbotBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptAimbotBoneRight.AllowInput = true;
        OptAimbotBoneRight.SetTexture((int)E_Texture.IDLE, OptAimbotBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptTriggerbotBoneLeft, null, () =>
        {
            if (selectedTriggerbotBoneIndex - 1 == -1)
                selectedTriggerbotBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedTriggerbotBoneIndex--;
            LMS_Meta.ModifyHackRecord("TRIGGERBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedTriggerbotBoneIndex]);
        }, true);
        InitButtonDefault(OptTriggerbotBoneRight, null, () =>
        {
            if (selectedTriggerbotBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedTriggerbotBoneIndex = 0;
            else selectedTriggerbotBoneIndex++;
            LMS_Meta.ModifyHackRecord("TRIGGERBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedTriggerbotBoneIndex]);
        }, true);
        OptTriggerbotBoneLeft.AllowInput = true;
        OptTriggerbotBoneLeft.SetTexture((int)E_Texture.IDLE, OptTriggerbotBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptTriggerbotBoneRight.AllowInput = true;
        OptTriggerbotBoneRight.SetTexture((int)E_Texture.IDLE, OptTriggerbotBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptSaimbotBoneLeft, null, () =>
        {
            if (selectedSilentAimbotBoneIndex - 1 == -1)
                selectedSilentAimbotBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedSilentAimbotBoneIndex--;
            LMS_Meta.ModifyHackRecord("SILENT_AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedSilentAimbotBoneIndex]);
        }, true);
        InitButtonDefault(OptSaimbotBoneRight, null, () =>
        {
            if (selectedSilentAimbotBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedSilentAimbotBoneIndex = 0;
            else selectedSilentAimbotBoneIndex++;
            LMS_Meta.ModifyHackRecord("SILENT_AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedSilentAimbotBoneIndex]);
        }, true);
        OptSaimbotBoneLeft.AllowInput = true;
        OptSaimbotBoneLeft.SetTexture((int)E_Texture.IDLE, OptSaimbotBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptSaimbotBoneRight.AllowInput = true;
        OptSaimbotBoneRight.SetTexture((int)E_Texture.IDLE, OptSaimbotBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptInvisAimbotBoneLeft, null, () =>
        {
            if (selectedInvisAimbotBoneIndex - 1 == -1)
                selectedInvisAimbotBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedInvisAimbotBoneIndex--;
            LMS_Meta.ModifyHackRecord("INVISIBLE_AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedInvisAimbotBoneIndex]);
        }, true);
        InitButtonDefault(OptInvisAimbotBoneRight, null, () =>
        {
            if (selectedInvisAimbotBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedInvisAimbotBoneIndex = 0;
            else selectedInvisAimbotBoneIndex++;
            LMS_Meta.ModifyHackRecord("INVISIBLE_AIMBOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedInvisAimbotBoneIndex]);
        }, true);
        OptInvisAimbotBoneLeft.AllowInput = true;
        OptInvisAimbotBoneLeft.SetTexture((int)E_Texture.IDLE, OptInvisAimbotBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptInvisAimbotBoneRight.AllowInput = true;
        OptInvisAimbotBoneRight.SetTexture((int)E_Texture.IDLE, OptInvisAimbotBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptMeleeBoneLeft, null, () =>
        {
            if (selectedAutoMeleeBoneIndex - 1 == -1)
                selectedAutoMeleeBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedAutoMeleeBoneIndex--;
            LMS_Meta.ModifyHackRecord("AUTO_MELEE", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedAutoMeleeBoneIndex]);
        }, true);
        InitButtonDefault(OptMeleeBoneRight, null, () =>
        {
            if (selectedAutoMeleeBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedAutoMeleeBoneIndex = 0;
            else selectedAutoMeleeBoneIndex++;
            LMS_Meta.ModifyHackRecord("AUTO_MELEE", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedAutoMeleeBoneIndex]);
        }, true);
        OptMeleeBoneLeft.AllowInput = true;
        OptMeleeBoneLeft.SetTexture((int)E_Texture.IDLE, OptMeleeBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptMeleeBoneRight.AllowInput = true;
        OptMeleeBoneRight.SetTexture((int)E_Texture.IDLE, OptMeleeBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptSBBoneLeft, null, () =>
        {
            if (selectedShootBotBoneIndex - 1 == -1)
                selectedShootBotBoneIndex = ExternalCOPSHaXHook.BONES.Length - 1;
            else selectedShootBotBoneIndex--;
            LMS_Meta.ModifyHackRecord("SHOOT_BOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedShootBotBoneIndex]);
        }, true);
        InitButtonDefault(OptSBBoneRight, null, () =>
        {
            if (selectedShootBotBoneIndex + 1 == ExternalCOPSHaXHook.BONES.Length)
                selectedShootBotBoneIndex = 0;
            else selectedShootBotBoneIndex++;
            LMS_Meta.ModifyHackRecord("SHOOT_BOT", 1, ExternalCOPSHaXHook.SERIALIZED_BONES[selectedShootBotBoneIndex]);
        }, true);
        OptSBBoneLeft.AllowInput = true;
        OptSBBoneLeft.SetTexture((int)E_Texture.IDLE, OptSBBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptSBBoneRight.AllowInput = true;
        OptSBBoneRight.SetTexture((int)E_Texture.IDLE, OptSBBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        Aimbot.RegisterClientViewTick((view) => { UpdateBoneLabels(); }, null);
    }
    void InitToggles()
    {
        OptAimbotToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        OptTriggerbotToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        OptSaimbotToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        OptInvisAimbotToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        OptMeleeToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        OptSBToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(247f, 151f, 200f, 146f),
        });
        InitToggleDefault(OptAimbotToggle, (val) => { LMS_Meta.ModifyHackRecord("AIMBOT", 0, val.ToString().ToLower()); });
        InitToggleDefault(OptTriggerbotToggle, (val) => { LMS_Meta.ModifyHackRecord("TRIGGERBOT", 0, val.ToString().ToLower()); });
        InitToggleDefault(OptSaimbotToggle, (val) => { LMS_Meta.ModifyHackRecord("SILENT_AIMBOT", 0, val.ToString().ToLower()); });
        InitToggleDefault(OptInvisAimbotToggle, (val) => { LMS_Meta.ModifyHackRecord("INVISIBLE_AIMBOT", 0, val.ToString().ToLower()); });
        InitToggleDefault(OptMeleeToggle, (val) => { LMS_Meta.ModifyHackRecord("AUTO_MELEE", 0, val.ToString().ToLower()); });
        InitToggleDefault(OptSBToggle, (val) => { LMS_Meta.ModifyHackRecord("SHOOT_BOT", 0, val.ToString().ToLower()); });
    }
    void InitToggleDefault(LMS_GuiBaseToggle toggle, OnToggleValueChanged value = null)
    {
        toggle.UseRelativeRect = true;
        //toggle.SetTexture((int)E_Texture.IDLE, toggle.GeneratePlainTexture(Color.red, 16, 16).Circlify());
        //toggle.SetTexture((int)E_Texture.DOWN, toggle.GeneratePlainTexture(Color.green, 16, 16).Circlify());
        toggle.SetBlendMode(E_BlendMode.BLENDED);
        if (value != null)
            toggle.OnToggleChanged += value;
    }
    public override string ScreenName()
    {
        return "Automation";
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
    void UpdateBoneLabels()
    {
        OptAimbotSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedAimbotBoneIndex]);
        OptTriggerbotSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedTriggerbotBoneIndex]);
        OptSaimbotSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedSilentAimbotBoneIndex]);
        OptInvisAimbotSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedInvisAimbotBoneIndex]);
        OptMeleeSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedAutoMeleeBoneIndex]);
        OptSBSelectedBoneLabel.Config.SetText(ExternalCOPSHaXHook.BONES[selectedShootBotBoneIndex]);
    }
    T InstantiateOptionWindowChild<T>(LMS_GuiConfig c) where T : LMS_GuiBaseCallback
    {
        return InstantiateChild<T>(c, 72);
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Automation;
    }
}