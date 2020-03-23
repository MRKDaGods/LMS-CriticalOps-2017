using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_GuiBaseLayout : MonoBehaviour
{
    public LMS_GuiBaseCallback[] GetCallbacks()
    {
        return gameObject.GetComponentsInChildren<LMS_GuiBaseCallback>();
    }
}
