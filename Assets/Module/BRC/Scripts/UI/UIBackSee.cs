using TenThousandField;
using WT.UI;
using System.Collections.Generic;
using FairyGUI;
using System;
using UnityEngine;

public class UIBackSee : WTUIPage<UI_backSee, TenThousandRoomCtrl>
{
    private List<BackSeeRoundData> list_backSeeRoundData;

    public UIBackSee() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CLASSIC)
    { }

    public override void Awake()
    {
        UIPage.onClick.Add(base.Hide);
    }
    public void Init(List<BackSeeRoundData> list_backSeeRoundData)
    {
        this.list_backSeeRoundData = list_backSeeRoundData;
        UIPage.m_n3.itemRenderer = ListRender;
        UIPage.m_n3.numItems = list_backSeeRoundData.Count;
        Debug.Log("Init list_backSeeRoundData.cout "+ list_backSeeRoundData.Count);
    }

    private void ListRender(int index, GObject item)
    {
        BackSeeRoundData backSeeRoundData = list_backSeeRoundData[index];

        UI_backSeeItem uI_BackSeeItem = (UI_backSeeItem)item;
        uI_BackSeeItem.m_icon.texture = new NTexture(backSeeRoundData.icon);
        if (backSeeRoundData.roundBet > 0)
        {
            uI_BackSeeItem.m_winOrLoss.SetSelectedIndex(0);
            uI_BackSeeItem.m_winTxt.text ="+"+ Math.Abs(backSeeRoundData.roundBet);
        }
        else
        {
            uI_BackSeeItem.m_winOrLoss.SetSelectedIndex(1);
            uI_BackSeeItem.m_lossTxt.text ="-"+ Math.Abs(backSeeRoundData.roundBet);
        }
        uI_BackSeeItem.m_name.text = backSeeRoundData.nickName;

        if (backSeeRoundData.list_handPoker != null && backSeeRoundData.list_handPoker.Count > 0)
        {
            uI_BackSeeItem.m_card1.texture = new NTexture(Pokers.GetPokerFace(backSeeRoundData.list_handPoker[0].value));
            uI_BackSeeItem.m_card2.texture = new NTexture(Pokers.GetPokerFace(backSeeRoundData.list_handPoker[1].value));
            uI_BackSeeItem.m_card3.texture = new NTexture(Pokers.GetPokerFace(backSeeRoundData.list_handPoker[2].value));
        }
        else
        {
            uI_BackSeeItem.m_card1.texture = new NTexture(Pokers.GetPokerFace(R.SpritePack.CARDS_CARD00));
            uI_BackSeeItem.m_card2.texture = new NTexture(Pokers.GetPokerFace(R.SpritePack.CARDS_CARD00));
            uI_BackSeeItem.m_card3.texture = new NTexture(Pokers.GetPokerFace(R.SpritePack.CARDS_CARD00));
        }

    }
}