using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class LMS_Textures
{
    static Dictionary<string, Texture2D> Cache = new Dictionary<string, Texture2D>();

    public static void AddCache(string s, Texture2D t)
    {
        Cache[s] = t;
    }
    public static Texture2D GetCache(string s)
    {
        return Cache[s];
    }
}
