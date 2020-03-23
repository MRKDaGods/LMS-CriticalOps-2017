#undef LMS_EDIT_MODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;

public static class LMS_GuiBaseUtils
{
    static Dictionary<int, LMS_GuiBaseCallback> Memory = new Dictionary<int, LMS_GuiBaseCallback>();
    static List<int> UsedIDs = new List<int>();
    static GameObject GuiContainer;
    static Dictionary<string, LMS_ModifiedTexture> ModifiedTextures = new Dictionary<string, LMS_ModifiedTexture>();
    static GUISkin DarkSkin;

    /// <summary>
    /// CALL FROM THE MAIN THREAD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="conf"></param>
    /// <returns></returns>
    public static T InstantiateGUIElement<T>(LMS_GuiConfig conf, int memoryID, GameObject g = null, bool hidden = false) where T : LMS_GuiBaseCallback
    {
        int id = GenerateId();
        if (GuiContainer == null)
        {
            GuiContainer = new GameObject("LMS GUI Container");
            #if LMS_EDIT_MODE
#else
            UnityEngine.Object.DontDestroyOnLoad(GuiContainer);
#endif
        }
        GameObject go = new GameObject(typeof(T).Name + id);
        UnityEngine.Object.DontDestroyOnLoad(go);
        T element = go.AddComponent<T>();
        element.Config = conf;
        element.Hidden = hidden;
        Memory[id] = element;
        return element;
    }
    public static T _InstantiateGUIElement<T>(LMS_GuiConfig conf, int memoryID, GameObject g, bool hidden = false) where T : LMS_GuiBaseCallback
    {
        if (Memory.Keys.Contains(memoryID))
        {
            Debug.LogError("Attempting to create an instance of an existing memory id! " + conf.Text);
            return null;
        }
        GameObject guiContainer = g;
        T element = guiContainer.AddComponent<T>();
        element.Config = conf;
        element.Hidden = hidden;
        Memory[memoryID] = element;
#if LMS_EDIT_MODE
#else
        UnityEngine.Object.DontDestroyOnLoad(g);
#endif
        return element;
    }
    public static void DestroyElement(int memoryID)
    {
        LMS_GuiBaseCallback element = Memory[memoryID];
        if (element == null)
        {
            Debug.LogError("Attempting to destroy an unavailable element!");
            return;
        }
        UnityEngine.Object.Destroy(element.gameObject);
        Memory.Remove(1000);
    }
    public static LMS_GuiBaseCallback GetElementAt(Vector2 mousePos)
    {
        try
        {
            return Memory.Values.Where(curr => !curr.Hidden && curr.QuickRect().Contains(mousePos)).ToArray()[0];
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log("LMS Exception Caught!\n" + e.StackTrace);
            return null;
        }
    }
    public static List<LMS_GuiBaseCallback> GetElementsAt(Vector2 mousePos)
    {
        try
        {
            return Memory.Values.Where(curr => !curr.Hidden && curr.QuickRect().Contains(mousePos)).ToList();
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log("LMS Exception Caught!\n" + e.StackTrace);
            return null;
        }
    }
    public static bool IsConflicting(Rect baseRect)
    {
        return Memory.Values.Where(curr => curr.QuickRect().Contains(baseRect)).ToArray().Length > 0;
    }
    public static bool IsConflicting(Vector2 baseRect)
    {
        return Memory.Values.Where(curr => curr.QuickRect().Contains(baseRect)).ToArray().Length > 0;
    }
    public static int GenerateId()
    {
        int id = UnityEngine.Random.Range(0, 100000);
        if (UsedIDs.Contains(id))
            return GenerateId();
        UsedIDs.Add(id);
        return id;
    }
    public static void PreparePopup(LMS_GuiPopup popup, string text, string title, Color c, PopupHandler handler = null)
    {
        popup.SetText(text);
        popup.SetTitle(title);
        popup.SetPopupOutlineColor(c);
        popup.SetHandle(handler);
    }
    public static void ModifiedTexture(string interTex, out LMS_ModifiedTexture tex)
    {
        tex = null;
        if (ModifiedTextures.ContainsKey(interTex))
            tex = ModifiedTextures[interTex];
        LMS_ModifiedTexture[] modTex = UnityEngine.Object.FindObjectsOfType<LMS_ModifiedTexture>().Where(ch => ch.MainModifier == interTex).ToArray();
        if (modTex.Length > 0)
        {
            tex = modTex[0];
            ModifiedTextures[interTex] = modTex[0];
        }
    }
    public static Texture2D NextGrade(Texture2D curr)
    {
        Color cons = curr.GetPixel(0, 0);
        float res = DoubleConGrade(cons.r);
        return GeneratePlainTexture(res, res, res, cons.a);
    }
    public static Texture2D PreviousGrade(Texture2D curr)
    {
        Color cons = curr.GetPixel(0, 0);
        float res = DeDoubleConGrade(cons.r);
        return GeneratePlainTexture(res, res, res, cons.a);
    }
    static float DeDoubleConGrade(float grade, bool even = false)
    {
        if (even && (grade * 255f) % 2 != 0)
            return 0f;
        return ((grade * 255f) - ((grade * 255f) / 2f)) / 255f;
    }
    static float DoubleConGrade(float grade, bool even = false)
    {
        if (even && (grade * 255f) % 2 != 0)
            return 0f;
        return ((grade * 255f) * 2f) / 255f;
    }
    public static GUISkin GetDarkSkin()
    {
        if (DarkSkin != null)
            return DarkSkin;
        DarkSkin = ScriptableObject.CreateInstance<GUISkin>();
        DarkSkin.box.normal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.box.onNormal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.box.active.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.box.onActive.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.window.normal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.window.onNormal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.window.active.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.window.onActive.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
        DarkSkin.button.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        DarkSkin.button.onNormal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        DarkSkin.button.active.background = GeneratePlainTexture(0.3254901960784314f, 0.3254901960784314f, 0.3254901960784314f, 1f);
        DarkSkin.button.onActive.background = GeneratePlainTexture(0.3254901960784314f, 0.3254901960784314f, 0.3254901960784314f, 1f);
        DarkSkin.button.fontSize = 16;
        DarkSkin.button.alignment = TextAnchor.MiddleCenter;
        DarkSkin.button.fixedHeight = 25f;
        DarkSkin.button.normal.textColor = Color.white;
        DarkSkin.label.normal.textColor = Color.white;
        DarkSkin.label.fontStyle = FontStyle.Bold;
        DarkSkin.label.alignment = TextAnchor.MiddleCenter;
        DarkSkin.horizontalSlider.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        DarkSkin.horizontalSliderThumb.normal.background = GeneratePlainTexture(0f, 0f, 1f, 0.6f);
        DarkSkin.horizontalSlider.alignment = TextAnchor.MiddleCenter;
        DarkSkin.horizontalSlider.fixedHeight = 10f;
        DarkSkin.horizontalSliderThumb.fixedWidth = 15f;
        DarkSkin.horizontalSliderThumb.fixedHeight = 9f;
        DarkSkin.textField.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
        return DarkSkin;
    }
    static Texture2D GeneratePlainTexture(float r, float g, float b, float a, int w = 1, int h = 1)
    {
        Texture2D t = new Texture2D(w, h);
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                t.SetPixel(i, j, new Color(r, g, b, a));
            }
        }
        t.Apply();
        return t;
    }
    public static float CalculateTitleXAxis(float width)
    {
        return width * 0.1573529411764706f;
    }
    public static Color StringToColor(string s)
    {
        PropertyInfo colF = typeof(Color).GetProperty(s, BindingFlags.Public | BindingFlags.Static);
        if (colF != null)
        {
            return (Color)colF.GetGetMethod().Invoke(null, new object[0]);
        }
        else
        {
            int parX = s.IndexOf('('), parY = s.IndexOf(')');
            if (parX != -1 && parY != -1)
            {
                string[] nums = s.Substring(parX + 1, parY - parX - 1).Split(',');
                if (nums.Length == 3)
                {
                    try
                    {
                        return new Color(float.Parse(nums[0]), float.Parse(nums[1]), float.Parse(nums[2]));
                    }
                    catch (Exception e) { Debug.Log(e.Message); }
                }
            }
        }
        return Color.clear;
    }

    public static List<Vector2> ClearPoints16x16 = new List<Vector2>()
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(2, 0),
            new Vector2(3, 0),
            new Vector2(4, 0),
            new Vector2(5, 0),
            new Vector2(6, 0),
            new Vector2(7, 0),
            new Vector2(8, 0),
            new Vector2(9, 0),
            new Vector2(10, 0),
            new Vector2(11, 0),
            new Vector2(12, 0),
            new Vector2(13, 0),
            new Vector2(14, 0),
            new Vector2(15, 0),
            new Vector2(0, 1),
            new Vector2(0, 2),
            new Vector2(0, 3),
            new Vector2(0, 4),
            new Vector2(0, 5),
            new Vector2(0, 6),
            new Vector2(0, 7),
            new Vector2(0, 8),
            new Vector2(0, 9),
            new Vector2(0, 10),
            new Vector2(0, 11),
            new Vector2(0, 12),
            new Vector2(0, 13),
            new Vector2(0, 14),
            new Vector2(0, 15),
            new Vector2(1, 15),
            new Vector2(2, 15),
            new Vector2(3, 15),
            new Vector2(4, 15),
            new Vector2(5, 15),
            new Vector2(6, 15),
            new Vector2(7, 15),
            new Vector2(8, 15),
            new Vector2(9, 15),
            new Vector2(10, 15),
            new Vector2(11, 15),
            new Vector2(12, 15),
            new Vector2(13, 15),
            new Vector2(14, 15),
            new Vector2(15, 1),
            new Vector2(15, 2),
            new Vector2(15, 3),
            new Vector2(15, 4),
            new Vector2(15, 5),
            new Vector2(15, 6),
            new Vector2(15, 7),
            new Vector2(15, 8),
            new Vector2(15, 9),
            new Vector2(15, 10),
            new Vector2(15, 11),
            new Vector2(15, 12),
            new Vector2(15, 13),
            new Vector2(15, 14),
            new Vector2(15, 15),
            new Vector2(1, 12),
            new Vector2(1, 13),
            new Vector2(1, 14),
            new Vector2(2, 13),
            new Vector2(2, 14),
            new Vector2(3, 14),
            new Vector2(14, 12),
            new Vector2(13, 13),
            new Vector2(14, 13),
            new Vector2(12, 14),
            new Vector2(13, 14),
            new Vector2(14, 14),
            new Vector2(1, 1),
            new Vector2(2, 1),
            new Vector2(3, 1),
            new Vector2(1, 2),
            new Vector2(2, 2),
            new Vector2(1, 3),
            new Vector2(12, 1),
            new Vector2(13, 1),
            new Vector2(14, 1),
            new Vector2(13, 2),
            new Vector2(14, 2),
            new Vector2(14, 3)
        };
}