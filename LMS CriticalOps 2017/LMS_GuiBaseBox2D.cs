using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum E_Texture
{
    IDLE = 39289728,
    DOWN = 68178312,
    OTHER = 76567829
}

public class LMS_GuiBaseBox2D : LMS_GuiBaseCallback
{
    [SerializeField]
    public Texture2D m_IdleStateTex;
    public Rect liveRect;
    bool m_Down;
    public bool primary;
    public bool Down { get { return m_Down; } }

    void Start()
    {
        liveRect = QuickRect();
        if (FindObjectOfType<LMS_GuiEditor>() != null)
            Draggable = false;
    }
    void OnGUI()
    {
        if (Hidden || m_IdleStateTex == null)
            return;
        if (!canRender)
            return;
        GUI.DrawTexture(primary ? liveRect : QuickRect(), m_IdleStateTex);
        if (!Draggable)
            return;
        Event e = Event.current;
        if (e.type == EventType.MouseDown && liveRect.Contains(e.mousePosition))
            m_Down = true;
        if (e.type == EventType.MouseDrag && m_Down && LMS_Meta.getMetaValue("VERT_SCROLL_DOWN", "0") == "0")
        {
            liveRect.x += e.delta.x;
            if (Application.platform == RuntimePlatform.Android)
                liveRect.y -= e.delta.y;
            else liveRect.y += e.delta.y;
        }
        if (e.type == EventType.MouseUp && m_Down)
            m_Down = false;
    }
    public override string ComponentName()
    {
        return "BOX2D";
    }
    public override void SetTexture(int t, Texture2D tex)
    {
        switch (t)
        {
            case (int)E_Texture.IDLE:
                m_IdleStateTex = tex;
                break;
            default:
                Debug.Log("Attemping to register an unsupported texture, ID:" + t);
                break;
        }
    }
    public override LMS_Txt[] ParserTXT()
    {
        return new LMS_Txt[3] { new LMS_Txt(Convert.ToBase64String(m_IdleStateTex.EncodeToPNG())), null, null };
    }
}
