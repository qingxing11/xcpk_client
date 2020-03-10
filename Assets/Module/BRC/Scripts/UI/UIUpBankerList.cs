using FairyGUI;
using Room;
using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using UpBankerList;
/// <summary>
/// 上庄列表
/// </summary>
public class UIUpBankerList : WTUIPage<UI_UpBankerList, UpBankerListCtrl>
{
    public Action ActionUpBank;


    private List<PlayerSimpleData> list_bankerList;



    public UIUpBankerList() : base(UIType.PopUp, UIMode.HideOther, R.UI.UPBANKERLIST)
    {
    }
    public override void Awake()
    {
        UIPage.m_btn_upbank.onClick.Add(() => { ActionUpBank?.Invoke(); });
    }
    public override void Refresh()
    {
        if (BaseCanvas.GetController<RoomCtrl>().InUpBankerList()||BaseCanvas.GetController<RoomCtrl>().IsBanker())
        {
            UIPage.m_btn_upbank.title = "申请下庄";
        }
        else
            UIPage.m_btn_upbank.title = "申请上庄";
    }

    internal void Init()
    {
        List<PlayerSimpleData> list_bankerList = CacheManager.List_bankerList;
        list_bankerList.Sort((x1, x2) => { return (x2.coins.CompareTo(x1.coins)); });
        if (list_bankerList == null || list_bankerList.Count <= 0)
        {
            UIPage.m_list.numItems = 0;
        }
        else
        {
            this.list_bankerList = list_bankerList;
            UIPage.m_list.itemRenderer = SetIten;
            UIPage.m_list.numItems = list_bankerList.Count;
        }
        if (BaseCanvas.GetController<RoomCtrl>().InUpBankerList() || BaseCanvas.GetController<RoomCtrl>().IsBanker())
        {
            UIPage.m_btn_upbank.title = "申请下庄";
        }
        else
        {
            UIPage.m_btn_upbank.title = "申请上庄";
        }
    }

    private void SetIten(int index, GObject item)
    {
        PlayerSimpleData playerSimpleData = list_bankerList[index];
        UI_BankItem uI_UpBankeritem = (UI_BankItem)item;
        uI_UpBankeritem.m_text_num.text = (index + 1).ToString();
        uI_UpBankeritem.m_text_nickname.text = playerSimpleData.nickName;
        uI_UpBankeritem.m_text_conis.text = ToolClass.LongConverStr(playerSimpleData.coins);
    }


    public override void Hide()
    {
        base.Hide();
    }
}