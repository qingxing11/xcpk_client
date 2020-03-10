using FairyGUI;
using SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UISignInCom:WTUIPage<UI_SignInCom,SignCtrl>
{
    private int num = 7;//七天
    public Action<int> sign;//签到
    public Action showShopComInVip;//商城界面
    public UISignInCom() : base(UIType.PopUp, UIMode.DoNothing, R.UI.SIGNIN)
    {

    }

    public override void Awake()
    {
        UIPage.m_list_sign.itemRenderer = ItemRenderer;
        UIPage.m_list_sign.numItems = 0;
        //UIPage.m_list_sign.onClickItem.Add(OnClickItem);
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_coin.onClick.Add(OnClickCoin);//领取
        UIPage.m_btn_Vip.onClick.Add(()=> showShopComInVip());
    }

    public override void Refresh()
    {
        base.Refresh();
        RefreshList();
        RefreshTxt();
        BtnCoinIsShow();
    }

    /// <summary>
    /// 签到按钮显隐
    /// </summary>
    public void BtnCoinIsShow()
    {
        if (!CacheManager.todayIsSign)//不可以签到
        {
            UIPage.m_btn_coin.visible = false;
        }
    }

    private void OnClickCoin()
    {
        int index = 0;
        foreach (var item in CacheManager.signList)
        {
            if (item)
            {
                index++;
            }
            else
            {
                break;
            }
        }

        if (!CacheManager.todayIsSign)//不可以签到
        {
            return;
        }

        if (CacheManager.signList[index])//已经签到
        {
            //Debug.Log("已经签到");
            //ui.selected = true;
            return;
        }

        if (index >= 0)
        {
            if (index > 0 && !CacheManager.signList[index - 1])//前一天没有签到
            {
                return;
            }
            sign(index + 1);
        }
    }

    private void OnClickItem(EventContext context)
    {
        UI_btn_Sign ui = (UI_btn_Sign)context.data;
        int index = UIPage.m_list_sign.GetChildIndex(ui);

        if (!CacheManager.todayIsSign)//不可以签到
        {
            return;
        }

        if (CacheManager.signList[index])//已经签到
        {
            //Debug.Log("已经签到");
            //ui.selected = true;
            return;
        }
      
        if (index>=0)
        {
            if (index>0&&!CacheManager.signList[index-1])//前一天没有签到
            {
                return;
            }
            sign(index + 1);
        }
    }

    private void ItemRenderer(int index, GObject item)
    {
        UI_btn_Sign ui=(UI_btn_Sign)item;
        ui.m_c1.selectedIndex = index;
        int addMoney = 0;
        if (ConfigManager.Configs.DataVipSign.ContainsKey(CacheManager.gameData.vipLv))
        {
            addMoney = ConfigManager.Configs.DataVipSign[CacheManager.gameData.vipLv].AddMoney;
        }
        ui.m_txt_number.text =(ConfigManager.Configs.DataSign[index + 1].AddMoney+addMoney).ToString();
        if (CacheManager.signList!=null)
        {
            bool sign = CacheManager.signList[index];
            ui.m_n9.visible = sign;
        }
    }

    public void RefreshList()
    {
        Debug.Log("刷新界面："+ CacheManager.signList.Count);
        UIPage.m_list_sign.numItems =7;
    }

    public void RefreshTxt()
    {
        int addMoney = 0;
        if (ConfigManager.Configs.DataVipSign.ContainsKey(CacheManager.gameData.vipLv))
        {
            addMoney = ConfigManager.Configs.DataVipSign[CacheManager.gameData.vipLv].AddMoney;
        }
        UIPage.m_txt_vip.text = "您当前VIP等级为VIP"+ CacheManager.gameData.vipLv+"，额外奖励+"+ addMoney;
    }
}
