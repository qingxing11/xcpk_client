using FairyGUI;
using Message;
using WT.UI;

public class UIMessage : WTUIPage<UI_message, MessageCtrl>
{
    public UIMessage() : base(UIType.Dialog, UIMode.DoNothing, R.UI.MESSAGE)
    {
    }



    public void PlayAnim(string str, PlayCompleteCallback callback)
    {
        UIPage.m_t0.Play(callback);
        UIPage.m_text_content.text = str;
    } 
}