using FairyGUI;
using Room;
using System;
using System.Collections.Generic;
using WT.UI;

/// <summary>
/// 走势
/// </summary>
public class UITrend : WTUIPage<UI_TrendCom, TrendCtrl>
{

    public UITrend() : base(UIType.PopUp, UIMode.HideOther, R.UI.ROOM)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_close.onClick.Add(base.Hide);
    }

    public override void Refresh()
    {
        UIPage.m_vrOrls.m_list_banker.itemRenderer = SetBankItem;
        UIPage.m_vrOrls.m_list_banker.numItems = CacheManager.List_bankerWin.Count;

        UIPage.m_vrOrls.m_list_east.itemRenderer = SetDongItem;
        UIPage.m_vrOrls.m_list_east.numItems = CacheManager.List_dongWin.Count;

        UIPage.m_vrOrls.m_list_west.itemRenderer = SetXiItem;
        UIPage.m_vrOrls.m_list_west.numItems = CacheManager.List_xiWin.Count;

        UIPage.m_vrOrls.m_list_south.itemRenderer = SetNanItem;
        UIPage.m_vrOrls.m_list_south.numItems = CacheManager.List_nanWin.Count;

        UIPage.m_vrOrls.m_list_north.itemRenderer = SetBeiItem;
        UIPage.m_vrOrls.m_list_north.numItems = CacheManager.List_beiWin.Count;
    }
    private void SetBankItem(int index, GObject item)
    {
        UI_victoryOrloser uI_VictoryOrloser = (UI_victoryOrloser)item;
        if (CacheManager.List_bankerWin[CacheManager.List_bankerWin.Count - index - 1])
            uI_VictoryOrloser.m_c1.SetSelectedIndex(2);
        else
            uI_VictoryOrloser.m_c1.SetSelectedIndex(1);
    }
    private void SetDongItem(int index, GObject item)
    {
        UI_victoryOrloser uI_VictoryOrloser = (UI_victoryOrloser)item;
        if (CacheManager.List_dongWin[CacheManager.List_dongWin.Count - index - 1])
            uI_VictoryOrloser.m_c1.SetSelectedIndex(0);
        else
            uI_VictoryOrloser.m_c1.SetSelectedIndex(1);
    }
    private void SetXiItem(int index, GObject item)
    {
        UI_victoryOrloser uI_VictoryOrloser = (UI_victoryOrloser)item;
        if (CacheManager.List_xiWin[CacheManager.List_xiWin.Count - index - 1])
            uI_VictoryOrloser.m_c1.SetSelectedIndex(0);
        else
            uI_VictoryOrloser.m_c1.SetSelectedIndex(1);
    }

    private void SetNanItem(int index, GObject item)
    {
        UI_victoryOrloser uI_VictoryOrloser = (UI_victoryOrloser)item;
        if (CacheManager.List_nanWin[CacheManager.List_nanWin.Count - index - 1])
            uI_VictoryOrloser.m_c1.SetSelectedIndex(0);
        else
            uI_VictoryOrloser.m_c1.SetSelectedIndex(1);
    }


    private void SetBeiItem(int index, GObject item)
    {
        UI_victoryOrloser uI_VictoryOrloser = (UI_victoryOrloser)item;
        if (CacheManager.List_beiWin[CacheManager.List_beiWin.Count - index - 1])
            uI_VictoryOrloser.m_c1.SetSelectedIndex(0);
        else
            uI_VictoryOrloser.m_c1.SetSelectedIndex(1);
    }
}