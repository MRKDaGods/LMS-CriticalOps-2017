using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

public struct CustomEx
{
    public bool lateinit;
    public void EnInit()
    {
        lateinit = true;
    }
}

public delegate void CustomExTask();
public delegate bool CustomExTaskKiller();

public class LMS_CustomExecutor : MonoBehaviour
{
    Dictionary<MonoBehaviour, CustomEx> st = new Dictionary<MonoBehaviour, CustomEx>();
    public static LMS_CustomExecutor Instance { get { return LMS_Main.Instance.CustomExecutor; } }
    List<QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask>> QueuedTasks = new List<QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask>>();

    public void Handle(CustomExTask task, CustomExTaskKiller end, string tag, CustomExTask OnEndTask)
    {
        QueuedTasks.Add(QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask>.Instantiate(task, end, tag, OnEndTask));
    }
    public bool IsInterrupted(string tag)
    {
        return QueuedTasks.Where(curr => curr.Triple == tag).ToArray().Length > 1;
    }
    void Update()
    {
        List<QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask>> toRemove = new List<QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask>>();
        foreach (QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask> task in QueuedTasks)
        {
            if (task.Value())
            {
                task.Quad();
                toRemove.Add(task);
            }
            task.Key();
        }
        foreach (QuadValPair<CustomExTask, CustomExTaskKiller, string, CustomExTask> s in toRemove)
            QueuedTasks.Remove(s);
    }
    void InvokeLateInit(MonoBehaviour mono)
    {
        mono.GetType().GetMethod("LateInit", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, new object[0]);
    }
}