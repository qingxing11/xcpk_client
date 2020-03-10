﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Classic;
using System;
using FairyGUI;
using DG.Tweening;

public class UIManyPeople : WTUIPage<UI_ManyPeopleTV, TenThousandRoomCtrl>
{
    public UIManyPeople() : base(UIType.Normal, UIMode.DoNothing, R.UI.CLASSIC)
    { } 

    public Action hide;
    public Action ActionCall;//跟注
    public Action ActionSee; //看牌
    public Action<int> ActionRaise;//加注
    public Action<int> ActionComparer;//比牌
    public Action ActionFold;    //弃牌
    public Action ActionAllin;   //全压


    //public Action ActionReady; //准备
    public Action ActionChat;  //聊天
    public Action ActionHorn;  //喇叭
    public Action<bool> ActionShowReturn;//返回

    public Action<int> ActionInfo; //玩家信息

    public Action hideClassChat;
    public Action ActionUpTable;  //申请上桌

    public Action<Vector2> hornRecord;//消息记录面板

    public Action lottery;//彩票
    public Action ActionMore;//更多
    public Action ActionFriend;//好友
 
    public Action<bool> ActionCloseTV;//返回
    public Action ActionFastBuy;//快速充值

    public Action ActionBackSee;//上局回顾
    public Action ActionJackPot;//奖池

    public Action ActionOnClick;

    /// <summary>
    /// 单注
    /// </summary>
    private int betNum;
    /// <summary>
    /// 跟到底
    /// </summary>
    private bool callAll = false;

    /// <summary>
    /// 总注
    /// </summary>
    private long allBetNum;
    /// <summary>
    /// 回合数
    /// </summary>
    public int round = 0;


    public List<UIChip> Chips = new List<UIChip>();
    private Coroutine coroutine;
    private List<GImage> cardS = new List<GImage>();
    /// <summary>
    /// 房间可操作人数
    /// </summary>
    public int roomPeople;     //房间人数
    private bool isComp = false;
    public bool[] tablePokerState = new bool[5] { false, false, false, false, false };

    public bool isAllin = false;
    /// <summary>
    /// 是否是第一个玩家操作 第一个玩家操作 不能跟注 加注全亮
    /// </summary>
   // private bool allInstate3 = false;


    public override void Awake()
    {
        UIPage.m_roomMany.m_info1.m_c2.SetSelectedIndex(0);
        UIPage.m_roomMany.m_info2.m_c2.SetSelectedIndex(0);
        UIPage.m_roomMany.m_info3.m_c2.SetSelectedIndex(1);
        UIPage.m_roomMany.m_info4.m_c2.SetSelectedIndex(1);

        UIPage.m_roomMany.m_cards0.m_c1.SetSelectedIndex(0);
        UIPage.m_roomMany.m_cards1.m_c1.SetSelectedIndex(1);
        UIPage.m_roomMany.m_cards2.m_c1.SetSelectedIndex(1);
        UIPage.m_roomMany.m_cards3.m_c1.SetSelectedIndex(1);
        UIPage.m_roomMany.m_cards4.m_c1.SetSelectedIndex(1);

        InitBtn();
        UIPage.m_roomMany.m_n300.onClick.Add(UIPageOnClick);

        UIPage.m_roomMany.m_lotteryNum.visible = false;//彩票界面数字显示
        UIPage.m_roomMany.m_movie_win.visible = false;//彩票中奖闪烁

        ShowAddFriendIcon(false);//不显示红点
    }

    public void ShowAddFriendIcon(bool show)
    {
        UIPage.m_roomMany.m_addfriends.visible = show;
    }

    public override void Refresh()
    {
        

        callAll = false;
        UIPage.m_roomMany.m_btn_callall.selected = false;
        Init();
      
        if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            UIPage.m_roomMany.m_playerDownDesk.visible = false;
        }

        Debug.Log("CacheManager.manyPeopleId:"+ CacheManager.manyPeopleId);
        if (CacheManager.manyPeopleId == 0)
        {
            UIPage.m_c1.SetSelectedIndex(0);
            UIPage.m_roomMany.m_c1.SetSelectedIndex(0);
            WTUIPage.ShowPage<UIGlobalNotic>().SetPosition(201, 10).SetRotate(0);
        }
        else if (CacheManager.manyPeopleId == 1)
        {
            UIPage.m_c1.SetSelectedIndex(1);
            UIPage.m_roomMany.m_c1.SetSelectedIndex(1);

           
        }
    }

    internal void HideTV()
    {
        if (UIPage != null)
        {
            if (UIPage.m_c1.selectedIndex == 1)
            {
                Hide();
            }
        }
    }

    /// <summary>
    /// 断线重连
    /// </summary>
    public void Reconnection(int pokerType, int allInState,PlayerSimpleData playerSimple, int round)
    {
        PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[0];
        if (playerSimpleData != null && playerSimpleData.userId == CacheManager.gameData.userId)//自己在座位上
        {
            SetPlayerDownDesk(false);
            if (playerSimpleData.gameState != 2)
            {
                if (!playerSimple.isCheckPoker)
                {
                    SetObjState(UIPage.m_roomMany.m_btn_see, true);     //看牌
                    SetObjState(UIPage.m_roomMany.m_text_see, true);
                }

                SetObjState(UIPage.m_roomMany.m_btn_fold, true);     //弃牌
                SetObjState(UIPage.m_roomMany.m_btn_fold, true);
            }
            if (CacheManager.stateManypeople == 3)
                HideBtn(true);
            else
            {
                HideBtn(false);
            }

            if (CacheManager.list_pokersManyPeople != null)
            {
                SelfCheckPoker(CacheManager.list_pokersManyPeople, pokerType);
            }
            if (CacheManager.manyPeopleActionPos == 0)
            {
                if (CacheManager.stateManypeople == 3)
                {
                    PlayPlayerActionTimer(0, CacheManager.manyPeopleActionTime);
                }
                if (playerSimpleData != null && playerSimpleData.userId == CacheManager.gameData.userId && playerSimpleData.gameState != 2)
                {
                    SetObjState(UIPage.m_roomMany.m_text_fold, true);
                    SetObjState(UIPage.m_roomMany.m_btn_fold, true);
                }
            }
        }
        else
        {
            HideBtn(false);
        }
        if (playerSimple != null && CacheManager.stateManypeople == 3)
        {
            PlayerAction(CacheManager.manyPeopleActionPos, this.betNum, playerSimple.isCheckPoker, round, allInState);
        }
    }

    private void Init()
    {

        ClearAnim();
        coroutine = GameCanvas.gameCanvas.StartCoroutine(Timer());
        ClearAllPoker();
        UpdateJackPot();
        ClearCoinsAnim();
        StopPlayerActionTimer();
        while (Chips.Count > 0)
        {
            UIChip uIChip = Chips[Chips.Count - 1];
            Chips.Remove(uIChip);
            ClosePage(uIChip);
        }
        if (CacheManager.list_allBetManyPeople != null)
        {
            foreach (int allBet in CacheManager.list_allBetManyPeople)
            {
                List<int> list_allBet = ToolClass.CoinCconversionManyPeople(allBet);
                foreach (int item in list_allBet)
                {
                    UIChip uIChip = BaseCanvas.GetController<ChipCtrl>().Show(item);
                    int x = UnityEngine.Random.Range(0, 300) - 150;
                    int y = UnityEngine.Random.Range(0, 80) - 100;
                    uIChip.SetPosition(new Vector2(400 + x, 240 + y));
                    Chips.Add(uIChip);
                }
            }
        }

        PlayerSimpleData[] manyPeopleRoomPlayers = CacheManager.ManyPeopleRoomPlayers;
        for (int i = 0; i < manyPeopleRoomPlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = manyPeopleRoomPlayers[i];

            if (playerSimpleData != null)
            {
                UI_cards uI_Cards = null;
                switch (i)
                {
                    case 0: SetInfo0(); uI_Cards = UIPage.m_roomMany.m_cards0; break;
                    case 1: SetInfo(UIPage.m_roomMany.m_info1, playerSimpleData); uI_Cards = UIPage.m_roomMany.m_cards1; break;
                    case 2: SetInfo(UIPage.m_roomMany.m_info2, playerSimpleData); uI_Cards = UIPage.m_roomMany.m_cards2; break;
                    case 3: SetInfo(UIPage.m_roomMany.m_info3, playerSimpleData); uI_Cards = UIPage.m_roomMany.m_cards3; break;
                    case 4: SetInfo(UIPage.m_roomMany.m_info4, playerSimpleData); uI_Cards = UIPage.m_roomMany.m_cards4; break;
                    default:
                        break;
                }
                if (CacheManager.stateManypeople == 2 || CacheManager.stateManypeople == 3)
                {
                    if (playerSimpleData.gameState != 0&&playerSimpleData.gameState != 3)
                    {
                        if (uI_Cards != null)
                        {
                            uI_Cards.m_n0.visible = true;
                            uI_Cards.m_n1.visible = true;
                            uI_Cards.m_n2.visible = true;
                        }
                    }
                    if (playerSimpleData.gameState == 2) //失败
                    {
                        PokerLoser(i);
                    }
                    if (playerSimpleData.isCheckPoker)
                    {
                        OtherCheckPoker(i);  //其他玩家看牌
                    }
                }

            }
            else
            {
                switch (i)
                {
                    case 1: UIPage.m_roomMany.m_info1.visible = false; break;
                    case 2: UIPage.m_roomMany.m_info2.visible = false; break;
                    case 3: UIPage.m_roomMany.m_info3.visible = false; break;
                    case 4: UIPage.m_roomMany.m_info4.visible = false; break;
                    default:
                        break;
                }
            }
        }

        cardS = new List<GImage>();

        cardS.Add(UIPage.m_roomMany.m_card_back1);
        cardS.Add(UIPage.m_roomMany.m_card_back2);
        cardS.Add(UIPage.m_roomMany.m_card_back3);
        cardS.Add(UIPage.m_roomMany.m_card_back4);
        cardS.Add(UIPage.m_roomMany.m_card_back5);
        cardS.Add(UIPage.m_roomMany.m_card_back6);
        cardS.Add(UIPage.m_roomMany.m_card_back7);
        cardS.Add(UIPage.m_roomMany.m_card_back8);
        cardS.Add(UIPage.m_roomMany.m_card_back9);
        foreach (GImage gImage in cardS)
        {
            if (gImage.visible)
                gImage.visible = false;
        }

        if (CacheManager.ManyPeopleRoomPlayers[0] == null || CacheManager.ManyPeopleRoomPlayers[0].userId != CacheManager.gameData.userId)
        {
            UIPage.m_roomMany.m_playerDownDesk.visible = true;
            UIPage.m_roomMany.m_lottery.visible = true;
            if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
            {
                Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                UIPage.m_roomMany.m_icon.texture = new NTexture(t2d);
            }
            else if (CacheManager.gameData.roleId == 0)
            {
                UIPage.m_roomMany.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
            }
            else
            {
                UIPage.m_roomMany.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
            }
            UIPage.m_roomMany.m_playerName.text = CacheManager.gameData.nickName;
            UIPage.m_roomMany.m_playerCoin.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
            switch (CacheManager.gameData.vipLv)
            {
                case 0:UIPage.m_roomMany.m_vip.texture = null; break;
                case 1: UIPage.m_roomMany.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP1)); ; break;
                case 2: UIPage.m_roomMany.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP2)); break;
                case 3: UIPage.m_roomMany.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP3)); break;
                case 4: UIPage.m_roomMany.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP4)); break;
                case 5: UIPage.m_roomMany.m_vip.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP5)); break;
                default:
                    break;
            }
        }
        else
        {
            UIPage.m_roomMany.m_lottery.visible = false;
            UIPage.m_roomMany.m_playerDownDesk.visible = false;
        }
    }


    public void UpdateJackPot()
    {
        UIPage.m_roomMany.m_sumPool.text = ToolClass.LongConverStr(CacheManager.manyPeopleJackpot);
    }
    /// <summary>
    /// 刷新自己金币
    /// </summary>
    internal void RefSelfConis()
    {
        UIPage.m_roomMany.m_playerCoin.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            CacheManager.ManyPeopleRoomPlayers[0].coins = CacheManager.gameData.coins;
            UIPage.m_roomMany.m_info0.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.gameData.coins);
        }
    }
    internal void RefPosCoins(int pos)
    {
        switch (pos)
        {
            case 0: UIPage.m_roomMany.m_info0.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);break;
            case 1: UIPage.m_roomMany.m_info1.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins); break;
            case 2: UIPage.m_roomMany.m_info2.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins); break;
            case 3: UIPage.m_roomMany.m_info3.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins); break;
            case 4: UIPage.m_roomMany.m_info4.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins); break;
            default:break;
        }
    }

    private void InitBtn()
    {
        UIPage.m_roomMany.m_btn_compate.onClick.Add(BtnCompateOnClick);  //比牌
        UIPage.m_roomMany.m_btn_fold.onClick.Add(BtnFoldOnClick);        //弃牌
        UIPage.m_roomMany.m_btn_see.onClick.Add(BtnSeeOnClick);          //看牌
        UIPage.m_roomMany.m_btn_raise.onClick.Add(BtnRaiseOnClick);      //加注
        UIPage.m_roomMany.m_btn_allin.onClick.Add(BtnAllinOnClick);      //全压
        UIPage.m_roomMany.m_btn_call.onClick.Add(BtnCallOnClick);        //跟注
        UIPage.m_roomMany.m_btn_callall.onClick.Add(BtnCallAllOnClick); //跟到底

        //加注
        UIPage.m_roomMany.m_raiseBet.m_n50000.onClick.Add(() => { RaiseBetOnClick(50000); });
        UIPage.m_roomMany.m_raiseBet.m_n80000.onClick.Add(() => { RaiseBetOnClick(80000); });
        UIPage.m_roomMany.m_raiseBet.m_n100000.onClick.Add(() => { RaiseBetOnClick(100000); });
        UIPage.m_roomMany.m_raiseBet.m_n150000.onClick.Add(() => { RaiseBetOnClick(150000); });
        UIPage.m_roomMany.m_raiseBet.m_n250000.onClick.Add(() => { RaiseBetOnClick(250000); });



        //玩家信息点击玩家头像
        UIPage.m_roomMany.m_info0.m_head.onClick.Add(() => { BtnInFoOnClick(0); });
        UIPage.m_roomMany.m_info1.m_head.onClick.Add(() => { BtnInFoOnClick(1); });
        UIPage.m_roomMany.m_info2.m_head.onClick.Add(() => { BtnInFoOnClick(2); });
        UIPage.m_roomMany.m_info3.m_head.onClick.Add(() => { BtnInFoOnClick(3); });
        UIPage.m_roomMany.m_info4.m_head.onClick.Add(() => { BtnInFoOnClick(4); });

        UIPage.m_roomMany.m_btn_chat.onClick.Add(() => { ActionChat?.Invoke(); });

        UIPage.m_roomMany.m_btn_back.onClick.Add(BackOnClick);

        UIPage.m_roomMany.m_btn_upTable.onClick.Add(BtnUpTableOnClick);//申请上桌

        UIPage.m_roomMany.m_btn_horn.onClick.Add(() => { ActionHorn?.Invoke(); });

        UIPage.m_roomMany.m_btn_hornReocrd.onClick.Add(BtnRocrd);//消息记录面板
        UIPage.m_roomMany.m_btn_lottery.onClick.Add(() => { lottery(); });//彩票
        UIPage.m_roomMany.m_btn_more.onClick.Add(() => { ActionMore?.Invoke(); });
        UIPage.m_roomMany.m_btn_friend.onClick.Add(() => { ActionFriend?.Invoke(); });
        UIPage.m_roomMany.m_btn_fastbuy.onClick.Add(() => { ActionFastBuy?.Invoke(); });
        UIPage.m_roomMany.m_btn_backSee.onClick.Add(() => { ActionBackSee?.Invoke(); });//上局回顾
        UIPage.m_roomMany.m_jackPotOnClick.onClick.Add(() => { ActionJackPot?.Invoke(); });
        UIPage.m_roomMany.onClick.Add(() => 
        {
            if (BaseCanvas.GetController<TenThousandRoomCtrl>().isReturnPanel)
            {
                ActionShowReturn?.Invoke(false);
            }
            ActionOnClick?.Invoke();
        });

        UIPage.m_btn_close.onClick.Add(() => {
            ActionCloseTV?.Invoke(true);
        });

        
    }


   

    public void BackOnClick()
    {
        ActionShowReturn?.Invoke(true);
    }

    public void BtnUpTableOnClick()
    {
        ActionUpTable?.Invoke();
    }

    private void UIPageOnClick()
    {
        if (UIPage.m_roomMany.m_c_raiseBet.selectedIndex == 1)
            UIPage.m_roomMany.m_c_raiseBet.SetSelectedIndex(0);
       
        BaseCanvas.GetController<ShopBoxCtrl>().Hide2();
    }

    private void BtnInFoOnClick(int index)
    {
        if (!isComp)
            ActionInfo?.Invoke(index);
        else
        {
            if (index != 0)
            {
                ActionComparer(index);
                isComp = false;
                GenIconFalse();
            }
        }
    }

    /// <summary>
    /// 隐藏玩家的跟字
    /// </summary>
    internal void GenIconFalse()
    {
        if (UIPage == null)
            return;
        if (UIPage.m_roomMany.m_info1.visible)
            UIPage.m_roomMany.m_info1.m_c1.SetSelectedIndex(0);
        if (UIPage.m_roomMany.m_info2.visible)
            UIPage.m_roomMany.m_info2.m_c1.SetSelectedIndex(0);
        if (UIPage.m_roomMany.m_info3.visible)
            UIPage.m_roomMany.m_info3.m_c1.SetSelectedIndex(0);
        if (UIPage.m_roomMany.m_info4.visible)
            UIPage.m_roomMany.m_info4.m_c1.SetSelectedIndex(0);
    }

    private void SetInfo0()
    {
        PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[0];
        UI_selfInfo uI_SelfInfo = UIPage.m_roomMany.m_info0;
        UIPage.m_roomMany.m_info0.visible = true;

        uI_SelfInfo.m_head.texture = new NTexture(playerSimpleData.headIcon);


        ToolClass.SetVipTexture(uI_SelfInfo.m_vip, playerSimpleData.vipLv);

        uI_SelfInfo.m_text_nickname.text = playerSimpleData.nickName;
        uI_SelfInfo.m_text_selfgold.text = ToolClass.LongConverStr(playerSimpleData.coins);
        uI_SelfInfo.m_text_gold.text = ToolClass.LongConverStr(playerSimpleData.betNum);
        SetRankIcon(uI_SelfInfo.m_icon_list, playerSimpleData);
    }

    private void SetInfo(UI_otherInfo uI_OtherInfo, PlayerSimpleData playerSimpleData)
    {
        uI_OtherInfo.visible = true;
        uI_OtherInfo.m_head.texture = new NTexture(playerSimpleData.headIcon);
        

        if (playerSimpleData.sprites.Count > 0)
        {
            SetRankIcon(uI_OtherInfo.m_icon_list, playerSimpleData);
        }

        ToolClass.SetVipTexture(uI_OtherInfo.m_vip, playerSimpleData.vipLv);
        uI_OtherInfo.m_text_nickname.text = playerSimpleData.nickName;
        uI_OtherInfo.m_text_selfgold.text = ToolClass.LongConverStr(playerSimpleData.coins);
        uI_OtherInfo.m_text_gold.text = ToolClass.LongConverStr(playerSimpleData.betNum);
    }

    private void SetRankIcon(GList gList, PlayerSimpleData playerSimpleData)
    {
        gList.numItems = 0;
        if (playerSimpleData.sprites.Count > 0)
        {
            foreach (Sprite sprite in playerSimpleData.sprites)
            {
                UI_icon uI_Icon = (UI_icon)UIPackage.CreateObject("Classic", "icon");
                uI_Icon.m_n0.texture = new NTexture(sprite);
                gList.AddChild(uI_Icon);
            }
        }
    }

    /// <summary>
    /// 自己上座时候刷新座位信息及座位玩家扑克牌信息
    /// </summary>
    public void RefSetPoker()
    {
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[i];

            if (playerSimpleData != null)
            {
                UI_cards uI_Cards = null;
                switch (i)
                {
                    case 0: uI_Cards = UIPage.m_roomMany.m_cards0; break;
                    case 1: uI_Cards = UIPage.m_roomMany.m_cards1; break;
                    case 2: uI_Cards = UIPage.m_roomMany.m_cards2; break;
                    case 3: uI_Cards = UIPage.m_roomMany.m_cards3; break;
                    case 4: uI_Cards = UIPage.m_roomMany.m_cards4; break;
                    default:
                        break;
                }

                if (playerSimpleData.gameState != 0&& playerSimpleData.gameState != 3)
                {
                    if (uI_Cards != null)
                    {
                        uI_Cards.m_n0.visible = true;
                        uI_Cards.m_n1.visible = true;
                        uI_Cards.m_n2.visible = true;
                    }
                }

                if (playerSimpleData.gameState == 0)
                {
                    if (uI_Cards != null)
                    {
                        uI_Cards.m_n0.visible = false;
                        uI_Cards.m_n1.visible = false;
                        uI_Cards.m_n2.visible = false;
                    }
                }

                if (playerSimpleData.gameState == 2) //失败
                {
                    PokerLoser(i);
                }
                if (playerSimpleData.isCheckPoker)
                {
                    OtherCheckPoker(i);  //其他玩家看牌
                }
            }
        }
    }
    internal void SetPosData(int pos)
    {
        PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[pos];

        switch (pos)
        {
            case 0:SetInfo0(); break;
            case 1: SetInfo(UIPage.m_roomMany.m_info1, playerSimpleData); break;
            case 2: SetInfo(UIPage.m_roomMany.m_info2, playerSimpleData); break;
            case 3: SetInfo(UIPage.m_roomMany.m_info3, playerSimpleData); break;
            case 4:
                SetInfo(UIPage.m_roomMany.m_info4, playerSimpleData); break;
            default:
                break;
        }
    }
    //自己上座时候刷新座位信息
    internal void RefPosData()
    {
        ClearAllPoker();
        UIPage.m_roomMany.m_info1.visible = false;
        UIPage.m_roomMany.m_info2.visible = false;
        UIPage.m_roomMany.m_info3.visible = false;
        UIPage.m_roomMany.m_info4.visible = false;
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            if (CacheManager.ManyPeopleRoomPlayers[i] != null)
            {
                SetPosData(i);
            }
        }
    }

    internal void SetPlayerDownDesk(bool state)
    {
        UIPage.m_roomMany.m_playerDownDesk.visible = state;
        if (state)
        {
            UIPage.m_roomMany.m_playerCoin.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        }
    }
    /// <summary>
    /// 发牌动画
    /// </summary>
    /// <param name="bankerPos"></param>
    /// <returns></returns>
    internal IEnumerator DealPokerAnim(int bankerPos)
    {
        ClearPokerState();     
        SetOneBet(50000);//发牌时设置底注
        bool[] Fapai = new bool[5]; ;
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            Fapai[i] = CacheManager.ManyPeopleRoomPlayers[i] != null;
        }

        isAllin = false;
        roomPeople = 0;
        for (int i = 0; i < 5; i++)
        {
            if (CacheManager.ManyPeopleRoomPlayers[i] != null)
            {
                roomPeople++;
            }
        }
        for (int i = 0; i < 15; i++)
        {
            int pos = (bankerPos + i) % 5;

            if (Fapai[pos])
            {
                BaseCanvas.PlaySound(R.AudioClip.SOUND_DEALPOKER);
                GImage cardBack = cardS[0];
                cardBack.SetPosition(375, 73, 0);
                cardS.Remove(cardBack);
                cardBack.visible = true;
                tablePokerState[pos] = true;
                switch (pos)
                {
                    case 0:
                        if (!UIPage.m_roomMany.m_cards0.m_n0.visible)
                        {
                            GTweener tween = cardBack.TweenMove(UIPage.m_roomMany.m_cards0.position + Vector3.right * -30f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards0.m_n0.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });

                        }
                        else if (!UIPage.m_roomMany.m_cards0.m_n1.visible)
                        {
                            cardBack.TweenMove(UIPage.m_roomMany.m_cards0.position + Vector3.right * 20f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards0.m_n1.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards0.m_n2.visible)
                        {
                            cardBack.TweenMove(UIPage.m_roomMany.m_cards0.position + Vector3.right * 70f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards0.m_n2.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        break;
                    case 1:
                       
                        if (!UIPage.m_roomMany.m_cards1.m_n0.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards1.position, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards1.m_n0.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);

                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards1.m_n1.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards1.position + Vector3.right * 20f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards1.m_n1.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards1.m_n2.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards1.position + Vector3.right * 40f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards1.m_n2.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        break;
                    case 2:
                       
                        if (!UIPage.m_roomMany.m_cards2.m_n0.visible)
                        {
                          cardBack.TweenMove(UIPage.m_roomMany.m_cards2.position, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards2.m_n0.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards2.m_n1.visible)
                        {
                            cardBack.TweenMove(UIPage.m_roomMany.m_cards2.position + Vector3.right * 20f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards2.m_n1.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards2.m_n2.visible)
                        {
                            cardBack.TweenMove(UIPage.m_roomMany.m_cards2.position + Vector3.right * 40f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards2.m_n2.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        break;
                    case 3:
                       
                        if (!UIPage.m_roomMany.m_cards3.m_n0.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards3.position, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards3.m_n0.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards3.m_n1.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards3.position + Vector3.right * 20f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards3.m_n1.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards3.m_n2.visible)
                        {
                          cardBack.TweenMove(UIPage.m_roomMany.m_cards3.position + Vector3.right * 40f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards3.m_n2.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        break;
                    case 4:
                       
                        if (!UIPage.m_roomMany.m_cards4.m_n0.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards4.position, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards4.m_n0.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards4.m_n1.visible)
                        {
                           cardBack.TweenMove(UIPage.m_roomMany.m_cards4.position + Vector3.right * 20f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards4.m_n1.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        else if (!UIPage.m_roomMany.m_cards4.m_n2.visible)
                        {
                         cardBack.TweenMove(UIPage.m_roomMany.m_cards4.position + Vector3.right * 40f, 0.5f).OnComplete(() =>
                            {
                                UIPage.m_roomMany.m_cards4.m_n2.visible = true;
                                cardBack.visible = false;
                                cardBack.SetPosition(386, 168, 0);
                                cardS.Add(cardBack);
                            });
                        }
                        break;
                    default:
                        break;
                }
                yield return new WaitForSeconds(0.3f);
            }
        }


        for (int i = 0; i < Fapai.Length; i++)
        {
            bool fapai = Fapai[i];
            switch (i)
            {
                case 0:
                    if (fapai)
                    {
                        UIPage.m_roomMany.m_cards0.m_n0.visible = true;
                        UIPage.m_roomMany.m_cards0.m_n1.visible = true;
                        UIPage.m_roomMany.m_cards0.m_n2.visible = true;
                    }
                    else
                    {
                        UIPage.m_roomMany.m_cards0.m_n0.visible = false;
                        UIPage.m_roomMany.m_cards0.m_n1.visible = false;
                        UIPage.m_roomMany.m_cards0.m_n2.visible = false;
                    }
                    break;
                case 1:
                    if (fapai)
                    {
                        UIPage.m_roomMany.m_cards1.m_n0.visible = true;
                        UIPage.m_roomMany.m_cards1.m_n1.visible = true;
                        UIPage.m_roomMany.m_cards1.m_n2.visible = true;
                    }
                    else
                    {
                        UIPage.m_roomMany.m_cards1.m_n0.visible = false;
                        UIPage.m_roomMany.m_cards1.m_n1.visible = false;
                        UIPage.m_roomMany.m_cards1.m_n2.visible = false;
                    }
                    break;
                case 2:
                    if (fapai)
                    {
                        UIPage.m_roomMany.m_cards2.m_n0.visible = true;
                        UIPage.m_roomMany.m_cards2.m_n1.visible = true;
                        UIPage.m_roomMany.m_cards2.m_n2.visible = true;
                    }
                    else
                    {
                        UIPage.m_roomMany.m_cards2.m_n0.visible = false;
                        UIPage.m_roomMany.m_cards2.m_n1.visible = false;
                        UIPage.m_roomMany.m_cards2.m_n2.visible = false;
                    }
                    break;
                case 3:
                    if (fapai)
                    {
                        UIPage.m_roomMany.m_cards3.m_n0.visible = true;
                        UIPage.m_roomMany.m_cards3.m_n1.visible = true;
                        UIPage.m_roomMany.m_cards3.m_n2.visible = true;
                    }
                    else
                    {
                        UIPage.m_roomMany.m_cards3.m_n0.visible = false;
                        UIPage.m_roomMany.m_cards3.m_n1.visible = false;
                        UIPage.m_roomMany.m_cards3.m_n2.visible = false;
                    }
                    break;
                case 4:
                    if (fapai)
                    {
                        UIPage.m_roomMany.m_cards4.m_n0.visible = true;
                        UIPage.m_roomMany.m_cards4.m_n1.visible = true;
                        UIPage.m_roomMany.m_cards4.m_n2.visible = true;
                    }
                    else
                    {
                        UIPage.m_roomMany.m_cards4.m_n0.visible = false;
                        UIPage.m_roomMany.m_cards4.m_n1.visible = false;
                        UIPage.m_roomMany.m_cards4.m_n2.visible = false;
                    }
                    break;
                default:
                    break;
            }
        }

        SetObjState(UIPage.m_roomMany.m_btn_callall, true); //跟到底
        SetObjState(UIPage.m_roomMany.m_btn_see, true);     //看牌
        SetObjState(UIPage.m_roomMany.m_text_see, true);
        SetObjState(UIPage.m_roomMany.m_btn_fold, true);    //弃牌
        SetObjState(UIPage.m_roomMany.m_text_fold, true);
        HideBtn(true);
        yield return new WaitForSeconds(1);
        ClearMatherBackCards();
        yield return null;
    }


    internal void ClearMatherBackCards()
    {

        cardS = new List<GImage>();

        
        cardS.Clear();
        cardS.Add(UIPage.m_roomMany.m_card_back1);
        cardS.Add(UIPage.m_roomMany.m_card_back2);
        cardS.Add(UIPage.m_roomMany.m_card_back3);
        cardS.Add(UIPage.m_roomMany.m_card_back4);
        cardS.Add(UIPage.m_roomMany.m_card_back5);
        cardS.Add(UIPage.m_roomMany.m_card_back6);
        cardS.Add(UIPage.m_roomMany.m_card_back7);
        cardS.Add(UIPage.m_roomMany.m_card_back8);
        cardS.Add(UIPage.m_roomMany.m_card_back9);
        foreach (GImage gImage in cardS)
        {
            if (gImage.visible)
                gImage.visible = false;
            gImage.SetPosition(375, 73, 0);
        }
    }

    internal void setSelfLevelTable(bool isState)
    {
        UIPage.m_roomMany.m_lottery.visible = isState;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="betNum"></param>
    internal void StartChipAnim(int betNum)
    {
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[i];
            if (playerSimpleData != null)
            {
                UIChip uIChip = BaseCanvas.GetController<ChipCtrl>().Show(betNum);
                Vector2 startVec = Vector2.zero;
                switch (i)
                {
                    case 0: startVec = UIPage.m_roomMany.m_info0.position; break;
                    case 1: startVec = UIPage.m_roomMany.m_info1.position; break;
                    case 2: startVec = UIPage.m_roomMany.m_info2.position; break;
                    case 3: startVec = UIPage.m_roomMany.m_info3.position; break;
                    case 4: startVec = UIPage.m_roomMany.m_info4.position; break;
                    default:
                        break;
                }
              
                int x = UnityEngine.Random.Range(0, 100) - 50;
                int y = UnityEngine.Random.Range(0, 50) - 100;
               
                Vector2 endVec = new Vector2(400 + x, 240 + y);
                if (CacheManager.manyPeopleId == 1)
                {
                    endVec = new Vector2(0.2f * 800 + 0.6f * endVec.x, 0.2f * 480 + 0.6f * endVec.y);
                    startVec = new Vector2(0.2f * 800 + 0.6f * startVec.x, 0.2f * 480 + 0.6f * startVec.y);   
                }
                uIChip.SetPosition(startVec);
                uIChip.getGComponent().TweenMove(endVec, 1);
                Chips.Add(uIChip);
            }
        }
    }

    /// <summary>
    /// 玩家下桌
    /// </summary>
    /// <param name="pos"></param>
    internal void OtherPlayerLeave(int pos)
    {
        switch (pos)
        {
            case 0:
                UIPage.m_roomMany.m_cards0.m_n0.visible = false;
                UIPage.m_roomMany.m_cards0.m_n1.visible = false;
                UIPage.m_roomMany.m_cards0.m_n2.visible = false;
                UIPage.m_roomMany.m_ready0.visible = false;
                UIPage.m_roomMany.m_info0.visible = false;
                break;
            case 1:
                UIPage.m_roomMany.m_cards1.m_n0.visible = false;
                UIPage.m_roomMany.m_cards1.m_n1.visible = false;
                UIPage.m_roomMany.m_cards1.m_n2.visible = false;
                UIPage.m_roomMany.m_ready1.visible = false;
                UIPage.m_roomMany.m_info1.visible = false;
                break;
            case 2:
                UIPage.m_roomMany.m_cards2.m_n0.visible = false;
                UIPage.m_roomMany.m_cards2.m_n1.visible = false;
                UIPage.m_roomMany.m_cards2.m_n2.visible = false;
                UIPage.m_roomMany.m_ready2.visible = false;
                UIPage.m_roomMany.m_info2.visible = false;
                break;
            case 3:
                UIPage.m_roomMany.m_cards3.m_n0.visible = false;
                UIPage.m_roomMany.m_cards3.m_n1.visible = false;
                UIPage.m_roomMany.m_cards3.m_n2.visible = false;
                UIPage.m_roomMany.m_ready3.visible = false;
                UIPage.m_roomMany.m_info3.visible = false;
                break;
            case 4:
                UIPage.m_roomMany.m_cards4.m_n0.visible = false;
                UIPage.m_roomMany.m_cards4.m_n1.visible = false;
                UIPage.m_roomMany.m_cards4.m_n2.visible = false;
                UIPage.m_roomMany.m_ready4.visible = false;
                UIPage.m_roomMany.m_info4.visible = false;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 下注动画
    /// </summary>
    internal void ChipAnim(int startPos, List<int> betNums)
    {
        foreach (int item in betNums)
        {
            UIChip uIChip = BaseCanvas.GetController<ChipCtrl>().Show(item);
            Vector2 startVec = Vector2.zero;
            switch (startPos)
            {
                case 0: startVec = UIPage.m_roomMany.m_info0.position; break;
                case 1: startVec = UIPage.m_roomMany.m_info1.position; break;
                case 2: startVec = UIPage.m_roomMany.m_info2.position; break;
                case 3: startVec = UIPage.m_roomMany.m_info3.position; break;
                case 4: startVec = UIPage.m_roomMany.m_info4.position; break;
                default:
                    break;
            }

            int x = UnityEngine.Random.Range(0, 240) - 120;
            int y = UnityEngine.Random.Range(0, 80) - 100;
            Vector2 endVec = new Vector2(400 + x, 240 + y);

            if (CacheManager.manyPeopleId == 1)
            {
                startVec = new Vector2(0.2f * 800 + 0.6f * startVec.x, 0.2f * 480 + 0.6f * startVec.y);
                endVec = new Vector2(0.2f * 800 + 0.6f * endVec.x, 0.2f * 480 + 0.6f * endVec.y);
            }

            uIChip.SetPosition(startVec);
            uIChip.getGComponent().TweenMove(endVec, 0.5f);
            Chips.Add(uIChip);
        }
    }

    public List<GTweener> coinsTween = new List<GTweener>();

    /// <summary>
    /// 结算收金币
    /// </summary>
    /// <param name="pos"></param>
    internal void ChipAnim2(int pos)
    {
        coinsTween.Clear();
        Vector2 endVec = Vector2.zero;
        switch (pos)
        {
            case 0: endVec = UIPage.m_roomMany.m_info0.position; break;
            case 1: endVec = UIPage.m_roomMany.m_info1.position; break;
            case 2: endVec = UIPage.m_roomMany.m_info2.position; break;
            case 3: endVec = UIPage.m_roomMany.m_info3.position; break;
            case 4: endVec = UIPage.m_roomMany.m_info4.position; break;
            default:
                break;
        }
        while (Chips.Count > 0)
        {
            UIChip uIChip = Chips[Chips.Count - 1];
            Chips.Remove(uIChip);
            if (CacheManager.manyPeopleId == 1)
            {
                endVec = new Vector2(0.2f * 800 + 0.6f * endVec.x, 0.2f * 480 + 0.6f * endVec.y);
            }

            coinsTween.Add( uIChip.getGComponent().TweenMove(endVec, 1.0f).OnComplete(() => 
            {
                ClosePage(uIChip);
            }));
        }
    }
    internal void ClearCoinsAnim()
    {
        for (int i = coinsTween.Count - 1; i >= 0; i--)
        {
            coinsTween[i].Kill();
        }
    }


    private void RaiseBetOnClick(int raiseBetNum)
    {
        UIPage.m_roomMany.m_c_raiseBet.SetSelectedIndex(0);
        ActionRaise?.Invoke(raiseBetNum);
    }

    private void ComparerOnClick(int index)
    {
        ActionComparer?.Invoke(index); isComp = false;
    }

    public void HideAddCoins()
    {
        if (UIPage.m_roomMany.m_c_raiseBet.selectedIndex == 1)
            UIPage.m_roomMany.m_c_raiseBet.SetSelectedIndex(0);
    }

    /// <summary>
    /// 玩家行动
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="nowBet"></param>
    /// <param name="isCheckPoker"></param>
    /// <param name="round"></param>
    /// <param name="allInState"></param>
    internal void PlayerAction(int pos, int nowBet, bool isCheckPoker, int round, int allInState)
    {
        //下个玩家行动的时候隐藏跟icon
        GenIconFalse();
        CacheManager.manyPeopleActionPos = pos;
        HideAddCoins();
        if (this.round != round) //回合数
        {
            this.round = round;
            UIPage.m_roomMany.m_text_round.text = round + "/20";
        }

        if (pos == 0) //轮到自己行动
        {
            if (isCheckPoker)      //看牌
            {
                SetObjState(UIPage.m_roomMany.m_btn_see, false);
                SetObjState(UIPage.m_roomMany.m_text_see, false);
            }

            if (round < 3)
            {
                SetObjState(UIPage.m_roomMany.m_btn_compate, false); //比牌按钮
                SetObjState(UIPage.m_roomMany.m_text_compate, false);
            }
            else
            {
                SetObjState(UIPage.m_roomMany.m_btn_compate, true);//比牌按钮
                SetObjState(UIPage.m_roomMany.m_text_compate, true);//
            }
            if (this.betNum < 250000)
            {
                SetObjState(UIPage.m_roomMany.m_btn_raise, true);       //加注
                SetObjState(UIPage.m_roomMany.m_text_raise, true);       //加注
            }
            //allInstate3 = false;
            if (allInState == 0 || allInState == 3)      //0:不显示全压
            {
                SetObjState(UIPage.m_roomMany.m_btn_call, true);  //跟注
                SetObjState(UIPage.m_roomMany.m_text_call, true);  //跟注

                SetObjState(UIPage.m_roomMany.m_btn_allin, false);     //全压
                SetObjState(UIPage.m_roomMany.m_text_allin, false);     //全压
            }
            else if (allInState == 1) //1:显示全压
            {
                SetObjState(UIPage.m_roomMany.m_btn_allin, true);     //全压
                SetObjState(UIPage.m_roomMany.m_text_allin, true);     //全压

                SetObjState(UIPage.m_roomMany.m_btn_call, true);  //跟注
                SetObjState(UIPage.m_roomMany.m_text_call, true);  //跟注
            }
            else if (allInState == 2)  //2:强制全压
            {
                SetObjState(UIPage.m_roomMany.m_btn_call, false);  //跟注
                SetObjState(UIPage.m_roomMany.m_text_call, false);  //跟注

                SetObjState(UIPage.m_roomMany.m_btn_allin, true);     //全压
                SetObjState(UIPage.m_roomMany.m_text_allin, true);     //全压

                SetObjState(UIPage.m_roomMany.m_btn_raise, false);       //加注
                SetObjState(UIPage.m_roomMany.m_text_raise, false);       //加注
            }
            //else if (allInState == 3)
            //{
            //    //allInstate3 = true;
            //    SetObjState(UIPage.m_roomMany.m_btn_call, false);  //跟注
            //    SetObjState(UIPage.m_roomMany.m_text_call, false);  //跟注
            //    if (this.betNum < 250000)
            //    {
            //        SetObjState(UIPage.m_roomMany.m_btn_raise, true);  //加注
            //        SetObjState(UIPage.m_roomMany.m_text_raise, true);
            //    }
            //    BtnRaiseOnClick();
            //}

            if (IsHighestRaise())//已经到达最高注 加注按钮不亮
            {
                SetObjState(UIPage.m_roomMany.m_btn_raise, false);       //加注
                SetObjState(UIPage.m_roomMany.m_text_raise, false);       //加注
            }
            if (callAll)
            {
                GameCanvas.gameCanvas.StartCoroutine(WaitTimer(0.5f));
            }
        }
        else
        {
            SetObjState(UIPage.m_roomMany.m_btn_compate, false);   //比牌按钮
            SetObjState(UIPage.m_roomMany.m_text_compate, false);

            SetObjState(UIPage.m_roomMany.m_btn_raise, false);      //加注
            SetObjState(UIPage.m_roomMany.m_text_raise, false);

            SetObjState(UIPage.m_roomMany.m_btn_allin, false);     //全压
            SetObjState(UIPage.m_roomMany.m_text_allin, false);

            SetObjState(UIPage.m_roomMany.m_btn_call, false); //跟注
            SetObjState(UIPage.m_roomMany.m_text_call, false); //跟注
        }

        if (isAllin)
        {
            SetObjState(UIPage.m_roomMany.m_btn_raise, false);  //加注
            SetObjState(UIPage.m_roomMany.m_text_raise, false);

            SetObjState(UIPage.m_roomMany.m_btn_compate, false);//比牌
            SetObjState(UIPage.m_roomMany.m_text_compate, false);

            SetObjState(UIPage.m_roomMany.m_btn_call, false);//跟注
            SetObjState(UIPage.m_roomMany.m_text_call, false);
        }

        if (round == 20)
        {
            SetObjState(UIPage.m_roomMany.m_btn_raise, false);  //加注
            SetObjState(UIPage.m_roomMany.m_text_raise, false);

            SetObjState(UIPage.m_roomMany.m_btn_allin, false);//全压
            SetObjState(UIPage.m_roomMany.m_text_allin, false);

            SetObjState(UIPage.m_roomMany.m_btn_call, false);//
            SetObjState(UIPage.m_roomMany.m_text_call, false);
            Debug.Log("20局操作");
        }
    }
    IEnumerator WaitTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        BtnCallOnClick();
    }
    /// <summary>
    /// 自己看牌
    /// </summary>
    internal void SelfCheckPoker(List<PokerVO> list_poker, int pokerType)
    {
        list_poker.Sort();
        SetPokerFace(list_poker, UIPage.m_roomMany.m_cards0);
        SetPokerType(0, pokerType);
    }

    internal void Fold()
    {
        SetObjState(UIPage.m_roomMany.m_btn_fold, true);
        SetObjState(UIPage.m_roomMany.m_text_fold, true);
    }

    /// <summary>
    /// 其他玩家看牌
    /// </summary>
    /// <param name="pos"></param>
    internal void OtherCheckPoker(int pos)
    {
        switch (pos)
        {
            case 1: UIPage.m_roomMany.m_state1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_SEE)); break;
            case 2: UIPage.m_roomMany.m_state2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_SEE)); break;
            case 3: UIPage.m_roomMany.m_state3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_SEE)); break;
            case 4: UIPage.m_roomMany.m_state4.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_SEE)); break;
            default:
                break;
        }
    }
    /// <summary>
    /// 其他玩家弃牌
    /// </summary>
    /// <param name="pos"></param>
    internal void OtherDealPoker(int pos)
    {
        roomPeople--;
        tablePokerState[pos] = false;
        switch (pos)
        {
            case 0: UIPage.m_roomMany.m_state0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_FOLD)); break;
            case 1: UIPage.m_roomMany.m_state1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_FOLD)); break;
            case 2: UIPage.m_roomMany.m_state2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_FOLD)); break;
            case 3: UIPage.m_roomMany.m_state3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_FOLD)); break;
            case 4: UIPage.m_roomMany.m_state4.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_FOLD)); break;
            default:
                break;
        }
    }

    /// <summary>
    /// 玩家失败
    /// </summary>
    /// <param name="pos"></param>
    internal void PokerLoser(int pos)
    {
        tablePokerState[pos] = false;
        switch (pos)
        {
            case 0: UIPage.m_roomMany.m_state0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_LOSE)); break;
            case 1: UIPage.m_roomMany.m_state1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_LOSE)); break;
            case 2: UIPage.m_roomMany.m_state2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_LOSE)); break;
            case 3: UIPage.m_roomMany.m_state3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_LOSE)); break;
            case 4: UIPage.m_roomMany.m_state4.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.CARDSTATE_LOSE)); break;
            default:
                break;
        }
    }
    private void BtnCallAllOnClick()
    {
        callAll = UIPage.m_roomMany.m_btn_callall.selected;
        if (CacheManager.manyPeopleActionPos == 0) //行动玩家是自己
        {
            BtnCallOnClick();
        }
    }

    internal void SetCallAllBtnStateFalse()
    {
        callAll = false;
        UIPage.m_roomMany.m_btn_callall.selected = false;
    }

    private void BtnCallOnClick()
    {
        ActionCall?.Invoke();
    }

    private void BtnAllinOnClick()
    {
        ActionAllin?.Invoke();
    }

    private void BtnRaiseOnClick()
    {
        if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            UIPage.m_roomMany.m_c_raiseBet.SetSelectedIndex(1);
            RefRaiseBet();
        }
    }

    private void BtnSeeOnClick()
    {
        SetObjState(UIPage.m_roomMany.m_btn_see, false);
        SetObjState(UIPage.m_roomMany.m_text_see, false);
        ActionSee?.Invoke();
    }

    /// <summary>
    /// 弃牌
    /// </summary>
    private void BtnFoldOnClick()
    {
        ActionFold?.Invoke();
    }

    private void BtnCompateOnClick()
    {
        Debug.LogError("比牌人数"+roomPeople);
        if (roomPeople == 2)
        {
            for (int i = 1; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
            {
                PlayerSimpleData playerSimple = CacheManager.ManyPeopleRoomPlayers[i];
                if (playerSimple != null && tablePokerState[i])
                {
                    ComparerOnClick(i);
                    return;
                }
            }
        }
        else
        {
            isComp = true;
            for (int i = 1; i < tablePokerState.Length; i++)
            {
                if (tablePokerState[i])
                {
                    switch (i)
                    {
                        case 1: UIPage.m_roomMany.m_info1.m_c1.SetSelectedIndex(1); break;
                        case 2: UIPage.m_roomMany.m_info2.m_c1.SetSelectedIndex(1); break;
                        case 3: UIPage.m_roomMany.m_info3.m_c1.SetSelectedIndex(1); break;
                        case 4: UIPage.m_roomMany.m_info4.m_c1.SetSelectedIndex(1); break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    internal void UpdateUserCoins(int pos)
    {
        switch (pos)
        {
            case 0:
                UIPage.m_roomMany.m_info0.m_text_gold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].betNum);
                UIPage.m_roomMany.m_info0.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);
                //Debug.Log("pos:"+ pos+",player:" + CacheManager.ManyPeopleRoomPlayers[pos].userId+",coins:"+ CacheManager.ManyPeopleRoomPlayers[pos].coins);
                break;
            case 1:
                UIPage.m_roomMany.m_info1.m_text_gold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].betNum);
                UIPage.m_roomMany.m_info1.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);
                //Debug.Log("pos:" + pos + ",player:" + CacheManager.ManyPeopleRoomPlayers[pos].userId + ",coins:" + CacheManager.ManyPeopleRoomPlayers[pos].coins);
                break;
            case 2:
                UIPage.m_roomMany.m_info2.m_text_gold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].betNum);
                UIPage.m_roomMany.m_info2.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);
                //Debug.Log("pos:" + pos + ",player:" + CacheManager.ManyPeopleRoomPlayers[pos].userId + ",coins:" + CacheManager.ManyPeopleRoomPlayers[pos].coins);
                break;
            case 3:
                UIPage.m_roomMany.m_info3.m_text_gold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].betNum);
                UIPage.m_roomMany.m_info3.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);
                //Debug.Log("pos:" + pos + ",player:" + CacheManager.ManyPeopleRoomPlayers[pos].userId + ",coins:" + CacheManager.ManyPeopleRoomPlayers[pos].coins);
                break;
            case 4:
                UIPage.m_roomMany.m_info4.m_text_gold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].betNum);
                UIPage.m_roomMany.m_info4.m_text_selfgold.text = ToolClass.LongConverStr(CacheManager.ManyPeopleRoomPlayers[pos].coins);
                //Debug.Log("pos:" + pos + ",player:" + CacheManager.ManyPeopleRoomPlayers[pos].userId + ",coins:" + CacheManager.ManyPeopleRoomPlayers[pos].coins);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 一局结束设置最后两家的扑克牌
    /// </summary>
    internal void SetPoker(List<PokerVO> list_handPoker, int pos)
    {
        list_handPoker.Sort();
        switch (pos)
        {
            case 0: SetPokerFace(list_handPoker, UIPage.m_roomMany.m_cards0); break;
            case 1: SetPokerFace(list_handPoker, UIPage.m_roomMany.m_cards1); break;
            case 2: SetPokerFace(list_handPoker, UIPage.m_roomMany.m_cards2); break;
            case 3: SetPokerFace(list_handPoker, UIPage.m_roomMany.m_cards3); break;
            case 4: SetPokerFace(list_handPoker, UIPage.m_roomMany.m_cards4); break;
            default:
                break;
        }
    }

    private void SetPokerFace(List<PokerVO> list_handPoker, UI_cards uI_Cards)
    {
        uI_Cards.m_n0.texture = new NTexture(Pokers.GetPokerFace(list_handPoker[0].value));
        uI_Cards.m_n1.texture = new NTexture(Pokers.GetPokerFace(list_handPoker[1].value));
        uI_Cards.m_n2.texture = new NTexture(Pokers.GetPokerFace(list_handPoker[2].value));
    }



    /// <summary>
    /// 设置加注按钮显示
    /// </summary>
    private void RefRaiseBet()
    {
        //if (allInstate3)
        //{
        //    SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, true);
        //    SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, true);
        //    SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, true);
        //    SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, true);
        //    SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, true);
        //}
        //else 
        if (betNum <= 50000)
        {
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, true);
        }
        else if (betNum <= 80000)
        {
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, true);
        }
        else if (betNum <= 100000)
        {
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, true);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, true);
        }
        else if (betNum <= 150000)
        {
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, true);
        }
        else if (betNum <= 250000)
        {
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n50000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n80000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n100000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n150000, false);
            SetObjState(UIPage.m_roomMany.m_raiseBet.m_n250000, false);
        }
        
    }
    /// <summary>
    /// 设置按钮的状态，
    /// </summary>
    /// <param name="gButton"></param>
    /// <param name="isTrue"></param>
    private void SetObjState(GObject gButton, bool isTrue)
    {
        gButton.grayed = !isTrue;
        gButton.touchable = isTrue;
    }

    /// <summary>
    /// 设置单注
    /// </summary>
    public void SetOneBet(int betNum)
    {
        this.betNum = betNum;
        if (betNum >= 250000)
        {
            SetObjState(UIPage.m_roomMany.m_btn_raise, false);      //加注
            SetObjState(UIPage.m_roomMany.m_text_raise, false);
        }
        UIPage.m_roomMany.m_text_oneBet.text = ToolClass.LongConverStr(betNum);
    }
    /// <summary>
    /// 设置总注
    /// </summary>
    public void SetAllBet(long allBetNum)
    {
        this.allBetNum += allBetNum;
        UIPage.m_roomMany.m_text_allBet.text = ToolClass.LongConverStr(this.allBetNum);
    }

    //public bool timing = false;
    Coroutine CoroutinePlayerActionTimer = null;
    private float timer = 0;

    public void PlayPlayerActionTimer(int pos, float time)
    {
        StopPlayerActionTimer();
        CoroutinePlayerActionTimer = GameCanvas.gameCanvas.StartCoroutine(TimerBar(pos, time));
    }

    public void StopPlayerActionTimer()
    {
        if (CoroutinePlayerActionTimer != null)
        {
            GameCanvas.gameCanvas.StopCoroutine(CoroutinePlayerActionTimer);
        }
        ClearProgress();
    }
    internal IEnumerator TimerBar(int pos, float time)
    {
        timer = time;
        if (callAll)
        {
            yield return null;
        }

        GProgressBar gProgressBar = null;
        switch (pos)
        {
            case 0: gProgressBar = UIPage.m_roomMany.m_info0.m_bar; break;
            case 1: gProgressBar = UIPage.m_roomMany.m_info1.m_bar; break;
            case 2: gProgressBar = UIPage.m_roomMany.m_info2.m_bar; break;
            case 3: gProgressBar = UIPage.m_roomMany.m_info3.m_bar; break;
            case 4: gProgressBar = UIPage.m_roomMany.m_info4.m_bar; break;
            default:
                break;
        }
        while (gProgressBar.value <= 100)
        {
            if (gProgressBar != null)
            {
                gProgressBar.value = (timer / 20) * 100;
            }

            timer += Time.deltaTime;
            CacheManager.manyPeopleActionTime = timer;
            yield return new WaitForEndOfFrame();
        }
        timer = 0;
        gProgressBar.value = 0;
        yield return null;
    }

    internal void SetReadIcon(bool state)
    {
        for (int i = 0; i < 5; i++)
        {
            if (CacheManager.ManyPeopleRoomPlayers[i] != null)
            {
                switch (i)
                {
                    case 0: UIPage.m_roomMany.m_ready0.visible = state; break;
                    case 1: UIPage.m_roomMany.m_ready1.visible = state; break;
                    case 2: UIPage.m_roomMany.m_ready2.visible = state; break;
                    case 3: UIPage.m_roomMany.m_ready3.visible = state; break;
                    case 4: UIPage.m_roomMany.m_ready4.visible = state; break;
                    default:
                        break;
                }
            }
        }
    }

    internal IEnumerator Clock(int waitPlayerTime)
    {
        UIPage.m_roomMany.m_clock.visible = true;
        while ( waitPlayerTime > 0)
        {
            UIPage.m_roomMany.m_clock.m_timer.text = waitPlayerTime.ToString();
            yield return new WaitForSeconds(1.0f);
            waitPlayerTime -= 1;
        }
        UIPage.m_roomMany.m_clock.visible = false;
        yield return null;
    }

    internal IEnumerator Timer()
    {
        while (true)
        {
            UIPage.m_roomMany.m_text_time.text = DateTime.Now.ToShortTimeString();
            yield return new WaitForSeconds(30f);
        }
        yield return null;
    }

    internal void SetResults(int pos, long roundBet)
    {
        string resultStr = null;
        if (roundBet >= 0)
        {
            resultStr = "+" + roundBet;
            switch (pos)
            {
                case 0: UIPage.m_roomMany.m_text_results0Win.text = resultStr; break;
                case 1: UIPage.m_roomMany.m_text_results1Win.text = resultStr; break;
                case 2: UIPage.m_roomMany.m_text_results2Win.text = resultStr; break;
                case 3: UIPage.m_roomMany.m_text_results3Win.text = resultStr; break;
                case 4: UIPage.m_roomMany.m_text_results4Win.text = resultStr; break;
                default:
                    break;
            }
        }
        else
        {
            resultStr = roundBet.ToString();
            switch (pos)
            {
                case 0: UIPage.m_roomMany.m_text_results0Loss.text = resultStr; break;
                case 1: UIPage.m_roomMany.m_text_results1Loss.text = resultStr; break;
                case 2: UIPage.m_roomMany.m_text_results2Loss.text = resultStr; break;
                case 3: UIPage.m_roomMany.m_text_results3Loss.text = resultStr; break;
                case 4: UIPage.m_roomMany.m_text_results4Loss.text = resultStr; break;
                default:
                    break;
            }
        }

    }

    //播放玩家操作
    /// <summary>
    /// 播放玩家操作
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="act">1 看牌 2 弃牌 3 加注  4跟注  5 全压 6  比牌 </param>
    internal void PlayerAct(int pos, int act)
    {
        switch (pos)
        {
            case 1: UIPage.m_roomMany.m_PlayerAction1.m_c_state.SetSelectedIndex(act); UIPage.m_roomMany.m_PlayerAction1.m_t_anim.Play(); break;
            case 2: UIPage.m_roomMany.m_PlayerAction2.m_c_state.SetSelectedIndex(act); UIPage.m_roomMany.m_PlayerAction2.m_t_anim.Play(); break;
            case 3: UIPage.m_roomMany.m_PlayerAction3.m_c_state.SetSelectedIndex(act); UIPage.m_roomMany.m_PlayerAction3.m_t_anim.Play(); break;
            case 4: UIPage.m_roomMany.m_PlayerAction4.m_c_state.SetSelectedIndex(act); UIPage.m_roomMany.m_PlayerAction4.m_t_anim.Play(); break;
            default:
                break;
        }
    }

    internal void SetPokerType(int pos, int pokerType1)
    {
        switch (pos)
        {
            case 0:
                UIPage.m_roomMany.m_cards0.m_c_cardType.SetSelectedIndex(pokerType1);
                break;
            case 1:
                UIPage.m_roomMany.m_cards1.m_c_cardType.SetSelectedIndex(pokerType1);
                break;
            case 2: UIPage.m_roomMany.m_cards2.m_c_cardType.SetSelectedIndex(pokerType1); break;
            case 3: UIPage.m_roomMany.m_cards3.m_c_cardType.SetSelectedIndex(pokerType1); break;
            case 4: UIPage.m_roomMany.m_cards4.m_c_cardType.SetSelectedIndex(pokerType1); break;

            default:
                break;
        }
    }
    /// <summary>
    /// 播放胜利动画
    /// </summary>
    /// <param name="pos"></param>
    internal void PlayWinAnim(int pos)
    {
        switch (pos)
        {
            case 0:
                UIPage.m_roomMany.m_info0.m_t_win.Play();
                break;
            case 1:
                UIPage.m_roomMany.m_info1.m_t_win.Play();
                break;
            case 2:
                UIPage.m_roomMany.m_info2.m_t_win.Play();
                break;
            case 3:
                UIPage.m_roomMany.m_info3.m_t_win.Play();
                break;
            case 4:
                UIPage.m_roomMany.m_info4.m_t_win.Play();
                break;
            default:
                break;
        }
    }
    internal void PlayResults()
    {
        UIPage.m_roomMany.m_t_result.Play();
        UIPage.m_roomMany.m_t_result.SetHook("over", ClearResults);
    }
    internal void ClearResults()
    {
        ClearPoker();
        UIPage.m_roomMany.m_text_results0Loss.text = "";
        UIPage.m_roomMany.m_text_results0Win.text = "";
        UIPage.m_roomMany.m_text_results1Loss.text = "";
        UIPage.m_roomMany.m_text_results1Win.text = "";
        UIPage.m_roomMany.m_text_results2Loss.text = "";
        UIPage.m_roomMany.m_text_results2Win.text = "";
        UIPage.m_roomMany.m_text_results3Loss.text = "";
        UIPage.m_roomMany.m_text_results3Win.text = "";
        UIPage.m_roomMany.m_text_results4Loss.text = "";
        UIPage.m_roomMany.m_text_results4Win.text = "";
    }

    private void ClearPosPoker(UI_cards uI_Cards)
    {
        Sprite sprite = FileIO.LoadSprite(R.SpritePack.CARDS_CARD00);
        if (uI_Cards.m_n0.visible)
            uI_Cards.m_n0.visible = false;
        if (uI_Cards.m_n1.visible)
            uI_Cards.m_n1.visible = false;
        if (uI_Cards.m_n2.visible)
            uI_Cards.m_n2.visible = false;
        uI_Cards.m_n0.texture = new NTexture(sprite);
        uI_Cards.m_n1.texture = new NTexture(sprite);
        uI_Cards.m_n2.texture = new NTexture(sprite);
        uI_Cards.m_c_cardType.SetSelectedIndex(0);
    }

    private void ClearPokerState()
    {
        UIPage.m_roomMany.m_state0.texture = null;
        UIPage.m_roomMany.m_state1.texture = null;
        UIPage.m_roomMany.m_state2.texture = null;
        UIPage.m_roomMany.m_state3.texture = null;
        UIPage.m_roomMany.m_state4.texture = null;
    }

    private void ClearPoker()
    {
        if (UIPage != null)
        {
            ClearPosPoker(UIPage.m_roomMany.m_cards0);
            UIPage.m_roomMany.m_info0.m_text_gold.text = "0";

            ClearPosPoker(UIPage.m_roomMany.m_cards1);
            UIPage.m_roomMany.m_info1.m_text_gold.text = "0";

            ClearPosPoker(UIPage.m_roomMany.m_cards2);
            UIPage.m_roomMany.m_info2.m_text_gold.text = "0";

            ClearPosPoker(UIPage.m_roomMany.m_cards3);
            UIPage.m_roomMany.m_info3.m_text_gold.text = "0";

            ClearPosPoker(UIPage.m_roomMany.m_cards4);
            UIPage.m_roomMany.m_info4.m_text_gold.text = "0";

            ClearPokerState();

            this.allBetNum = 0;
            UIPage.m_roomMany.m_text_allBet.text = ToolClass.LongConverStr(this.allBetNum);

            for (int i = 0; i < 5; i++)
            {
                if (CacheManager.ManyPeopleRoomPlayers[i] != null)
                {
                    CacheManager.ManyPeopleRoomPlayers[i].betNum = 0;
                }
            }

            UIPage.m_roomMany.m_ready0.visible = false;
            UIPage.m_roomMany.m_ready1.visible = false;
            UIPage.m_roomMany.m_ready2.visible = false;
            UIPage.m_roomMany.m_ready3.visible = false;
            UIPage.m_roomMany.m_ready4.visible = false;
        }
    }

    public override void Hide()
    {
        if (UIPage == null)
            return;
        if (coroutine != null && GameCanvas.gameCanvas != null)
            GameCanvas.gameCanvas.StopCoroutine(coroutine);
        if(UIPage!=null)
            ClearProgress();
        if(cardS!=null)
        foreach (GImage item in cardS)
        {
            if (item != null)
                item.visible = false;
        }

        ClearPoker();
        for (int i = 0; i < 5; i++)
        {
            CacheManager.ManyPeopleRoomPlayers[i] = null;
        }
        UIPage.m_roomMany.m_info0.visible = false;
        UIPage.m_roomMany.m_info1.visible = false;
        UIPage.m_roomMany.m_info2.visible = false;
        UIPage.m_roomMany.m_info3.visible = false;
        UIPage.m_roomMany.m_info4.visible = false;

        for (int i = Chips.Count - 1; i >= 0; i--)
        {
            UIChip uIChip = Chips[i];
            Chips.Remove(uIChip);
            ClosePage(uIChip);
        }

        hideClassChat?.Invoke();
        if (UIPage.m_c1.selectedIndex == 0)
        {
            BaseCanvas.GetController<ShopBoxCtrl>().Hide();
        }
      
        BaseCanvas.GetController<MessageCtrl>().HideTipesUI();

        UIPage.m_roomMany.m_state0.texture = null;
        UIPage.m_roomMany.m_state1.texture = null;
        UIPage.m_roomMany.m_state2.texture = null;
        UIPage.m_roomMany.m_state3.texture = null;
        UIPage.m_roomMany.m_state4.texture = null;

        while (Chips.Count > 0)
        {
            UIChip uIChip = Chips[Chips.Count - 1];
            Chips.Remove(uIChip);
            ClosePage(uIChip);
        }
        base.Hide();

    }

    internal void ClearInfo()
    {
        UIPage.m_roomMany.m_info0.visible = false;
        UIPage.m_roomMany.m_info1.visible = false;
        UIPage.m_roomMany.m_info2.visible = false;
        UIPage.m_roomMany.m_info3.visible = false;
        UIPage.m_roomMany.m_info4.visible = false;
    }
      
    private Tween tween;
    public void ShowLotteryTime(int time)
    {
        //Debug.LogError("Room彩票时间");
        tween = DOTween.To(() => time - 1, (value) => {

            UIPage.m_roomMany.m_txt_lotteryTime.text = MyTimeUtil.TimeToString(value);

        }, 0, time).SetEase(Ease.Linear);
    }

    public void LotteryWinPlay(bool play)
    {
        UIPage.m_roomMany.m_movie_win.visible = play;
        if (play)
        {
            if (UIPage.m_roomMany.m_t0.playing)
            {
                UIPage.m_roomMany.m_t0.Stop();
            }
            UIPage.m_roomMany.m_t0.Play();
        }
        else
        {
            if (UIPage.m_roomMany.m_t0.playing)
            {
                UIPage.m_roomMany.m_t0.Stop();
            }
        }
    }

    public void ShowCurBuyLotteryNum(int num)
    {
        if (num <= 0)
        {
            UIPage.m_roomMany.m_lotteryNum.visible = false;
        }
        else
        {
            UIPage.m_roomMany.m_txt_lotteryNum.text = num.ToString();
            UIPage.m_roomMany.m_lotteryNum.visible = true;
        }
    }

    internal void SetBtn(bool state)
    {
        SetObjState(UIPage.m_roomMany.m_btn_compate, state);
        SetObjState(UIPage.m_roomMany.m_text_compate, state);

        SetObjState(UIPage.m_roomMany.m_btn_fold, state);
        SetObjState(UIPage.m_roomMany.m_text_fold, state);

        SetObjState(UIPage.m_roomMany.m_btn_see, state);
        SetObjState(UIPage.m_roomMany.m_text_see, state);

        SetObjState(UIPage.m_roomMany.m_btn_raise, state);
        SetObjState(UIPage.m_roomMany.m_text_raise, state);

        SetObjState(UIPage.m_roomMany.m_btn_allin, state);
        SetObjState(UIPage.m_roomMany.m_text_allin, state);

        SetObjState(UIPage.m_roomMany.m_btn_call, state);
        SetObjState(UIPage.m_roomMany.m_text_call, state);

    }

    /// <summary>
    /// 比牌动画
    /// </summary>
    /// <param name="pos0"></param>
    /// <param name="pos1"></param>
    /// <param name="lossPos"></param>
    /// <returns></returns>
    internal IEnumerator PlayComparerPokerAnim(int pos0, int pos1)
    {
        List<GLoader> gLoaders = new List<GLoader>();

        switch (pos0)
        {
            case 0:
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n2);
                break;
            case 1:
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n2);
                break;
            case 2:
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n2);
                break;
            case 3:
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n2);
                break;
            case 4:
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n2);
                break;
            default:
                break;
        }

        switch (pos1)
        {
            case 0:
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards0.m_n2);
                break;
            case 1:
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards1.m_n2);
                break;
            case 2:
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards2.m_n2);
                break;
            case 3:
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards3.m_n2);
                break;
            case 4:
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n0);
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n1);
                gLoaders.Add(UIPage.m_roomMany.m_cards4.m_n2);
                break;
            default:
                break;
        }


        for (int i = 0; i < gLoaders.Count; i++)
        {
            gLoaders[i].visible = false;
        }


        yield return new WaitForSeconds(4f);
        for (int i = 0; i < gLoaders.Count; i++)
        {
            gLoaders[i].visible = true;
        }
        yield return null;
    }


    /// <summary>
    /// 打开消息记录面板
    /// </summary>
    private void BtnRocrd()
    {
        Vector2 pos = new Vector2(UIPage.m_roomMany.m_bg_horn.x, UIPage.m_roomMany.m_bg_horn.y) + new Vector2((UIPage.m_roomMany.m_bg_horn.width - 383) / 2, UIPage.m_roomMany.m_bg_horn.height);
        hornRecord(pos);
    }

    public void ClearProgress()
    {
        UIPage.m_roomMany.m_info0.m_bar.value = 0;
        UIPage.m_roomMany.m_info1.m_bar.value = 0;
        UIPage.m_roomMany.m_info2.m_bar.value = 0;
        UIPage.m_roomMany.m_info3.m_bar.value = 0;
        UIPage.m_roomMany.m_info4.m_bar.value = 0;
    }

    public void ClearEffect()
    {
        UIPage.m_roomMany.m_info0.m_n9.texture = null;
        UIPage.m_roomMany.m_info1.m_n13.texture = null;
        UIPage.m_roomMany.m_info2.m_n13.texture = null;
        UIPage.m_roomMany.m_info3.m_n13.texture = null;
        UIPage.m_roomMany.m_info4.m_n13.texture = null;
    }
    /// <summary>
    /// 判断是否是最高注
    /// </summary>
    /// <returns></returns>
    public bool IsHighestRaise()
    {
        if (CacheManager.RunRoomId ==5 && betNum >=250000)
            return true;
        return false;
    }

    internal void HideBtn(bool state)
    {
        if (state)
        {
            if (CacheManager.ManyPeopleRoomPlayers[0] == null || CacheManager.ManyPeopleRoomPlayers[0].userId != CacheManager.gameData.userId)
            {
                return;
            }
            BaseCanvas.GetController<MessageCtrl>().HideTipesUI();
        }
        UIPage.m_roomMany.m_btns.visible = state;
    }

    internal void SetStateText(string str)
    {
        UIPage.m_roomMany.m_text_timer.text = str;
    }

    /// <summary>
    /// 清理输赢金币和赢的玩家动画特效
    /// </summary>
    internal void ClearAnim()
    {
        UIPage.m_roomMany.m_info0.m_n9.texture = null;
        UIPage.m_roomMany.m_info1.m_n13.texture = null;
        UIPage.m_roomMany.m_info2.m_n13.texture = null;
        UIPage.m_roomMany.m_info3.m_n13.texture = null;
        UIPage.m_roomMany.m_info4.m_n13.texture = null;

        UIPage.m_roomMany.m_text_results0Win.text = "";
        UIPage.m_roomMany.m_text_results0Loss.text = "";
        UIPage.m_roomMany.m_text_results1Win.text = "";
        UIPage.m_roomMany.m_text_results1Loss.text = "";
        UIPage.m_roomMany.m_text_results2Win.text = "";
        UIPage.m_roomMany.m_text_results2Loss.text = "";
        UIPage.m_roomMany.m_text_results3Win.text = "";
        UIPage.m_roomMany.m_text_results3Loss.text = "";
        UIPage.m_roomMany.m_text_results4Win.text = "";
        UIPage.m_roomMany.m_text_results4Loss.text = "";

    }

    internal void ClearAllPoker()
    {
        UIPage.m_roomMany.m_info0.visible = false;
        UIPage.m_roomMany.m_cards0.m_n0.visible = false;
        UIPage.m_roomMany.m_cards0.m_n1.visible = false;
        UIPage.m_roomMany.m_cards0.m_n2.visible = false;

        UIPage.m_roomMany.m_info1.visible = false;
        UIPage.m_roomMany.m_cards1.m_n0.visible = false;
        UIPage.m_roomMany.m_cards1.m_n1.visible = false;
        UIPage.m_roomMany.m_cards1.m_n2.visible = false;

        UIPage.m_roomMany.m_info2.visible = false;
        UIPage.m_roomMany.m_cards2.m_n0.visible = false;
        UIPage.m_roomMany.m_cards2.m_n1.visible = false;
        UIPage.m_roomMany.m_cards2.m_n2.visible = false;

        UIPage.m_roomMany.m_info3.visible = false;
        UIPage.m_roomMany.m_cards3.m_n0.visible = false;
        UIPage.m_roomMany.m_cards3.m_n1.visible = false;
        UIPage.m_roomMany.m_cards3.m_n2.visible = false;

        UIPage.m_roomMany.m_info4.visible = false;
        UIPage.m_roomMany.m_cards4.m_n0.visible = false;
        UIPage.m_roomMany.m_cards4.m_n1.visible = false;
        UIPage.m_roomMany.m_cards4.m_n2.visible = false;

    }
}