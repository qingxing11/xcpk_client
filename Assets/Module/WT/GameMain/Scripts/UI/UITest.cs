using Chat;
using FairyGUI;
using Set;
using WT.UI;

public class UITest : WTUIPage<UI_Chat, TestCtrl>
{
    public UITest() : base(UIType.Normal, UIMode.DoNothing, R.UI.CHAT)
    {
    }
     
    public override void Awake()
    {
        
    }
}