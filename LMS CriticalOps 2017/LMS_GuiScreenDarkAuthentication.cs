using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenDarkAuthentication : LMS_GuiScreen
{
    GUISkin m_Skin;
    LMS_GuiBaseBox2D LMSLogo;
    LMS_GuiBaseLabel UsernameLabel, TitleLabel, UsernameRenderer, PasswordLabel, PasswordRenderer, LoginText, ErrorLabel, DiscordLabel;
    LMS_GuiBaseTextField UsernameTextField, PasswordTextField;
    LMS_GuiBaseButton LoginButton, DiscordButton;

    void Awake()
    {
        m_Skin = LMS_GuiBaseUtils.GetDarkSkin();
        InitLabels();
        InitButtons();
        InitOverlays();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig
        {
            Rect = new Rect(290f, 103f, 680f, 460f)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, m_Skin.box.normal.background);
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(TitleLabel);
        Owner.AddChild(UsernameLabel);
        Owner.AddChild(UsernameTextField);
        Owner.AddChild(UsernameRenderer);
        Owner.AddChild(PasswordRenderer);
        Owner.AddChild(PasswordLabel);
        Owner.AddChild(PasswordTextField);
        Owner.AddChild(LoginButton);
        Owner.AddChild(LoginText);
        Owner.AddChild(ErrorLabel);
        Owner.AddChild(DiscordButton);
        Owner.AddChild(DiscordLabel);
    }
    public override string ScreenName()
    {
        return "Authentication";
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Authentication;
    }
    void InitLabels()
    {
        UsernameLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(4f, 80f, 431f, 150f),
            Text = "Username",
            RenderStyle = new GUIStyle
            {
                fontSize = 15,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        TitleLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(107f, 4f, 431f, 150f),
            Text = string.Format("<b>LMS {0} [<color=#83b6ef>Critical OPS</color></b>] - Authentication", LMS_Meta.getMetaValue("VER")),
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
        UsernameRenderer = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(120f, 80f, 461f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 1);
        PasswordLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(4f, 120f, 431f, 150f),
            Text = "Password",
            RenderStyle = new GUIStyle
            {
                fontSize = 15,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        PasswordRenderer = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(120f, 120f, 461f, 150f),
            RenderStyle = new GUIStyle
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 1);
        LoginText = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(150f, 165f, 370f, 190f),
            Text = "Login",
            RenderStyle = new GUIStyle
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        ErrorLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(210f, 260f, 431f, 150f),
            Text = "ERROR HERE",
            RenderStyle = new GUIStyle
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleRight,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 15);
        DiscordLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(10f, 185f, 340f, 250f),
            Text = LMS_GuiBaseLabelBoundaries.WrapText("Don't own the hack? Click here to join our discord and purchase it!", 14, 200f),
            RenderStyle = new GUIStyle
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.white
                }
            }
        }, 15);
        InitLabelDefault(UsernameLabel);
        InitLabelDefault(TitleLabel);
        InitLabelDefault(UsernameRenderer);
        InitLabelDefault(PasswordLabel);
        InitLabelDefault(PasswordRenderer);
        InitLabelDefault(LoginText);
        InitLabelDefault(ErrorLabel);
        InitLabelDefault(DiscordLabel);
        UsernameLabel.SetRenderMode(E_ColorFlags.FIXED);
        TitleLabel.SetRenderMode(E_ColorFlags.FIXED);
        UsernameRenderer.SetRenderMode(E_ColorFlags.FIXED);
        PasswordLabel.SetRenderMode(E_ColorFlags.FIXED);
        PasswordRenderer.SetRenderMode(E_ColorFlags.FIXED);
        ErrorLabel.SetRenderMode(E_ColorFlags.FIXED);
        DiscordLabel.SetFlags("UNDERLINE", LMS_GuiBaseLabelBoundaries.WrapText("_____ ___ ___ _____ _____ ____ __ ____ ___ _______ ___ ________ ___", 14, 200f));
    }
    void InitOverlays()
    {
        UsernameTextField = InstantiateChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(120f, 80f, 461f, 150f)
        }, 1);
        UsernameTextField.SetTexture((int)E_Texture.IDLE, m_Skin.textField.normal.background);
        UsernameTextField.OnTextChanged += (text) => UsernameRenderer.Config.Text = UsernameTextField.TextToRender;
        PasswordTextField = InstantiateChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(120f, 120f, 461f, 150f)
        }, 1);
        PasswordTextField.SetTexture((int)E_Texture.IDLE, m_Skin.textField.normal.background);
        PasswordTextField.OnTextChanged += (text) => PasswordRenderer.Config.Text = PasswordTextField.TextToRender;
        PasswordTextField.Password = true;
    }
    void Update()
    {
        string outputError;
        ValidateEntries(out outputError);
        ErrorLabel.Config.Text = outputError;
    }
    bool ValidateEntries(out string error)
    {
        error = "";
        if (UsernameTextField.Text.Length < 3)
        {
            error = "Username must be atleast 3 characters";
            return false;
        }
        if (PasswordTextField.Text.Length < 6)
        {
            error = "Password must be atleast 6 characters";
            return false;
        }
        if (PasswordTextField.Text.Length > 16)
        {
            error = "Password must be 16 or less characters";
            return false;
        }
        if (UsernameTextField.Text.Length > 16)
        {
            error = "Username must be 16 or less characters";
            return false;
        }
        return true;
    }
    void InitButtons()
    {
        LoginButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(150f, 165f, 370f, 190f),
        }, 1);
        InitButtonDefault(LoginButton, null, null, () => 
        {
            if (ErrorLabel.Config.Text != "")
            {
                LMS_Main.Instance.ShowPopup(1, LMS_GuiBaseLabelBoundaries.WrapText(ErrorLabel.Config.Text, 14, 250f), "Authentication", Color.red);
                return;
            }
            LMS_Main.Instance.ShowPopup(1, "Authentication in progress", "Authentication", Color.gray);
            LMS_Main.Instance.DarkMessageBoxPopup.ShowBackButton(false);
        LMS_TaskManager.RunTaskLater(3, () => { LMS_Main.Instance.DarkMessageBoxPopup.HidePopup(); LMS_SessionServerPeer.Instance.Authenticate(UsernameTextField.Text, PasswordTextField.Text); }, this);
        });
        LoginButton.AllowInput = true;
        DiscordButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(10f, 185f, 340f, 250f),
        }, 1);
        InitButtonDefault(DiscordButton, null, null, () => { LMS_Main.Instance.ShowPopup(0, "Would you like to join\nour discord server?", "Discord Server", Color.blue, (res, popup) => { if (res == E_PopupCallback.YES) Application.OpenURL(LMS_Meta.getMetaValue("DISCORD_URL")); }); });
        DiscordButton.AllowInput = true;
    }
    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.CHROMATIMED);
    }
    void InitButtonDefault(LMS_GuiBaseButton b, string text = "", string title = "", LMS_GuiBaseButton.ClickCallbackDelegate onClick = null)
    {
        b.SetTexture((int)E_Texture.DOWN, m_Skin.button.active.background);
        b.SetTexture((int)E_Texture.IDLE, m_Skin.button.normal.background);
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
}
