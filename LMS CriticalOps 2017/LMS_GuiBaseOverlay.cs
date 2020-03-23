using System;
using System.Collections;
using UnityEngine;

public enum E_Overlay
{
    Left,
    Right,
    Top,
    Bottom
}

public abstract class LMS_GuiBaseOverlay : LMS_GuiScreen
{
    public void ShowOverlay(bool clearstack = false)
    {
        Owner.Hidden = false;
        Visible = true;
        if (clearstack)
            ClearOverlayStack();
    }
    void ClearOverlayStack()
    {
        foreach (LMS_GuiBaseOverlay overlay in FindObjectsOfType<LMS_GuiBaseOverlay>())
            if (OverlayName() != overlay.ScreenName())
                overlay.HideOverlay();
    }
    public void HideOverlay()
    {
        Visible = false;
    }
    void OnGUI()
    {
        float posX = OverlayType() == E_Overlay.Left ? Visible ? 0f : 0f - Owner.Config.Rect.width : 0f;
        Owner.liveRect.x = Mathf.MoveTowards(Owner.liveRect.x, posX, 2f);
    }
    IEnumerator UpdateHideInterpolation()
    {
        float posX = 0f - Owner.Config.Rect.width;
        while (Owner.Config.Rect.x != posX)
        {
            yield return new WaitForSeconds(0.3f);
            Owner.Config.Rect.x = Mathf.MoveTowards(Owner.Config.Rect.x, posX, 10f);
        }
    }
    IEnumerator UpdateShowInterpolation()
    {
        float posX = 0f;
        while (Owner.Config.Rect.x != posX)
        {
            yield return new WaitForSeconds(0.3f);
            Owner.Config.Rect.x = Mathf.MoveTowards(Owner.Config.Rect.x, posX, 10f);
        }
        yield return new WaitForEndOfFrame();
    }
    public override string ScreenName()
    {
        return OverlayName();
    }
    public abstract string OverlayName();
    public abstract E_Overlay OverlayType();
    public override E_Screen ScreenType()
    {
        return E_Screen.Other;
    }
}
