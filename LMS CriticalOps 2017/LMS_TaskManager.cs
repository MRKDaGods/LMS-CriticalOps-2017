using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

public delegate void LMSTask();
public class LMS_TaskManager
{
    public static void RunTaskLater(int Secs, LMSTask del, MonoBehaviour owner)
    {
        owner.StartCoroutine(eRunTaskLater(Secs, del));
    }
    static IEnumerator eRunTaskLater(int secs, LMSTask t)
    {
        yield return new WaitForSeconds(secs);
        t.Invoke();
    }
}

public class LMS_WAIT_WHILE : CustomYieldInstruction
{
    bool m_Condition;
    public override bool keepWaiting
    {
        get
        {
            return m_Condition;
        }
    }

    public LMS_WAIT_WHILE(bool condition)
    {
        m_Condition = condition;
    }
}

