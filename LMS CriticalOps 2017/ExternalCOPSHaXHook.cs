using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ExternalCOPSHaXHook
{
    public static string[] BONES = new string[] { "Head", "Chest", "Stomach", "L Lower Leg", "R Lower Leg", "L Upper Leg", "R Upper Leg", "L Lower Arm", "R Lower Arm", "L Upper Arm", "R Upper Arm" };
    public static string[] SERIALIZED_BONES = new string[] { "head", "chest", "stomach", "lowleftleg", "lowrightleg", "upleftleg", "uprightleg", "lowleftarm", "lowrightarm", "upleftarm", "uprightarm" };
    public const string AIMBOT = "AIMBOT", TRIGGERBOT = "TRIGGERBOT", SILENT_AIMBOT = "SILENT_AIMBOT", INVISIBLE_AIMBOT = "INVISIBLE_AIMBOT", AUTO_MELEE = "AUTO_MELEE", SHOOT_BOT = "SHOOT_BOT",
        BOX_ESP = "BOX_ESP", LINE_ESP = "LINE_ESP", NAME_ESP = "NAME_ESP", DISTANCE_ESP = "DISTANCE_ESP", CHAMS = "CHAMS", HEALTH_BAR = "HEALTH_BAR", TRAJECTORIES = "TRAJECTORIES";
    public const int VISIBLITY_INDEX = 2, ENABLED_INDEX = 0, BONE_INDEX = 1;
}