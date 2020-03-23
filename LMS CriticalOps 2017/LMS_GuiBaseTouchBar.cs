using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum E_Swipe
{
    UP,
    DOWN,
    IDLE
}
public delegate void OnSwipe(E_Swipe swipe);

public class LMS_GuiBaseTouchBar : LMS_GuiBaseCallback
{
    bool mouseDown;
    Vector2 loc;
    Vector2 newOrigin;
    public OnSwipe onSwipe;
    Texture2D m_IdleTex;

    void OnGUI()
    {
        if (Hidden)
            return;
        GUI.DrawTexture(QuickRect(), m_IdleTex);
        if (LMS_GuiBaseUtils.IsConflicting(QuickRect()))
            return;
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            LMS_GuiBaseCallback cb = LMS_GuiBaseUtils.GetElementAt(e.mousePosition);
            if (cb != null && (cb.Hack || cb is LMS_GuiBaseTouchBar))
                if (QuickRect().Contains(e.mousePosition))
                {
                    loc = e.mousePosition;
                    mouseDown = true;
                }
        }
        if (e.type == EventType.MouseDrag)
        {
            if (mouseDown)
                newOrigin = e.mousePosition;
        }
        if (e.type == EventType.MouseUp)
        {
            if (mouseDown)
            {
                if (LMS_Main.Instance.LeftBarOverlay.Owner.liveRect.Contains(e.mousePosition) || LMS_Meta.getMetaValue("VERT_SCROLL_DOWN", "0") == "1")
                    return;
                if (newOrigin == Vector2.zero)
                    onSwipe(E_Swipe.IDLE);
                else if (newOrigin.y > loc.y)
                    onSwipe(E_Swipe.DOWN);
                else if (newOrigin.y < loc.y)
                    onSwipe(E_Swipe.UP);
                mouseDown = false;
            }
            loc = Vector2.zero;
            newOrigin = loc;
        }
    }
    public override void SetTexture(int t, Texture2D tex)
    {
        if (t == (int)E_Texture.IDLE)
            m_IdleTex = tex;
        else Debug.LogError("Wrong Tex!");
    }
}
