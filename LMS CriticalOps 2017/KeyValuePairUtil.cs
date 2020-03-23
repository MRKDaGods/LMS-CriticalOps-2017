using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class KeyValuePairUtil
{
    public static KeyValuePair<string, string> a(string o, string o2)
    {
        return new KeyValuePair<string, string>(o, o2);
    }
    public static TripleValPair<LMS_GuiBaseCallback, int, GuiViewClientTick> b(LMS_GuiBaseCallback o, GuiViewClientTick c = null, int o2 = 1)
    {
        return TripleValPair<LMS_GuiBaseCallback, int, GuiViewClientTick>.Instantiate(o, o2, c);
    }
}
