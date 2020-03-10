using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenThousandField;
using WT.UI;
using UnityEngine;
using FairyGUI;

public class UIWin : WTUIPage<UI_win, TenThousandRoomCtrl>
{
    public UIWin() : base(UIType.Normal, UIMode.DoNothing, R.UI.TENTHOUSANDFIELD)
    {
    }

    public override void Awake()
    {
        UIPage.m_click.onClick.Add(Hide);
        UIPage.m_btnReady.onClick.Add(Hide);
    }

    public override void Refresh()
    {
        UIPage.m_pos1.m_havePlayer.selectedIndex = 1;
        UIPage.m_pos2.m_havePlayer.selectedIndex = 1;
        UIPage.m_pos3.m_havePlayer.selectedIndex = 1;
        UIPage.m_pos4.m_havePlayer.selectedIndex = 1;
        UIPage.m_pos5.m_havePlayer.selectedIndex = 1;
    }

    public void SetPlayerWinOrLossInfo(List<GameRoundDataVO> list_info)
    {
        if (!isActive())
        {
            return;
        }
        PlayerSimpleData playerSelf = null;
        if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            playerSelf = CacheManager.ManyPeopleRoomPlayers[0];
        }
        foreach (GameRoundDataVO item in list_info)
        {
            //PlayerSimpleData player = BaseCanvas.GetController<TenThousandRoomCtrl>().GetCurrentPosPlayer(item.pos);
            PlayerSimpleData player = CacheManager.ManyPeopleRoomPlayers[ToolClass.AbsToRelThous(item.pos)];
            if (player == null)
            {
                Debug.LogError("结算时 player为空:" + player);
                continue;
            }
            SetInfo(item, player.nickName);

            if (playerSelf == null)
            {
                continue;
            }
            if (playerSelf.userId == player.userId)
            {
                if (item.roundBet > 0)
                {
                    UIPage.m_win.selectedIndex = 0;
                }
                else
                {
                    UIPage.m_win.selectedIndex = 1;
                }
            }
        }


    }

    private void SetInfo(GameRoundDataVO item, string nickName)
    {
        UI_winOrLoss winOrLoss = UIPage.GetChild("pos" + (item.pos + 1)) as UI_winOrLoss;
        winOrLoss.m_havePlayer.selectedIndex = 0;
        if (item.roundBet > 0)
        {
            winOrLoss.m_have.m_winOrLoss.selectedIndex = 0;
            if (item.roundBet > 10000)
            {
                winOrLoss.m_have.m_winTxt.text = "+" + item.roundBet;
            }
            else
            {
                winOrLoss.m_have.m_winTxt.text = "+" + item.roundBet;
            }
        }
        else
        {
            winOrLoss.m_have.m_winOrLoss.selectedIndex = 1;
            if (Mathf.Abs(item.roundBet) > 10000)
            {
                winOrLoss.m_have.m_lossTxt.text = "-" + Mathf.Abs(item.roundBet);
            }
            else
            {
                winOrLoss.m_have.m_lossTxt.text = "-" + Mathf.Abs(item.roundBet);
            }
        }



        winOrLoss.m_have.m_icon.texture = new NTexture(item.headIcon);


        //winOrLoss.m_have.m_pokerType.selectedIndex = item.pokerType - 1;
        winOrLoss.m_have.m_name.text = nickName;
        winOrLoss.m_have.m_card1.texture = new NTexture(Pokers.GetPokerFace(item.list_handPoker[0].value));
        winOrLoss.m_have.m_card2.texture = new NTexture(Pokers.GetPokerFace(item.list_handPoker[1].value));
        winOrLoss.m_have.m_card3.texture = new NTexture(Pokers.GetPokerFace(item.list_handPoker[2].value));
    }
}