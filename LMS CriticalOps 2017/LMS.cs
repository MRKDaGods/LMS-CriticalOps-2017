using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

public abstract class EditorCallback
{
    LMS_GuiConfig m_Config;
    LMS_GuiBaseCallback m_cb;

    public EditorCallback(LMS_GuiConfig conf, LMS_GuiBaseCallback cb)
    {
        m_Config = conf;
        m_cb = cb;
    }
    public abstract void Draw();
    public LMS_GuiConfig GetConfig()
    {
        return m_Config;
    }
    public LMS_GuiBaseCallback GetCallbackElement()
    {
        return m_cb;
    }
}

class EditorLabel : EditorCallback
{
    public EditorLabel(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.Label(GetCallbackElement().QuickRect(), GetConfig().Text, GetConfig().RenderStyle);
    }
}

class EditorButton : EditorCallback
{
    public EditorButton(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.DrawTexture(GetCallbackElement().QuickRect(), (GetCallbackElement() as LMS_GuiBaseButton).m_IdleTex);
    }
}

class EditorBox : EditorCallback
{
    public EditorBox(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.DrawTexture(GetCallbackElement().QuickRect(), (GetCallbackElement() as LMS_GuiBaseBox2D).m_IdleStateTex);
    }
}

class EditorProgressBar : EditorCallback
{
    public EditorProgressBar(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.DrawTexture(GetCallbackElement().QuickRect(), LMS_GuiBaseUtils.GetDarkSkin().box.normal.background);
    }
}

class EditorTextField : EditorCallback
{
    public EditorTextField(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.Label(GetCallbackElement().QuickRect(), "|||");
        GUI.DrawTexture(GetCallbackElement().QuickRect(), (GetCallbackElement() as LMS_GuiBaseTextField).m_IdleTex);
    }
}

class EditorToggle : EditorCallback
{
    public EditorToggle(LMS_GuiConfig conf, LMS_GuiBaseCallback cb) : base(conf, cb)
    {
    }

    public override void Draw()
    {
        GUI.Label(GetCallbackElement().QuickRect(), "T");
        GUI.DrawTexture(GetCallbackElement().QuickRect(), LMS_GuiBaseUtils.GetDarkSkin().button.normal.background);
    }
}

class CallbackComparer : IComparer<LMS_GuiBaseCallback>
{
    public int Compare(LMS_GuiBaseCallback x, LMS_GuiBaseCallback y)
    {
        if (x is LMS_GuiBaseLabel || y is LMS_GuiBaseLabel)
            return 1;
        else return -1;
    }
}

public class LMS : EditorWindow
{
    bool Layout;
    Rect DEFRECT = new Rect(5f, 5f, 1280, 520), SDEFRECT = new Rect(5f, 5f, 0f, 0f);
    float ZoomS = 1f;
    LMS_GuiBaseLayout SelectedLayout;
    List<LMS_GuiBaseCallback> CachedOrig = new List<LMS_GuiBaseCallback>();
    List<EditorCallback> DrawBuffer = new List<EditorCallback>();
    EditorCallback SelectedCallback;
    int Mode = 0;
    bool MDown;

    [MenuItem("LMS/GUI Creator")]
    static void Init()
    {
        GetWindow<LMS>().Show();
    }

    void OnEnable()
    {
        List<GameObject> gos = Selection.gameObjects.ToList();
        DrawBuffer = new List<EditorCallback>();
        CachedOrig = new List<LMS_GuiBaseCallback>();
        GameObject[] g = gos.Where(g2 => g2.GetComponent<LMS_GuiBaseLayout>() != null).ToArray();
        if (g.Length > 0)
        {
            Layout = true;
            SelectedLayout = g[0].GetComponent<LMS_GuiBaseLayout>();
            foreach (LMS_GuiBaseCallback cb in SelectedLayout.GetComponentsInChildren<LMS_GuiBaseCallback>())
            {
                CachedOrig.Add(cb);
            }
            CachedOrig.Sort(new CallbackComparer());
            foreach(LMS_GuiBaseCallback cb in CachedOrig)
            {
                switch(cb.ComponentName())
                {
                    case "BOX2D":
                        DrawBuffer.Add(new EditorBox(cb.Config, cb));
                        break;
                    case "BUTTON":
                        DrawBuffer.Add(new EditorButton(cb.Config, cb));
                        break;
                    case "LABEL":
                        DrawBuffer.Add(new EditorLabel(cb.Config, cb));
                        break;
                    case "PROGRESS_BAR":
                        DrawBuffer.Add(new EditorProgressBar(cb.Config, cb));
                        break;
                    case "TEXT_FIELD":
                        DrawBuffer.Add(new EditorTextField(cb.Config, cb));
                        break;
                    case "TOGGLE":
                        DrawBuffer.Add(new EditorToggle(cb.Config, cb));
                        break;
                }
            }
        }
        else { Layout = false; SelectedLayout = null; }
    }

    void OnGUI()
    {
        ProcessTouchEvt();
        if (SelectedCallback != null)
        {
            GLCanvas.DrawBox(SelectedCallback.GetCallbackElement().QuickRect().AddToS(SDEFRECT), Color.blue, 1.3f);
        }
        GUILayout.BeginArea(new Rect(0f, 550f, 1500f, 400f)); 
        EditorGUILayout.LabelField("Zoom");
        ZoomS = EditorGUILayout.Slider(ZoomS, 0f, 2f);
        Rect r = new Rect();
        if (SelectedCallback != null)
        {
            r = SelectedCallback.GetConfig().Rect;
        }
        EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(400f));
        EditorGUILayout.LabelField("Rect (X,Y,W,H)");
        Color col = GUI.color;
        GUI.color = Mode == 0 ? Color.red : col;
        if (GUILayout.Button("Move"))
        {
            Mode = 0;
        }
        GUI.color = Mode == 1 ? Color.red : col;
        if (GUILayout.Button("Resize"))
        {
            Mode = 1;
        }
        GUI.color = Mode == 2 ? Color.red : col;
        if (GUILayout.Button("Scale"))
        {
            Mode = 2;
        }
        GUI.color = col;
        EditorGUILayout.EndHorizontal();
        r.x = EditorGUILayout.Slider(r.x, 0f, DEFRECT.width);
        r.y = EditorGUILayout.Slider(r.y, 0f, DEFRECT.height);
        r.width = EditorGUILayout.Slider(r.width, 0f, DEFRECT.width);
        r.height = EditorGUILayout.Slider(r.height, 0f, DEFRECT.height);
        if (SelectedCallback != null)
        {
            SelectedCallback.GetConfig().Rect = r;
        }
        GUILayout.EndArea();
        Matrix4x4 oM = GUI.matrix;
        Matrix4x4 Trans = Matrix4x4.TRS(new Vector2(0f, 21f), Quaternion.identity, Vector3.one), Sc = Matrix4x4.Scale(new Vector3(ZoomS, ZoomS, 1f));
        GUI.matrix = Trans * Sc * Trans.inverse;
        GUI.skin.label.richText = true;
        DrawGrid();
        GLCanvas.DrawBox(DEFRECT, Color.red, 1.4f);
        if (!Layout)
        {
            GUI.Label(new Rect(540f, 300f, 200f, 40f), "<size=15><b>No Screen Selected</b></size>");
        }
        else
        {
            GUILayout.BeginArea(DEFRECT);
            foreach (EditorCallback ecb in DrawBuffer)
            {
                ecb.Draw();
            }
            GUILayout.EndArea();
            if (SelectedCallback != null)
            {
                DrawTool(SelectedCallback.GetCallbackElement().QuickRect().AddToS(SDEFRECT));
            }
        }
        GUI.matrix = oM;
    }

    void ProcessTouchEvt()
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            EditorCallback ecb = GetElementAt(e.mousePosition);
            if (ecb != null)
                SelectedCallback = ecb;
            MDown = true;
        }
        if (e.type == EventType.MouseDrag)
        {
            if (MDown)
            {
                if (SelectedCallback != null)
                {
                    switch (Mode)
                    {
                        case 1:
                            SelectedCallback.GetConfig().Rect.width += e.delta.x;
                            SelectedCallback.GetConfig().Rect.height += e.delta.y;
                            break;
                        case 0:
                            SelectedCallback.GetConfig().Rect.x += e.delta.x;
                            SelectedCallback.GetConfig().Rect.y += e.delta.y;
                            break;
                        case 2:
                            if (e.delta.x > 1f || e.delta.y > 1f)
                            {
                                SelectedCallback.GetConfig().Rect.width += e.delta.x;
                                SelectedCallback.GetConfig().Rect.height += e.delta.y;
                            }
                            else
                            {
                                SelectedCallback.GetConfig().Rect.width -= e.delta.x;
                                SelectedCallback.GetConfig().Rect.height -= e.delta.y;
                            }
                            break;
                    }
                }
            }
        }
        if (e.type == EventType.MouseUp)
        {
            MDown = false;
        }
    }

    void DrawTool(Rect r)
    {
        switch(Mode)
        {
            case 0:
            case 1:
            case 2:
                GLCanvas.DrawLine(r.center, r.center - new Vector2(0f, 90f), Color.green, 1f);
                GLCanvas.DrawLine(r.center, r.center + new Vector2(90f, 0f), Color.red, 1f);
                break;
        }
    }

    void DrawGrid()
    {
        //we want 20 lines X, 20 Y?? yes
        for (int x = 1; x <= 20; x++)
        {
            float dX = Mathf.Round((1280f / 20f) * x) + 5f;
            GLCanvas.DrawLine(new Vector2(dX, 5f), new Vector2(dX, 525f), Color.gray, 1f);
        }
        for (int y = 1; y <= 20; y++)
        {
            float dY = Mathf.Round((520f / 20f) * y) + 5f;
            GLCanvas.DrawLine(new Vector2(5f, dY), new Vector2(1285f, dY), Color.gray, 1f);
        }
    }

    EditorCallback GetElementAt(Vector2 vec)
    {
        try
        {
            return DrawBuffer.Where(curr => curr.GetCallbackElement().QuickRect().AddToS(SDEFRECT).Contains(vec)).ToArray()[0];
        }
        catch { return null; }
    }
}                  