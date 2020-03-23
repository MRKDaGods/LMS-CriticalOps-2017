public class LMS_GuiView //base class
{
    public static void ShowPopup(string name, string txt, string caption, string col, PopupHandler hnd)
    {
        if (CheckThread())
        {
            LMS_MainThread.Instance.ShowPopup(name, txt, caption, col, hnd);
        }
    }
    public static void ShowScreen(string name)
    {
        if (CheckThread())
        {
            LMS_MainThread.Instance.ShowScreen(name);
        }
    }
    static bool CheckThread()
    {
        return LMS_MainThread.Instance != null;
    }
}