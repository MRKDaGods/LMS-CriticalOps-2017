using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

public class TextureGrabber : MonoBehaviour
{
    public Texture2D t;

    void Start()
    {
        byte[] b = t.EncodeToPNG();
        File.WriteAllText(@"C:\Users\knigh\Desktop\out.txt", Convert.ToBase64String(b));
    }
}
