using UnityEngine;
using System.Collections;

public class SimpleDesign : MonoBehaviour
{
    #region i love cookies
    GUISkin m_skin;
    float m_Width;
    float m_Height;
    //
    //REKT++
    //
    Rect rekt;
    Rect devRekt;
    Rect AimbotRekt;
    Rect EspRekt;
    Rect MovementRekt;
    Rect MiscRekt;
    Rect PlayerRekt;
    Rect StringzZRekt;
    Rect SettingsRekt;
    //
    //MENUS -> Bools
    //
    bool ShowMainMenu = false;
    bool ShowAimbotMenu = false;
    bool ShowEspMenu = false;
    bool ShowMovementMenu = false;
    bool ShowMiscMenu = false;
    bool ShowPlayerMenu = false;
    bool ShowStringzZMenu = false;
    bool ShowSettingsMenu = false;
    //
    //AIMBOT MEMBERS
    //
    bool a_autoShoot;
    bool a_silent;
    bool a_ENABLE;
    bool a_AimKey;
    bool a_InfAmmo;
    bool a_RF;
    bool a_Inv;
    bool a_fade;
    KeyCode a_key = KeyCode.LeftAlt;
    //
    //ESP MEMBERS
    //
    bool e_Line = false;
    bool e_Box = false;
    bool e_HP = false;
    bool e_name = false;
    bool e_chams = false;
    bool e_mine = false;
    bool e_sentry = false;
    bool e_accinfo = false;
    bool e_localinfo = false;
    //
    //MOVEMENT MEMBERS
    //
    bool mo_InfStam;
    bool mo_Speed;
    bool mo_Walkin;
    bool mo_fly;
    bool mo_tele;
    bool mo_walkBot;
    //
    //MISC MEMBERS
    //
    bool mi_Killfeed;
    bool mi_Melee;
    bool mi_Particles;
    bool mi_dWalls;
    bool mi_fkheal;
    bool mi_Spectator;
    bool mi_SpoofKills;
    bool mi_SpoofGold;
    bool mi_clone;
    bool mi_Wireframe;
    //
    //TARGETTING MEMBERS
    //
    bool t_eENEMY;
    bool t_eFRIEND;
    bool t_aENEMY;
    bool t_aFRIEND;
    bool t_gENEMY;
    bool t_gFRIEND;
    //
    // ----- 
    //       
    void CreateMenu()
    {
        GUI.skin = m_skin;
        if (ShowMainMenu)
        {
            rekt = GUI.Window(1, rekt, new GUI.WindowFunction(MainMenuGUI), "");
            GUI.Window(2, devRekt, new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowAimbotMenu)
        {
            AimbotRekt = GUI.Window(3, AimbotRekt, new GUI.WindowFunction(AimbotRektGUI), "");
            GUI.Window(4, new Rect(450f, 510f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowEspMenu)
        {
            EspRekt = GUI.Window(5, EspRekt, new GUI.WindowFunction(EspRektGUI), "");
            GUI.Window(6, new Rect(450f, 490f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowMovementMenu)
        {
            MovementRekt = GUI.Window(7, MovementRekt, new GUI.WindowFunction(MovementRektGUI), "");
            GUI.Window(8, new Rect(450f, 400f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowMiscMenu)
        {
            MiscRekt = GUI.Window(9, MiscRekt, new GUI.WindowFunction(MiscRektGUI), "");
            GUI.Window(10, new Rect(450f, 540f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowPlayerMenu)
        {
            PlayerRekt = GUI.Window(11, PlayerRekt, new GUI.WindowFunction(PlayerRektGUI), "");
            GUI.Window(12, new Rect(450f, 400f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowStringzZMenu)
        {
            StringzZRekt = GUI.Window(13, StringzZRekt, new GUI.WindowFunction(StringzZRektGUI), "");
            GUI.Window(14, new Rect(450f, 400f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
        if (ShowSettingsMenu)
        {
            SettingsRekt = GUI.Window(15, SettingsRekt, new GUI.WindowFunction(SettingsRektGUI), "");
            GUI.Window(16, new Rect(450f, 545f, m_Width, 35f), new GUI.WindowFunction(nubDevcred), "");
        }
    }
    void mlovinit()
    {
        if (m_skin == null)
        {
            m_skin = new GUISkin();
            m_skin.window.normal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
            m_skin.window.onNormal.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
            m_skin.window.active.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
            m_skin.window.onActive.background = GeneratePlainTexture(0.0627450980392157f, 0.0627450980392157f, 0.0627450980392157f, 1f);
            //
            //Buttons
            //
            m_skin.button.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
            m_skin.button.onNormal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
            m_skin.button.active.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
            m_skin.button.onActive.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
            m_skin.button.fontSize = 16;
            m_skin.button.alignment = TextAnchor.MiddleCenter;
            m_skin.button.fixedHeight = 25f;
            m_skin.button.normal.textColor = Color.white;
            //
            //Label -> PADDING - Alignment
            //
            m_skin.label.normal.textColor = Color.white;
            m_skin.label.fontStyle = FontStyle.Bold;
            m_skin.label.alignment = TextAnchor.MiddleCenter;
            //
            //ez life ez codez xD -> HORIZONTALSLIDER
            //
            m_skin.horizontalSlider.normal.background = GeneratePlainTexture(0.1254901960784314f, 0.1254901960784314f, 0.1254901960784314f, 1f);
            m_skin.horizontalSliderThumb.normal.background = GeneratePlainTexture(0f, 0f, 1f, 0.6f);
            m_skin.horizontalSlider.alignment = TextAnchor.MiddleCenter;
            m_skin.horizontalSlider.fixedHeight = 10f;
            m_skin.horizontalSliderThumb.fixedWidth = 15f;
            m_skin.horizontalSliderThumb.fixedHeight = 9f;
        }
    }

    void MainMenuGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Main Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Aimbot"))
        {
            ShowAimbotMenu = !ShowAimbotMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "ESP"))
        {
            ShowEspMenu = !ShowEspMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Movement"))
        {
            ShowMovementMenu = !ShowMovementMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Misc"))
        {
            ShowMiscMenu = !ShowMiscMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Players [<color=yellow>Target</color>]"))
        {
            ShowPlayerMenu = !ShowPlayerMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "StringzZ"))
        {
            ShowStringzZMenu = !ShowStringzZMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Settings"))
        {
            ShowSettingsMenu = !ShowSettingsMenu;
            ShowMainMenu = !ShowMainMenu;
        }
        Y += 25;
        GUI.Label(new Rect(5f, Y, 265f, 25f), "Cure To <color=orange>Cancerous</color> MotherFuckers");
    }
    void nubDevcred(int winID)
    {
        GUI.Button(new Rect(5f, 5f, 265f, 10f), "Developed By <color=red>MRK n ShanGo</color>");
    }
    void lel(int winID)
    {
        GUI.Button(new Rect(5f, 5f, 265f, 10f), "Developed By <color=red>MRK n ShanGo</color>");
    }
    void AimbotRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Aimbot Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_ENABLE ? "white" : "blue", ">Toggle Aimbot</color>" })))
        {
            a_ENABLE = !a_ENABLE;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_AimKey ? "white" : "blue", ">AimKey </color>", "[", "<color=yellow>", a_key, "</color>", "]" })))
        {
            a_AimKey = !a_AimKey;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "AimBone ", "[", "<color=yellow>", aimboneSTR, "</color>", "]" })))
        {
            if (aimboneSTR == "Head") { aimboneSTR = "Chest"; }
            else if (aimboneSTR == "Chest") { aimboneSTR = "Pelvis"; }
            else if (aimboneSTR == "Pelvis") { aimboneSTR = "Head"; }
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_autoShoot ? "white" : "blue", ">Auto Shoot</color>" })))
        {
            a_autoShoot = !a_autoShoot;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_silent ? "white" : "blue", ">Silent</color>" })))
        {
            a_silent = !a_silent;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_InfAmmo ? "white" : "blue", ">Infinite Ammo</color>" })))
        {
            a_InfAmmo = !a_InfAmmo;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_RF ? "white" : "blue", ">RapidFire + NoReload</color>" })))
        {
            a_RF = !a_RF;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_Inv ? "white" : "blue", ">Invisible Weapon</color>" })))
        {
            a_Inv = !a_Inv;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !a_fade ? "white" : "blue", ">Fadeout</color>" })))
        {
            a_fade = !a_fade;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowAimbotMenu = !ShowAimbotMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void EspRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - ESP Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_Box ? "white" : "blue", ">Boxes EsP</color>" })))
        {
            e_Box = !e_Box;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_Line ? "white" : "blue", ">Lines EsP</color>" })))
        {
            e_Line = !e_Line;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_HP ? "white" : "blue", ">Health Boxes</color>" })))
        {
            e_HP = !e_HP;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_name ? "white" : "blue", ">Name EsP</color>" })))
        {
            e_name = !e_name;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_chams ? "white" : "blue", ">Chams</color>" })))
        {
            e_chams = !e_chams;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_mine ? "white" : "blue", ">Land Mine EsP</color>" })))
        {
            e_mine = !e_mine;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_sentry ? "white" : "blue", ">Sentry EsP</color>" })))
        {
            e_sentry = !e_sentry;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_accinfo ? "white" : "blue", ">Accounts Info</color>" })))
        {
            e_accinfo = !e_accinfo;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !e_localinfo ? "white" : "blue", ">LocalPlayer's Info</color>" })))
        {
            e_localinfo = !e_localinfo;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowEspMenu = !ShowEspMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void MovementRektGUI(int windID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Movement Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_InfStam ? "white" : "blue", ">Infinite Sprint</color>" })))
        {
            mo_InfStam = !mo_InfStam;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_Speed ? "white" : "blue", ">Speed </color>", "[<color=yellow>X</color>]" })))
        {
            mo_Speed = !mo_Speed;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_Walkin ? "white" : "blue", ">Wall Hack </color>", "[<color=yellow>G</color>]" })))
        {
            mo_Walkin = !mo_Walkin;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_fly ? "white" : "blue", ">Fly </color>", "[<color=yellow>F</color>]" })))
        {
            mo_fly = !mo_fly;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_tele ? "white" : "blue", ">Teleport </color>", "[<color=yellow>C</color>]" })))
        {
            mo_tele = !mo_tele;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mo_walkBot ? "white" : "blue", ">Walk Bot</color>" })))
        {
            mo_walkBot = !mo_walkBot;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowMovementMenu = !ShowMovementMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void MiscRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Misc Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_dWalls ? "white" : "blue", ">FPS Boost</color>" })))
        {
            mi_dWalls = !mi_dWalls;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_Particles ? "white" : "blue", ">Cant See Me</color>" })))
        {
            mi_Particles = !mi_Particles;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_Killfeed ? "white" : "blue", ">Killfeed Spam</color>" })))
        {
            mi_Killfeed = !mi_Killfeed;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_Melee ? "white" : "blue", ">MeleeBot</color>" })))
        {
            mi_Melee = !mi_Melee;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_fkheal ? "white" : "blue", ">Make Them Blind</color>" })))
        {
            mi_fkheal = !mi_fkheal;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_clone ? "white" : "blue", ">Clone LocalAgent </color>", "[<color=yellow>Y</color>]" })))
        {
            mi_clone = !mi_clone;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_Spectator ? "white" : "blue", ">Spectator </color>", "[<color=yellow>P</color>]" })))
        {
            mi_Spectator = !mi_Spectator;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_SpoofKills ? "white" : "blue", ">Spoof </color>", "<color=red>Kills</color>" })))
        {
            mi_SpoofKills = !mi_SpoofKills;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_SpoofGold ? "white" : "blue", ">Spoof </color>", "<color=yellow>Gold</color>" })))
        {
            mi_SpoofGold = !mi_SpoofGold;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !mi_Wireframe ? "white" : "blue", ">Wireframe </color>", "[<color=yellow>Z</color>]" })))
        {
            mi_Wireframe = !mi_Wireframe;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowMiscMenu = !ShowMiscMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void PlayerRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Players Menu");
        int Y = 24;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_eENEMY ? "white" : "blue", ">Enemy </color>", "[<color=yellow>ESP</color>]" })))
        {
            t_eENEMY = !t_eENEMY;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_eFRIEND ? "white" : "blue", ">Friendly </color>", "[<color=yellow>ESP</color>]" })))
        {
            t_eFRIEND = !t_eFRIEND;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_aENEMY ? "white" : "blue", ">Enemy </color>", "[<color=yellow>Aimbot</color>]" })))
        {
            t_aENEMY = !t_aENEMY;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_aFRIEND ? "white" : "blue", ">Friendly </color>", "[<color=yellow>Aimbot</color>]" })))
        {
            t_aFRIEND = !t_aFRIEND;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_gENEMY ? "white" : "blue", ">Enemy </color>", "[<color=yellow>Account</color>", "<color=orange>INFO</color>]" })))
        {
            t_gENEMY = !t_gENEMY;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !t_gFRIEND ? "white" : "blue", ">Friendly </color>", "[<color=yellow>Account</color>", "<color=orange>INFO</color>]" })))
        {
            t_gFRIEND = !t_gFRIEND;
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowPlayerMenu = !ShowPlayerMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void StringzZRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - StringzZ Menu");
        GUI.skin = null;
        GUI.skin.textField.normal.textColor = Color.green;
        GUI.skin.textField.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontStyle = FontStyle.BoldAndItalic;
        int Y = 24;
        GUI.Label(new Rect(5f, Y, 256f, 25f), "<color=blue>Nickname</color>");
        Y += 25;
        GUI.color = Color.yellow;
        nick = GUI.TextField(new Rect(10f, Y, 256, 25f), nick);
        Y += 30;
        GUI.Label(new Rect(5f, Y, 256f, 25f), "<color=blue>KillFeed</color>");
        Y += 25;
        killfeed = GUI.TextField(new Rect(10f, Y, 256, 25f), killfeed);
        Y += 30;
        GUI.Label(new Rect(5f, Y, 256f, 25f), "<color=blue>Spoof Kill</color>");
        Y += 25;
        spoofkill = GUI.TextField(new Rect(10f, Y, 256, 25f), spoofkill);
        Y += 30;
        GUI.Label(new Rect(5f, Y, 256f, 25f), "<color=blue>Spoof Gold Value</color>");
        Y += 25;
        gold = GUI.TextField(new Rect(10f, Y, 256, 25f), gold, 3);
        Y += 50;
        GUI.skin = m_skin;
        GUI.color = Color.white;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "Back: <color=yellow>Main</color>" })))
        {
            ShowStringzZMenu = !ShowStringzZMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }
    void SettingsRektGUI(int winID)
    {
        Label("Anti ShitzZ V3 [<color=green>SGDZ</color>] - Settings Menu");
        int Y = 24;
        GUI.Label(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=blue>Speed </color>", "<color=orange>=> </color>", "<color=yellow>", speedVal, "</color>" }));
        Y += 30;
        speedVal = GUI.HorizontalSlider(new Rect(5f, Y, 265f, 10f), speedVal, 6f, 15f);
        Y += 20;
        GUI.Label(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=blue>Aimbot Distance </color>", "<color=orange>=> </color>", "<color=yellow>", aimbotDist, "</color>" }));
        Y += 30;
        aimbotDist = GUI.HorizontalSlider(new Rect(5f, Y, 265f, 10f), aimbotDist, 20f, 100f);
        Y += 20;
        GUI.Label(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=blue>MeleeBot Distance </color>", "<color=orange>=> </color>", "<color=yellow>", meleeDist, "</color>" }));
        Y += 30;
        meleeDist = GUI.HorizontalSlider(new Rect(5f, Y, 265f, 10f), meleeDist, 5f, 15f);
        Y += 25;
        GUI.Label(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=blue>Lines Mode </color>", "[<color=yellow>", lineMode, "</color>]" }));
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 88f, 25f), "Fixed"))
        {
            lineMode = "Fixed";
        }
        if (GUI.Button(new Rect(95f, Y, 88f, 25f), "Visibillity"))
        {
            lineMode = "Visibillity";
        }
        if (GUI.Button(new Rect(185f, Y, 88f, 25f), "Rainbow"))
        {
            lineMode = "Rainbow";
        }
        Y += 30;
        GUI.Label(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=blue>Boxes Mode </color>", "[<color=yellow>", boxMode, "</color>]" }));
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), string.Concat(new object[] { "<color=", !filledBox ? "white" : "blue", ">Filled Boxes </color>" })))
        {
            filledBox = !filledBox;
        }
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 88f, 25f), "Fixed"))
        {
            boxMode = "Fixed";
        }
        if (GUI.Button(new Rect(95f, Y, 88f, 25f), "Visibillity"))
        {
            boxMode = "Visibillity";
        }
        if (GUI.Button(new Rect(185f, Y, 88f, 25f), "Rainbow"))
        {
            boxMode = "Rainbow";
        }
        Y += 30;
        GUI.Label(new Rect(5f, Y, 265f, 25f), "<color=blue>AccInfo Mode </color>" + "[<color=yellow>" + accMode + "</color>]");
        Y += 30;
        if (GUI.Button(new Rect(5f, Y, 132.5f, 25f), "With Password"))
        {
            accMode = "With Password";
        }
        if (GUI.Button(new Rect(140.5f, Y, 132.5f, 25f), "Without Password"))
        {
            accMode = "Without Password";
        }
        Y += 50;
        if (GUI.Button(new Rect(5f, Y, 265f, 25f), "Back: <color=yellow>Main</color>"))
        {
            ShowSettingsMenu = !ShowSettingsMenu;
            ShowMainMenu = !ShowMainMenu;
        }
    }

    void DefineVals()
    {
        m_Width = 275f;
        m_Height = 290f;
        rekt = new Rect(450f, 100f, m_Width, m_Height);
        devRekt = new Rect(450f, 395f, m_Width, 35f);
        AimbotRekt = new Rect(450f, 100f, m_Width, 405f);
        EspRekt = new Rect(450f, 100f, m_Width, 385f);
        MovementRekt = new Rect(450f, 100f, m_Width, 295f);
        MiscRekt = new Rect(450f, 100f, m_Width, 435f);
        PlayerRekt = new Rect(450f, 100f, m_Width, 295f);
        StringzZRekt = new Rect(450f, 100f, m_Width, 295f);
        SettingsRekt = new Rect(450f, 100f, m_Width, 440f);
    }
    void Label(string str)
    {
        GUILayout.Label(str);
    }
    string aimboneSTR = "Pelvis";
    string meleeBotMode = "Normal";
    string nick = "Nickname...";
    string killfeed = "KF Spam text...";
    string spoofkill = "SpoofKill Text...";
    static int goldVal = 50;
    string gold = goldVal.ToString();
    //
    //Thumbs :d
    //
    float speedVal;
    float aimbotDist;
    float meleeDist;
    string lineMode = "Fixed";
    string boxMode = "Fixed";
    string accMode = "With Password";
    bool filledBox;
    #endregion
    void Toggle(ref bool b)
    {
        b = !b;
    }
    void Start()
    {
        DefineVals();
        mlovinit();
    }
    string txt = "";
    void OnGUI()
    {
        CreateMenu();
        if (GUILayout.Button("dankk memz?"))
        {
            //test stringTOColor
            Debug.Log(LMS_GuiBaseUtils.StringToColor("blue").ToString());
        }
        GUI.skin = null;
        txt = GUI.TextField(new Rect(100f, 50f, 200f, 40f), txt);
        GUILayout.Label(LMS_Txt.Resolve(txt).ToString());
    }
    Texture2D GeneratePlainTexture(float r, float g, float b, float a, int w = 1, int h = 1)
    {
        Texture2D t = new Texture2D(w, h);
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                t.SetPixel(i, j, new Color(r, g, b, a));
            }
        }
        t.Apply();
        return t;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
            Toggle(ref ShowMainMenu);
    }
}
