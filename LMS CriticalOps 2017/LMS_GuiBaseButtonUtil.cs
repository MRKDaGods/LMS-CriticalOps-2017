using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class LMS_GuiBaseButtonUtil
{
    public static LMS_GuiBaseButton a(LMS_GuiConfig b, int c, UnityEngine.GameObject g, bool hidden)
    {
        return LMS_GuiBaseUtils.InstantiateGUIElement<LMS_GuiBaseButton>(b, c, g, hidden);
    }
}