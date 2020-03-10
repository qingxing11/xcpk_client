using Classic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIReturnPanelClassic : WTUIPage<UI_ReturnPanelClassic, ClassicRoomCtrl>
{
    public UIReturnPanelClassic() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CLASSIC)
    { }

    public Action ActionLeave;  //离开游戏
    public Action ActionSet;    //设置
    public Action ActionHuanZuo;//换桌
    public Action ActionHelp;

    public override void Awake()
    {
        UIPage.m_btn_return.onClick.Add(() => { ActionLeave?.Invoke(); }); //返回大厅
        UIPage.m_btn_set.onClick.Add(() => { ActionSet?.Invoke(); });      //设置
        UIPage.m_btn_huanzuo.onClick.Add(() => { ActionHuanZuo?.Invoke(); });
        UIPage.m_btn_help.onClick.Add(() => { ActionHelp?.Invoke(); });//帮助
    }

    public void Init()
    {
        UIPage.SetPosition(0, -174, 0);
        UIPage.TweenMoveY(0, 0.35f);
    }

    public override void Hide()
    {
        if (UIPage != null && isActive())
        {
            UIPage.TweenMoveY(-174, 0.35f).OnComplete(() =>
            {
                base.Hide();
            });
        }
    }
    public void HideNow()
    { 
        UIPage.SetPosition(0, -174, 0);
        base.Hide();
    }
}
