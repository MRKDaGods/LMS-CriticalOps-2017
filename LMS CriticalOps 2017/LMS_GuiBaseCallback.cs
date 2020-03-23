using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public delegate void LoopCallback<T>(T curr);
public delegate void TextureModificationCallback(Texture2D t);

public static class LMSExtensions
{
    static Dictionary<object, int> InstanceTable = new Dictionary<object, int>();
    static int InstanceModifier = 2;

    public static Rect AddTo(this Rect r1, Rect r2)
    {
        return new Rect
        {
            x = r1.x + r2.x,
            y = r1.y + r2.y,
            width = r2.width,
            height = r2.height
        };
    }
    public static Rect AddToS(this Rect r1, Rect r2)
    {
        return new Rect
        {
            x = r1.x + r2.x,
            y = r1.y + r2.y,
            width = r1.width,
            height = r1.height
        };
    }
    public static bool Contains(this Rect self, Rect rect) 
    {
         return self.Contains(new Vector2(rect.xMin, rect.yMin)) && self.Contains(new Vector2(rect.xMax, rect.yMax)); 
    }
    public static Color AlterAlpha(this Color c, float newAlpha)
    {
        return new Color(c.r, c.g, c.b, newAlpha);
    }
    public static string GetTill(this string str, string to)
    {
        try
        {
            int startIndex = str.IndexOf(str[str.Length - 1]);
            return str + str.Substring(startIndex, (str.LastIndexOf(to) + to.Length) - startIndex);
        }
        catch (Exception)
        {}
        return "";
    }
    public static string LMS_Replace(this string str, string oldVal, string newVal)
    {
        if (oldVal == "")
            return str;
        return str.Replace(oldVal, newVal);
    }
    public static void Loop<T>(this IEnumerator<T> collection, LoopCallback<T> callback)
    {
        while (collection.MoveNext())
        {
            callback(collection.Current);
        }
    }
    public static void Loop<T>(this IEnumerable<T> collection, LoopCallback<T> callback)
    {
        IEnumerator<T> e = collection.GetEnumerator();
        while (e.MoveNext())
        {
            callback(e.Current);
        }
    }
    public static void SuppressTriplet<K, V, T>(this TripleValPair<K, V, T> inTr, out KeyValuePair<K, V> pair)
    {
        pair = new KeyValuePair<K, V>(inTr.Key, inTr.Value);
    }
    public static void ArraySuppressTriplet<K, V, T>(this TripleValPair<K, V, T>[] inTr, out KeyValuePair<K, V>[] outpair)
    {
        List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
        foreach (TripleValPair<K, V, T> pair in inTr)
            list.Add(new KeyValuePair<K, V>(pair.Key, pair.Value));
        outpair = list.ToArray();
    }
    public static Texture2D Circlify(this Texture2D tex)
    {
        //we wanna knw which pixels we r going to set to clear
        if (tex.width != 16 && tex.height != 16)
        {
            Debug.LogWarning("Circlify :: Unsupported size");
            return tex;
        }
        for (int i = 0; i < tex.width; i++)
        {
            for (int j = 0; j < tex.height; j++)
            {
                if (LMS_GuiBaseUtils.ClearPoints16x16.Contains(new Vector2(i, j)))
                    tex.SetPixel(i, j, Color.clear);
            }
        }
        tex.Apply();
        return tex;
    }
    public static Texture2D Modify(this Texture2D tex, TextureModificationCallback callback)
    {
        callback(tex);
        return tex;
    }
    public static int LMS(this object o)
    {
        if (InstanceTable.ContainsKey(o))
            return InstanceTable[o];
        InstanceTable[o] = InstanceModifier++;
        return InstanceTable[o];
    }
}

public abstract class LMS_GuiBaseCallback : MonoBehaviour
{
    public LMS_GuiConfig Config;
    public bool RelativeFontSize;
    public bool Draggable;
    public bool UseRelativeRect;
    public LMS_GuiBaseCallback Parent, Sibling;
    public bool ReloadRenderer;
    bool m_Hidden;
    public bool Hidden { get { return m_Hidden; } set { m_CustomLock = value; m_Hidden = value; } }
    public List<LMS_GuiBaseCallback> Children;
    bool needPlus;
    public bool canRender = true;
    public bool Hack;
    bool m_GUIEditorActive;
    GuiViewClientTick m_ClientViewTick;
    public Dictionary<string, int> Constraints = new Dictionary<string, int>();
    public bool IsGUIEditorActive { get { return m_GUIEditorActive; } }
    LMS_GuiView m_AttachedView;
    bool m_CustomLock;

    void Awake()
    {
        if (Config == null)
        {
            Config = new LMS_GuiConfig();
            needPlus = true;
        }
        RelativeFontSize = true;
        UseRelativeRect = true;
        if (Children == null)
            Children = new List<LMS_GuiBaseCallback>();
        m_GUIEditorActive = FindObjectOfType<LMS_GuiEditor>() != null;
    }
    void OnGUI()
    {
        if (needPlus)
        {
            Config.Inst();
            needPlus = false;
        }
        if (RelativeFontSize)
            Config.RenderStyle.fontSize = ((Screen.height / 26) * 2) / 3;
    }
    public Rect RelativeRect()
    {
        Rect m_Rect = Config.Rect;
        Rect t = Parent != null ? (Parent as LMS_GuiBaseBox2D).liveRect : new Rect();
        if (Sibling != null)
        {
            if (Sibling is LMS_GuiBaseVerticalScroller)
                t.y += (Sibling as LMS_GuiBaseVerticalScroller).Axis.y;
        }
        float fw = m_Rect.width / 800;
        float rw = fw * m_Rect.width;
        float fh = m_Rect.height / 600;
        float rh = fh * m_Rect.height;
        float finalX = (m_Rect.x / 800f) * Screen.width;
        float finalY = (m_Rect.y / 600f) * Screen.height;
        return new Rect(finalX + t.x, finalY + t.y, rw, rh); 
    }
    public LMS_GuiParserOptions GetParserOptions()
    {
        return new LMS_GuiParserOptions {
            canrender = canRender,
            children = LitJson.JsonMapper.ToJson(Children),
            clientviewtick = "Debug.Log(\"MRK\");",
            customlock = m_CustomLock,
            draggable = Draggable,
            hack = Hack,
            hidden = m_Hidden,
            needplus = needPlus,
            objname = name,
            parent = Parent != null ? Parent.name : "",
            relativefontsize = RelativeFontSize,
            sibling = Sibling != null ? Sibling.name : "",
            type = ComponentName(),
            userelativerect = UseRelativeRect,
            x = (int)Config.Rect.x,
            y = (int)Config.Rect.y,
            w = (int)Config.Rect.width,
            h = (int)Config.Rect.height,
            text = Config.Text,
            style = Config.RenderStyle,
            idle = ParserTXT()[0],
            down = ParserTXT()[1],
            other = ParserTXT()[2]
        };
    }
    public virtual LMS_Txt[] ParserTXT()
    {
        return new LMS_Txt[3] { null, null, null };
    }
    public Rect PayloadRect()
    {
        Rect ret = Config.Rect;
        if (Parent != null)
        {
            ret = ret.AddTo((Parent as LMS_GuiBaseBox2D).liveRect);
            ret.height = Config.Rect.height;
            ret.width = Config.Rect.width;
        }
        if (Sibling != null)
        {
            if (Sibling is LMS_GuiBaseVerticalScroller)
                ret.y += (Sibling as LMS_GuiBaseVerticalScroller).Axis.y;
        }
        return ret;
    }
    public virtual string ComponentName()
    {
        return "Callback Handler";
    }
    public Rect QuickRect()
    {
        return UseRelativeRect ? RelativeRect() : PayloadRect();
    }
    void LateUpdate()
    {
        if (m_ClientViewTick != null)
            m_ClientViewTick(m_AttachedView);
        //UpdateElementVisiblity();
    }
    public void RegisterClientViewTick(GuiViewClientTick tick, LMS_GuiView Owner)
    {
        m_ClientViewTick = tick;
        m_AttachedView = Owner;
    }
    public abstract void SetTexture(int t, Texture2D tex);
    public Texture2D GeneratePlainTexture(Color c, int w = 1, int h = 1)
    {
        Texture2D t = new Texture2D(w, h);
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                t.SetPixel(i, j, c);
            }
        }
        t.Apply();
        return t;
    }
    public void RemoveChild(LMS_GuiBaseCallback cb)
    {
        if (Children.Contains(cb))
            Children.Remove(cb);
    }
    void UpdateElementVisiblity()
    {
        if (m_CustomLock)
            return;
        if (Sibling == null)
            return;
        Rect targetRect = Sibling.QuickRect();
        if (Sibling is LMS_GuiBaseVerticalScroller)
            m_Hidden = QuickRect().y > targetRect.y;
    }
    public void AddChild(LMS_GuiBaseCallback e)
    {
        Children.Add(e);
        e.Parent = this;
    }
    public string HexColor(Color32 inCol)
    {
        return inCol.r.ToString("X2") + inCol.g.ToString("X2") + inCol.b.ToString("X2");
    }
    public LMS_GuiBaseCallback this[int idx]
    {
        get
        {
            if (Children.Count - 1 < idx)
                return null;
            return Children[idx];
        }
    }
}
