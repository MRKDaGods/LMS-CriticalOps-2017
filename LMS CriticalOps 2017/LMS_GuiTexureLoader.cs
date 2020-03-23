using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class LMS_GuiTexureLoader
{
    public static void LoadTexture(string bytes, out Texture2D tex)
    {
        Texture2D t = new Texture2D(Screen.width, Screen.height);
        t.LoadImage(Convert.FromBase64String(bytes));
        tex = t;
    }
}
