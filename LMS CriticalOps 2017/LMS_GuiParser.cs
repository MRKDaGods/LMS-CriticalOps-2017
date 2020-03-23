using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using LitJson;

public class LMS_GuiParser
{
    public static LMS_GuiBaseCallback Parse(string str)
    {
        {
            LMS_GuiParserOptions options = JsonMapper.ToObject<LMS_GuiParserOptions>(str);
            System.IO.File.WriteAllText("C:\\js.txt", options.idle.GetText());
            //Debug.Log(str);
        }
        //catch (Exception e ){ Debug.LogError(e.Message); }
        return null;
    }
}
public class LMS_GuiParserOptions
{
    public string type;
    public bool relativefontsize;
    public bool draggable;
    public bool userelativerect;
    public string sibling;
    public string parent;
    public bool needplus;
    public bool canrender;
    public bool hack;
    public bool customlock;
    public bool hidden;
    public string clientviewtick; //lms code is inserted here
    public string children;
    public string objname;
    public int x, y, w, h;
    public string text;
    public GUIStyle style;
    public LMS_Txt idle, down, other;
}
