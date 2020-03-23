using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiBaseOverlayLeftBar : LMS_GuiBaseOverlay
{
    LMS_GuiBaseLabel LoggedInAs;
    LMS_GuiBaseLabel[] Msgs;
    LMS_GuiBaseButton SendButton;
    LMS_GuiBaseTextField MsgTextField;
    LMS_GuiBaseLabel MsgTextFieldRenderer, SendButtonLabel;

    void Awake()
    {
        InitLabels();
        InitButtons();
        InitOverlays();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(0f, 0f, 500f, Screen.height)
        }, 20000, null);
        Owner.SetTexture((int)E_Texture.IDLE, LMS_Textures.GetCache("OVERLAY_BACK_TEX"));
        Owner.primary = true;
        Owner.AddChild(LoggedInAs);
        Msgs.Loop(curr => Owner.AddChild(curr));
        Owner.AddChild(SendButton);
        Owner.AddChild(SendButtonLabel);
        Owner.AddChild(MsgTextField);
        Owner.AddChild(MsgTextFieldRenderer);
    }
    void InitLabels()
    {
        LoggedInAs = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(0f, 68f, 500f, 134f),
            Text = "",
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
        Msgs = new LMS_GuiBaseLabel[8];
        float ypos = 1f;
        for (int i = 0; i < Msgs.Length; i++)
        {
            LMS_GuiBaseLabel lab = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
            {
                Rect = new Rect(30f, 60f + ypos * 50f, 500f, 134f),
                Text = "",
                RenderStyle = new GUIStyle
                {
                    fontSize = 14,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleLeft
                }
            }, 15);
            lab.Constraints["viewtick"] = (int)ypos;
            lab.RegisterClientViewTick((view) =>
            {
                try
                {
                    List<LMS_Chat.ChatMsg> msg = LMS_SessionServerPeer.Instance.Chat.Messages;
                    LMS_Chat.ChatMsg m = msg[msg.Count - lab.Constraints["viewtick"]];
                    lab.Config.RenderStyle.normal.textColor = LMS_SessionServerPeer.Instance.Chat[m.Type];
                    lab.Config.Text = LMS_GuiBaseLabelBoundaries.WrapText(LMS_Chat.FixedName(m.Prefix, m.User) + ' ' + m.Text, 16, 400f);
                }
                catch { lab.Config.Text = ""; }
            }, null);
            ypos++;
            InitLabelDefault(lab);
            lab.SetRenderMode(E_ColorFlags.FIXED);
            Msgs[i] = lab;
        }
        SendButtonLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(30f, 530f, 431f, 150f),
            Text = "Send Message",
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
        MsgTextFieldRenderer = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(30f, 495f, 431f, 150f),
            Text = "",
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
        InitLabelDefault(LoggedInAs);
        InitLabelDefault(SendButtonLabel);
        InitLabelDefault(MsgTextFieldRenderer);
        LoggedInAs.RegisterClientViewTick((view) => { LoggedInAs.Config.SetText(LMS_SessionServerPeer.Instance.Peer == null ? "dank memes kid" : "Logged in as " + LMS_SessionServerPeer.Instance.Peer.user); }, null);
        MsgTextFieldRenderer.RegisterClientViewTick((view) => { MsgTextFieldRenderer.Config.Text = MsgTextField.TextToRender; }, null);
    }
    void InitButtons()
    {
        SendButton = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig()
        {
            Rect = new Rect(30f, 530f, 431f, 150f)
        }, 50);
        InitButtonDefault(SendButton, null, () => { LMS_SessionServerPeer.Instance.SendChatMessage(LMS_Chat.ChatMsg.Create(MsgTextField.TextToRender, "", LMS_SessionServerPeer.Instance.Peer.user, LMS_SessionServerPeer.Instance.Peer.accesslevel)); MsgTextField.Text = ""; });
    }
    void InitOverlays()
    {
        MsgTextField = InstantiateChild<LMS_GuiBaseTextField>(new LMS_GuiConfig
        {
            Rect = new Rect(30f, 495f, 431f, 150f)
        }, 93);
        MsgTextField.SetValidation(E_Validation.ALPHA_NUMERIC);
        MsgTextField.SetTexture((int)E_Texture.IDLE, MsgTextField.GeneratePlainTexture(Color.green.AlterAlpha(0.4f)));
        MsgTextField.UseRelativeRect = true;
        MsgTextField.Hidden = false;
    }
    void InitButtonDefault(LMS_GuiBaseButton b, LMS_GuiView Details = null, LMS_GuiBaseButton.ClickCallbackDelegate onClick = null, bool ignoreindexing = false)
    {
        if (onClick != null)
            b.OnClick += onClick;
        b.SetTexture((int)E_Texture.DOWN, b.GeneratePlainTexture(new Color(200f / 255f, 220f / 255f, 35f / 255f, 1f)));
        b.SetTexture((int)E_Texture.IDLE, b.GeneratePlainTexture(Color.green));
        b.AllowInput = true;
        b.Hidden = false;
        if (!ignoreindexing)
            SelectionIndex[SelectionIndex.Values.Count] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(Details, b);
    }
    void InitLabelDefault(LMS_GuiBaseLabel l)
    {
        l.UseRelativeRect = true;
        l.SetInterval("0.5 + 0.5");
        l.SetFlags("EXTRUDE");
        l.SetRenderMode(E_ColorFlags.CHROMATIMED);
        l.Hidden = false;
    }
    public override string OverlayName()
    {
        return "LeftBar Overlay " + (this as object).LMS();
    }
    public override E_Overlay OverlayType()
    {
        return E_Overlay.Left;
    }
}
