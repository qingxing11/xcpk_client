using System;
using WT.UI;
using Room;

public class UIReturnPanel : WTUIPage<UI_ReturnPanel, RoomCtrl>
{
    public Action ActionStandUp;         //站起
    public Action ActionSet;             //设置
    public Action ActionCloseRoom;       //退出房间
    public Action ActionHelp;
    public UIReturnPanel() : base(UIType.PopUp, UIMode.DoNothing, R.UI.ROOM)
    {

    }
    public override void Awake()
    {
        UIPage.m_btn_return.onClick.Add(() => {
            ActionCloseRoom?.Invoke();
            base.Hide();
        });
        UIPage.m_btn_set.onClick.Add(() => {
            ActionSet?.Invoke();
        });
        UIPage.m_btn_standup.onClick.Add(() => {
            ActionStandUp?.Invoke();
        });
        UIPage.m_btn_help.onClick.Add(() => {
            ActionHelp?.Invoke();
        });
        UIPage.onClick.Add(Hide);
    }

    internal void Init()
    {
        UIPage.SetPosition(5, -138,0);
        UIPage.TweenMoveY(0,0.8f);
    }

    public override void Hide()
    {
        if(UIPage!=null)
            UIPage.TweenMoveY(-140,0.8f).OnComplete(()=> {  base.Hide();});
    }
}