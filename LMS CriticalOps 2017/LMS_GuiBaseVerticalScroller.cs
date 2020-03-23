using UnityEngine;
using System.Collections.Generic;

public class LMS_GuiBaseVerticalScroller : LMS_GuiBaseCallback
{
    public int Slots;
    [SerializeField] Texture2D m_DownTexture, m_IdleTexture, m_BackgroundTexture;
    public List<LMS_GuiBaseCallback> CallbackCollection;
#if UNITY_EDITOR
    public int MAXCOUNT;
#endif
    public int state;
    int MAX;
    bool m_Down;
    Vector2 m_DownPos;
    Vector2 m_Axis;
    public Vector2 Axis { get { return m_Axis; } }
    Vector2 m_DrawingAxis;
    List<LMS_GuiBaseCallback> m_Siblings = new List<LMS_GuiBaseCallback>();

    void Start()
    {
        ReloadRenderer = true;
#if UNITY_EDITOR
        MAX = MAXCOUNT;
#else
        MAX = CallbackCollection.Count;
#endif
    }
    void OnGUI()
    {
        if (Hidden)
            return;
        /*Rect desiredRect = new Rect
        {
            x = QuickRect().x,
            y = QuickRect().y + m_DrawingAxis.y,
            width = QuickRect().width,
            height = 100f
        };
        Event e = Event.current;
        if (e.type == EventType.mouseDown)
        {
            if (desiredRect.Contains(e.mousePosition))
            {
                m_Down = true;
                m_DownPos = e.mousePosition;
                LMS_Meta.setMetaValue("VERT_SCROLL_DOWN", "1");
            }
        }
        //GLCanvas.DrawBox(QuickRect(), Color.blue, 2f);
        if (e.type == EventType.mouseDrag)
        {
            if (m_Down)
            {
                LMS_Meta.setMetaValue("VERT_SCROLL_DOWN", "1");
                if (Application.platform == RuntimePlatform.Android)
                    m_DrawingAxis.y -= e.delta.y;
                else m_DrawingAxis.y += e.delta.y;
                float maxAxis = QuickRect().height - QuickRect().y;
                if (m_DrawingAxis.y > maxAxis)
                    m_DrawingAxis.y = maxAxis;
                float minAxis = maxAxis - QuickRect().y;
                if (m_DrawingAxis.y < minAxis)
                    m_DrawingAxis.y = minAxis;
                m_Axis = m_DrawingAxis;
            }
        }
        if (e.type == EventType.mouseUp)
        {
            if (m_Down)
                LMS_Meta.setMetaValue("VERT_SCROLL_DOWN", "0");
            {
                m_Down = false;
                m_DownPos = Vector2.zero;
            }
        }
        GUI.DrawTexture(QuickRect(), m_BackgroundTexture);
        GUI.DrawTexture(desiredRect, m_Down ? m_DownTexture : m_IdleTexture);*/
        if (ReloadRenderer)
        {
            Config.RenderStyle = new GUIStyle(GUI.skin.verticalScrollbar)
            {
                normal =
                {
                    background = m_IdleTexture
                },
                active =
                {
                    background = m_DownTexture
                },
                hover =
                {
                    background = m_BackgroundTexture
                }
            };
            ReloadRenderer = false;
        }
        GUILayout.BeginArea(QuickRect());
        m_Axis = GUILayout.BeginScrollView(m_Axis, Config.RenderStyle);
        GUILayout.Space(QuickRect().height * 2f);
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
    public override void SetTexture(int t, Texture2D tex)
    {
        switch ((E_Texture)t)
        {
            case E_Texture.DOWN:
                m_DownTexture = tex;
                break;
            case E_Texture.IDLE:
                m_IdleTexture = tex;
                break;
            case E_Texture.OTHER:
                m_BackgroundTexture = tex;
                break;
        }
    }
    public void AddSibling(LMS_GuiBaseCallback c)
    {
        c.Sibling = this;
        m_Siblings.Add(c);
    }
}