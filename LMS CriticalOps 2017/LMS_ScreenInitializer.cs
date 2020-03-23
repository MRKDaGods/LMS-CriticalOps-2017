using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_ScreenInitializer : MonoBehaviour
{
    [SerializeField]
    string[] Screens;

    void Awake()
    {
        LMS_TaskManager.RunTaskLater(3, () =>
        {
            foreach (LMS_GuiScreen s in GetComponents<LMS_GuiScreen>())
            {
                s.HideScreen();
                foreach (string str in Screens)
                {
                    if (str == s.ScreenName())
                    {
                        s.ShowScreen();
                        break;
                    }
                }
            }
        }, this);
    }
}
