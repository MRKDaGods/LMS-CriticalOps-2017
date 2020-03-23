using UnityEngine;
using UnityEditor;
using System.IO;

public class LMSTexCreator : EditorWindow
{
    string height = "1", width = "1";
    float r = 1f, g = 1f, b = 1f;

    [MenuItem("MRK/Texture Creator")]
    static void Init()
    {
        GetWindow<LMSTexCreator>().Show();
    }
    Texture2D GeneratePlainTexture(Color c, int w = 1, int h = 1)
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
    void OnGUI()
    {
        GUI.skin.label.richText = true;
        GUILayout.BeginArea(new Rect(0f, 0f, 300f, 300f));
        GUILayout.Label("Height");
        height = GUILayout.TextField(height);
        GUILayout.Label("Width");
        width = GUILayout.TextField(width);
        GUILayout.FlexibleSpace();
        r = GUILayout.HorizontalSlider(r, 0f, 1f);
        g = GUILayout.HorizontalSlider(g, 0f, 1f);
        b = GUILayout.HorizontalSlider(b, 0f, 1f);
        GUILayout.Label(string.Format("<color=red>r={0}</color>,<color=green>g={1}</color>,<color=blue>b={2}</color>", r, g, b));
        Texture2D tex = GeneratePlainTexture(new Color(r, g, b), int.Parse(width), int.Parse(height));
        if (GUILayout.Button("Generate"))
        {
            if (!Directory.Exists((Application.dataPath + "/Textures")))
                Directory.CreateDirectory((Application.dataPath + "/Textures"));
            File.WriteAllBytes(Application.dataPath + "/Textures/Tex" + Random.Range(1, 5000) + ".png", tex.EncodeToPNG());
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(0f, 500f, 200f, 200f));
        GUI.DrawTexture(new Rect(0f, 0f, 200f, 200f), tex);
        GUILayout.EndArea();
    }
}
