using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class LMS_Meta
{
    public static Dictionary<string, string> meta = new Dictionary<string, string>();

    static LMS_Meta()
    {
        meta["VER"] = "1.0";
        meta["LAB_FONT"] = "Candara"; //use Candara as a default font
        meta["DISCORD_URL"] = "https://discord.gg/kJsCPJ4";
        RegisterNewHackEntry("AIMBOT", "false", "head", "50");
        RegisterNewHackEntry("TRIGGERBOT", "false", "head", "50");
        RegisterNewHackEntry("SILENT_AIMBOT", "false", "head", "50");
        RegisterNewHackEntry("INVISIBLE_AIMBOT", "false", "head", "50");
        RegisterNewHackEntry("AUTO_MELEE", "false", "head", "50");
        RegisterNewHackEntry("SHOOT_BOT", "false", "head", "50");
        RegisterNewHackEntry("BOX_ESP", "false", "none", "false");
        RegisterNewHackEntry("LINE_ESP", "false", "chest", "false");
        RegisterNewHackEntry("NAME_ESP", "false", "chest", "false");
        RegisterNewHackEntry("DISTANCE_ESP", "false", "chest", "false");
        RegisterNewHackEntry("CHAMS", "false", "none", "false");
        RegisterNewHackEntry("HEALTH_BAR", "false", "h_above_head", "false");
        RegisterNewHackEntry("TRAJECTORIES", "false", "none", "none");
    }
    public static string getMetaValue(string key, string defaultVal = "")
    {
        if (!meta.ContainsKey(key))
            meta[key] = defaultVal;
        return meta[key];
    }
    public static void setMetaValue(string key, string value)
    {
        meta[key] = value;
    }
    public static void ModifyHackRecord(string hack, int recordAt, string newValue)
    {
        string[] args = meta[hack].Split('|');
        args[recordAt] = newValue;
        string str = "";
        for (int i = 0; i < args.Length; i++)
                str += args[i] + (i < args.Length - 1 ? "|" : "");
        meta[hack] = str;
    }
    static void RegisterNewHackEntry(params string[] args)
    {
        string str = "";
        for (int i = 1; i < args.Length; i++)
            str += args[i] + (i < args.Length - 1 ? "|" : "");
        meta[args[0]] = str;
    }
}
