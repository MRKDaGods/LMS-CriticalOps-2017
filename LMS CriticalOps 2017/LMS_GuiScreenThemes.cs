using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiScreenThemes : LMS_GuiScreen
{
    Texture2D m_RandTex;
    LMS_ColorThread m_ColorThread;
    LMS_GuiBaseLabel m_Title;
    LMS_GuiBaseButton GEditor, Colors;
    LMS_GuiBaseLabel GEditorLabel, ColorsLabel;

    void Awake()
    {
        m_ColorThread = gameObject.AddComponent<LMS_ColorThread>();
        m_ColorThread.SetInterval(0.5f);
        m_ColorThread.IgnoreOwner = true;
        m_ColorThread.Render = true;
        InitLabels();
        InitButtons();
        Owner = LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseBox2D>(new LMS_GuiConfig()
        {
            Rect = new Rect(Screen.width / 2 - 400f, Screen.height / 2 - 250f, 800f, 500f)
        }, 20000, null);
        Owner.RegisterClientViewTick((view) => 
        {
            Owner.SetTexture((int)E_Texture.IDLE, new Texture2D(1, 1).Modify((tex) => { tex.SetPixel(0, 0, m_ColorThread.RawValue().AlterAlpha(0.7f)); tex.Apply(); }));
        }, null);
        Owner.primary = true;
        Owner.Draggable = true;
        Owner.AddChild(m_Title);
        Owner.AddChild(GEditor);
        Owner.AddChild(GEditorLabel);
        Owner.AddChild(Colors);
        Owner.AddChild(ColorsLabel);
    }
    void InitLabels()
    {
        m_Title = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(170f, 13f, 431f, 150f),
            Text = "GUI Editor",
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
        GEditorLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(78f, 89f, 654f, 239f),
            Text = "Element Editor",
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
        ColorsLabel = InstantiateChild<LMS_GuiBaseLabel>(new LMS_GuiConfig()
        {
            Rect = new Rect(78f, 177f, 654f, 239f),
            Text = "Color Editor",
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
        InitLabelDefault(m_Title);
        InitLabelDefault(GEditorLabel);
        InitLabelDefault(ColorsLabel);
        m_Title.SetFlags("OUTLINE", "EXTRUDE");
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
        GEditor = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(78f, 89f, 654f, 239f)
        }, 9);
        Colors = InstantiateChild<LMS_GuiBaseButton>(new LMS_GuiConfig
        {
            Rect = new Rect(78f, 177f, 654f, 239f)
        }, 9);
        InitButtonDefault(GEditor, null, null, false);
        InitButtonDefault(Colors, null, null, false);
        GEditor.AllowInput = true;
        GEditor.ForceDownState(true);
        GEditor.BlendMode = E_BlendMode.NORMAL;
        Colors.AllowInput = true;
        Colors.ForceDownState(true);
        Colors.BlendMode = E_BlendMode.NORMAL;
    }
    void InitButtonDefault(LMS_GuiBaseButton b, LMS_GuiView Details = null, LMS_GuiBaseButton.ClickCallbackDelegate onClick = null, bool ignoreindexing = false)
    {
        if (onClick != null)
            b.OnClick += onClick;
        b.SetTexture((int)E_Texture.DOWN, b.GeneratePlainTexture(Color.black));
        b.SetTexture((int)E_Texture.IDLE, b.GeneratePlainTexture(Color.clear));
        b.BlendMode = E_BlendMode.BLENDED;
        if (!ignoreindexing)
            SelectionIndex[SelectionIndex.Values.Count] = new KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>(Details, b);
    }
    public override string ScreenName()
    {
        return "Themes";
    }
    public override E_Screen ScreenType()
    {
        return E_Screen.Themes;
    }
}
