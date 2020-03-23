using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LMS_GuiScreenESP : LMS_GuiScreen
{
    LMS_GuiBaseLabel Creditslabel;
    LMS_GuiBaseBox2D CopsLogo;
    LMS_GuiBaseBox2D OptionsWindow;
    LMS_GuiBaseLabel Version;
    LMS_GuiBaseTouchBar TouchBar;
    LMS_GuiBaseLabel OptTitle;
    LMS_GuiBaseLabel OptText;
    LMS_GuiBaseButton Box, Line, Name, Distance, Chams, Health, Back, Trajectories;
    LMS_GuiBaseLabel BoxLabel, LineLabel, NameLabel, DistanceLabel, ChamsLabel, HealthLabel, BackLabel, TrajectoriesLabel;
    #region BOX
    LMS_GuiBaseToggle OptBoxVisibilityToggle, OptBoxEnabledToggle;
    LMS_GuiBaseLabel OptBoxVisibilityLabel, OptBoxEnabledLabel, OptBoxVisibilityTickLabel, OptBoxEnabledTickLabel;
    #endregion
    #region LINE
    LMS_GuiBaseToggle OptLineVisibilityToggle, OptLineEnabledToggle;
    LMS_GuiBaseLabel OptLineVisibilityLabel, OptLineEnabledLabel, OptLineVisibilityTickLabel, OptLineEnabledTickLabel, OptLineBoneLeftLabel, OptLineBoneRightLabel, OptLineSelectedBoneLabel;
    LMS_GuiBaseButton OptLineBoneLeft, OptLineBoneRight;
    #endregion
    #region NAME
    LMS_GuiBaseToggle OptNameVisibilityToggle, OptNameEnabledToggle;
    LMS_GuiBaseLabel OptNameVisibilityLabel, OptNameEnabledLabel, OptNameVisibilityTickLabel, OptNameEnabledTickLabel, OptNameBoneLeftLabel, OptNameBoneRightLabel, OptNameSelectedBoneLabel;
    LMS_GuiBaseButton OptNameBoneLeft, OptNameBoneRight;
    #endregion
    #region Dist
    LMS_GuiBaseToggle OptDistVisibilityToggle, OptDistEnabledToggle;
    LMS_GuiBaseLabel OptDistVisibilityLabel, OptDistEnabledLabel, OptDistVisibilityTickLabel, OptDistEnabledTickLabel, OptDistBoneLeftLabel, OptDistBoneRightLabel, OptDistSelectedBoneLabel;
    LMS_GuiBaseButton OptDistBoneLeft, OptDistBoneRight;
    #endregion
    #region CHAMS
    LMS_GuiBaseToggle OptChamsVisibilityToggle, OptChamsEnabledToggle;
    LMS_GuiBaseLabel OptChamsVisibilityLabel, OptChamsEnabledLabel, OptChamsVisibilityTickLabel, OptChamsEnabledTickLabel;
    #endregion
    #region HP
    LMS_GuiBaseToggle OptHPColToggle, OptHPEnabledToggle;
    LMS_GuiBaseLabel OptHPColLabel, OptHPEnabledLabel, OptHPColTickLabel, OptHPEnabledTickLabel, OptHPBoneLeftLabel, OptHPBoneRightLabel, OptHPSelectedBoneLabel;
    LMS_GuiBaseButton OptHPBoneLeft, OptHPBoneRight;
    #endregion
    #region TRAJECTORIES
    LMS_GuiBaseToggle OptTrajectoriesEnabledToggle;
    LMS_GuiBaseLabel OptTrajectoriesEnabledLabel, OptTrajectoriesEnabledTickLabel;
    #endregion
    int selectedIndex;

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
        Owner.AddChild(Box);
        Owner.AddChild(Line);
        Owner.AddChild(Name);
        Owner.AddChild(Distance);
        Owner.AddChild(Chams);
        Owner.AddChild(Health);
        Owner.AddChild(BoxLabel);
        Owner.AddChild(LineLabel);
        Owner.AddChild(NameLabel);
        Owner.AddChild(DistanceLabel);
        Owner.AddChild(ChamsLabel);
        Owner.AddChild(HealthLabel);
        Owner.AddChild(OptBoxVisibilityToggle);
        Owner.AddChild(OptBoxEnabledToggle);
        Owner.AddChild(OptBoxVisibilityLabel);
        Owner.AddChild(OptBoxEnabledLabel);
        Owner.AddChild(OptBoxVisibilityTickLabel);
        Owner.AddChild(OptBoxEnabledTickLabel);
        Owner.AddChild(OptLineVisibilityToggle);
        Owner.AddChild(OptLineEnabledToggle);
        Owner.AddChild(OptLineVisibilityLabel);
        Owner.AddChild(OptLineEnabledLabel);
        Owner.AddChild(OptLineVisibilityTickLabel);
        Owner.AddChild(OptLineEnabledTickLabel);
        Owner.AddChild(OptLineBoneLeft);
        Owner.AddChild(OptLineBoneLeftLabel);
        Owner.AddChild(OptLineBoneRight);
        Owner.AddChild(OptLineBoneRightLabel);
        Owner.AddChild(OptLineSelectedBoneLabel);
        Owner.AddChild(Back);
        Owner.AddChild(BackLabel);
        Owner.AddChild(OptNameVisibilityToggle);
        Owner.AddChild(OptNameEnabledToggle);
        Owner.AddChild(OptNameVisibilityLabel);
        Owner.AddChild(OptNameEnabledLabel);
        Owner.AddChild(OptNameVisibilityTickLabel);
        Owner.AddChild(OptNameEnabledTickLabel);
        Owner.AddChild(OptNameBoneLeft);
        Owner.AddChild(OptNameBoneLeftLabel);
        Owner.AddChild(OptNameBoneRight);
        Owner.AddChild(OptNameBoneRightLabel);
        Owner.AddChild(OptNameSelectedBoneLabel);
        Owner.AddChild(OptDistVisibilityToggle);
        Owner.AddChild(OptDistEnabledToggle);
        Owner.AddChild(OptDistVisibilityLabel);
        Owner.AddChild(OptDistEnabledLabel);
        Owner.AddChild(OptDistVisibilityTickLabel);
        Owner.AddChild(OptDistEnabledTickLabel);
        Owner.AddChild(OptDistBoneLeft);
        Owner.AddChild(OptDistBoneLeftLabel);
        Owner.AddChild(OptDistBoneRight);
        Owner.AddChild(OptDistBoneRightLabel);
        Owner.AddChild(OptDistSelectedBoneLabel);
        Owner.AddChild(OptChamsVisibilityToggle);
        Owner.AddChild(OptChamsEnabledToggle);
        Owner.AddChild(OptChamsVisibilityLabel);
        Owner.AddChild(OptChamsEnabledLabel);
        Owner.AddChild(OptChamsVisibilityTickLabel);
        Owner.AddChild(OptChamsEnabledTickLabel);
        Owner.AddChild(OptHPColToggle);
        Owner.AddChild(OptHPEnabledToggle);
        Owner.AddChild(OptHPColLabel);
        Owner.AddChild(OptHPEnabledLabel);
        Owner.AddChild(OptHPColTickLabel);
        Owner.AddChild(OptHPEnabledTickLabel);
        Owner.AddChild(OptHPBoneLeft);
        Owner.AddChild(OptHPBoneLeftLabel);
        Owner.AddChild(OptHPBoneRight);
        Owner.AddChild(OptHPBoneRightLabel);
        Owner.AddChild(OptHPSelectedBoneLabel);
        Owner.AddChild(Trajectories);
        Owner.AddChild(TrajectoriesLabel);
        Owner.AddChild(OptTrajectoriesEnabledToggle);
        Owner.AddChild(OptTrajectoriesEnabledLabel);
        Owner.AddChild(OptTrajectoriesEnabledTickLabel);
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
        BoxLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f),
            Text = "Boxes",
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
        LineLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f),
            Text = "Tracelines",
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
        NameLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f),
            Text = "Name Labels",
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
        DistanceLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f),
            Text = "Distance Labels",
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
        ChamsLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f),
            Text = "Chams",
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
        HealthLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 205f, 431f, 150f),
            Text = "Health Bar",
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
        TrajectoriesLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 240f, 431f, 150f),
            Text = "Trajectories",
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
        OptBoxEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptBoxEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptBoxVisibilityLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptBoxVisibilityTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptLineEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptLineEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptLineVisibilityLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptLineVisibilityTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptLineBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 221f, 167f, 150f),
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
        OptLineBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 221f, 167f, 150f),
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
        OptLineSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 221f, 430f, 150f),
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
        BackLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Back",
            Rect = new Rect(12f, 275f, 430f, 150f),
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
        OptNameEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptNameEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptNameVisibilityLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptNameVisibilityTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptNameBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 221f, 167f, 150f),
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
        OptNameBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 221f, 167f, 150f),
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
        OptNameSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 221f, 430f, 150f),
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
        OptDistEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptDistEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptDistVisibilityLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptDistVisibilityTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptDistBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 221f, 167f, 150f),
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
        OptDistBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 221f, 167f, 150f),
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
        OptDistSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "Chest",
            Rect = new Rect(168f, 221f, 430f, 150f),
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
        OptChamsEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptChamsEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptChamsVisibilityLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptChamsVisibilityTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptHPEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptHPEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptHPColLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(142f, 186f, 431f, 150f),
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
        OptHPColTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "",
            Rect = new Rect(247f, 186f, 200f, 146f),
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
        OptHPBoneLeftLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "<",
            Rect = new Rect(167f, 221f, 167f, 150f),
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
        OptHPBoneRightLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = ">",
            Rect = new Rect(292f, 221f, 167f, 150f),
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
        OptHPSelectedBoneLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
        {
            Text = "H Above Head",
            Rect = new Rect(168f, 221f, 430f, 150f),
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
        OptTrajectoriesEnabledLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        OptTrajectoriesEnabledTickLabel = InstantiateOptionWindowChild<LMS_GuiBaseLabel>(new LMS_GuiConfig
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
        InitLabelDefault(Creditslabel);
        InitLabelDefault(Version);
        InitLabelDefault(OptText);
        InitLabelDefault(OptTitle);
        InitLabelDefault(BoxLabel);
        InitLabelDefault(LineLabel);
        InitLabelDefault(NameLabel);
        InitLabelDefault(DistanceLabel);
        InitLabelDefault(ChamsLabel);
        InitLabelDefault(HealthLabel);
        InitLabelDefault(TrajectoriesLabel);
        InitLabelDefault(OptBoxEnabledLabel);
        InitLabelDefault(OptBoxEnabledTickLabel);
        InitLabelDefault(OptBoxVisibilityLabel);
        InitLabelDefault(OptBoxVisibilityTickLabel);
        InitLabelDefault(OptLineEnabledLabel);
        InitLabelDefault(OptLineEnabledTickLabel);
        InitLabelDefault(OptLineVisibilityLabel);
        InitLabelDefault(OptLineVisibilityTickLabel);
        InitLabelDefault(OptLineBoneLeftLabel);
        InitLabelDefault(OptLineBoneRightLabel);
        InitLabelDefault(OptLineSelectedBoneLabel);
        InitLabelDefault(OptNameEnabledLabel);
        InitLabelDefault(OptNameEnabledTickLabel);
        InitLabelDefault(OptNameVisibilityLabel);
        InitLabelDefault(OptNameVisibilityTickLabel);
        InitLabelDefault(OptNameBoneLeftLabel);
        InitLabelDefault(OptNameBoneRightLabel);
        InitLabelDefault(OptNameSelectedBoneLabel);
        InitLabelDefault(OptDistEnabledLabel);
        InitLabelDefault(OptDistEnabledTickLabel);
        InitLabelDefault(OptDistVisibilityLabel);
        InitLabelDefault(OptDistVisibilityTickLabel);
        InitLabelDefault(OptDistBoneLeftLabel);
        InitLabelDefault(OptDistBoneRightLabel);
        InitLabelDefault(OptDistSelectedBoneLabel);
        InitLabelDefault(OptChamsEnabledLabel);
        InitLabelDefault(OptChamsEnabledTickLabel);
        InitLabelDefault(OptChamsVisibilityLabel);
        InitLabelDefault(OptChamsVisibilityTickLabel);
        InitLabelDefault(OptHPEnabledLabel);
        InitLabelDefault(OptHPEnabledTickLabel);
        InitLabelDefault(OptHPColLabel);
        InitLabelDefault(OptHPColTickLabel);
        InitLabelDefault(OptHPBoneLeftLabel);
        InitLabelDefault(OptHPBoneRightLabel);
        InitLabelDefault(OptHPSelectedBoneLabel);
        InitLabelDefault(BackLabel);
        InitLabelDefault(OptTrajectoriesEnabledLabel);
        InitLabelDefault(OptTrajectoriesEnabledTickLabel);
        Creditslabel.SetFlags("EXTRUDE", "OUTLINE");
        Version.SetFlags("OUTLINE");
        Creditslabel.SetRenderMode(E_ColorFlags.FIXED);
        Version.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetRenderMode(E_ColorFlags.FIXED);
        OptTitle.SetRenderMode(E_ColorFlags.FIXED);
        OptText.SetFlags("NONE");
        OptTitle.SetFlags("NONE");
        OptBoxEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptBoxEnabledLabel.SetFlags("NONE");
        OptBoxEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptBoxEnabledTickLabel.SetFlags("NONE");
        OptBoxVisibilityLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptBoxVisibilityLabel.SetFlags("NONE");
        OptBoxVisibilityTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptBoxVisibilityTickLabel.SetFlags("NONE");
        OptLineEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptLineEnabledLabel.SetFlags("NONE");
        OptLineEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptLineEnabledTickLabel.SetFlags("NONE");
        OptLineVisibilityLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptLineVisibilityLabel.SetFlags("NONE");
        OptLineVisibilityTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptLineVisibilityTickLabel.SetFlags("NONE");
        OptNameEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptNameEnabledLabel.SetFlags("NONE");
        OptNameEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptNameEnabledTickLabel.SetFlags("NONE");
        OptNameVisibilityLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptNameVisibilityLabel.SetFlags("NONE");
        OptNameVisibilityTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptNameVisibilityTickLabel.SetFlags("NONE");
        OptDistEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptDistEnabledLabel.SetFlags("NONE");
        OptDistEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptDistEnabledTickLabel.SetFlags("NONE");
        OptDistVisibilityLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptDistVisibilityLabel.SetFlags("NONE");
        OptDistVisibilityTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptDistVisibilityTickLabel.SetFlags("NONE");
        OptChamsEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptChamsEnabledLabel.SetFlags("NONE");
        OptChamsEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptChamsEnabledTickLabel.SetFlags("NONE");
        OptChamsVisibilityLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptChamsVisibilityLabel.SetFlags("NONE");
        OptChamsVisibilityTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptChamsVisibilityTickLabel.SetFlags("NONE");
        OptHPEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptHPEnabledLabel.SetFlags("NONE");
        OptHPEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptHPEnabledTickLabel.SetFlags("NONE");
        OptHPColLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptHPColLabel.SetFlags("NONE");
        OptHPColTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptHPColTickLabel.SetFlags("NONE");
        OptTrajectoriesEnabledLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptTrajectoriesEnabledLabel.SetFlags("NONE");
        OptTrajectoriesEnabledTickLabel.SetRenderMode(E_ColorFlags.FIXED);
        OptTrajectoriesEnabledTickLabel.SetFlags("NONE");
    }
    void InitButtons()
    {
        Box = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 30f, 431f, 150f)
        }, 50);
        Line = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 65f, 431f, 150f)
        }, 50);
        Name = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 100f, 431f, 150f)
        }, 50);
        Distance = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 135f, 431f, 150f)
        }, 50);
        Chams = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 170f, 431f, 150f)
        }, 50);
        Health = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 205f, 431f, 150f)
        }, 50);
        OptLineBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 221f, 167f, 150f)
        });
        OptLineBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 221f, 167f, 150f)
        });
        OptNameBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 221f, 167f, 150f)
        });
        OptNameBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 221f, 167f, 150f)
        });
        OptDistBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 221f, 167f, 150f)
        });
        OptDistBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 221f, 167f, 150f)
        });
        OptHPBoneLeft = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(167f, 221f, 167f, 150f)
        });
        OptHPBoneRight = InstantiateOptionWindowChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(292f, 221f, 167f, 150f)
        });
        Trajectories = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 240f, 431f, 150f)
        }, 50);
        Back = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(12f, 275f, 431f, 150f)
        }, 50);
        InitButtonDefault(Box, CreateDetails("Box ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draw boxes around enemies", 19, 200f), KeyValuePairUtil.b(OptBoxEnabledLabel, (view) => { OptBoxVisibilityLabel.Config.SetText(OptBoxVisibilityToggle.Value ? "Visibility E" : "Visibility NE"); OptBoxVisibilityLabel.Config.SetColor(OptBoxVisibilityToggle.Value ? Color.green : Color.red); OptBoxVisibilityTickLabel.Config.SetText(OptBoxVisibilityToggle.Value ? "Y" : "X"); OptBoxVisibilityTickLabel.Config.SetColor(OptBoxVisibilityToggle.Value ? Color.green : Color.red); OptBoxVisibilityTickLabel.Config.SetX(OptBoxVisibilityToggle.Value ? 283f : 267f); OptBoxEnabledLabel.Config.SetText(OptBoxEnabledToggle.Value ? "Enabled" : "Disabled"); OptBoxEnabledLabel.Config.SetColor(OptBoxEnabledToggle.Value ? Color.green : Color.red); OptBoxEnabledTickLabel.Config.SetText(OptBoxEnabledToggle.Value ? "Y" : "X"); OptBoxEnabledTickLabel.Config.SetColor(OptBoxEnabledToggle.Value ? Color.green : Color.red); OptBoxEnabledTickLabel.Config.SetX(OptBoxEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptBoxEnabledTickLabel), KeyValuePairUtil.b(OptBoxEnabledToggle), KeyValuePairUtil.b(OptBoxVisibilityLabel), KeyValuePairUtil.b(OptBoxVisibilityTickLabel), KeyValuePairUtil.b(OptBoxVisibilityToggle)));
        InitButtonDefault(Line, CreateDetails("Line ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draw lines to enemies", 19, 200f), KeyValuePairUtil.b(OptLineEnabledLabel, (view) => { OptLineVisibilityLabel.Config.SetText(OptLineVisibilityToggle.Value ? "Visibility E" : "Visibility NE"); OptLineVisibilityLabel.Config.SetColor(OptLineVisibilityToggle.Value ? Color.green : Color.red); OptLineVisibilityTickLabel.Config.SetText(OptLineVisibilityToggle.Value ? "Y" : "X"); OptLineVisibilityTickLabel.Config.SetColor(OptLineVisibilityToggle.Value ? Color.green : Color.red); OptLineVisibilityTickLabel.Config.SetX(OptLineVisibilityToggle.Value ? 283f : 267f); OptLineEnabledLabel.Config.SetText(OptLineEnabledToggle.Value ? "Enabled" : "Disabled"); OptLineEnabledLabel.Config.SetColor(OptLineEnabledToggle.Value ? Color.green : Color.red); OptLineEnabledTickLabel.Config.SetText(OptLineEnabledToggle.Value ? "Y" : "X"); OptLineEnabledTickLabel.Config.SetColor(OptLineEnabledToggle.Value ? Color.green : Color.red); OptLineEnabledTickLabel.Config.SetX(OptLineEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptLineEnabledTickLabel), KeyValuePairUtil.b(OptLineEnabledToggle), KeyValuePairUtil.b(OptLineVisibilityLabel), KeyValuePairUtil.b(OptLineVisibilityTickLabel), KeyValuePairUtil.b(OptLineVisibilityToggle), KeyValuePairUtil.b(OptLineBoneLeft), KeyValuePairUtil.b(OptLineBoneLeftLabel), KeyValuePairUtil.b(OptLineBoneRight), KeyValuePairUtil.b(OptLineBoneRightLabel), KeyValuePairUtil.b(OptLineSelectedBoneLabel)));
        InitButtonDefault(Name, CreateDetails("Name ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draw a player's name on the selected bone", 19, 200f), KeyValuePairUtil.b(OptNameEnabledLabel, (view) => { OptNameVisibilityLabel.Config.SetText(OptNameVisibilityToggle.Value ? "Visibility E" : "Visibility NE"); OptNameVisibilityLabel.Config.SetColor(OptNameVisibilityToggle.Value ? Color.green : Color.red); OptNameVisibilityTickLabel.Config.SetText(OptNameVisibilityToggle.Value ? "Y" : "X"); OptNameVisibilityTickLabel.Config.SetColor(OptNameVisibilityToggle.Value ? Color.green : Color.red); OptNameVisibilityTickLabel.Config.SetX(OptNameVisibilityToggle.Value ? 283f : 267f); OptNameEnabledLabel.Config.SetText(OptNameEnabledToggle.Value ? "Enabled" : "Disabled"); OptNameEnabledLabel.Config.SetColor(OptNameEnabledToggle.Value ? Color.green : Color.red); OptNameEnabledTickLabel.Config.SetText(OptNameEnabledToggle.Value ? "Y" : "X"); OptNameEnabledTickLabel.Config.SetColor(OptNameEnabledToggle.Value ? Color.green : Color.red); OptNameEnabledTickLabel.Config.SetX(OptNameEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptNameEnabledTickLabel), KeyValuePairUtil.b(OptNameEnabledToggle), KeyValuePairUtil.b(OptNameVisibilityLabel), KeyValuePairUtil.b(OptNameVisibilityTickLabel), KeyValuePairUtil.b(OptNameVisibilityToggle), KeyValuePairUtil.b(OptNameBoneLeft), KeyValuePairUtil.b(OptNameBoneLeftLabel), KeyValuePairUtil.b(OptNameBoneRight), KeyValuePairUtil.b(OptNameBoneRightLabel), KeyValuePairUtil.b(OptNameSelectedBoneLabel)));
        InitButtonDefault(Distance, CreateDetails("Distance ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draw a player's distance on the selected bone", 19, 200f), KeyValuePairUtil.b(OptDistEnabledLabel, (view) => { OptDistVisibilityLabel.Config.SetText(OptDistVisibilityToggle.Value ? "Visibility E" : "Visibility NE"); OptDistVisibilityLabel.Config.SetColor(OptDistVisibilityToggle.Value ? Color.green : Color.red); OptDistVisibilityTickLabel.Config.SetText(OptDistVisibilityToggle.Value ? "Y" : "X"); OptDistVisibilityTickLabel.Config.SetColor(OptDistVisibilityToggle.Value ? Color.green : Color.red); OptDistVisibilityTickLabel.Config.SetX(OptDistVisibilityToggle.Value ? 283f : 267f); OptDistEnabledLabel.Config.SetText(OptDistEnabledToggle.Value ? "Enabled" : "Disabled"); OptDistEnabledLabel.Config.SetColor(OptDistEnabledToggle.Value ? Color.green : Color.red); OptDistEnabledTickLabel.Config.SetText(OptDistEnabledToggle.Value ? "Y" : "X"); OptDistEnabledTickLabel.Config.SetColor(OptDistEnabledToggle.Value ? Color.green : Color.red); OptDistEnabledTickLabel.Config.SetX(OptDistEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptDistEnabledTickLabel), KeyValuePairUtil.b(OptDistEnabledToggle), KeyValuePairUtil.b(OptDistVisibilityLabel), KeyValuePairUtil.b(OptDistVisibilityTickLabel), KeyValuePairUtil.b(OptDistVisibilityToggle), KeyValuePairUtil.b(OptDistBoneLeft), KeyValuePairUtil.b(OptDistBoneLeftLabel), KeyValuePairUtil.b(OptDistBoneRight), KeyValuePairUtil.b(OptDistBoneRightLabel), KeyValuePairUtil.b(OptDistSelectedBoneLabel)));
        InitButtonDefault(Chams, CreateDetails("Chams", LMS_GuiBaseLabelBoundaries.WrapText("Abillity to see players through walls", 19, 200f), KeyValuePairUtil.b(OptChamsEnabledLabel, (view) => { OptChamsVisibilityLabel.Config.SetText(OptChamsVisibilityToggle.Value ? "Visibility E" : "Visibility NE"); OptChamsVisibilityLabel.Config.SetColor(OptChamsVisibilityToggle.Value ? Color.green : Color.red); OptChamsVisibilityTickLabel.Config.SetText(OptChamsVisibilityToggle.Value ? "Y" : "X"); OptChamsVisibilityTickLabel.Config.SetColor(OptChamsVisibilityToggle.Value ? Color.green : Color.red); OptChamsVisibilityTickLabel.Config.SetX(OptChamsVisibilityToggle.Value ? 283f : 267f); OptChamsEnabledLabel.Config.SetText(OptChamsEnabledToggle.Value ? "Enabled" : "Disabled"); OptChamsEnabledLabel.Config.SetColor(OptChamsEnabledToggle.Value ? Color.green : Color.red); OptChamsEnabledTickLabel.Config.SetText(OptChamsEnabledToggle.Value ? "Y" : "X"); OptChamsEnabledTickLabel.Config.SetColor(OptChamsEnabledToggle.Value ? Color.green : Color.red); OptChamsEnabledTickLabel.Config.SetX(OptChamsEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptChamsEnabledTickLabel), KeyValuePairUtil.b(OptChamsEnabledToggle), KeyValuePairUtil.b(OptChamsVisibilityLabel), KeyValuePairUtil.b(OptChamsVisibilityTickLabel), KeyValuePairUtil.b(OptChamsVisibilityToggle)));
        InitButtonDefault(Health, CreateDetails("Health Bar ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draw a player's health based on the config below", 19, 200f), KeyValuePairUtil.b(OptHPEnabledLabel, (view) => { OptHPColLabel.Config.SetText(OptHPColToggle.Value ? "Health Color E" : "Health Color NE"); OptHPColLabel.Config.SetColor(OptHPColToggle.Value ? Color.green : Color.red); OptHPColTickLabel.Config.SetText(OptHPColToggle.Value ? "Y" : "X"); OptHPColTickLabel.Config.SetColor(OptHPColToggle.Value ? Color.green : Color.red); OptHPColTickLabel.Config.SetX(OptHPColToggle.Value ? 283f : 267f); OptHPEnabledLabel.Config.SetText(OptHPEnabledToggle.Value ? "Enabled" : "Disabled"); OptHPEnabledLabel.Config.SetColor(OptHPEnabledToggle.Value ? Color.green : Color.red); OptHPEnabledTickLabel.Config.SetText(OptHPEnabledToggle.Value ? "Y" : "X"); OptHPEnabledTickLabel.Config.SetColor(OptHPEnabledToggle.Value ? Color.green : Color.red); OptHPEnabledTickLabel.Config.SetX(OptHPEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptHPEnabledTickLabel), KeyValuePairUtil.b(OptHPEnabledToggle), KeyValuePairUtil.b(OptHPColLabel), KeyValuePairUtil.b(OptHPColTickLabel), KeyValuePairUtil.b(OptHPColToggle), KeyValuePairUtil.b(OptHPBoneLeft), KeyValuePairUtil.b(OptHPBoneLeftLabel), KeyValuePairUtil.b(OptHPBoneRight), KeyValuePairUtil.b(OptHPBoneRightLabel), KeyValuePairUtil.b(OptHPSelectedBoneLabel)));
        InitButtonDefault(Trajectories, CreateDetails("Trajectories ESP", LMS_GuiBaseLabelBoundaries.WrapText("Draws a set of overlays showing where the active projectile would hit", 19, 200f), KeyValuePairUtil.b(OptTrajectoriesEnabledLabel, (view) => { OptTrajectoriesEnabledLabel.Config.SetText(OptTrajectoriesEnabledToggle.Value ? "Enabled" : "Disabled"); OptTrajectoriesEnabledLabel.Config.SetColor(OptTrajectoriesEnabledToggle.Value ? Color.green : Color.red); OptTrajectoriesEnabledTickLabel.Config.SetText(OptTrajectoriesEnabledToggle.Value ? "Y" : "X"); OptTrajectoriesEnabledTickLabel.Config.SetColor(OptTrajectoriesEnabledToggle.Value ? Color.green : Color.red); OptTrajectoriesEnabledTickLabel.Config.SetX(OptTrajectoriesEnabledToggle.Value ? 283f : 267f); }), KeyValuePairUtil.b(OptTrajectoriesEnabledTickLabel), KeyValuePairUtil.b(OptTrajectoriesEnabledToggle)));
        InitButtonDefault(Back, CreateDetails("Back", LMS_GuiBaseLabelBoundaries.WrapText("Return to the Main Menu", 19, 200f)), () => { LMS_Main.Instance.ShowScreen(0); });
        InitButtonDefault(OptLineBoneLeft, null, null, true);
        InitButtonDefault(OptLineBoneRight, null, null, true);
        OptLineBoneLeft.AllowInput = true;
        OptLineBoneLeft.SetTexture((int)E_Texture.IDLE, OptLineBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptLineBoneRight.AllowInput = true;
        OptLineBoneRight.SetTexture((int)E_Texture.IDLE, OptLineBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptNameBoneLeft, null, null, true);
        InitButtonDefault(OptNameBoneRight, null, null, true);
        OptNameBoneLeft.AllowInput = true;
        OptNameBoneLeft.SetTexture((int)E_Texture.IDLE, OptNameBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptNameBoneRight.AllowInput = true;
        OptNameBoneRight.SetTexture((int)E_Texture.IDLE, OptNameBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptDistBoneLeft, null, null, true);
        InitButtonDefault(OptDistBoneRight, null, null, true);
        OptDistBoneLeft.AllowInput = true;
        OptDistBoneLeft.SetTexture((int)E_Texture.IDLE, OptDistBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptDistBoneRight.AllowInput = true;
        OptDistBoneRight.SetTexture((int)E_Texture.IDLE, OptDistBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        InitButtonDefault(OptHPBoneLeft, null, null, true);
        InitButtonDefault(OptHPBoneRight, null, null, true);
        OptHPBoneLeft.AllowInput = true;
        OptHPBoneLeft.SetTexture((int)E_Texture.IDLE, OptHPBoneLeft.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
        OptHPBoneRight.AllowInput = true;
        OptHPBoneRight.SetTexture((int)E_Texture.IDLE, OptHPBoneRight.GeneratePlainTexture(Color.yellow.AlterAlpha(0.3f)));
    }
    void InitToggles()
    {
        OptBoxEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptBoxEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.BOX_ESP, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptBoxVisibilityToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptBoxVisibilityToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.BOX_ESP, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptLineEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptLineEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.LINE_ESP, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptLineVisibilityToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptLineVisibilityToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.LINE_ESP, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptNameEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptNameEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.NAME_ESP, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptNameVisibilityToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptNameVisibilityToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.NAME_ESP, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptDistEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptDistEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.DISTANCE_ESP, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptDistVisibilityToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptDistVisibilityToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.DISTANCE_ESP, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptChamsEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptChamsEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.CHAMS, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptChamsVisibilityToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptChamsVisibilityToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.CHAMS, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptHPEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptHPEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.HEALTH_BAR, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
        OptHPColToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 186f, 200f, 146f),
        });
        OptHPColToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.HEALTH_BAR, ExternalCOPSHaXHook.VISIBLITY_INDEX, val.ToString().ToLower());
        OptTrajectoriesEnabledToggle = InstantiateOptionWindowChild<LMS_GuiBaseToggle>(new LMS_GuiConfig
        {
            Rect = new Rect(267f, 151f, 200f, 146f),
        });
        OptTrajectoriesEnabledToggle.OnToggleChanged += (val) => LMS_Meta.ModifyHackRecord(ExternalCOPSHaXHook.TRAJECTORIES, ExternalCOPSHaXHook.ENABLED_INDEX, val.ToString().ToLower());
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
    public override string ScreenName()
    {
        return "ESP";
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
    void InitToggleDefault(LMS_GuiBaseToggle toggle)
    {
        toggle.UseRelativeRect = true;
        //toggle.SetTexture((int)E_Texture.IDLE, toggle.GeneratePlainTexture(Color.red, 16, 16).Circlify());
        //toggle.SetTexture((int)E_Texture.DOWN, toggle.GeneratePlainTexture(Color.green, 16, 16).Circlify());
        toggle.SetBlendMode(E_BlendMode.BLENDED);
    }
    T InstantiateOptionWindowChild<T>(LMS_GuiConfig c) where T : LMS_GuiBaseCallback
    {
        return InstantiateChild<T>(c, 72);
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Esp;
    }
}
