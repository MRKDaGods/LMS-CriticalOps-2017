using System;
using System.Collections.Generic;
using UnityEngine;

struct CZLogInfo
{
    public string msg;
    public LogType type;
    public string stacktrace;
}

public class Logger : MonoBehaviour
{
    List<CZLogInfo> logs = new List<CZLogInfo>();
    bool draw;
    GUIStyle style;
    Vector2 scrollPos;
    bool autoscroll;

    void Start()
    {
        Application.logMessageReceived += (s, s1, s2) => {
            logs.Add(new CZLogInfo
            {
                msg = s,
                stacktrace = s1,
                type = s2
            });
        };
    }
    void OnGUI()
    {
        if (GUILayout.Button("Toggle Log"))
            draw = !draw;
        autoscroll = GUILayout.Toggle(autoscroll, "Auto Scroll");
        if (style == null)
        {
            Texture2D t = new Texture2D(1, 1);
            t.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.4f));
            t.Apply();
            style = new GUIStyle
            {
                normal =
                {
                    background = t
                }
            };
        }
        if (draw)
        {
            GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height), style);
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            foreach (CZLogInfo s in logs)
            {
                GUI.contentColor = s.type == LogType.Error || s.type == LogType.Exception || s.type == LogType.Assert ? Color.red : s.type == LogType.Log ? Color.cyan : Color.yellow;
                GUILayout.Label(s.msg + "\n\tStackTrace:\n\t\t" + s.stacktrace + "\n\n");
                GUI.contentColor = Color.white;
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
    void Update()
    {
        //auto drag scroll
        if (autoscroll) scrollPos = new Vector2(0f, float.MaxValue);
    }
}
