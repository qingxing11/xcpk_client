using System;
using System.Collections.Generic;
using FairyGUI;
using TenThousandField;
using WT.UI;
using UnityEngine;

public class UITenThousandUpDeskList : WTUIPage<UI_UpBankerList, TenThousandRoomCtrl>
{
    public Action requestUpBanker;
    public Action requestDownBanker;
    public UITenThousandUpDeskList() : base(UIType.PopUp, UIMode.DoNothing, R.UI.TENTHOUSANDFIELD)
    {
    }
    public override void Awake()
    {
        UIPage.m_upBanker.onClick.Add(() =>
        {
            requestUpBanker();
            Hide();
        });
        UIPage.m_downBanker.onClick.Add(() =>
        {
            requestDownBanker();
            Hide();
        });
        UIPage.m_btn_close.onClick.Add(Hide);

        UIPage.m_playerList.itemRenderer = PlayerItemRenderer;
    }

    private void PlayerItemRenderer(int index, GObject item)
    {
        UI_playerSinpleInfo uI_Player = (UI_playerSinpleInfo)item;
        PlayerSimpleData playerSimpleData = BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList[index];
        
        uI_Player.m_name.text = playerSimpleData.nickName;
        uI_Player.m_coinNum.text = ToolClass.LongConverStr(playerSimpleData.coins);
        uI_Player.m_shunXu.text = index + 1 + "";
    }

    public void SetPlayerListInfo()
    {
        if (UIPage != null && isActive())
        {
            if (BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList == null || BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList.Count <= 0)
            {
                UIPage.m_playerList.numItems = 0;
                return;
            }
            UIPage.m_playerList.numItems = BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList.Count;
        }
       
    }
    public override void Refresh()
    {
        SetPlayerBtnSelectIndex();
    }
    public void SetPlayerBtnSelectIndex()
    {
        bool inUpBankerList = false;
        if (BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList != null)
        {
            foreach (PlayerSimpleData item in BaseCanvas.GetController<TenThousandRoomCtrl>().list_upBankerList)
            {
                if (item.userId == CacheManager.gameData.userId)
                {
                    inUpBankerList = true;
                    break;
                }
            }
        }
        bool inTable = false;
        if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
            inTable = true;

        if (inUpBankerList||inTable)
        {
            UIPage.m_upOrDown.selectedIndex = 2;
            return;
        }
        

        if (CacheManager.gameData.coins >= 5000000)
        {
            UIPage.m_upOrDown.selectedIndex = 0;
        }
        else
        {
            UIPage.m_upOrDown.selectedIndex = 1;
        }
    }

    public override void Hide()
    {
        base.Hide();
    }
}