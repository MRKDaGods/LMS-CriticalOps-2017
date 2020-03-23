using System.Collections.Generic;

public delegate void GuiViewClientTick(LMS_GuiView view);

public class LMS_GuiViewDetail : LMS_GuiView
{
    public KeyValuePair<LMS_GuiBaseCallback, int>[] callback;
    public string Text, Text2;
    GuiViewClientTick onClientTick;

    public LMS_GuiViewDetail(KeyValuePair<LMS_GuiBaseCallback, int>[] callback, string Text, string Text2 = "")
    {
        this.callback = callback;
        this.Text = Text;
        this.Text2 = Text2;
    }
    public void RegisterTickCallback(GuiViewClientTick tick)
    {
        onClientTick += tick;
        try
        {
            callback[0].Key.RegisterClientViewTick(tick, this);
        }
        finally
        {
            UnityEngine.Debug.Log("Registered Tick Callback");
        }
    }
}