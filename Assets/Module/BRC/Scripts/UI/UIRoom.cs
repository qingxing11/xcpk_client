using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Room;
using WT.UI;
using System;
using FairyGUI;
using DG.Tweening;

public class UIRoom : WTUIPage<UI_RoomTV, RoomCtrl>
{

    public UIRoom() : base(UIType.Dialog, UIMode.DoNothing, R.UI.ROOM)
    {
    }
    private int odds = 20000;      //赔率
    private long selfNum0, selfNum1, selfNum2, selfNum3;
    private List<Coroutine> coroutines = new List<Coroutine>();    //协程
    private bool isClockAnimTrue = false;

    public Action ActionChat;
    public Action<int> ActionInfo;       //查看玩家信息
    public Action<int, int> ActionBet;   //下注(索引和赔率)
    public Action<int> ActionSitDown;    //坐下
    public Action ActionUpBank;          //上庄列表
    public Action ActionJackpot;         //奖池
    public Action ActionTrend;           //走势
    public Action lottery;               //彩票
    public Action ActionBack;            //返回按钮
    public Action ActionOnClick;         //点击任意地方
    public Action ActionHeadOnClick;     //
    public Action ActionMore;
    public Action ActionCloseTV;
    public Action showHorn;             //喇叭
    public Action ActionFriend;         //好友
    public Action ActionTableOnClick;        //
    public Action<Vector2> hornRecord;//消息记录面板
    public Action hide;
    public Action ActionFastBuy;

    private List<UIGold> uiGolds0 = new List<UIGold>();   //用来存放四堆金币
    private List<UIGold> uiGolds1 = new List<UIGold>();
    private List<UIGold> uiGolds2 = new List<UIGold>();
    private List<UIGold> uiGolds3 = new List<UIGold>();

    private void AddGoldToPosition0(UIGold gold)
    {
       
        uiGolds0.Add(gold);
    }

    private void AddGoldToPosition3(UIGold gold)
    {
 
        uiGolds3.Add(gold);
    }

    public override void Awake()
    {
        UIPage.m_room.m_btn_horn.onClick.Add(() => showHorn());//喇叭按钮
        UIPage.m_room.onClick.Add(() => { ActionOnClick?.Invoke(); });
        UIPage.onClick.Add(() => { ActionTableOnClick?.Invoke(); });
        UIPage.m_room.m_btn_back.onClick.Add(() => { ActionBack?.Invoke(); });         //菜单按钮
        UIPage.m_room.m_btn_chat.onClick.Add(() => { ActionChat?.Invoke(); });         //聊天
        UIPage.m_room.m_btn_jackpot.onClick.Add(() => { ActionJackpot?.Invoke(); });   //奖池
        UIPage.m_room.m_btn_trend.onClick.Add(() => { ActionTrend?.Invoke(); });       //走势
        UIPage.m_room.m_btn_lottery.onClick.Add(() => { lottery(); });                 //彩票
        UIPage.m_room.m_btn_friend.onClick.Add(() => { ActionFriend?.Invoke(); });                   //好友
        UIPage.m_room.m_btn_more.onClick.Add(() => { ActionMore?.Invoke(); });//更多按钮
        UIPage.m_n2.onClick.Add(() => { ActionCloseTV?.Invoke(); });          //关闭通杀场电视机
        UIPage.m_room.m_btn_fastbuy.onClick.Add(() => { ActionFastBuy?.Invoke(); }); //快速充值


        UIPage.m_room.m_info0.onClick.Add(() => { BtnInfoOnClick(0); });       //点击玩家头像
        UIPage.m_room.m_info1.onClick.Add(() => { BtnInfoOnClick(1); });
        UIPage.m_room.m_info2.onClick.Add(() => { BtnInfoOnClick(2); });
        UIPage.m_room.m_info3.onClick.Add(() => { BtnInfoOnClick(3); });
        UIPage.m_room.m_info4.onClick.Add(() => { BtnInfoOnClick(4); });
        UIPage.m_room.m_info5.onClick.Add(() => { BtnInfoOnClick(5); });
        UIPage.m_room.m_info6.onClick.Add(() => { BtnInfoOnClick(6); });
        UIPage.m_room.m_info7.onClick.Add(() => { BtnInfoOnClick(7); });
        UIPage.m_room.m_infoBanker.onClick.Add(() => { ActionInfo?.Invoke(8); }); //点击庄家头像
        UIPage.m_room.m_head.onClick.Add(() => { ActionHeadOnClick?.Invoke(); }); //点击自己头像

        UIPage.m_room.m_btn_gold10.onClick.Add(() => { BtnGoldOnClick(10); });     //点击赔率   
        UIPage.m_room.m_btn_gold20.onClick.Add(() => { BtnGoldOnClick(20); });
        UIPage.m_room.m_btn_gold50.onClick.Add(() => { BtnGoldOnClick(50); });

        UIPage.m_room.m_index0.onClick.Add(() => { BetOnClick(0); });  //点击下注
        UIPage.m_room.m_index1.onClick.Add(() => { BetOnClick(1); });
        UIPage.m_room.m_index2.onClick.Add(() => { BetOnClick(2); });
        UIPage.m_room.m_index3.onClick.Add(() => { BetOnClick(3); });

        UIPage.m_room.m_btn_hornReocrd.onClick.Add(BtnRocrd);//消息记录面板


        UIPage.m_room.m_btn_upbank.onClick.Add(() => { ActionUpBank?.Invoke(); });

        UIPage.m_room.m_lotteryNum.visible = false;//彩票界面数字显示
        UIPage.m_room.m_movie_win.visible = false;//彩票中奖闪烁

        UIPage.m_room.m_redEnvelope.onClick.Add(() =>
        {
            if (CacheManager.banker != null)
            {
                BaseCanvas.GetController<SendRedEnvelopeCtrl>().ShowSendRedEnvelope(CacheManager.banker.userId);
            }
        });
    }

    public void Set(int index)
    {
        UIPage.m_room.m_c2.SetSelectedIndex(index);

        UIPage.m_c1.SetSelectedIndex(index);

        //Debug.Log("KillRoomTV:" + CacheManager.KillRoomTV);
        if (CacheManager.KillRoomTV == 0)
        {
            WTUIPage.ShowPage<UIGlobalNotic>().SetPosition(197, 15).SetRotate(0);
        }
 
        switch (index)
        {
            case 0:
                foreach (UIGold uiGold in uiGolds0)
                {
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    //Vector2 endVector = UIPage.m_room.m_index0.position;
                    Vector2 endVector = new Vector2(175 + x, 272 + y);
                    uiGold.SetPosition(endVector);
                }
                foreach (UIGold uiGold in uiGolds1)
                {
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    //Vector2 endVector = UIPage.m_room.m_index1.position;
                    Vector2 endVector = new Vector2(324 + x, 272 + y);
                    uiGold.SetPosition(endVector);
                }
                foreach (UIGold uiGold in uiGolds2)
                {
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    //Vector2 endVector = UIPage.m_room.m_index2.position;
                    Vector2 endVector = new Vector2(477 + x, 272 + y);
                    uiGold.SetPosition(endVector);
                }

 
                foreach (UIGold uiGold in uiGolds3)
                {
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    //Vector2 endVector = UIPage.m_room.m_index3.position;
                    Vector2 endVector = new Vector2(634 + x, 272 + y);
                    uiGold.SetPosition(endVector);
                }


                break;
            case 1:
                break;
            case 2:
                foreach (UIGold uiGold in uiGolds0)
                {
                    BaseCanvas.GetController<GoldCtrl>().Show(uiGold.name);
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    Vector2 endVector = UIPage.m_room.m_index0.position;
                    endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x + x - 128f, 0.2f * 480 + 0.6f * endVector.y + y + 16);
                    uiGold.SetPosition(endVector);
                }
                foreach (UIGold uiGold in uiGolds1)
                {
                    BaseCanvas.GetController<GoldCtrl>().Show(uiGold.name);
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    Vector2 endVector = UIPage.m_room.m_index1.position;
                    endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x + x - 128f, 0.2f * 480 + 0.6f * endVector.y + y + 16);
                    uiGold.SetPosition(endVector);
                }
                foreach (UIGold uiGold in uiGolds2)
                {
                    BaseCanvas.GetController<GoldCtrl>().Show(uiGold.name);
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    Vector2 endVector = UIPage.m_room.m_index2.position;
                    endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x + x - 128f, 0.2f * 480 + 0.6f * endVector.y + y + 16);
                    uiGold.SetPosition(endVector);
                }
                foreach (UIGold uiGold in uiGolds3)
                {
                    BaseCanvas.GetController<GoldCtrl>().Show(uiGold.name);
                    int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
                    int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
                    Vector2 endVector = UIPage.m_room.m_index3.position;
                    endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x + x - 128f, 0.2f * 480 + 0.6f * endVector.y + y + 16);
                    uiGold.SetPosition(endVector);
                }
                break;
            default:
                break;
        }
    }

    public void SetBankerRound()
    {
        if (CacheManager.banker.userId == 100000)
        {
            UIPage.m_room.m_text_num.visible = false;
        }
        else
        {
            UIPage.m_room.m_text_num.visible = true;
            UIPage.m_room.m_text_num.text = "第" + CacheManager.bankerRound + "局";
        }
    }

    private void Init()
    {
        UIPage.m_room.m_vip.texture = null;

        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(Timer()));//"北京时间 "
        selfNum0 = selfNum1 = selfNum2 = selfNum3 = 0;

        UIPage.m_room.m_text_nickname.text = CacheManager.gameData.nickName;
        UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        SetBankerRound();

        SetTableHead();

        //if (CacheManager.headImgIcon != null)
        if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);

            UIPage.m_room.m_head.texture = new NTexture(t2d);
        }
        else if (CacheManager.gameData.roleId == 0)
            UIPage.m_room.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
        else
        {
            UIPage.m_room.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
        }
        UIPage.m_room.m_btn_jackpot.m_text_conis.text = ToolClass.LongConverStr(CacheManager.jackpot);


        if (CacheManager.state == KillRoom.STATE_BET_TIME)                    //下注
        {
            coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(IETimer(KillRoom.BET_TIME - CacheManager.stateTime)));//"下注时间 ",
        }
        else if (CacheManager.state == KillRoom.STATE_LOTTERY_TIME)           //开奖状态
        {
            coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(IETimer(KillRoom.LOTTERY_TIME - CacheManager.stateTime + KillRoom.IDLE_TIME)));//"休息时间 ",
        }
        else       //休息时间
        {
            coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(IETimer(KillRoom.IDLE_TIME - CacheManager.stateTime)));//"休息时间 ",
        }

        UpdataBaker();

        Sprite vipSprite = null;
        switch (CacheManager.gameData.vipLv)
        {
            case 1: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP1); break;
            case 2: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP2); break;
            case 3: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP3); break;
            case 4: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP4); break;
            case 5: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP5); break;
            default:
                break;
        }
        if (vipSprite != null)
        {
            UIPage.m_room.m_vip.texture = new NTexture(vipSprite);
        }


        //切换界面时，清空coins，重新创建
        ClearAllCoins();
        if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum != null)
        {
            for (int i = 0; i < BaseCanvas.GetController<RoomCtrl>().list_directionBetNum.Count; i++)
            {
                if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[i] <= 0)
                    continue;
                else if (BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[i] == 20000)
                    StartGold(i);
                else
                {
                    int num = UnityEngine.Random.Range(2, 8);
                    for (int j = 0; j < num; j++)
                    {
                        StartGold(i);
                    }
                }


                //UpdateSelf(i, (int)BaseCanvas.GetController<RoomCtrl>().list_directionBetNum[i]);
            }
        }

        for (int i = 0; i < CacheManager.killRoom.killRoomPayBet.Length; i++)
        {
            UpdateSelf(i, CacheManager.killRoom.killRoomPayBet[i]);
        }


        if (CacheManager.TablePlayers[0] != null)
        {
            SetPosData(UIPage.m_room.m_info0, 0, true);
        }

        if (CacheManager.TablePlayers[1] != null)
        {
            SetPosData(UIPage.m_room.m_info1, 1, true);
        }
        if (CacheManager.TablePlayers[2] != null)
        {
            SetPosData(UIPage.m_room.m_info2, 2, true);
        }
        if (CacheManager.TablePlayers[3] != null)
        {
            SetPosData(UIPage.m_room.m_info3, 3, true);
        }
        if (CacheManager.TablePlayers[4] != null)
        {
            SetPosData(UIPage.m_room.m_info4, 4, true);
        }

        if (CacheManager.TablePlayers[5] != null)
        {
            SetPosData(UIPage.m_room.m_info5, 5, true);
        }

        if (CacheManager.TablePlayers[6] != null)
        {
            SetPosData(UIPage.m_room.m_info6, 6, true);
        }

        if (CacheManager.TablePlayers[7] != null)
        {
            SetPosData(UIPage.m_room.m_info7, 7, true);
        }
    }

    internal void Clear()
    {
        selfNum0 = 0;
        selfNum1 = 0;
        selfNum2 = 0;
        selfNum3 = 0;

        if (UIPage != null)
        {
            UIPage.m_room.m_selfCoins0.m_text_coins.text = selfNum0.ToString();
            UIPage.m_room.m_selfCoins1.m_text_coins.text = selfNum1.ToString();
            UIPage.m_room.m_selfCoins2.m_text_coins.text = selfNum2.ToString();
            UIPage.m_room.m_selfCoins3.m_text_coins.text = selfNum3.ToString();
        }

    }

    public void SetNickname()
    {
        UIPage.m_room.m_text_nickname.text = CacheManager.gameData.nickName;
    }

    /// <summary>
    /// 设置东南西北头像
    /// </summary>
    private void SetTableHead()
    {
        if (BaseCanvas.GetController<RoomCtrl>().list_bigWin != null)
        {
            List<KillRoomBigWinVO> list_bigWin = BaseCanvas.GetController<RoomCtrl>().list_bigWin;
            for (int i = 0; i < list_bigWin.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        if (list_bigWin[0] != null)
                        {
                            UIPage.m_room.m_table_nickName0.text = list_bigWin[0].nickName;
                            Debug.Log("list_bigWin[0].headIconUrl):"+ list_bigWin[0].headIconUrl);
                            if (!string.IsNullOrEmpty(list_bigWin[0].headIconUrl))
                            {
                                Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[0].headIconUrl);

                                UIPage.m_room.m_table_head0.texture = new NTexture(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero));
                            }
                            else
                            {
                                UIPage.m_room.m_table_head0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                            }
                        }
                        else
                        {
                            UIPage.m_room.m_table_nickName0.text = "";
                        }
                        break;
                    case 1:
                        if (list_bigWin[1] != null)
                        {
                            UIPage.m_room.m_table_nickName1.text = list_bigWin[1].nickName;

                            //if (string.IsNullOrEmpty(list_bigWin[0].headIconUrl))
                            //{
                            //    Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[0].headIconUrl);
                            if (!string.IsNullOrEmpty(list_bigWin[1].headIconUrl))
                            {
                                Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[0].headIconUrl);

                                UIPage.m_room.m_table_head1.texture = new NTexture(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero));
                            }
                            else
                            {
                                UIPage.m_room.m_table_head1.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                            }
                        }
                        else
                        {
                            UIPage.m_room.m_table_nickName1.text = "";
                        }
                        break;
                    case 2:
                        if (list_bigWin[2] != null)
                        {
                            UIPage.m_room.m_table_nickName2.text = list_bigWin[2].nickName;

                            //if (string.IsNullOrEmpty(list_bigWin[0].headIconUrl))
                            //{
                            //    Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[0].headIconUrl);
                            if (!string.IsNullOrEmpty(list_bigWin[2].headIconUrl))
                            {
                                Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[2].headIconUrl);
                                UIPage.m_room.m_table_head2.texture = new NTexture(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero));
                            }
                            else
                            {
                                UIPage.m_room.m_table_head2.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                            }
                        }
                        else
                        {
                            UIPage.m_room.m_table_nickName2.text = "";
                        }
                        break;
                    case 3:
                        if (list_bigWin[3] != null)
                        {
                            UIPage.m_room.m_table_nickName3.text = list_bigWin[3].nickName;
                            //if (string.IsNullOrEmpty(list_bigWin[0].headIconUrl))
                            //{
                            //    Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[0].headIconUrl);
                            if (!string.IsNullOrEmpty(list_bigWin[3].headIconUrl))
                            {
                                Texture2D texture2D = CacheManager.GetHeadIcon(list_bigWin[3].headIconUrl);

                                UIPage.m_room.m_table_head3.texture = new NTexture(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero));
                            }
                            else
                            {
                                UIPage.m_room.m_table_head3.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                            }
                        }
                        else
                        {
                            UIPage.m_room.m_table_nickName3.text = "";
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

    internal void UpdateBankerCoins(int userId,long coins)
    {
        if (CacheManager.banker.userId == userId)
        {
            UIPage.m_room.m_infoBanker.m_gold.text = ToolClass.LongConverStr(coins);
        }
        else
        {
            Debug.Log("玩家:"+ userId+",更新金币:"+ coins);
            for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
            {
                if (CacheManager.TablePlayers[i] != null && CacheManager.TablePlayers[i].userId == userId)
                {
                    Debug.Log("匹配玩家 ："+ CacheManager.TablePlayers[i].userId+",位置;"+ CacheManager.TablePlayers[i].killRoomPos);
                    CacheManager.TablePlayers[i].coins = coins;
                    UpdataTableCoins(CacheManager.TablePlayers[i].killRoomPos);
                    break;
                }
            }
        }
         
    }

    private void SetBanker(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.banker.sprites[index]);
    }

    private void BtnInfoOnClick(int pos)
    {
        if (CacheManager.KillRoomTV == 0)
        {
            switch (pos)
            {
                case 0: SetInfoItem(UIPage.m_room.m_info0, 0); break;
                case 1: SetInfoItem(UIPage.m_room.m_info1, 1); break;
                case 2: SetInfoItem(UIPage.m_room.m_info2, 2); break;
                case 3: SetInfoItem(UIPage.m_room.m_info3, 3); break;
                case 4: SetInfoItem(UIPage.m_room.m_info4, 4); break;
                case 5: SetInfoItem(UIPage.m_room.m_info5, 5); break;
                case 6: SetInfoItem(UIPage.m_room.m_info6, 6); break;
                case 7: SetInfoItem(UIPage.m_room.m_info7, 7); break;
                default:
                    break;
            }
        }
    }
    private void SetInfoItem(UI_infoitem uI_Infoitem, int pos)
    {
        if (uI_Infoitem.m_c1.selectedIndex == 0)
        {
            ActionSitDown?.Invoke(pos);
        }
        else
        {
            ActionInfo?.Invoke(pos);
        }
    }

    /// <summary>
    /// 设置座位数据
    /// </summary>
    /// <param name="uI_Infoitem"></param>
    private void SetPosData(UI_infoitem uI_Infoitem, int pos, bool isSitdwon)
    {
        if (isSitdwon)      //有人
        {
            PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[pos];
            if (playerSimpleData.sprites.Count > 0)
            {
                switch (pos)
                {
                    case 0:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon0;
                        break;
                    case 1:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon1;
                        break;
                    case 2:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon2;
                        break;
                    case 3:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon3;
                        break;
                    case 4:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon4;
                        break;
                    case 5:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon5;
                        break;
                    case 6:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon6;
                        break;
                    case 7:
                        uI_Infoitem.m_icon_list.itemRenderer = SetIcon7;
                        break;
                    default:
                        break;
                }

                uI_Infoitem.m_icon_list.numItems = playerSimpleData.sprites.Count;
            }
            else
            {
                uI_Infoitem.m_icon_list.numItems = 0;
            }
            ToolClass.SetVipTexture(uI_Infoitem.m_vip, playerSimpleData.vipLv);
            uI_Infoitem.m_gold.text = ToolClass.LongConverStr2(playerSimpleData.coins);
            ToolClass.GetHead(playerSimpleData);
            uI_Infoitem.m_head.m_n0.texture = new NTexture(playerSimpleData.headIcon);
            uI_Infoitem.m_c1.selectedIndex = 1;
        }
        else      //没人
        {
            uI_Infoitem.m_c1.selectedIndex = 0;
            uI_Infoitem.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        }
    }

    internal void SetInfoVip()
    {
        if (UIPage.m_room.m_c1.selectedIndex == 0)
        {
            Sprite sprite = null;
            switch (CacheManager.gameData.vipLv)
            {
                case 1: sprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP1); break;
                case 2: sprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP2); break;
                case 3: sprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP3); break;
                case 4: sprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP4); break;
                case 5: sprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP5); break;
                default:
                    break;
            }
            if (CacheManager.gameData.vipLv > 0)
                UIPage.m_room.m_vip.texture = new NTexture(sprite);
            else
                UIPage.m_room.m_vip.texture = null;
        }
    }

    private void SetIcon0(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[0].sprites[index]);
    }
    private void SetIcon1(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[1].sprites[index]);
    }
    private void SetIcon2(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[2].sprites[index]);
    }
    private void SetIcon3(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[3].sprites[index]);
    }
    private void SetIcon4(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[4].sprites[index]);
    }
    private void SetIcon5(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[5].sprites[index]);
    }
    private void SetIcon6(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[6].sprites[index]);
    }
    private void SetIcon7(int index, GObject item)
    {
        UI_icon uI_Icon = (UI_icon)item;
        uI_Icon.m_n0.texture = new NTexture(CacheManager.TablePlayers[7].sprites[index]);
    }

    public void SetPosData(int pos, bool isSitdwon)
    {
        switch (pos)
        {
            case 0: SetPosData(UIPage.m_room.m_info0, 0, isSitdwon); break;
            case 1: SetPosData(UIPage.m_room.m_info1, 1, isSitdwon); break;
            case 2: SetPosData(UIPage.m_room.m_info2, 2, isSitdwon); break;
            case 3: SetPosData(UIPage.m_room.m_info3, 3, isSitdwon); break;
            case 4: SetPosData(UIPage.m_room.m_info4, 4, isSitdwon); break;
            case 5: SetPosData(UIPage.m_room.m_info5, 5, isSitdwon); break;
            case 6: SetPosData(UIPage.m_room.m_info6, 6, isSitdwon); break;
            case 7: SetPosData(UIPage.m_room.m_info7, 7, isSitdwon); break;
            default:
                break;
        }
    }

    //玩家下注
    internal void UpdatePosGold(int startPos, int endPos)
    {
        GoldAnim(startPos, endPos);
        switch (startPos)
        {
            case 0: UIPage.m_room.m_info0.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[0].coins); break;
            case 1: UIPage.m_room.m_info1.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[1].coins); break;
            case 2: UIPage.m_room.m_info2.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[2].coins); break;
            case 3: UIPage.m_room.m_info3.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[3].coins); break;
            case 4: UIPage.m_room.m_info4.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[4].coins); break;
            case 5: UIPage.m_room.m_info5.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[5].coins); break;
            case 6: UIPage.m_room.m_info6.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[6].coins); break;
            case 7: UIPage.m_room.m_info7.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[7].coins); break;
            case 8:
                UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
                BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                break;     //最下边自己不再座位的时候
            case 9:
                break;     //外围玩家
            default:
                break;
        }
    }
    public void RefPosCoins(int pos)
    {
        switch (pos)
        {
            case 0: UIPage.m_room.m_info0.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[0].coins); break;
            case 1: UIPage.m_room.m_info1.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[1].coins); break;
            case 2: UIPage.m_room.m_info2.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[2].coins); break;
            case 3: UIPage.m_room.m_info3.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[3].coins); break;
            case 4: UIPage.m_room.m_info4.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[4].coins); break;
            case 5: UIPage.m_room.m_info5.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[5].coins); break;
            case 6: UIPage.m_room.m_info6.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[6].coins); break;
            case 7: UIPage.m_room.m_info7.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[7].coins); break;
            case 8:
                UIPage.m_room.m_infoBanker.text = ToolClass.LongConverStr(CacheManager.banker.coins);
                BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                break;     //最下边自己不再座位的时候
            case 9:
                break;     //外围玩家
        }
    }
    /// <summary>
    /// 刷新自己金币金币
    /// </summary>
    public void RefreshCoin()
    {
        Debug.Log("RefreshCoin,CacheManager.gameData.coins:" + CacheManager.gameData.coins);
        UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
        {
            if (CacheManager.TablePlayers[i] != null && CacheManager.TablePlayers[i].userId == CacheManager.gameData.userId)
            {
                CacheManager.TablePlayers[i].coins = CacheManager.gameData.coins;
                UpdateSelfPosPosition(i);
                break;
            }
        }
        if (CacheManager.banker.userId == CacheManager.gameData.userId)
        {
            UIPage.m_room.m_infoBanker.m_gold.text = ToolClass.LongConverStr(CacheManager.gameData.coins);
        }
    }

    public void UpdateSelfPosPosition(int pos)
    {
        switch (pos)
        {
            case 0: UIPage.m_room.m_info0.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[0].coins); break;
            case 1: UIPage.m_room.m_info1.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[1].coins); break;
            case 2: UIPage.m_room.m_info2.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[2].coins); break;
            case 3: UIPage.m_room.m_info3.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[3].coins); break;
            case 4: UIPage.m_room.m_info4.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[4].coins); break;
            case 5: UIPage.m_room.m_info5.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[5].coins); break;
            case 6: UIPage.m_room.m_info6.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[6].coins); break;
            case 7: UIPage.m_room.m_info7.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[7].coins); break;
            default:
                break;
        }
    }

    private void BtnGoldOnClick(int index)
    {
        switch (index)
        {
            case 10:

                UIPage.m_room.m_btn_gold20.selected = false;
                UIPage.m_room.m_btn_gold50.selected = false;
                if (odds == 200000)
                {
                    UIPage.m_room.m_btn_gold10.selected = false;
                    odds = 20000;
                }
                else
                {
                    odds = 200000;
                }
                break;
            case 20:

                UIPage.m_room.m_btn_gold10.selected = false;
                UIPage.m_room.m_btn_gold50.selected = false;
                if (odds == 400000)
                {
                    UIPage.m_room.m_btn_gold20.selected = false;
                    odds = 20000;
                }
                else
                {
                    odds = 400000;
                }
                break;
            case 50:

                UIPage.m_room.m_btn_gold10.selected = false;
                UIPage.m_room.m_btn_gold20.selected = false;
                if (odds == 1000000)
                {
                    UIPage.m_room.m_btn_gold50.selected = false;
                    odds = 20000;
                }
                else
                {
                    odds = 1000000;
                }
                break;
            default:
                break;
        }
    }

    //下注
    private void BetOnClick(int pos)
    {
        if (CacheManager.killRoom.state == KillRoom.STATE_BET_TIME)
        {
            ActionBet?.Invoke(pos, odds);
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
    /// 下注金币动画
    /// </summary>
    /// <param name="startPos">开始位置</param>
    /// <param name="endPos">结束位置</param>
    /// <param name="numCount">金币数量</param>
    public void GoldAnim(int startPos, int endPos)
    {

        int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
        int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
        UIGold uiGold = CacheManager.GetUIGold();
        uiGold.Init(startPos, endPos);
        Vector2 startVector = Vector2.zero;//开始位置
        Vector2 endVector = Vector2.zero;  //结束位置
        switch (startPos)        //开始位置
        {   //0-7座位玩家
            case 0: startVector = UIPage.m_room.m_info0.position; break;
            case 1: startVector = UIPage.m_room.m_info1.position; break;
            case 2: startVector = UIPage.m_room.m_info2.position; break;
            case 3: startVector = UIPage.m_room.m_info3.position; break;
            case 4: startVector = UIPage.m_room.m_info4.position; break;
            case 5: startVector = UIPage.m_room.m_info5.position; break;
            case 6: startVector = UIPage.m_room.m_info6.position; break;
            case 7: startVector = UIPage.m_room.m_info7.position; break;
            case 8: startVector = UIPage.m_room.m_head.position; break;        //最下边自己未在座位上 
            case 9: startVector = UIPage.m_room.m_btn_out.position; break;     //外场玩家
            case 10: startVector = UIPage.m_room.m_infoBanker.position; break; //庄家
            default:
                break;
        }
        switch (endPos)
        {
            case 0:
                endVector = UIPage.m_room.m_index0.position;
                AddGoldToPosition0(uiGold);
                break;
            case 1:
                endVector = UIPage.m_room.m_index1.position;
                uiGolds1.Add(uiGold);
                break;
            case 2:
                endVector = UIPage.m_room.m_index2.position;
                uiGolds2.Add(uiGold);
                break;
            case 3:
                endVector = UIPage.m_room.m_index3.position;
                AddGoldToPosition3(uiGold);
                break;
            default:
                break;
        }
        endVector = new Vector2(endVector.x + x, endVector.y + y);
        if (CacheManager.KillRoomTV == 1)
        {
            startVector = new Vector2(0.2f * 800 + 0.6f * startVector.x, 0.2f * 480 + 0.6f * startVector.y);
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x, 0.2f * 480 + 0.6f * endVector.y);
        }
        else if (CacheManager.KillRoomTV == 2)
        {
            startVector = new Vector2(0.2f * 800 + 0.6f * startVector.x - 128f, 0.2f * 480 + 0.6f * startVector.y + 16);
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x - 128f, 0.2f * 480 + 0.6f * endVector.y + 16);
        }
        uiGold.SetPosition(startVector);
        GTweener tweener = uiGold.getGComponent().TweenMove(endVector, 1f);
        uiGold.SetGTweener(tweener);
    }

    public void StartGold(int endPos)
    {
       
        int x = UnityEngine.Random.Range(0, 40) - 20 - 8;
        int y = UnityEngine.Random.Range(0, 40) - 20 - 9;
        UIGold uiGold = CacheManager.GetUIGold();
        uiGold.Init(9, endPos);
        Vector2 endVector = Vector2.zero;  //结束位置
        switch (endPos)
        {
            case 0:
                endVector = UIPage.m_room.m_index0.position;
                AddGoldToPosition0(uiGold);
                break;
            case 1:
                endVector = UIPage.m_room.m_index1.position;
                uiGolds1.Add(uiGold);
                break;
            case 2:
                endVector = UIPage.m_room.m_index2.position;
                uiGolds2.Add(uiGold);
                break;
            case 3:
                endVector = UIPage.m_room.m_index3.position;
                AddGoldToPosition3(uiGold);
                break;
            default:
                break;
        }
        endVector = new Vector2(endVector.x + x, endVector.y + y);
        if (CacheManager.KillRoomTV == 1)
        {
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x, 0.2f * 480 + 0.6f * endVector.y);
        }
        else if (CacheManager.KillRoomTV == 2)
        {
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x - 128f, 0.2f * 480 + 0.6f * endVector.y + 16);
        }
        //Debug.Log("startGold:" + endVector);
        uiGold.SetPosition(endVector);
        //GTweener gTween = uiGold.getGComponent().TweenMove(endVector, 1f);
       
        //uiGold.SetGTweener(gTween);
    }


    private void GoldOverAnim(int endPos, UIGold uiGold)
    {
        Vector2 endVector = Vector2.zero;
        switch (endPos)
        {   //0-7座位玩家
            case 0: endVector = UIPage.m_room.m_info0.position; break;
            case 1: endVector = UIPage.m_room.m_info1.position; break;
            case 2: endVector = UIPage.m_room.m_info2.position; break;
            case 3: endVector = UIPage.m_room.m_info3.position; break;
            case 4: endVector = UIPage.m_room.m_info4.position; break;
            case 5: endVector = UIPage.m_room.m_info5.position; break;
            case 6: endVector = UIPage.m_room.m_info6.position; break;
            case 7: endVector = UIPage.m_room.m_info7.position; break;
            case 8:
                endVector = UIPage.m_room.m_head.position;  //自己最新下方
                break;
            case 9:   //外围玩家
                endVector = UIPage.m_room.m_btn_out.position;
                break;
            case 10:  //庄家
                endVector = UIPage.m_room.m_infoBanker.position;
                break;
            default:
                break;
        }
        if (CacheManager.KillRoomTV == 1)
        {
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x, 0.2f * 480 + 0.6f * endVector.y);
        }
        else if (CacheManager.KillRoomTV == 2)
        {
            endVector = new Vector2(0.2f * 800 + 0.6f * endVector.x - 128f, 0.2f * 480 + 0.6f * endVector.y + 16);
        }
        uiGold.getGComponent().TweenMove(endVector, 0.75f).OnComplete(() =>
        {
            ClosePage(uiGold);
            //CacheManager.AddUIGold(uiGold); 
        });
    }

    public IEnumerator IEBankerWinCons(bool dongWin, bool nanWin, bool xiWin, bool beiWin)
    {
        bool xunhuan = true;
        while (xunhuan)
        {
            xunhuan = ((!dongWin) && uiGolds0.Count > 0 || (!nanWin) && uiGolds1.Count > 0 || (!xiWin) && uiGolds2.Count > 0 || (!beiWin) && uiGolds3.Count > 0);
            if (!dongWin && uiGolds0.Count > 0)
            {
                UIGold uIGold = uiGolds0[0];
                GoldOverAnim(10, uIGold);
                uiGolds0.Remove(uIGold);
            }
            if (!nanWin && uiGolds1.Count > 0)
            {
                UIGold uIGold = uiGolds1[0];
                GoldOverAnim(10, uIGold);
                uiGolds1.Remove(uIGold);
            }
            if (!xiWin && uiGolds2.Count > 0)
            {
                UIGold uIGold = uiGolds2[0];
                GoldOverAnim(10, uIGold);
                uiGolds2.Remove(uIGold);
            }
            if (!beiWin && uiGolds3.Count > 0)
            {
                UIGold uIGold = uiGolds3[0];
                GoldOverAnim(10, uIGold);
                uiGolds3.Remove(uIGold);
            }
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
    public IEnumerator IEBankerLossCons(bool dongWin, bool nanWin, bool xiWin, bool beiWin)
    {
        bool xunhuan = true;
        while (xunhuan)
        {
            xunhuan = (dongWin && uiGolds0.Count > 0 || nanWin && uiGolds1.Count > 0 || xiWin && uiGolds2.Count > 0 || beiWin && uiGolds3.Count > 0);
            if (dongWin && uiGolds0.Count > 0)
            {
                for (int i = uiGolds0.Count - 1; i >= 0; i--)
                {
                    UIGold uIGold = uiGolds0[i];

                    if (uIGold.startPos != 10)//不是庄家的金币
                    {
                        GoldOverAnim(uIGold.startPos, uIGold);
                        uiGolds0.Remove(uIGold);
                        for (int j = uiGolds0.Count - 1; j >= 0; j--)
                        {
                            UIGold uIGold2 = uiGolds0[i];
                            if (uIGold2.startPos == 10)//不是庄家的金币
                            {
                                GoldOverAnim(uIGold.startPos, uIGold2);
                                uiGolds0.Remove(uIGold2);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            if (nanWin)
            {

                for (int i = uiGolds1.Count - 1; i >= 0; i--)
                {
                    UIGold uIGold = uiGolds1[i];

                    if (uIGold.startPos != 10)//不是庄家的金币
                    {
                        GoldOverAnim(uIGold.startPos, uIGold);
                        uiGolds1.Remove(uIGold);
                        for (int j = uiGolds1.Count - 1; j >= 0; j--)
                        {
                            UIGold uIGold2 = uiGolds1[i];
                            if (uIGold2.startPos == 10)//不是庄家的金币
                            {
                                GoldOverAnim(uIGold.startPos, uIGold2);
                                uiGolds1.Remove(uIGold2);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            if (xiWin)
            {
                for (int i = uiGolds2.Count - 1; i >= 0; i--)
                {
                    UIGold uIGold = uiGolds2[i];

                    if (uIGold.startPos != 10)//不是庄家的金币
                    {
                        GoldOverAnim(uIGold.startPos, uIGold);
                        uiGolds2.Remove(uIGold);
                        for (int j = uiGolds2.Count - 1; j >= 0; j--)
                        {
                            UIGold uIGold2 = uiGolds2[i];
                            if (uIGold2.startPos == 10)//不是庄家的金币
                            {
                                GoldOverAnim(uIGold.startPos, uIGold2);
                                uiGolds2.Remove(uIGold2);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            if (beiWin)
            {
                for (int i = uiGolds3.Count - 1; i >= 0; i--)
                {
                    UIGold uIGold = uiGolds3[i];

                    if (uIGold.startPos != 10)//不是庄家的金币
                    {
                        GoldOverAnim(uIGold.startPos, uIGold);
                        uiGolds3.Remove(uIGold);
                        for (int j = uiGolds3.Count - 1; j >= 0; j--)
                        {
                            UIGold uIGold2 = uiGolds3[i];
                            if (uIGold2.startPos == 10)//不是庄家的金币
                            {
                                GoldOverAnim(uIGold.startPos, uIGold2);
                                uiGolds3.Remove(uIGold2);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
    /// <summary>
    /// 清理金币和扑克牌
    /// </summary>
    /// <param name="list_tablePlayerScore"></param>
    /// <returns></returns>
    public IEnumerator ClearRoomTable(KillRoomLog killRoomLog)
    {
        //庄家赢
        yield return new WaitForSeconds(8f);
        if (!(killRoomLog.dongWin && killRoomLog.xiWin && killRoomLog.nanWin && killRoomLog.beiWin))
        {
            if (CacheManager.KillRoomTV == 0)
                BaseCanvas.PlaySound(R.AudioClip.SOUND_JINBI);
        }
        GameCanvas.gameCanvas.StartCoroutine(IEBankerWinCons(killRoomLog.dongWin, killRoomLog.nanWin, killRoomLog.xiWin, killRoomLog.beiWin));

        //庄家吐金币
        yield return new WaitForSeconds(2f);
        int uiGolds0Count = uiGolds0.Count;
        int uiGolds1Count = uiGolds1.Count;
        int uiGolds2Count = uiGolds2.Count;
        int uiGolds3Count = uiGolds3.Count;
        if (killRoomLog.dongWin)
        {
            for (int i = 0; i < uiGolds0Count; i++)
            {
                GoldAnim(10, 0);
            }
        }
        if (killRoomLog.nanWin)
        {
            for (int i = 0; i < uiGolds1Count; i++)
            {
                GoldAnim(10, 1);
            }
        }
        if (killRoomLog.xiWin)
        {
            for (int i = 0; i < uiGolds2Count; i++)
            {
                GoldAnim(10, 2);
            }
        }
        if (killRoomLog.beiWin)
        {
            for (int i = 0; i < uiGolds3Count; i++)
            {
                GoldAnim(10, 3);
            }
        }
        //桌面上金币流向玩家
        yield return new WaitForSeconds(2f);
        GameCanvas.gameCanvas.StartCoroutine(IEBankerLossCons(killRoomLog.dongWin, killRoomLog.nanWin, killRoomLog.xiWin, killRoomLog.beiWin));
    }
    /// <summary>
    /// 更新奖池及各玩家金币
    /// </summary>
    /// <param name="list_tablePlayerScore"></param>
    public void UpdateCoins(List<KillRoomTablePlayerRoundScore> list_tablePlayerScore)
    {
        UIPage.m_room.m_btn_jackpot.m_text_conis.text = ToolClass.LongConverStr(CacheManager.jackpot);
        UpdataTableCoins(8);
        UpdataTableCoins(9);

        
        if (list_tablePlayerScore != null)
        {
            foreach (KillRoomTablePlayerRoundScore item in list_tablePlayerScore)
            {
                if (item != null)
                {
                    for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                    {
                        PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];
                         
                        if (playerSimpleData != null && playerSimpleData.userId == item.userId)
                        {
                            playerSimpleData.coins = item.score;
                            UpdataTableCoins(playerSimpleData.killRoomPos);
                            break;
                        }

                    }
                     
                }
            }
        }


        selfNum0 = 0;
        selfNum1 = 0;
        selfNum2 = 0;
        selfNum3 = 0;

        if (UIPage.m_room.m_selfCoins0.visible)
            UIPage.m_room.m_selfCoins0.visible = false;
        if (UIPage.m_room.m_selfCoins1.visible)
            UIPage.m_room.m_selfCoins1.visible = false;
        if (UIPage.m_room.m_selfCoins2.visible)
            UIPage.m_room.m_selfCoins2.visible = false;
        if (UIPage.m_room.m_selfCoins3.visible)
            UIPage.m_room.m_selfCoins3.visible = false;
    }

    /// <summary>
    /// 更新金币
    /// </summary>
    /// <param name="pos"></param>
    private void UpdataTableCoins(int pos)
    {
        switch (pos)
        {   //0-7座位玩家
            case 0: UIPage.m_room.m_info0.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[0].coins); break;
            case 1: UIPage.m_room.m_info1.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[1].coins); break;
            case 2: UIPage.m_room.m_info2.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[2].coins); break;
            case 3: UIPage.m_room.m_info3.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[3].coins); break;
            case 4: UIPage.m_room.m_info4.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[4].coins); break;
            case 5: UIPage.m_room.m_info5.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[5].coins); break;
            case 6: UIPage.m_room.m_info6.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[6].coins); break;
            case 7: UIPage.m_room.m_info7.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[7].coins); break;
            case 8:
                UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);


                BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                break;   //自己
            case 9: UIPage.m_room.m_infoBanker.m_gold.text = ToolClass.LongConverStr(CacheManager.banker.coins); break;   //庄家

            default:
                break;
        }
    }
    internal void RefSelfCoins()
    {
        if (CacheManager.banker.userId == CacheManager.gameData.userId)
        {
            CacheManager.banker.coins = CacheManager.gameData.coins;
            UIPage.m_room.m_infoBanker.m_gold.text = ToolClass.LongConverStr(CacheManager.gameData.coins);
        }
        else
        {
            for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
            {
                PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];
                if (playerSimpleData != null && playerSimpleData.userId == CacheManager.gameData.userId)
                {
                    switch (i)
                    {   //0-7座位玩家
                        case 0: UIPage.m_room.m_info0.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[0].coins); break;
                        case 1: UIPage.m_room.m_info1.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[1].coins); break;
                        case 2: UIPage.m_room.m_info2.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[2].coins); break;
                        case 3: UIPage.m_room.m_info3.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[3].coins); break;
                        case 4: UIPage.m_room.m_info4.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[4].coins); break;
                        case 5: UIPage.m_room.m_info5.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[5].coins); break;
                        case 6: UIPage.m_room.m_info6.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[6].coins); break;
                        case 7: UIPage.m_room.m_info7.m_gold.text = ToolClass.LongConverStr2(CacheManager.TablePlayers[7].coins); break;
                        default:
                            break;
                    }
                }
            }
        }

        //Debug.Log("RefSelfCoins........");
        UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
    }
    internal void RefUpBankerBtn()
    {
        if (BaseCanvas.GetController<RoomCtrl>().InUpBankerList() || BaseCanvas.GetController<RoomCtrl>().IsBanker())
        {
            UIPage.m_room.m_btn_upbank.title = "申请下庄";
        }
        else
        {
            UIPage.m_room.m_btn_upbank.title = "申请上庄";
        }
    }

    internal IEnumerator Timer()
    {
        while (true)
        {
            UIPage.m_room.m_text_time.text = DateTime.Now.ToShortTimeString();
            yield return new WaitForSeconds(30f);
        }
        yield return null;
    }

    public IEnumerator IETimer(float timer)
    {
        UIPage.m_room.m_t_clock.Stop();
        UIPage.m_room.m_clock.rotation = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            UIPage.m_room.m_clock.m_timer.text = timer + "S";
            if (timer <= 5 && CacheManager.killRoom.state == KillRoom.STATE_BET_TIME)
            {
                if (CacheManager.KillRoomTV == 0)
                    BaseCanvas.PlaySound(R.AudioClip.SOUND_TIMEUP);
                if (timer == 5 && (!isClockAnimTrue))
                {
                    UIPage.m_room.m_t_clock.Play();
                    isClockAnimTrue = true;
                }
            }
            if (timer <= 0)
            {
                if (CacheManager.state == KillRoom.STATE_BET_TIME)
                {
                    UIPage.m_room.m_t_clock.Stop();
                    UIPage.m_room.m_clock.rotation = 0;
                    isClockAnimTrue = false;
                }
                break;
            }
        }
        yield return null;
    }


    internal void SitDown(int pos)
    {
        string strCoins = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        switch (pos)
        {
            case 0:
                UIPage.m_room.m_info0.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info0.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info0.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info0.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }

                UIPage.m_room.m_info0.m_gold.text = strCoins;
                break;
            case 1:
                UIPage.m_room.m_info1.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {

                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info1.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info1.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info1.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info1.m_gold.text = strCoins;
                break;
            case 2:
                UIPage.m_room.m_info2.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info2.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info2.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info2.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info2.m_gold.text = strCoins;
                break;
            case 3:
                UIPage.m_room.m_info3.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info3.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info3.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info3.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info3.m_gold.text = strCoins;
                break;
            case 4:
                UIPage.m_room.m_info4.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info4.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info4.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info4.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info4.m_gold.text = strCoins;
                break;
            case 5:
                UIPage.m_room.m_info5.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info5.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info5.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info5.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info5.m_gold.text = strCoins;
                break;
            case 6:
                UIPage.m_room.m_info6.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info6.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info6.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info6.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info6.m_gold.text = strCoins;
                break;
            case 7:
                UIPage.m_room.m_info7.m_c1.selectedIndex = 1;
                if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
                {
                    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                    UIPage.m_room.m_info7.m_head.m_n0.texture = new NTexture(t2d);
                }
                else
                {
                    if (CacheManager.gameData.roleId == 0)
                        UIPage.m_room.m_info7.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    else
                        UIPage.m_room.m_info7.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                }
                UIPage.m_room.m_info7.m_gold.text = strCoins;
                break;
            default:
                break;
        }
    }

    internal void UpdataBaker()
    {
        if (CacheManager.banker.userId == CacheManager.gameData.userId)
        {
            UIPage.m_room.m_c1.selectedIndex = 1;
        }
        else
        {
            UIPage.m_room.m_c1.selectedIndex = 0;
        }


        UIPage.m_room.m_infoBanker.m_text_nickname.text = CacheManager.banker.nickName;
        UIPage.m_room.m_infoBanker.m_gold.text = ToolClass.LongConverStr(CacheManager.banker.coins);

        UIPage.m_room.m_infoBanker.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));



        if (CacheManager.banker.userId == 100000)
        {
            UIPage.m_room.m_infoBanker.m_gold.text = "10亿";
            UIPage.m_room.m_infoBanker.m_text_nickname.text = "系统女神";
            UIPage.m_room.m_infoBanker.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_SYSTEM));
            UIPage.m_room.m_infoBanker.m_icon_list.numItems = 0;
            UIPage.m_room.m_infoBanker.m_vip.texture = null;
        }
        else
        {

            if (CacheManager.banker.sprites.Count > 0)
            {
                UIPage.m_room.m_infoBanker.m_icon_list.itemRenderer = SetBanker;
                UIPage.m_room.m_infoBanker.m_icon_list.numItems = CacheManager.banker.sprites.Count;
            }
            else
            {
                UIPage.m_room.m_infoBanker.m_icon_list.numItems = 0;
            }

            ToolClass.SetVipTexture(UIPage.m_room.m_infoBanker.m_vip, CacheManager.banker.vipLv);
            UIPage.m_room.m_infoBanker.m_head.m_n0.texture = new NTexture(CacheManager.banker.headIcon);
        }
    }


    internal void UpdateSelf(int pos, int chipNum)
    {
        //Debug.Log("UpdateSelf,pos:"+ pos+ ",chipNum:"+ chipNum);
        UIPage.m_room.m_text_nickname.text = CacheManager.gameData.nickName;
        UIPage.m_room.m_text_gold.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        switch (pos)
        {
            case 0:
                selfNum0 += chipNum / 20000;
                UIPage.m_room.m_selfCoins0.visible = false;
                if (!UIPage.m_room.m_selfCoins0.visible && selfNum0 > 0)
                    UIPage.m_room.m_selfCoins0.visible = true;
                UIPage.m_room.m_selfCoins0.m_text_coins.text = selfNum0.ToString();
                break;
            case 1:
                selfNum1 += chipNum / 20000;
                UIPage.m_room.m_selfCoins1.visible = false;
                if (!UIPage.m_room.m_selfCoins1.visible && selfNum1 > 0)
                    UIPage.m_room.m_selfCoins1.visible = true;
                UIPage.m_room.m_selfCoins1.m_text_coins.text = selfNum1.ToString();
                break;
            case 2:
                selfNum2 += chipNum / 20000;
                UIPage.m_room.m_selfCoins2.visible = false;
                if (!UIPage.m_room.m_selfCoins2.visible && selfNum2 > 0)
                    UIPage.m_room.m_selfCoins2.visible = true;
                UIPage.m_room.m_selfCoins2.m_text_coins.text = selfNum2.ToString();
                break;
            case 3:
                selfNum3 += chipNum / 20000;
                UIPage.m_room.m_selfCoins3.visible = false;
                if (!UIPage.m_room.m_selfCoins3.visible && selfNum3 > 0)
                    UIPage.m_room.m_selfCoins3.visible = true;
                UIPage.m_room.m_selfCoins3.m_text_coins.text = selfNum3.ToString();
                break;
            default:
                break;
        }
    }


    public override void Refresh()
    {
        base.Refresh();
        CacheManager.killRoom.state = CacheManager.state;

        if (CacheManager.gameData.userId == CacheManager.banker.userId)
        {
            UIPage.m_c1.SetSelectedIndex(1);
        }
        //UIPage.m_room.m_notice.visible = false;



        Init();
        //Debug.Log("通杀场刷新。。。");
    }


    public override void Hide()
    {
        for (int i = coroutines.Count - 1; i >= 0; i--)
        {
            Coroutine coroutine = coroutines[i];
            if (coroutine != null)
            {
                if (GameCanvas.gameCanvas != null)
                    GameCanvas.gameCanvas.StopCoroutine(coroutine);
            }
        }
        selfNum0 = 0;
        selfNum1 = 0;
        selfNum2 = 0;
        selfNum3 = 0;

        if (UIPage.m_room.m_selfCoins0.visible)
            UIPage.m_room.m_selfCoins0.visible = false;
        if (UIPage.m_room.m_selfCoins1.visible)
            UIPage.m_room.m_selfCoins1.visible = false;
        if (UIPage.m_room.m_selfCoins2.visible)
            UIPage.m_room.m_selfCoins2.visible = false;
        if (UIPage.m_room.m_selfCoins3.visible)
            UIPage.m_room.m_selfCoins3.visible = false;

        for (int i = uiGolds0.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds0[i];
            ClosePage(uIGold);
            uiGolds0.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds1.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds1[i];
            ClosePage(uIGold);
            uiGolds1.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds2.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds2[i];
            ClosePage(uIGold);
            uiGolds2.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds3.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds3[i];
            ClosePage(uIGold);
            uiGolds3.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        base.Hide();


        hide();
    }

    private int mLotteryTime;
    public int LotteryTime
    {
        get
        {
            return mLotteryTime;
        }
        set
        {
            mLotteryTime = value;
        }
    }
    private Tween tween;
    public void ShowLotteryTime(int time)
    {
        tween = DOTween.To(() => time - 1, (value) =>
        {

            UIPage.m_room.m_txt_lotteryTime.text = MyTimeUtil.TimeToString(value);
            mLotteryTime = value;
        }, 0, time).SetEase(Ease.Linear);
    }

    private List<HornInfoVO> infoList = new List<HornInfoVO>();


    public void NoticPlay(HornInfoVO vo)
    {
        infoList.Add(vo);
        PlayAll();
    }

    private void PlayAll()
    {
        //if (UIPage.m_room.m_notice.m_t1.playing)
        //{
        //    PlayAllSecond();//再来消息 
        //    return;
        //}
        //if (UIPage.m_room.m_notice.m_t2.playing)
        //{
        //    PlayAllOne();//再来消息
        //    return;
        //}

        //if (infoList == null || infoList.Count == 0)
        //{
        //    ResetNotie();
        //    return;
        //}
        //Movie();
    }

    /// <summary>
    ///重置小广播面板
    /// </summary>
    private void ResetNotie()
    {
        //UIPage.m_room.m_notice.visible = false;
        //UIPage.m_room.m_notice.m_n2.text = "";
        //UIPage.m_room.m_notice.m_n4.texture = null;
        //UIPage.m_room.m_notice.m_n6.text = "";
        //UIPage.m_room.m_notice.m_n7.texture = null;
    }

    /// <summary>
    /// 播放动效1
    /// </summary>
    private void PlayAllOne()
    {
        CancelMovieTwo();
        Movie();
    }
    /// <summary>
    /// 处理动效2
    /// </summary>
    private void CancelMovieTwo()
    {
        //if (UIPage.m_room.m_notice.m_t2.playing)
        //{
        //    UIPage.m_room.m_notice.m_n8.visible = false;
        //    UIPage.m_room.m_notice.m_n6.text = "";
        //    UIPage.m_room.m_notice.m_n7.texture = null;
        //    UIPage.m_room.m_notice.m_t2.Stop();
        //}
    }

    /// <summary>
    /// 动效1
    /// </summary>
    private void Movie()
    {
        //UIPage.m_room.m_notice.visible = true;
        //UIPage.m_room.m_notice.m_n5.visible = true;
        //UIPage.m_room.m_notice.m_n8.visible = false;

        //HornInfoVO vo = infoList[0];
        //Sprite sp = null; 
        //if (vo.vipLv>0)
        //{
        //    string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
        //    sp = FileIO.LoadSprite(vipName);
        //}
        //if (sp != null)
        //{
        //    UIPage.m_room.m_notice.m_n4.texture = new NTexture(sp.texture);
        //}

        //string info;


        //if (vo.nikeName == "系统")
        //{ 
        //    info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}
        //else if (vo.role == 0)
        //{
        //    info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}
        //else
        //{
        //    info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}
        //info = info.Replace("\n", "");
        //UIPage.m_room.m_notice.m_n2.text = info;
        //infoList.RemoveAt(0);

        //float speed = (UIPage.m_room.m_notice.width + 387) / 16F;
        //float add = 0;
        ////动效播放的速度将会是原来的一半。
        //if (sp != null)
        //{
        //    add = UIPage.m_room.m_notice.m_n4.width;
        //}
        //float time = (UIPage.m_room.m_notice.m_n2.textWidth + add + UIPage.m_room.m_notice.width) / speed;
        ////Debug.Log("真实时间："+ time+ ",UIPage.m_room.m_notice.width="+ UIPage.m_room.m_notice.width);

        //if (vo.nikeName == "系统")
        //{
        //    UIPage.m_room.m_notice.m_t1.timeScale = 6f / time*2;
        //}
        //else
        //{
        //    UIPage.m_room.m_notice.m_t1.timeScale = 6f / time;
        //}

        ////Debug.Log("acale:"+(6f / time));
        //UIPage.m_room.m_notice.m_t1.Play(() => {
        //    UIPage.m_room.m_notice.visible = false;
        //    UIPage.m_room.m_notice.m_n5.visible = false;
        //    PlayAll();
        //});
    }

    private void PlayAllSecond()
    {
        CancelMovie1();
        Movie2();
    }

    /// <summary>
    /// 处理动效1
    /// </summary>
    private void CancelMovie1()
    {
        //if (UIPage.m_room.m_notice.m_t1.playing)
        //{
        //    UIPage.m_room.m_notice.m_n5.visible = false;
        //    UIPage.m_room.m_notice.m_n2.text = "";
        //    UIPage.m_room.m_notice.m_n4.texture = null;
        //    UIPage.m_room.m_notice.m_t1.Stop();
        //}
    }

    /// <summary>
    /// 动效2
    /// </summary>
    private void Movie2()
    {
        //UIPage.m_room.m_notice.visible = true;
        //UIPage.m_room.m_notice.m_n8.visible = true;
        //UIPage.m_room.m_notice.m_n5.visible = false;

        //HornInfoVO vo = infoList[0];
        //if (vo.vipLv != 0)
        //{
        //    string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
        //    Debug.Log("move2:" + vipName);
        //    Sprite sp = FileIO.LoadSprite(vipName);
        //    if (sp != null)
        //    {
        //        UIPage.m_room.m_notice.m_n7.texture = new NTexture(sp.texture);
        //    }
        //}

        //string info;
        //if (vo.nikeName == "系统")
        //{
        //    info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}
        //else if (vo.role == 0)
        //{
        //    info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}
        //else
        //{
        //    info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
        //}

        //UIPage.m_room.m_notice.m_n6.text = info;
        //infoList.RemoveAt(0);

        //UIPage.m_room.m_notice.m_t2.Play(() => { UIPage.m_room.m_notice.visible = false; UIPage.m_room.m_notice.m_n8.visible = false; PlayAll(); });
    }

    public void ShowCurBuyLotteryNum(int num)
    {
        if (num <= 0)
        {
            UIPage.m_room.m_lotteryNum.visible = false;
        }
        else
        {
            UIPage.m_room.m_txt_lotteryNum.text = num.ToString();
            UIPage.m_room.m_lotteryNum.visible = true;
        }
    }

    public void LotteryWinPlay(bool play)
    {
        UIPage.m_room.m_movie_win.visible = play;
        if (play)
        {
            if (UIPage.m_room.m_t0.playing)
            {
                UIPage.m_room.m_t0.Stop();
            }
            UIPage.m_room.m_t0.Play();
        }
        else
        {
            if (UIPage.m_room.m_t0.playing)
            {
                UIPage.m_room.m_t0.Stop();
            }
        }
    }

    /// <summary>
    /// 打开消息记录面板
    /// </summary>
    private void BtnRocrd()
    {
        Vector2 pos = new Vector2(UIPage.m_room.m_bg_horn.x, UIPage.m_room.m_bg_horn.y) + new Vector2((UIPage.m_room.m_bg_horn.width - 383) / 2, UIPage.m_room.m_bg_horn.height);
        hornRecord(pos);
    }

    public void RefHead()
    {
        if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
            UIPage.m_room.m_head.texture = new NTexture(t2d);  //设置头像
        }
        else
        {

            Sprite sprite = null;
            if (CacheManager.gameData.roleId == 0)
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_MAN);
            }
            else
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN);
            }

            UIPage.m_room.m_head.texture = new NTexture(sprite);
        }
    }
    /// <summary>
    /// 断线重连
    /// </summary>
    public void Connect()
    {
        for (int i = coroutines.Count - 1; i >= 0; i--)
        {
            Coroutine coroutine = coroutines[i];
            if (coroutine != null)
            {
                if (GameCanvas.gameCanvas != null)
                    GameCanvas.gameCanvas.StopCoroutine(coroutine);
            }
        }
        UIPage.m_room.m_info0.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info1.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info2.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info3.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info4.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info5.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info6.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_info7.m_c1.SetSelectedIndex(0);
        UIPage.m_room.m_infoBanker.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_SYSTEM));
        UIPage.m_room.m_info0.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info1.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info2.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info3.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info4.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info5.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info6.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        UIPage.m_room.m_info7.m_head.m_n0.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_BACKHEAD));
        selfNum0 = 0;
        selfNum1 = 0;
        selfNum2 = 0;
        selfNum3 = 0;

        if (UIPage.m_room.m_selfCoins0.visible)
            UIPage.m_room.m_selfCoins0.visible = false;
        if (UIPage.m_room.m_selfCoins1.visible)
            UIPage.m_room.m_selfCoins1.visible = false;
        if (UIPage.m_room.m_selfCoins2.visible)
            UIPage.m_room.m_selfCoins2.visible = false;
        if (UIPage.m_room.m_selfCoins3.visible)
            UIPage.m_room.m_selfCoins3.visible = false;

        for (int i = uiGolds0.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds0[i];
            ClosePage(uIGold);
            uiGolds0.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds1.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds1[i];
            ClosePage(uIGold);
            uiGolds1.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds2.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds2[i];
            ClosePage(uIGold);
            uiGolds2.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }


        for (int i = uiGolds3.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds3[i];
            ClosePage(uIGold);
            uiGolds3.Remove(uIGold);
            //CacheManager.AddUIGold(uIGold);
        }
    }

    public void ClearAllCoins()
    {
        for (int i = uiGolds0.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds0[i];
            if (uIGold != null)
            {
                uIGold.KillTweener();
                ClosePage(uIGold);
            }
        }
        uiGolds0.Clear();

        for (int i = uiGolds1.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds1[i];
            if (uIGold != null)
            {
                uIGold.KillTweener();
                ClosePage(uIGold);
            }
        }
        uiGolds1.Clear();

        for (int i = uiGolds2.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds2[i];
            if (uIGold != null)
            {
                uIGold.KillTweener();
                ClosePage(uIGold);
            }
        }
        uiGolds2.Clear();
        for (int i = uiGolds3.Count - 1; i >= 0; i--)
        {
            UIGold uIGold = uiGolds3[i];
            if (uIGold != null)
            {
                uIGold.KillTweener();
                ClosePage(uIGold);
            }
        }
        uiGolds3.Clear();
    }
}