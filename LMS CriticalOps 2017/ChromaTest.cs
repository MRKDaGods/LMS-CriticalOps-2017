using UnityEngine;
using System.Collections.Generic;

public class ChromaTest : MonoBehaviour
{
    LRenderer l;
    float slerpFactor, elerpFactor;
    Color stoLerp, etoLerp, endCol, startCol;
    int invokes;
    Color c;
    Dictionary<string, int> d = new Dictionary<string, int>();


    void Start()
    {
        d.Add("kek", ke());
        l = gameObject.AddComponent<LRenderer>().Init(new Color[2] { startCol, startCol }, new Vector3[] { new Vector3(-Screen.width / 2f, 0f), new Vector3(Screen.width / 2f, 0f) });
    }
    private static Color[] ColorSequence = new Color[] { new Color(1f, 0f, 0f),
                              new Color(1f, 1f, 0f),
                              new Color(0f, 1f, 0f),
                              new Color(0f, 1f, 1f),
                              new Color(0f, 0f, 1f),
                              new Color(1f, 0f, 1f) };

    public float Speed = 1f;
    private float _t;

    int ke()
    {
        Debug.Log("Dale");
        return 0;
    }

    void ExecuteC(string s)
    {
        Debug.Log(s + " exited with code " + d[s]);
    }
    /// <summary>
    /// see :P
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            ExecuteC("kek");
    }
    void OnGUI()
    {
        _t = (_t + Time.deltaTime * this.Speed) % (float)ColorSequence.Length;

        int ilow = Mathf.FloorToInt(_t);
        int ihigh = (ilow + 1) % ColorSequence.Length;

        c = Color.Lerp(ColorSequence[ilow], ColorSequence[ihigh], _t % 1f);
        l.UpdateColors(new Color[2] { c, c });
        GLCanvas.DrawLine(new Vector3(-Screen.width / 2f, Screen.height / 2 - 100f), new Vector3(Screen.width, Screen.height / 2 - 100f), c, 2.6f);
    }
}
