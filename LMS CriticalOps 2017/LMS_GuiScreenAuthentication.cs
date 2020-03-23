using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenAuthentication : LMS_GuiScreen
{
    LMS_GuiBaseLabel Title, SubTitle, UserLabel, PassLabel, UserTextFieldRenderer, PassTextFieldRenderer, LoginButtonLabel, PurchaseButtonLabel;
    LMS_GuiBaseTextField UserTextField, PassTextField;
    LMS_GuiBaseButton LoginButton, PurchaseButton;

    void Awake()
    {
        InitLabels();
        InitButtons();
        InitOverlays();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(Screen.width / 2 - 400f, Screen.height / 2 - 250f, 800f, 500f)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("AUTH_BACK_TEX"));
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(Title);
        Owner.AddChild(SubTitle);
        Owner.AddChild(UserLabel);
        Owner.AddChild(PassLabel);
        Owner.AddChild(UserTextFieldRenderer);
        Owner.AddChild(PassTextFieldRenderer);
        Owner.AddChild(UserTextField);
        Owner.AddChild(PassTextField);
        Owner.AddChild(LoginButton);
        Owner.AddChild(LoginButtonLabel);
        Owner.AddChild(PurchaseButton);
        Owner.AddChild(PurchaseButtonLabel);
    }
    void InitLabels()
    {
        Title = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(170f, 13f, 431f, 150f),
            Text = "Authentication",
            RenderStyle = new GUIStyle
            {
                fontSize = 23,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 15);
        SubTitle = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(171f, 63f, 431f, 150f),
            Text = "Please fill out the required fields below\nIf you aren't an LMS Hack subscriber,\nyou cannot use the hack!",
            RenderStyle = new GUIStyle
            {
                fontSize = 19,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 15);
        UserLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(171f, 141f, 431f, 150f),
            Text = "Username",
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
        PassLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(171f, 201f, 431f, 150f),
            Text = "Password",
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
        UserTextFieldRenderer = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(165f, 174f, 452f, 134f),
            Text = "",
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
        PassTextFieldRenderer = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(165f, 235f, 452f, 134f),
            Text = "",
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
        LoginButtonLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(165f, 295f, 452f, 154f),
            Text = "Login",
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
        PurchaseButtonLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(363f, 125f, 402f, 374f),
            Text = "Don't own the\nhack?\nJoin our discord\nto purchase it!",
            RenderStyle = new GUIStyle
            {
                fontSize = 21,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                normal =
                {
                    textColor = Color.cyan
                }
            }
        }, 15);
        InitLabelDefault(Title);
        InitLabelDefault(SubTitle);
        InitLabelDefault(UserLabel);
        InitLabelDefault(PassLabel);
        InitLabelDefault(UserTextFieldRenderer);
        InitLabelDefault(PassTextFieldRenderer);
        InitLabelDefault(LoginButtonLabel);
        InitLabelDefault(PurchaseButtonLabel);
        Title.SetRenderMode(E_ColorFlags.FIXED);
        SubTitle.SetRenderMode(E_ColorFlags.FIXED);
        UserLabel.SetRenderMode(E_ColorFlags.CHROMA);
        PassLabel.SetRenderMode(E_ColorFlags.CHROMA);
        UserTextFieldRenderer.SetRenderMode(E_ColorFlags.FIXED);
        PassTextFieldRenderer.SetRenderMode(E_ColorFlags.FIXED);
        UserTextFieldRenderer.RegisterClientViewTick((view) => UserTextFieldRenderer.Config.Text = UserTextField.TextToRender, null);
        PassTextFieldRenderer.RegisterClientViewTick((view) => PassTextFieldRenderer.Config.Text = PassTextField.TextToRender, null);
        LoginButtonLabel.Disable = true;
    }
    void InitOverlays()
    {
        UserTextField = InstantiateChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(165f, 174f, 452f, 134f)
        }, 93);
        PassTextField = InstantiateChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(165f, 235f, 452f, 134f)
        }, 93);
        UserTextField.SetValidation(E_Validation.ALPHA_NUMERIC);
        UserTextField.SetTexture((int)E_Texture.IDLE, UserTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        UserTextField.UseRelativeRect = true;
        PassTextField.SetValidation(E_Validation.ALPHA_NUMERIC);
        PassTextField.SetTexture((int)E_Texture.IDLE, PassTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        PassTextField.UseRelativeRect = true;
        PassTextField.Password = true;
        PassTextField.OnTextChanged += (ntext) => 
        {
            if (ntext.Length >= 8 && UserTextField.TextToRender.Length >= 6)
            {
                LoginButton.Hidden = false;
                LoginButtonLabel.Disable = false;
            }
            else
            {
                LoginButton.Hidden = true;
                LoginButtonLabel.Disable = true;
            }
        };
        UserTextField.OnTextChanged += (ntext) =>
        {
            if (ntext.Length >= 6 && PassTextField.TextToRender.Length >= 8)
            {
                LoginButton.Hidden = false;
                LoginButtonLabel.Disable = false;
            }
            else
            {
                LoginButton.Hidden = true;
                LoginButtonLabel.Disable = true;
            }
        };
    }
    void InitButtons()
    {
        LoginButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(165f, 295f, 452f, 154f)
        }, 93);
        PurchaseButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(363f, 125f, 402f, 374f)
        }, 93);
        LoginButton.SetTexture((int)E_Texture.IDLE, LoginButton.GeneratePlainTexture(new Color(200f / 255f, 220f / 255f, 35f / 255f, 0.3f)));
        LoginButton.SetTexture((int)E_Texture.DOWN, LoginButton.GeneratePlainTexture(new Color(200f / 255f, 220f / 255f, 35f / 255f, 1f)));
        LoginButton.AllowInput = true;
        LoginButton.Hidden = true;
        LoginButton.OnClick += () => { LMS_SessionServerPeer.Instance.Authenticate(UserTextField.Text, PassTextField.Text); };
        PurchaseButton.SetTexture((int)E_Texture.IDLE, PurchaseButton.GeneratePlainTexture(Color.clear));
        PurchaseButton.SetTexture((int)E_Texture.DOWN, PurchaseButton.GeneratePlainTexture(Color.blue.AlterAlpha(0.8f)));
        PurchaseButton.AllowInput = true;
        PurchaseButton.OnClick += () => { LMS_Main.Instance.ShowPopup(0, "Would you like to join\nour discord server?", "Discord Server", Color.blue, (res, popup) => { if (res == E_PopupCallback.YES) Application.OpenURL(LMS_Meta.getMetaValue("DISCORD_URL")); }); };
    }
    void OnGUI()
    {
        if (!PurchaseButton.Hidden)
            GLCanvas.DrawBox(PurchaseButton.QuickRect(), Color.cyan, 2f);
    }
    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.CHROMATIMED);
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
    public override string ScreenName()
    {
        return "Authentication";
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Authentication;
    }
}
