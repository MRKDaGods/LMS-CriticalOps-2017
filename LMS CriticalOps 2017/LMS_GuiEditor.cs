using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class LMS_GuiEditor : MonoBehaviour
{
    bool MouseDown;
    LMS_GuiBaseCallback selected;
    List<string> selectedElements = new List<string>();
    string mode = "move";
    float lastScrollerUpdate;

    void OnGUI()
    {
        if (GUILayout.Button("MOVE"))
            mode = "move";
        if (GUILayout.Button("RESIZE"))
            mode = "resize";
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            LMS_GuiBaseCallback callback = LMS_GuiBaseUtils.GetElementAt(e.mousePosition);
            if (callback != null)
            {
                selected = callback;
                MouseDown = true;
            }
        }
        else if (e.type == EventType.MouseUp)
        {
            if (MouseDown)
            {
                selectedElements.Add(selected.GetType().ToString() + " RECT=" + selected.Config.Rect.ToString());
                MouseDown = false;
            }
        }
        else if (e.type == EventType.MouseDrag)
        {
            if (MouseDown)
            {
                if (mode == "move")
                {
                    selected.Config.Rect.x += e.delta.x;
                    selected.Config.Rect.y += e.delta.y;
                } else
                {
                    selected.Config.Rect.width += e.delta.x;
                    selected.Config.Rect.height += e.delta.y;
                }
            }
        }
        /*if (lastScrollerUpdate + 3f < Time.timeSinceLevelLoad)
        {
            selected = FindObjectsOfType<LMS_GuiBaseVerticalScroller>().Where(c => !c.Hidden).ToArray()[0];
            lastScrollerUpdate = Time.timeSinceLevelLoad;
        }*/
        if (selected != null)
        {
            GLCanvas.DrawBox(selected.QuickRect(), Color.green, 2f);
        }
    }
    void OnDestroy()
    {
        File.WriteAllLines(string.Format(@"C:\Users\{0}\Desktop\editor.txt", Environment.UserName), selectedElements.ToArray());
    }
}
