using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_ModifiedTexture : MonoBehaviour
{
    [SerializeField]
    Texture2D m_Texture;
    [SerializeField]
    string m_MainModifier;
    public Texture2D MainTexture { get { return m_Texture; } }
    public string MainModifier { get { return m_MainModifier; } }
}
