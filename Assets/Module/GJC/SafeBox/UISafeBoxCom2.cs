using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;
using Safebox;
using FairyGUI;
using UnityEngine;

public class UISafeBoxCom2 : WTUIPage<UI_SafeBoxCom2, SafeBoxCtrl>
{
    public Action<long> fetchSafeBox;//取出银行

    public UISafeBoxCom2() : base(UIType.Dialog, UIMode.DoNothing, R.UI.SAFEBOX)
    {

    }

    public override void Awake()
    {
        UIPage.m_txt_input.text = "";
        UIPage.m_btn_Close.onClick.Add(Hide);//关闭
        UIPage.m_btn_Fetch.onClick.Add(Fetch);//取出

    }

    public void OnClickMyBox()
    {
        UIPage.m_txt_boxBalance.text = CacheManager.GetBankCoin().ToString() + "万";
        UIPage.m_txt_cashBalance.text = CacheManager.GetCoin().ToString() + "万";
    }

    public bool TheStringIsOk(string txt)
    {
        foreach (var cha in txt)
        {
            if (!(cha >= '0' && cha <= '9'))
            {
                return false;
            }
        }
        return true;
    }

    private void Fetch(EventContext context)
    {
        Debug.Log("取出金币");
        string txt = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(txt) || (!TheStringIsOk(txt)))
        {
            return;
        }
        long money = long.Parse(UIPage.m_txt_input.text);
        Debug.Log("取出金币消息" + money);
        fetchSafeBox(money);
        UIPage.m_txt_input.text = "";//清空
    }

    public override void Refresh()
    {
        base.Refresh();
        OnClickMyBox();
    }

}
