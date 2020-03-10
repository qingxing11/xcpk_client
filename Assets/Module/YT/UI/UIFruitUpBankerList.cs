using FairyGUI;
using FruitMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UIFruitUpBankerList : WTUIPage<UI_UpBankerList, FruitMechineCtrl>
{
    public Action requestUpBanker;
    public Action requestDownBanker;
    private List<PlayerSimpleData> list_currentRoomeBankerplayers = new List<PlayerSimpleData>();
    public UIFruitUpBankerList() : base(UIType.PopUp, UIMode.DoNothing, R.UI.FRUITMACHINE)
    {
    }



    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_upBanker.onClick.Add(() => { requestUpBanker(); Hide(); });
        UIPage.m_btn_downBanker.onClick.Add(() => { requestDownBanker(); Hide(); });
        UIPage.m_players.itemRenderer = ListRenderer;
        UIPage.m_players.numItems = 0;
    }

    private void ListRenderer(int index, GObject item)
    {
        Debug.Log("回调函数 index " + index);
        UI_BankItem bankeritem = (UI_BankItem)item;
        PlayerSimpleData playerSimpleData = list_currentRoomeBankerplayers[index];
        bankeritem.m_text_conis.text = ToolClass.LongConverStr(playerSimpleData.coins);
        bankeritem.m_text_nickname.text = playerSimpleData.nickName;
        bankeritem.m_text_num.text = "" + index + 1;
    }

    //public override void Refresh()
    //{
    //    UpdateBankerList(list_currentRoomeBankerplayers);
    //}


    public void UpdateBankerList(List<PlayerSimpleData> players)
    {
        Debug.Log("UpdateBankerList---->players:"+ players.GetString());
        if (!isActive())
        {
            return;
        }

        

        if (players == null)//上庄列表空
        {
            UIPage.m_players.numItems = 0;

            ChangeZhungjiaBtn();
        }
        else
        {
            list_currentRoomeBankerplayers = players;
            
            UIPage.m_players.numItems = players.Count;
            

            bool isHave = false;

            foreach (PlayerSimpleData item in players)
            {
                if (item.userId == CacheManager.gameData.userId)
                {
                    isHave = true;
                    break;
                }
            }

            Debug.Log("isHave:" + isHave);
            if (isHave)//在上庄列表
            {
                UIPage.m_upOrDownBanker.selectedIndex = 1;
            }
            else
            {
                ChangeZhungjiaBtn();
            }
        }
      
    }

    private bool IsMineBanker()
    {
        if (isActive())
        {
            PlayerSimpleData banker = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();
            if (banker != null)
            {
                if (banker.userId == CacheManager.gameData.userId)//自己是庄家
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void ChangeZhungjiaBtn()
    {
        if (isActive())
        {
            PlayerSimpleData banker = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();
            if (banker != null)
            {
                if (banker.userId == CacheManager.gameData.userId)//自己是庄家
                {
                    UIPage.m_upOrDownBanker.selectedIndex = 1;
                }
                else
                {
                    UIPage.m_upOrDownBanker.selectedIndex = 0;//显示上桌
                }
            }
            else
            {
                UIPage.m_upOrDownBanker.selectedIndex = 0;//显示上桌
            }
        }
    }
}