#pragma warning disable 1066

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_DoubleBuffer<K, V>
{
    int m_Size, m_AvailableSize;
    public int Size { get { return m_Size; } }
    public int AvailableSize { get { return m_AvailableSize; } }
    bool m_CustomSize;
    List<K> m_ElementKL;
    List<V> m_ElementVL;
    Dictionary<K, int> m_IndexBuffer = new Dictionary<K, int>();

    public LMS_DoubleBuffer()
    {
    }
    public LMS_DoubleBuffer(int size)
    {
        m_Size = size;
        m_CustomSize = true;
    }
    public void Push(K k, V v)
    {
        Check();
        if (m_CustomSize && m_AvailableSize + 1 > m_Size)
        {
            Debug.LogError("Invalid size!");
            return;
        }
        m_ElementKL.Add(k);
        m_ElementVL.Add(v);
        m_AvailableSize++;
        if (m_AvailableSize > m_Size)
            m_Size++;
    }
    public void Pop(int desIndex)
    {
        if (desIndex <= -1 || m_CustomSize && desIndex > m_AvailableSize - 1)
        {
            Debug.LogError("Invalid Index received!");
            return;
        }
        m_ElementKL.RemoveAt(desIndex);
        m_ElementVL.RemoveAt(desIndex);
        m_AvailableSize--;
    }
    public void Pop()
    {
        int desIndex = m_AvailableSize--;
        m_ElementKL.RemoveAt(desIndex);
        m_ElementVL.RemoveAt(desIndex);
    }
    void Check()
    {
        if (m_ElementKL == null)
            m_ElementKL = new List<K>();
        if (m_ElementVL == null)
            m_ElementVL = new List<V>();
    }
    public bool ContainsKL(K ik)
    {
        try
        {
            return m_ElementKL.Contains(ik);
        } catch { return false; }
    }
    public V this[K k]
    {
        get
        {
            int i = CheckIndexInternal(k);
            if (i != -1)
                return m_ElementVL[i];
            return default(V);
        }
        set
        {
            int i = CheckIndexInternal(k);
            if (i != -1)
                m_ElementVL[i] = value;
        }
    }
    public KeyValuePair<K, V>[] this[int idx = -1]
    {
        get
        {
            List<KeyValuePair<K, V>> l = new List<KeyValuePair<K, V>>();
            for (int i = 0; i < m_AvailableSize; i++)
                l.Add(new KeyValuePair<K, V>(m_ElementKL[i], m_ElementVL[i]));
            return l.ToArray();
        }
    }
    int CheckIndexInternal(K k)
    {
        if (m_IndexBuffer.ContainsKey(k))
            return m_IndexBuffer[k];
        int i = m_ElementKL.FindIndex(c => c.LMS() == k.LMS());
        if (i != -1)
        {
            m_IndexBuffer[k] = i;
            return i;
        }
        return -1;
    }
}