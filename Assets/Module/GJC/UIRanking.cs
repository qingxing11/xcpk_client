using FairyGUI;
using Main;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIRanking : WTUIPage<UI_Ranking, NetCtrl>
{
    public Action<int> ActionLingjiang;

    private List<RankVO> Ranks;

    private int selectIndex = 0;

    public UIRanking() : base(UIType.Dialog, UIMode.DoNothing, R.UI.MAIN)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_btn_pay.onClick.Add(() => { SetBtnIndex(0); });
        UIPage.m_btn_win.onClick.Add(() => { SetBtnIndex(1); });
        UIPage.m_btn_wealth.onClick.Add(() => { SetBtnIndex(2); });
        UIPage.m_btn_chakan.onClick.Add(() => { ActionLingjiang?.Invoke(selectIndex); });
        SetListItem(UIPage.m_c1.selectedIndex);
    }

    private void SetBtnIndex(int btnIndex)
    {
        UIPage.m_c1.SetSelectedIndex(btnIndex);
        selectIndex = btnIndex;
        SetListItem(btnIndex);
    }
    private void SetListItem(int btnIndex)
    {
        switch (btnIndex)
        {
            case 0:
                Ranks = CacheManager.PayRank;
                break;
            case 1:
                Ranks = CacheManager.BigWinRank;
                break;
            case 2:
                Ranks = CacheManager.CoinsRank;
                break;
            default:
                break;
        }
        UIPage.m_rankList.itemRenderer = SetRankIten;
        UIPage.m_rankList.numItems = Ranks.Count;
    }

    private void SetRankIten(int index, GObject item)
    {
        RankVO rankVO = Ranks[index];
        UI_rankBtn ui_RankBtn = (UI_rankBtn)item;

        if (rankVO.rank < 3)
        {
            ui_RankBtn.m_c1.SetSelectedIndex(rankVO.rank+1);
        }
        else
        {
            ui_RankBtn.m_text_rank.text = (rankVO.rank+1).ToString();
            ui_RankBtn.m_c1.SetSelectedIndex(0);
        }
        ui_RankBtn.m_text_call.text = ToolClass.Grading(rankVO.level);
        ui_RankBtn.m_text_nickname.text = rankVO.nickName;
        ui_RankBtn.m_n12.text = ToolClass.LongConverStr(rankVO.score);
    }

    public override void Refresh()
    {
        

        base.Refresh();
    }
}