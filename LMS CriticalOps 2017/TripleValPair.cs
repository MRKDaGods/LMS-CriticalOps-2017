using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TripleValPair<K, V, T>
{
    K m_Key;
    V m_Value;
    T m_Triple;
    public K Key { get { return m_Key; } set { m_Key = value; } }
    public V Value { get { return m_Value; } set { m_Value = value; } }
    public T Triple { get { return m_Triple; } set { m_Triple = value; } }

    public static TripleValPair<K, V, T> Instantiate(K key, V value, T triple)
    {
        return new TripleValPair<K, V, T>
        {
            Key = key,
            Value = value,
            Triple = triple
        };
    }
}
