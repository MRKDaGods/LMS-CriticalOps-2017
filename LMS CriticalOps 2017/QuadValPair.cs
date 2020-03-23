using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QuadValPair<K, V, T, Q>
{
    K m_Key;
    V m_Value;
    T m_Triple;
    Q m_Quad;
    public K Key { get { return m_Key; } set { m_Key = value; } }
    public V Value { get { return m_Value; } set { m_Value = value; } }
    public T Triple { get { return m_Triple; } set { m_Triple = value; } }
    public Q Quad { get { return m_Quad; } set { m_Quad = value; } }

    public static QuadValPair<K, V, T, Q> Instantiate(K key, V value, T triple, Q quad)
    {
        return new QuadValPair<K, V, T, Q>
        {
            Key = key,
            Value = value,
            Triple = triple,
            Quad = quad
        };
    }
}
