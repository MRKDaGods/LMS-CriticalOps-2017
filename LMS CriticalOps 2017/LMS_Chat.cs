using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LMS_Chat
{
    List<ChatMsg> m_Msgs = new List<ChatMsg>();
    public List<ChatMsg> Messages { get { return m_Msgs; } }
    static Dictionary<int, Color> m_Table;

    static LMS_Chat()
    {
        m_Table = new Dictionary<int, Color>();
        m_Table[10] = Color.white;
        m_Table[20] = Color.green;
        m_Table[30] = new Color(1f, 0.65f, 0f);
        m_Table[40] = new Color(0.98f, 0.5f, 0.47f);
        m_Table[50] = Color.red;
    }
    public struct ChatMsg
    {
        public int Type;
        public string Text;
        public string Prefix;
        public string User;

        public static ChatMsg Create(string text, string prefix, string user, int type)
        {
            return new ChatMsg
            {
                Prefix = prefix,
                Text = text,
                Type = type,
                User = user
            };
        }
    }
    public void ReceiveChatMessage(string json, bool filter = false) //further development wether we wanna filter shit
    {
        m_Msgs.Add(LitJson.JsonMapper.ToObject<ChatMsg>(json));
    }
    public static string FixedName(string prefix, string name)
    {
        return prefix + " " + name + new string(' ', Mathf.Abs(15 - prefix.Length + name.Length));
    }
    public Color this[int i]
    {
        get
        {
            return m_Table[i];
        }
    }
}
