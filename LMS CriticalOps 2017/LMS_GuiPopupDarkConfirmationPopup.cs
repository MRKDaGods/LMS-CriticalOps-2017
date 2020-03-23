using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiPopupDarkConfirmationPopup : LMS_GuiPopup
{
    Color m_Outline = Color.cyan;
    string m_Title, m_Text;
    LMS_GuiBaseLabel Title, Text, YesLabel, NoLabel;
    LMS_GuiBaseButton Yes, No;
    GUISkin m_Skin;

    void Awake()
    {
        m_Skin = LMS_GuiBaseUtils.GetDarkSkin();
        InitLabels();
        InitButtons();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(Screen.width / 2 - 300f, Screen.height / 2 - 200f, 600f, 400f)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, m_Skin.box.normal.background);
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(Title);
        Owner.AddChild(Text);
        Owner.AddChild(Yes);
        Owner.AddChild(YesLabel);
        Owner.AddChild(No);
        Owner.AddChild(NoLabel);
    }
    void InitLabels()
    {
        Text = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(64f, 46f, 431f, 150f),
            Text = "Would you like to join\nour discord server?",
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
        Title = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(10f, 4f, 426f, 151f),
            Text = "Discord Server",
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
        }, 15);
        YesLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(9f, 176f, 387f, 157f),
            Text = "YES",
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
        NoLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(155f, 176f, 387f, 157f),
            Text = "NO",
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
        InitLabelDefault(Text);
        InitLabelDefault(Title);
        InitLabelDefault(YesLabel);
        InitLabelDefault(NoLabel);
        Text.RegisterClientViewTick((view) => { Text.Config.SetText(m_Text); }, null);
        Title.RegisterClientViewTick((view) => { Title.Config.SetText(m_Title); }, null);
    }
    void InitButtons()
    {
        Yes = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(9f, 176f, 387f, 157f)
        }, 93);
        No = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(155f, 176f, 387f, 157f)
        }, 93);
        InitButtonDefault(Yes, null, () => { HandleCallback(E_PopupCallback.YES); HidePopup(); });
        InitButtonDefault(No, null, () => { HandleCallback(E_PopupCallback.NO); HidePopup(); });
        Yes.AllowInput = true;
        No.AllowInput = true;
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
        b.SetTexture((int)E_Texture.DOWN, m_Skin.button.active.background);
        b.SetTexture((int)E_Texture.IDLE, m_Skin.button.normal.background);
        b.BlendMode = E_BlendMode.BLENDED;
        if (!ignoreindexing)
            SelectionIndex[SelectionIndex.Values.Count] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(Details, b);
    }
    public override string PopupName()
    {
        return "Confirmation Dialog" + (this as object).LMS();
    }
    public override void SetText(string text)
    {
        m_Text = text;
    }
    protected override void OnPopupHiding()
    {
        base.OnPopupHiding();
        m_Text = "";
        m_Title = "";
    }
    public override void SetTitle(string title)
    {
        m_Title = title;
    }
    void OnGUI()
    {
        if (Visible)
            GLCanvas.DrawBox(Owner.liveRect, m_Outline, 2f);
    }
    public override void SetPopupOutlineColor(Color c)
    {
        m_Outline = c;
    }
}