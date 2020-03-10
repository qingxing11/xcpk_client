using FairyGUI;
using Room;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class UIPokers : WTUIPage<UI_PokersTV, RoomCtrl>
{
    public Action<float, KillRoomLog, long> ActionShowPoker;

    private List<PokerVO> list_bankerPoker;   //庄家手牌
    private KillRoomDirectionPlayer[] killRoomDirectionPlayers = new KillRoomDirectionPlayer[4]; //其他玩家手牌
    private int pokerType;   //庄家手牌类型

    public UIPokers() : base(UIType.Normal, UIMode.DoNothing, R.UI.ROOM)
    { }

    public void Set(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
    }

    public override void Refresh()
    {
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[0] == 0)
            UIPage.m_pokers.m_text_gold0.text = "";
        else
            UIPage.m_pokers.m_text_gold0.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[0]);
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[1] == 0)
            UIPage.m_pokers.m_text_gold1.text = "";
        else
            UIPage.m_pokers.m_text_gold1.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[1]);
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[2] == 0)
            UIPage.m_pokers.m_text_gold2.text = "";
        else
            UIPage.m_pokers.m_text_gold2.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[2]);
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[3] == 0)
            UIPage.m_pokers.m_text_gold3.text = "";
        else
            UIPage.m_pokers.m_text_gold3.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[3]);
    }
    /// <summary>
    /// 发牌动画
    /// </summary>
    public void DealCard(List<PokerVO> list_bankerPoker, KillRoomLog killRoomLog, List<KillRoomDirectionPlayer> list_directionPlayers, int pokerType, long isJackpot)
    {
        this.list_bankerPoker = list_bankerPoker;
        for (int i = 0; i < list_directionPlayers.Count; i++)
        {
            KillRoomDirectionPlayer killRoomDirectionPlayer = list_directionPlayers[i];
            this.killRoomDirectionPlayers[killRoomDirectionPlayer.pos] = killRoomDirectionPlayer;
        }
        this.pokerType = pokerType;

        UIPage.m_pokers.m_card_back1.visible = true;
        UIPage.m_pokers.m_card_back2.visible = true;
        UIPage.m_pokers.m_card_back3.visible = true;

        if (CacheManager.KillRoomTV == 0)
        {
            BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
        }

        UIPage.m_pokers.m_CardsAnim0.Play();
        UIPage.m_pokers.m_CardsAnim0.SetHook("over", () =>
        {
            UIPage.m_pokers.m_cards0.visible = true;

            UIPage.m_pokers.m_CardsAnim1.Play();
            if (CacheManager.KillRoomTV == 0)
            {
                BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
            }
        });
        UIPage.m_pokers.m_CardsAnim1.SetHook("over", () =>
        {
            UIPage.m_pokers.m_cards1.visible = true;

            UIPage.m_pokers.m_CardsAnim2.Play();
            if (CacheManager.KillRoomTV == 0)
            {
                BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
            }
        });
        UIPage.m_pokers.m_CardsAnim2.SetHook("over", () =>
        {
            UIPage.m_pokers.m_cards2.visible = true;

            UIPage.m_pokers.m_CardsAnim3.Play();
            if (CacheManager.KillRoomTV == 0)
            {
                BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
            }
        });
        UIPage.m_pokers.m_CardsAnim3.SetHook("over", () =>
        {
            UIPage.m_pokers.m_cards3.visible = true;

            UIPage.m_pokers.m_CardsAnim4.Play();
            if (CacheManager.KillRoomTV == 0)
            {
                BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
            }
        });

       
        UIPage.m_pokers.m_CardsAnim4.SetHook("over", () =>
        {
            UIPage.m_pokers.m_cards4.visible = true;

            UIPage.m_pokers.m_card_back1.visible = false;
            UIPage.m_pokers.m_card_back2.visible = false;
            UIPage.m_pokers.m_card_back3.visible = false;
            ActionShowPoker?.Invoke(0.8f, killRoomLog, isJackpot);
        });
    }


    /// <summary>
    /// 清空扑克牌
    /// </summary>
    public IEnumerator ClosePokerFace()
    {
        yield return new WaitForSeconds(14f);
        ClearPokers();
        CacheManager.killRoom.ClearPayBet();
    }

    private void ClearPokers()
    {
        UIPage.m_pokers.m_CardType0.visible = false;
        UIPage.m_pokers.m_CardType1.visible = false;
        UIPage.m_pokers.m_CardType2.visible = false;
        UIPage.m_pokers.m_CardType3.visible = false;
        UIPage.m_pokers.m_CardType4.visible = false;

        UIPage.m_pokers.m_cards0.visible = false;
        UIPage.m_pokers.m_cards1.visible = false;
        UIPage.m_pokers.m_cards2.visible = false;
        UIPage.m_pokers.m_cards3.visible = false;
        UIPage.m_pokers.m_cards4.visible = false;

        UIPage.m_pokers.m_cards1.m_n3.visible = false;
        UIPage.m_pokers.m_cards2.m_n3.visible = false;
        UIPage.m_pokers.m_cards3.m_n3.visible = false;
        UIPage.m_pokers.m_cards4.m_n3.visible = false;

        UIPage.m_pokers.m_cards0.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards0.m_n1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards0.m_n2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards1.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards1.m_n1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards1.m_n2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards2.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards2.m_n1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards2.m_n2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards3.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards3.m_n1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards3.m_n2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards4.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards4.m_n1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_cards4.m_n2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDS_CARD00));
        UIPage.m_pokers.m_winordef0.visible = false;
        UIPage.m_pokers.m_winordef1.visible = false;
        UIPage.m_pokers.m_winordef2.visible = false;
        UIPage.m_pokers.m_winordef3.visible = false;
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum != null)
        {
            BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[0] = 0;
            BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[1] = 0;
            BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[2] = 0;
            BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[3] = 0;
        }

        UIPage.m_pokers.m_text_gold0.text = "";
        UIPage.m_pokers.m_text_gold1.text = "";
        UIPage.m_pokers.m_text_gold2.text = "";
        UIPage.m_pokers.m_text_gold3.text = "";

       
    }

    /// <summary>
    /// 给扑克牌牌面赋值
    /// </summary>
    /// <param name="timer"></param>
    /// <returns></returns>
    public IEnumerator IEShowPoker(float timer, KillRoomLog killRoomLog)
    {
        int index = 0;
        if (CacheManager.KillRoomTV == 0)
        {
            BaseCanvas.PlaySound(R.AudioClip.SOUND_FAPAI);
        }
        while (index < 5)
        {

            switch (index)
            {
                case 0:
                    KillRoomDirectionPlayer killRoomDirectionPlayer0 = killRoomDirectionPlayers[0];
                    UIPage.m_pokers.m_cards1.m_n0.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer0.list_poker[0].value));
                    UIPage.m_pokers.m_cards1.m_n1.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer0.list_poker[1].value));
                    UIPage.m_pokers.m_cards1.m_n2.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer0.list_poker[2].value));
                    UIPage.m_pokers.m_CardType1.texture = new NTexture(Pokers.GetPokerType(killRoomDirectionPlayer0.pokerType - 1));
                    UIPage.m_pokers.m_CardType1.visible = true;
                    break;
                case 1:
                    KillRoomDirectionPlayer killRoomDirectionPlayer1 = killRoomDirectionPlayers[1];
                    UIPage.m_pokers.m_cards2.m_n0.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer1.list_poker[0].value));
                    UIPage.m_pokers.m_cards2.m_n1.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer1.list_poker[1].value));
                    UIPage.m_pokers.m_cards2.m_n2.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer1.list_poker[2].value));
                    UIPage.m_pokers.m_CardType2.texture = new NTexture(Pokers.GetPokerType(killRoomDirectionPlayer1.pokerType - 1));
                    UIPage.m_pokers.m_CardType2.visible = true;
                    break;
                case 2:
                    KillRoomDirectionPlayer killRoomDirectionPlayer2 = killRoomDirectionPlayers[2];
                    UIPage.m_pokers.m_cards3.m_n0.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer2.list_poker[0].value));
                    UIPage.m_pokers.m_cards3.m_n1.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer2.list_poker[1].value));
                    UIPage.m_pokers.m_cards3.m_n2.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer2.list_poker[2].value));
                    UIPage.m_pokers.m_CardType3.texture = new NTexture(Pokers.GetPokerType(killRoomDirectionPlayer2.pokerType - 1));
                    UIPage.m_pokers.m_CardType3.visible = true;
                    break;
                case 3:
                    KillRoomDirectionPlayer killRoomDirectionPlayer3 = killRoomDirectionPlayers[3];
                    UIPage.m_pokers.m_cards4.m_n0.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer3.list_poker[0].value));
                    UIPage.m_pokers.m_cards4.m_n1.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer3.list_poker[1].value));
                    UIPage.m_pokers.m_cards4.m_n2.texture = new NTexture(Pokers.GetPokerFace(killRoomDirectionPlayer3.list_poker[2].value));
                    UIPage.m_pokers.m_CardType4.texture = new NTexture(Pokers.GetPokerType(killRoomDirectionPlayer3.pokerType - 1));
                    UIPage.m_pokers.m_CardType4.visible = true;
                    break;
                case 4:
                    UIPage.m_pokers.m_cards0.m_n0.texture = new NTexture(Pokers.GetPokerFace(list_bankerPoker[0].value));
                    UIPage.m_pokers.m_cards0.m_n1.texture = new NTexture(Pokers.GetPokerFace(list_bankerPoker[1].value));
                    UIPage.m_pokers.m_cards0.m_n2.texture = new NTexture(Pokers.GetPokerFace(list_bankerPoker[2].value));
                    UIPage.m_pokers.m_CardType0.texture = new NTexture(Pokers.GetPokerType(pokerType - 1));
                    UIPage.m_pokers.m_CardType0.visible = true;
                    break;

                default:
                    break;
            }

            //if (CacheManager.KillRoomTV == 0)
            //{
            //    BaseCanvas.PlaySound(R.AudioClip.SOUND_CHECKPOKER);
            //}
            index++;
            yield return new WaitForSeconds(timer);
        }
        if (!killRoomDirectionPlayers[0].isWin)
            UIPage.m_pokers.m_cards1.m_n3.visible = true;
        if (!killRoomDirectionPlayers[1].isWin)
            UIPage.m_pokers.m_cards2.m_n3.visible = true;
        if (!killRoomDirectionPlayers[2].isWin)
            UIPage.m_pokers.m_cards3.m_n3.visible = true;
        if (!killRoomDirectionPlayers[3].isWin)
            UIPage.m_pokers.m_cards4.m_n3.visible = true;
        if (killRoomLog.dongWin)
        {
            UIPage.m_pokers.m_winordef0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_WIN));
        }
        else
        {
            UIPage.m_pokers.m_winordef0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_LOSE));
        }
        if (killRoomLog.xiWin)
        {
            UIPage.m_pokers.m_winordef2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_WIN));
        }
        else
        {
            UIPage.m_pokers.m_winordef2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_LOSE));
        }
        if (killRoomLog.nanWin)
        {
            UIPage.m_pokers.m_winordef1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_WIN));
        }
        else
        {
            UIPage.m_pokers.m_winordef1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_LOSE));
        }
        if (killRoomLog.beiWin)
        {
            UIPage.m_pokers.m_winordef3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_WIN));
        }
        else
        {
            UIPage.m_pokers.m_winordef3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.WINORLOSE_LOSE));
        }
        UIPage.m_pokers.m_winordef0.visible = (true);
        UIPage.m_pokers.m_winordef1.visible = (true);
        UIPage.m_pokers.m_winordef2.visible = (true);
        UIPage.m_pokers.m_winordef3.visible = (true);

        yield return new WaitForSeconds(1);
        UIPage.m_pokers.m_winordef0.visible = false;
        UIPage.m_pokers.m_winordef1.visible = false;
        UIPage.m_pokers.m_winordef2.visible = false;
        UIPage.m_pokers.m_winordef3.visible = false;

        UIPage.m_pokers.m_text_gold0.text = "";
        UIPage.m_pokers.m_text_gold1.text = "";
        UIPage.m_pokers.m_text_gold2.text = "";
        UIPage.m_pokers.m_text_gold3.text = "";
        yield return null;
    }

    internal void UpdatePosGold(int endPos)
    {
        switch (endPos)
        {
            case 0: UIPage.m_pokers.m_text_gold0.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[0]); break;
            case 1: UIPage.m_pokers.m_text_gold1.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[1]); break;
            case 2: UIPage.m_pokers.m_text_gold2.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[2]); break;
            case 3: UIPage.m_pokers.m_text_gold3.text = ToolClass.LongConverStr(BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[3]); break;
            default:
                break;
        }
    }


    public override void Hide()
    {
        if (UIPage.m_pokers.m_CardsAnim0.playing)
            UIPage.m_pokers.m_CardsAnim0.Stop();
        if (UIPage.m_pokers.m_CardsAnim1.playing)
            UIPage.m_pokers.m_CardsAnim1.Stop();
        if (UIPage.m_pokers.m_CardsAnim2.playing)
            UIPage.m_pokers.m_CardsAnim2.Stop();
        if (UIPage.m_pokers.m_CardsAnim3.playing)
            UIPage.m_pokers.m_CardsAnim3.Stop();
        if (UIPage.m_pokers.m_CardsAnim4.playing)
            UIPage.m_pokers.m_CardsAnim4.Stop();
        ClearPokers();
    }
    /// <summary>
    /// 断线重连
    /// </summary>
    public void Connect()
    {
        

        if (UIPage.m_pokers.m_CardsAnim0.playing)
            UIPage.m_pokers.m_CardsAnim0.Stop();
        if (UIPage.m_pokers.m_CardsAnim1.playing)
            UIPage.m_pokers.m_CardsAnim1.Stop();
        if (UIPage.m_pokers.m_CardsAnim2.playing)
            UIPage.m_pokers.m_CardsAnim2.Stop();
        if (UIPage.m_pokers.m_CardsAnim3.playing)
            UIPage.m_pokers.m_CardsAnim3.Stop();
        if (UIPage.m_pokers.m_CardsAnim4.playing)
            UIPage.m_pokers.m_CardsAnim4.Stop();
        ClearPokers();

       
    }

}