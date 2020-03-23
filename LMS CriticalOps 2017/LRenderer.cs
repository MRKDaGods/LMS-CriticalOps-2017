using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LRenderer : MonoBehaviour
{
    LineRenderer m_L;

    public LRenderer Init(Color[] Col, Vector3[] Pos)
    {
        m_L = gameObject.AddComponent<LineRenderer>();
        m_L.material = new Material(Shader.Find("Hidden/Internal-Colored"));
        m_L.SetVertexCount(Pos.Length);
        int index = 0;
        while (index < Pos.Length) //faster
        {
            m_L.SetPosition(index, Pos[index]);
            index++;
        }
        try
        {
            m_L.SetColors(Col[0], Col[1]);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log(e.Message);
            m_L.SetColors(Color.yellow, Color.yellow);
        }
        m_L.SetWidth(0.1f, 0.1f);
        return this;
    }
    public void Render()
    {

    }
    public void UpdateColors(Color[] Col)
    {
        try
        {
            m_L.SetColors(Col[0], Col[1]);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.Log(e.Message);
        }
    }
}
