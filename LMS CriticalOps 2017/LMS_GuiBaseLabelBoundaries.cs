public static class LMS_GuiBaseLabelBoundaries
{
    static char[] Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static string WrapTextOLD(string inText, int inFontSize, float width)
    {
        int index = 0;
        float compensatedPos = 0f;
        string final = "";
        string initial = inText.LMS_Replace("<color=".GetTill(">"), "")
            .LMS_Replace("<size=".GetTill(">"), "")
            .LMS_Replace("<b>", "")
            .LMS_Replace("<i>", "")
            .LMS_Replace("</color>", "")
            .LMS_Replace("</size>", "")
            .LMS_Replace("</b>", "")
            .LMS_Replace("</i>", "");
        while (index < initial.Length)
        {
            char c = initial[index];
            float charWidth = 15f;
            if (compensatedPos + charWidth >= width)
            {
                final += "\n";
                compensatedPos = 0f;
            } else 
            {
                final += c;
                compensatedPos += charWidth;
            }
            index++;
        }
        return final;
    }
    public static string WrapText(string inText, int inFontSize, float width)
    {
        int index = 0;
        float compensatedPos = 0f;
        string final = "";
        string[] initial = inText.LMS_Replace("<color=".GetTill(">"), "")
            .LMS_Replace("<size=".GetTill(">"), "")
            .LMS_Replace("<b>", "")
            .LMS_Replace("<i>", "")
            .LMS_Replace("</color>", "")
            .LMS_Replace("</size>", "")
            .LMS_Replace("</b>", "")
            .LMS_Replace("</i>", "").Split(' ');
        while (index < initial.Length)
        {
            string c = initial[index];
            if (c.Length * 15f > width)
                c = c.Substring(0, (int)(width / 15f));
            if (compensatedPos + 15f * c.Length >= width)
            {
                final += "\n" + c + ' ';
                compensatedPos = 0f;
            }
            else 
            {
                final += c + ' ';
                compensatedPos += c.Length * 15f;
            }
            index++;
        }
        return final;
    }
    public static string Rand(int len)
    {
        string str = "";
        for (int i = 0; i < len; i++)
            str += Chars[UnityEngine.Random.Range(0, Chars.Length - 1)];
        return str;
    }
}