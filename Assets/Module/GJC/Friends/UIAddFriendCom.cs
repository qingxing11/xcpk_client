using Common;
using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;

public class UIAddFriendCom : WTUIPage<UI_AddFriendsCom, FriendCtrl>
{
    public Action sure;
    public Action refuse;
    public UIAddFriendCom() : base(UIType.PopUp, UIMode.DoNothing, R.UI.COMMON)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_sure.onClick.Add(BtnSure);
        UIPage.m_btn_refuse.onClick.Add(BtnRefuse);
    }

    private void BtnRefuse(EventContext context)
    {
        refuse();
        Hide();
    }

    private void BtnSure(EventContext context)
    {
        sure();
        Hide();
    }
}
