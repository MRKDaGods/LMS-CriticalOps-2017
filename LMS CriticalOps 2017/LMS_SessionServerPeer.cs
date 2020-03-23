using System.Text;
using System.Collections;
using uLobby;
using UnityEngine;
using LitJson;

public class LMS_SessionServerPeer : MonoBehaviour
{
    static LMS_SessionServerPeer ms_Instance;
    LocalPeer m_LocalPeer;
    public static LMS_SessionServerPeer Instance;
    const string IP = "127.0.0.1:23466";
    bool packetlooprunning;
    LMS_Chat m_Chat;
    float m_LastAuthenticationTime;
    const float AUTHENTICATION_COOLDOWN = 10f; //5 seconds edit: 10
    int m_SpamTries;
    public LMS_Chat Chat { get { if (m_Chat == null) m_Chat = new LMS_Chat(); return m_Chat; } }
    public LocalPeer Peer { get { return m_LocalPeer; } }

    public static void CreateInstance()
    {
        if (ms_Instance == null)
        {
            ms_Instance = new GameObject("Session Server Peer").AddComponent<LMS_SessionServerPeer>();
            DontDestroyOnLoad(ms_Instance.gameObject);
            Instance = ms_Instance;
        }
    }
    void Start()
    {
#if LMS_Auth
        StartCoroutine(PacketLoop(true));
        Lobby.AddListener(ms_Instance);
        Lobby.OnConnected += OnConnectedToSessionServer;
        Lobby.OnDisconnected += OnDisconnectFromSessionServer;
#endif
    }
    void OnConnectedToSessionServer()
    {
        Debug.Log("Successfully established a connection to the session server");
    }
    void OnDisconnectFromSessionServer()
    {
        Debug.Log("Disconnected from session server");
#if LMS_Auth
        if (!packetlooprunning)
            StartCoroutine(PacketLoop(false));
#endif
    }
    IEnumerator PacketLoop(bool initstate)
    {
        packetlooprunning = true;
        if (initstate)
            yield return new WaitForSeconds(2f);
        LMS_Main.Instance.ShowPopup(1, "Connecting to server", "Session Server", Color.red);
        LMS_GuiPopupMessageBox msbox = LMS_Main.Instance.MessageBoxPopup;
        LMS_Main.Instance.VisibilityButton.Hidden = true;
        msbox.ShowBackButton(false);
        while (!Lobby.isConnected)
        {
            Lobby.DisconnectImmediate();
            yield return new WaitForSeconds(2f);
            Lobby.ConnectAsClient(new uLink.NetworkEndPoint(IP));
            Debug.Log("Sent a connection packet to session server");
            yield return new WaitForSeconds(2f);
        }
        msbox.ForceClose();
        LMS_Main.Instance.ShowPopup(1, "Successfully connected to\nserver!", "Session Server", Color.green, (res, popup) => { LMS_Main.Instance.ShowScreen(3); LMS_Main.Instance.VisibilityButton.Hidden = false; });
        packetlooprunning = false;
    }
    [RPC]
    void FetchPeerInfo(string json)
    {
        m_LocalPeer = JsonMapper.ToObject<LocalPeer>(json);
    }
    [RPC]
    void AuthenticationReply(int reply, string[] str)
    {
        string title = "", text = "";
        bool success = false;
        PopupHandler handler = null;
        switch (reply)
        {
            case 0:
                title = "Not Found";
                text = "The specified account\nwasn't found";
                break;
            case 1:
                title = "Success";
                text = "Authentication Succeeded\nWelcome " + m_LocalPeer.user;
                success = true;
                handler = (res, popup) =>
                {
                    if (res == E_PopupCallback.OK)
                        LMS_Main.Instance.ShowScreen(0);
                };
                break;
            case 2:
                title = "Banned";
                text = "You've been banned\nfor " + str[0] + "\nby " + str[2] + "\nuntil " + new System.DateTime(long.Parse(str[1])).ToString();
                break;
            default:
                title = "Authentication";
                text = "Authentication failed!";
                break;
        }
        LMS_Main.Instance.ShowPopup(1, text, "Authentication", success ? Color.green : Color.red, handler);
    }
#if LMS_Auth
#else
    public void CircAuth()
    {
        m_LocalPeer = new LocalPeer
        {
            user = "test"
        };
        LMS_Main.Instance.ShowPopup(1, "Authentication Succeeded\nWelcome " + m_LocalPeer.user, "Success", Color.green, (res, popup) =>
        {
            if (res == E_PopupCallback.OK)
                LMS_Main.Instance.ShowScreen(0);
        });
    }
#endif
    [RPC]
    void InvalidAdministrationRequest(int request)
    {

    }
    [RPC]
    void SuccessfulAdministrationRequest(int request)
    {
        Debug.Log("Success admin req " + request);
    }
    public void Authenticate(string user, string pass)
    {
        if (m_LastAuthenticationTime + AUTHENTICATION_COOLDOWN > Time.timeSinceLevelLoad)
        {
            m_LastAuthenticationTime = Time.timeSinceLevelLoad;
            m_SpamTries++;
            if (m_SpamTries >= 5)
                LMS_Main.Instance.ShowPopup(1, "You have been temp banned\nfor an hour!", "Authentication", Color.red, (res, popup) => 
                {
                    if (res == E_PopupCallback.OK)
                        Application.Quit();
                });
            else LMS_Main.Instance.ShowPopup(1, "Don't spam the authentication\nelse you will receive a ban!", "Authentication", Color.red);
            return;
        }
        m_LastAuthenticationTime = Time.timeSinceLevelLoad;
        m_SpamTries = 0;
        if (!Lobby.isConnected)
        {
            AuthenticationReply(-1, null);
            return;
        }
        Lobby.RPC("AuthenticateUser", LobbyPeer.lobby, user, pass);
    }
    [RPC]
    void ReceiveChatMessage(string json)
    {
        Chat.ReceiveChatMessage(json);
    }
    public void SendChatMessage(LMS_Chat.ChatMsg msg)
    {
        Lobby.RPC("ChatMessage", LobbyPeer.lobby, JsonMapper.ToJson(msg));
    }
}

public class LocalPeer
{
    public bool admin;
    public bool ban;
    public string user;
    public string passhash;
    public string bannedby;
    public object banexp;
    public string reason;
    public int accesslevel;
}
