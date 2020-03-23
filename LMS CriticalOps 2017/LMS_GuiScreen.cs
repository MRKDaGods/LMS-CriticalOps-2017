using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BFlags = System.Reflection.BindingFlags;

public enum E_Screen
{
    MainMenu,
    Automation,
    Esp,
    Themes,
    Authentication,
    Misc,
    Other
}

public enum E_NativeMessage
{
    Awake,
    Start,
    OnGUI,
    Update,
    LateUpdate
}

public abstract class LMS_GuiScreen : MonoBehaviour
{
    public List<LMS_GuiBaseCallback> Children;
    public Dictionary<int, KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>> SelectionIndex;
    IEnumerable<LMS_GuiBaseCallback> m_NonHiddenChildren;
    public LMS_GuiBaseBox2D Owner;
    public bool Visible;
    public LMS_GuiBaseButton VisibilityButton { get { return LMS_Main.Instance.VisibilityButton; } }
    public virtual bool IsPopup { get { return false; } }

    public virtual void HideScreen()
    {
        if (Children != null)
            foreach (LMS_GuiBaseCallback child in Children)
                child.Hidden = true;
        Owner.Hidden = true;
        Visible = false;
    }
    public virtual void ShowScreen()
    {
        if (Children != null)
            foreach (LMS_GuiBaseCallback child in Children)
                child.Hidden = false;
        Owner.Hidden = false;
        Visible = true;
    }
    public virtual bool HitTest(Vector2 evt)
    {
        return true;
    }
    public T InstantiateChild<T>(LMS_GuiConfig config, int memID) where T : LMS_GuiBaseCallback
    {
        if (Children == null)
        {
            Children = new List<LMS_GuiBaseCallback>();
            SelectionIndex = new Dictionary<int, KeyValuePair<LMS_GuiView, LMS_GuiBaseButton>>();
            Debug.Log("Created new Collection -> 'Children'");
        }
        T local = LMS_GuiBaseUtils.InstantiateGUIElement<T>(config, memID, null, true);
        Children.Add(local);
        return local;
    }
    public string ExtractTextFromView(LMS_GuiView view)
    {
        if (view == null)
            return null;
        return view.GetType().GetField("Config", BFlags.Public | BFlags.Instance).GetType().GetField("Text", BFlags.Public | BFlags.Instance).GetRawConstantValue() as string;
    }
    public abstract string ScreenName();
    public abstract E_Screen ScreenType();
}
