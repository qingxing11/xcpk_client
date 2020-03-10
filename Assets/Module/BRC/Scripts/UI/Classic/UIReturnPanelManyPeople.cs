using System;
using Classic;
using WT.UI;

public class UIReturnPanelManyPeople : WTUIPage<UI_ReturnPanelManyPeople, TenThousandRoomCtrl>
{
    public UIReturnPanelManyPeople() : base(UIType.PopUp, UIMode.DoNothing, R.UI.TENTHOUSANDFIELD)
    { }

    public Action<bool> ActionLeave;  //离开游戏
    public Action ActionSet;    //设置
    public Action ActionHelp;   //帮助

    public override void Awake()
    {
        UIPage.m_btn_return.onClick.Add(() => { ActionLeave?.Invoke(false); }); //返回大厅
        UIPage.m_btn_set.onClick.Add(() => { ActionSet?.Invoke(); });      //设置
        UIPage.m_btn_help.onClick.Add(() => { ActionHelp?.Invoke(); });    //帮助
    }

    public void Init()
    {
        UIPage.SetPosition(0, -174, 0);
        UIPage.TweenMoveY(0, 0.35f).OnComplete(()=> { BaseCanvas.GetController<TenThousandRoomCtrl>().isReturnPanel = true; });
       
    }

    public override void Hide()
    {
        if(UIPage!=null)
        UIPage.TweenMoveY(-174, 0.35f).OnComplete(() =>
        {
            base.Hide();
            BaseCanvas.GetController<TenThousandRoomCtrl>().isReturnPanel = false;
        });

    }
    public void HideNow()
    {
        UIPage.SetPosition(0, -174, 0);
        base.Hide();
        BaseCanvas.GetController<TenThousandRoomCtrl>().isReturnPanel = false;
    }
}
