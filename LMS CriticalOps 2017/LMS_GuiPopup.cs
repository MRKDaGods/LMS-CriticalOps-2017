using System;
using UnityEngine;

public enum E_PopupCallback
{
    YES,
    NO,
    CANCEL,
    OK
}

public delegate void PopupHandler(E_PopupCallback callback, LMS_GuiPopup popup);

public abstract class LMS_GuiPopup : LMS_GuiScreen
{
    PopupHandler m_Handle;
    public override bool IsPopup { get { return true; } }

    public void SetHandle(PopupHandler handle)
    {
        if (handle != null)
            m_Handle = handle;
    }
    public void ShowPopup(bool clearstack = true)
    {
        if (clearstack)
            ClearPopupStack();
        if (!Visible)
            ShowScreen();
        if (LMS_Main.Instance.ActiveScreen.Visible)
            LMS_Main.Instance.ActiveScreen.HideScreen();
    }
    public void HidePopup()
    {
        if (Visible)
            HideScreen();
        OnPopupHiding();
        if (!LMS_Main.Instance.ActiveScreen.Visible)
            LMS_Main.Instance.ActiveScreen.ShowScreen();
    }
    void ClearPopupStack()
    {
        foreach (LMS_GuiPopup p in FindObjectsOfType<LMS_GuiPopup>())
            if (p.Visible)
            {
                p.HandleCallback(p is LMS_GuiPopupMessageBox ? E_PopupCallback.OK : E_PopupCallback.NO);
                p.HidePopup();
            }
    }
    public void HandleCallback(E_PopupCallback callback)
    {
        if (m_Handle != null)
            m_Handle(callback, this);
    }
    public override string ScreenName()
    {
        return PopupName();
    }
    protected virtual void OnPopupHiding()
    {
    }
    public abstract string PopupName();
    public abstract void SetText(string text);
    public abstract void SetTitle(string title);
    public abstract void SetPopupOutlineColor(Color c);
    public override E_Screen ScreenType()
    {
        return E_Screen.Other;
    }
}
