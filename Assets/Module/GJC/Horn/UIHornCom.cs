using FairyGUI;
using Horn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UIHornCom:WTUIPage<UI_HornCom,HornCtrl>
{
    public Action<string> sendInfo;
    public UIHornCom() : base(UIType.Dialog, UIMode.DoNothing, R.UI.HORN)
    {

    }

    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_cancel.onClick.Add(Cancel);
        UIPage.m_btn_sure.onClick.Add(SendInfo);
    }
    public override void Refresh()
    {
        base.Refresh();
        UIPage.m_txt_title.text = "发送喇叭每次扣除"+ConfigManager.Configs.DataVip[CacheManager.gameData.vipLv].HornMoney+"金币";
    }

    private void SendInfo(EventContext context)
    {
        string info = UIPage.m_txt_info.text;
        Debug.Log("发送消息！！！！");
        if (!string.IsNullOrEmpty(info))
        {
            sendInfo(info);
            UIPage.m_txt_info.text="";
        }
    }

    private void Cancel(EventContext context)
    {
        UIPage.m_txt_info.text = "";
        Hide();
    }
}
