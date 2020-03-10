using Main;
using System.Collections.Generic;
using FairyGUI;
using WT.UI;
using System;
using UnityEngine;

public class UIRanking2 : WTUIPage<UI_Ranking_lqjl, NetCtrl>
{
    public Action<int> ActionLingqu;
    private List<RankVO> BigWinRank;
    /// <summary> 
    /// 0：充值榜  1：赢金榜
    /// </summary>
    private int selectIndex;
    public UIRanking2() : base(UIType.Dialog, UIMode.DoNothing, R.UI.MAIN)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
        UIPage.m_btn_lingqu.onClick.Add(() =>
        {
            ActionLingqu?.Invoke(selectIndex);
        });

        UIPage.m_rankList.itemRenderer = SetRankIten;


    }


    internal void Init(int selectIndex)
    {
        this.selectIndex = selectIndex;
        if (selectIndex == 0)
        {
            UIPage.m_c1.SetSelectedIndex(0);
            BigWinRank = CacheManager.PayRank;
        }
        else
        {
            UIPage.m_c1.SetSelectedIndex(1);
            BigWinRank = CacheManager.BigWinRank;
        }

        UIPage.m_rankList.numItems = BigWinRank.Count;

        int ranIndex = -1;
        for (int i = 0; i < BigWinRank.Count && i < 15; i++)
        {
            if (BigWinRank[i].userId == CacheManager.gameData.userId)
            {
                ranIndex = BigWinRank[i].rank;
            }
        }
        if (selectIndex == 0)//充值榜
        {
            UIPage.m_rankList.numItems = 3;
            if (CacheManager.isGetPay)
            {
                UIPage.m_c2.SetSelectedIndex(1);
            }
            else
            {
                UIPage.m_c2.SetSelectedIndex(0);
            }
        }
        else
        {
            if (CacheManager.isGetWin)
            {
                UIPage.m_c2.SetSelectedIndex(1);
            }
            else
            {
                UIPage.m_c2.SetSelectedIndex(0);
            }
        }
        if (ranIndex != -1)
        {
            UIPage.m_text_paiming.text = (ranIndex + 1).ToString();
            UIPage.m_btn_lingqu.grayed = false;
            UIPage.m_btn_lingqu.touchable = true;
        }
        else
        {

            UIPage.m_text_paiming.text = "未上榜";
            UIPage.m_btn_lingqu.grayed = true;
            UIPage.m_btn_lingqu.touchable = false;
        }
    }

    private void SetRankIten(int index, GObject item)
    {
        RankVO rankVO = BigWinRank[index];
        UI_rankBtn ui_RankBtn = (UI_rankBtn)item;

        if (rankVO.rank < 3)
        {
            ui_RankBtn.m_c1.SetSelectedIndex(rankVO.rank + 1);
        }
        else
        {
            ui_RankBtn.m_text_rank.text = (rankVO.rank + 1).ToString();
            ui_RankBtn.m_c1.SetSelectedIndex(0);
        }
        ui_RankBtn.m_text_call.text = ToolClass.Grading(rankVO.level);
        ui_RankBtn.m_text_nickname.text = rankVO.nickName;
        if (selectIndex == 1)
        {
            ui_RankBtn.m_n12.text = (rankVO.score / 50).ToString();
        }
        else
        {
            if(rankVO.rank==0)
                ui_RankBtn.m_n12.text = ToolClass.LongConverStr(rankVO.score*10000);
            else if (rankVO.rank == 1)
                ui_RankBtn.m_n12.text = ToolClass.LongConverStr(rankVO.score * 10000/2);
            else if (rankVO.rank == 2)
                ui_RankBtn.m_n12.text = ToolClass.LongConverStr(rankVO.score * 10000 / 5);
            else
                ui_RankBtn.m_n12.text = ToolClass.LongConverStr(0);
        }
    }
}