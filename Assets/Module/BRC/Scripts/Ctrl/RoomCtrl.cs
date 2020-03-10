using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class RoomCtrl : BaseController, IHandlerReceive
{
    private UIRoom uiRoom;              //主面板
    private UIReturnPanel uiReturnPanel;//返回面板
    private UIPokers uiPokers;          //扑克牌图层

    private UIHornRecord uiHornRecord;//消息记录面板

    private List<Coroutine> coroutines = new List<Coroutine>();    //协程
    private bool inRoom;

    public List<KillRoomBigWinVO> list_bigWin;


    public List<long> list_directionBetNum;
    public override void InitAction()
    {
        uiRoom = GetUIPage<UIRoom>();
        uiRoom.ActionChat = ShowChat;
        uiRoom.ActionInfo = ShowUserInfo;
        uiRoom.ActionHeadOnClick = ShowSelfInfo;
        uiRoom.ActionBet = SendKillRoomPayBetRequest;       //下注
        uiRoom.ActionSitDown = SendKillRoomSitDownRequest;
        uiRoom.ActionUpBank = SendBankerListRequest;
        uiRoom.lottery = ShowUILottery;
        uiRoom.ActionJackpot = SendGetJackpotRequest;
        uiRoom.ActionTrend = ShowTrendUI;
        uiRoom.ActionBack = ShowReturnPanelUI;
        uiRoom.ActionOnClick = CloseOtherUI;
        uiRoom.showHorn = ShowHorn;
        uiRoom.ActionMore = ShowMoreUI;
        uiRoom.ActionCloseTV = SendLeaveKillRoomRequest;
        uiRoom.ActionFriend = ShowFriendUI;
        uiRoom.ActionTableOnClick = SetRoom;
        uiRoom.hornRecord = HornRecord;
        uiRoom.ActionFastBuy = FastBuyOnClick;
        uiRoom.hide = UIRoomHide;


        uiReturnPanel = GetUIPage<UIReturnPanel>();
        uiReturnPanel.ActionCloseRoom = CloseRoom;                 //退出房间
        uiReturnPanel.ActionStandUp = SendKillRoomStandUpRequest;  //站起
        uiReturnPanel.ActionSet = ShowSetUI;
        uiReturnPanel.ActionHelp = ShowHelpUI;


        uiPokers = GetUIPage<UIPokers>();
        uiPokers.ActionShowPoker = StartShowPoker;


        uiHornRecord = GetUIPage<UIHornRecord>();
    }

    private void UIRoomHide()
    {
        GetController<ChatCtrl>().HideUIRoomChat();
        GetController<ChatCtrl>().HideUIRoom();
        HideHornRecordCom();

        CacheManager.LeaveKillRoom();
        Debug.Log("通杀场界面关闭");

        SetIsActiveRoom(false);
    }

    private void UIRoomHide2()
    {
        GetController<ChatCtrl>().HideUIRoomChat();
        GetController<ChatCtrl>().HideUIRoom();
        HideHornRecordCom();

    }

    private void HideHornRecordCom()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.Hide();
        }
    }
    private void FastBuyOnClick()
    {
        GetController<ShopCtrl>().ActionShopClick(1, 2);
    }
    public void HornRecord(Vector2 pos)
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.Hide();
        }
        else
        {
            ShowUI<UIHornRecord>();
            uiHornRecord.SetHornPosition(pos);
        }
    }

    public void RefreshHornRecordList()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.RefreshList();
        }
    }

    /// <summary>
    /// 刷新自己金币
    /// </summary>
    public void RefreshCoin()
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.RefreshCoin();
        }
    }
    public void RefPosCoinse(int endPos)
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.RefPosCoins(endPos);
        }
    }
    private void SetRoom()
    {
        if (CacheManager.KillRoomTV == 2)
        {
            GetController<MainSceneCtrl>().ShowKillRoomUI();
        }
    }

    private bool isActiveRoom = false;

    public void SetIsActiveRoom(bool isAction)
    {
        isActiveRoom = isAction;
    }
    /// <summary>
    /// 滚动条消息
    /// </summary>
    /// <param name="vo"></param>
    public void ShowTxtTitle(HornInfoVO vo)
    {
        if (isActiveRoom && uiRoom.isActive())
        {
            uiRoom.NoticPlay(vo);
        }
        RefreshHornRecordList();
    }
    /// <summary>
    /// 滚动条消息
    /// </summary>
    /// <param name="vo"></param>
    public void ShowTxtTitle(string info)
    {
        HornInfoVO vo = new HornInfoVO(); 
        vo.info = info;
        vo.nikeName = "系统";
        if (uiRoom.isActive())
        {
            CacheManager.AddHorn(vo);
             
            GetUIPage<UIGlobalNotic>().NoticPlay(vo);//广播
        }
        RefreshHornRecordList();
    }

    private void ShowHorn()
    {
        GetController<HornCtrl>().ShowUIHornCom();
    }

    private void ShowUILottery()
    {
        GetController<LotteryCtrl>().ShowUILottery();
    }

    private Coroutine coroutineIEShowPoker;
    /// <summary>
    /// 给扑克牌牌面赋值
    /// </summary>
    /// <param name="timer"></param>
    public void StartShowPoker(float timer, KillRoomLog killRoomLog, long isJackpot)
    {
        if (uiPokers != null)
        {
            coroutineIEShowPoker = GameCanvas.gameCanvas.StartCoroutine(uiPokers.IEShowPoker(timer, killRoomLog));
            coroutines.Add(coroutineIEShowPoker);
            if (isJackpot > 0)
                coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(ShowJackpot(isJackpot)));
        }
        
    }
    public IEnumerator ShowJackpot(long isJackpot)
    {
        yield return new WaitForSeconds(4f);
        if (CacheManager.RunRoomId == 0)
            GetController<TaskCtrl>().ShowUIWinShow(isJackpot);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list_tablePlayerScore"></param>
    /// <param name="timer"></param>
    /// <param name="calcScore">自己输赢(自己是闲家的时候)</param>
    /// <param name="subCoins"></param>
    /// <param name="otherSubCoins"></param>
    /// <returns></returns>
    public IEnumerator ShowTips(List<KillRoomTablePlayerRoundScore> list_tablePlayerScore, float timer, long calcScore, long subCoins, int otherSubCoins, long bankerCalcScore)
    {
        yield return new WaitForSeconds(timer);



        //庄家输赢
        if (CacheManager.banker.userId == CacheManager.gameData.userId)//自己是庄家
        {
          
           
            Debug.Log("bankerScore:" + bankerCalcScore);
            if (bankerCalcScore > 0)
            {
                GetController<MessageCtrl>().ShowWinOrLosUI("恭喜你，本局赢得+" + bankerCalcScore);
                GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(bankerCalcScore);
                BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
            }
            else if (bankerCalcScore < 0)
            {
                GetController<MessageCtrl>().ShowWinOrLosUI("很遗憾，本局输了" + (0 - Math.Abs(bankerCalcScore)));
            }
        }
        else
        {

            Debug.Log("calcScore:"+ calcScore+ ",subCoins:"+ subCoins+ ",otherSubCoins:"+ otherSubCoins);
            calcScore = calcScore - subCoins - otherSubCoins;


            if (calcScore > 0)
            {
                GetController<MessageCtrl>().ShowWinOrLosUI("恭喜你，本局赢得+" + calcScore);
                GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(calcScore);
                BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
            }
            else if (calcScore < 0)
            {
                GetController<MessageCtrl>().ShowWinOrLosUI("很遗憾，本局输了" + (0 - calcScore));
            }
        }
         

        uiRoom.UpdateCoins(list_tablePlayerScore);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator AddTrend(float timer, KillRoomLog killRoomLog)
    {
        yield return new WaitForSeconds(timer);

        while (CacheManager.List_bankerWin.Count >= 10)
        {
            CacheManager.List_bankerWin.RemoveAt(0);
        }
        bool bankerWin = (!killRoomLog.dongWin && !killRoomLog.nanWin && !killRoomLog.xiWin && !killRoomLog.beiWin);
        CacheManager.List_bankerWin.Add(bankerWin);


        while (CacheManager.List_dongWin.Count >= 10)
            CacheManager.List_dongWin.RemoveAt(0);
        CacheManager.List_dongWin.Add(killRoomLog.dongWin);

        while (CacheManager.List_nanWin.Count >= 10)
            CacheManager.List_nanWin.RemoveAt(0);
        CacheManager.List_nanWin.Add(killRoomLog.nanWin);

        while (CacheManager.List_xiWin.Count >= 10)
            CacheManager.List_xiWin.RemoveAt(0);
        CacheManager.List_xiWin.Add(killRoomLog.xiWin);

        while (CacheManager.List_beiWin.Count >= 10)
            CacheManager.List_beiWin.RemoveAt(0);
        CacheManager.List_beiWin.Add(killRoomLog.beiWin);
    }

    public void RefUpBankerBtn()
    {
        uiRoom.RefUpBankerBtn();
    }

    public void StopCoroutine()
    {
        for (int i = coroutines.Count - 1; i >= 0; i--)
        {
            Coroutine coroutine = coroutines[i];
            if (coroutine != null)
            {
                GameCanvas.gameCanvas.StopCoroutine(coroutine);
            }
            else
            {
                Debug.LogError("这个协程为空");
            }
        }
    }

    #region Request
    private void SendKillRoomPayBetRequest(int pos, int odds)
    {
        KillRoomPayBetRequest request = new KillRoomPayBetRequest
        {
            pos = pos,
            chipNum = odds,
        };
        SendMessage(request);
    }

    private void SendKillRoomSitDownRequest(int pos)
    {
        KillRoomSitDownRequest request = new KillRoomSitDownRequest
        {
            pos = pos,
        };
        SendMessage(request);
    }



    private void SendLeaveKillRoomRequest()
    {
        LeaveKillRoomRequest request = new LeaveKillRoomRequest();
        SendMessage(request);
    }

    private void SendBankerListRequest()
    {
        BankerListRequest request = new BankerListRequest();
        SendMessage(request);
    }

    private void SendGetJackpotRequest()
    {
        GetJackpotRequest request = new GetJackpotRequest();
        SendMessage(request);
    }

    private void SendKillRoomStandUpRequest()
    {
        KillRoomStandUpRequest request = new KillRoomStandUpRequest();
        SendMessage(request);
    }

    private void SendKillRoomGetAllRedRequest()
    {
        KillRoomGetAllRedRequest request = new KillRoomGetAllRedRequest();
        SendMessage(request);
    }

    #endregion

    #region ShowUI
    /// <summary>
    /// 显示通杀场
    /// </summary>
    public void ShowRoomUI()
    {
        Debug.LogError("正常显示通杀场");
        ShowUI<UIRoom>();
     
        uiRoom.ChangeRoot(UIType.Normal);

        ShowUI<UIPokers>();
        uiPokers.Set(0);
        uiPokers.ChangeRoot(UIType.PopUp);

        SendKillRoomGetAllRedRequest();
        GetController<ShopBoxCtrl>().Show();

        //Debug.LogError("显示通杀场-请求同步数据");
        GetController<LotteryCtrl>().SendAskTime();

        GetController<MainSceneCtrl>().HideHornRecordCom();

        GetController<ChatCtrl>().ShowUIRoomChat();

        uiRoom.Set(0);
    }

    /// <summary>
    /// 在电视机中显示通杀场
    /// </summary>
    public void ShowRoomTVUI()
    {
        ShowUI<UIRoom>();
        uiRoom.Set(1);
        uiRoom.ChangeRoot(WT.UI.UIType.PopUp);
        //Debug.LogError("在电视机中显示通杀场 显示通杀场-请求同步数据");
        GetController<LotteryCtrl>().SendAskTime();

        ShowUI<UIPokers>();
        uiPokers.Set(1);
        uiPokers.ChangeRoot(WT.UI.UIType.PopUp);

        //GetController<ChatCtrl>().ShowUIRoomChat();
    }
    /// <summary>
    /// 主界面显示通杀场
    /// </summary>
    public void ShowRoomMainScene()
    {
        ShowUI<UIRoom>();
        uiRoom.Set(2);
        uiRoom.ChangeRoot(WT.UI.UIType.Normal);
        //Debug.LogError("主界面显示通杀场 显示通杀场-请求同步数据");
        GetController<LotteryCtrl>().SendAskTime();

        ShowUI<UIPokers>();
        uiPokers.Set(2);
        uiPokers.ChangeRoot(WT.UI.UIType.PopUp);

    }

    private void ShowChat()
    {
        GetController<ChatCtrl>().ShowUIChat2(1);
    }

    private void ShowUserInfo(int pos)
    {
        PlayerSimpleData playerSimpleData = null;
        if (pos == 8)
            playerSimpleData = CacheManager.banker;
        else
            playerSimpleData = CacheManager.TablePlayers[pos];

        if (playerSimpleData.userId == CacheManager.gameData.userId)
            GetController<UserInfoCtrl>().ShowSelfInfoUI();
        else
            GetController<UserInfoCtrl>().ShowOtherInfoUI(playerSimpleData);
    }

    private void ShowSelfInfo()
    {
        GetController<UserInfoCtrl>().ShowSelfInfoUI();
    }
    private void ShowUpBankUI()
    {
        GetController<UpBankerListCtrl>().Show();
    }

    private void ShowSetUI()
    {
        GetController<SetCtrl>().ShowSetUI(1);
    }
    private void ShowHelpUI()
    {
        GetController<HelpCtrl>().Show();
    }
    private void ShowJackpotUI(JackpotData jackpotData)
    {
        GetController<JackpotCtrl>().Show(jackpotData, CacheManager.jackpot);
    }

    private void ShowTrendUI()
    {
        GetController<TrendCtrl>().Show();
    }

    internal void ClearKillRoomBet()
    {
        if (uiRoom != null)
        {
            uiRoom.Clear();
          
        }
        if (uiPokers != null && uiPokers.isActive())
        {
            uiPokers.Connect();
            if (coroutineIEShowPoker != null)
            {
                GameCanvas.gameCanvas.StopCoroutine(coroutineIEShowPoker);
            }
           
        }
      
    }

    public void ShowReturnPanelUI()
    {
        ShowUI<UIReturnPanel>();
        uiReturnPanel.Init();
    }

    private void CloseOtherUI()
    {
        if (uiReturnPanel.isActive() && uiReturnPanel.Position.y >= -10)
        {
            uiReturnPanel.Hide();
        }
        GetController<ShopBoxCtrl>().Hide2();
        GetController<MoreCtrl>().Hide2();
        GetController<UpBankerListCtrl>().Hide();
    }

    private void ShowFriendUI()
    {
        GetController<FriendCtrl>().ShowUIFriend();
    }

    private void ShowMoreUI()
    {
        GetController<MoreCtrl>().Show(0);
    }
    #endregion

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
             
            if (CacheManager.KillRoomTV != -1)
            {
                
                switch (response.msgType)
                {
                    case MsgType.KillRoom_同步庄家金币:
                        ReceiveBankerCoins(response.data);
                        break;

                    case MsgType.KillRoom_休息时间:
                        ReceiveIdle(response.data);
                        break;
                    case MsgType.KillRoom_通杀场下注时间:
                        ReceiveChangeToBet(response.data);
                        break;
                    case MsgType.KillRoom_通杀场开奖状态:        //发牌
                        ReceiveChangeToLottery(response.data);
                        break;
                    case MsgType.KillRoom_通杀场下注:
                        ReceiveKillRoomPayBet(response.data);
                        break;
                    case MsgType.KillRoom_其他玩家下注:
                        ReceivePushkillRoomPayBet(response.data);
                        break;
                    case MsgType.KillRoom_选座坐下:
                        ReceiveSitDown(response.data);
                        break;
                    case MsgType.KillRoom_其他玩家坐下:
                        ReceiveOtherSitDown(response.data);
                        break;
                    case MsgType.KillRoom_从座位站起:
                        ReceiveStandUp(response.data);
                        break;
                    case MsgType.KillRoom_离开通杀场:
                        ReceiveLeaveKillRoom(response.data);
                        break;
                    case MsgType.KillRoom_庄家列表:
                        ReciveBankerList(response.data);
                        break;
                    case MsgType.KillRoom_其他玩家站起:
                        ReceiveOtherStandUp(response.data);
                        break;
                    case MsgType.KillRoom_更换庄家:
                        ReciveChangeBanker(response.data);
                        break;
                    case MsgType.KillRoom_获取奖池:
                        ReceiveGetJackpot(response.data);
                        break;
                    case MsgType.KillRoom_其他玩家上庄:
                        ReceiveKillRoomOtherPlayerApplicationBanker(response.data);
                        break;
                    case MsgType.KillRoom_其他玩家下庄:
                        ReceiveKillRoomOtherPlayerResignBanker(response.data);
                        break;
                    default:
                        return response;
                }
            }
            else
            {
                return response;
            }
        }
        return null;
    }

    private void ReceiveBankerCoins(byte[] data)
    {
        Push_killRoomBankerCoins response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomBankerCoins>(data);
        uiRoom.UpdateBankerCoins(response.userId,response.coins);
    }

    public void ShowLotteryTime(int time)
    {

        if (uiRoom.isActive())
        {
            uiRoom.ShowLotteryTime(time);
        }
    }

    public void ShowLotteryNum(int num)
    {
        if (uiRoom.isActive())
        {
            uiRoom.ShowCurBuyLotteryNum(num);
        }
    }
    public void ShowLotteryWin(bool play)
    {
        if (uiRoom.isActive())
        {
            uiRoom.LotteryWinPlay(play);
        }
    }
    #region Receive
    //休息时间
    private void ReceiveIdle(byte[] data)
    {
        Push_killRoomChangeToIdleResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomChangeToIdleResponse>(data);
        CacheManager.killRoom.state = KillRoom.STATE_IDLE;
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(uiRoom.IETimer(5f)));//"休息时间 "
        CacheManager.bankerRound++;
        uiRoom.SetBankerRound();
    }
    //通杀场下注时间
    private void ReceiveChangeToBet(byte[] data)
    {
        Push_killRoomChangeToBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomChangeToBetResponse>(data);
        CacheManager.killRoom.state = KillRoom.STATE_BET_TIME;
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(uiRoom.IETimer(18f)));//"下注时间 ", 
    }

    //通杀场发牌
    private void ReceiveChangeToLottery(byte[] data)
    {
        Push_killRoomChangeToLotteryResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomChangeToLotteryResponse>(data);
        Debug.Log("response:"+ response);

        CacheManager.gameData.exp += response.exp;
        if (CacheManager.KillRoomTV == 0 || CacheManager.KillRoomTV == 1)
            uiPokers.Set(CacheManager.KillRoomTV);
        CacheManager.killRoom.state = KillRoom.STATE_LOTTERY_TIME;
        KillRoomLog killRoomLog = response.killRoomLog;

        //while (CacheManager.List_bankerWin.Count >= 10)
        //{
        //    CacheManager.List_bankerWin.RemoveAt(0);
        //}
        //bool bankerWin = (!killRoomLog.dongWin && !killRoomLog.nanWin && !killRoomLog.xiWin && !killRoomLog.beiWin);
        //CacheManager.List_bankerWin.Add(bankerWin);


        //while (CacheManager.List_dongWin.Count >= 10)
        //    CacheManager.List_dongWin.RemoveAt(0);
        //CacheManager.List_dongWin.Add(killRoomLog.dongWin);

        //while (CacheManager.List_nanWin.Count >= 10)
        //    CacheManager.List_nanWin.RemoveAt(0);
        //CacheManager.List_nanWin.Add(killRoomLog.nanWin);

        //while (CacheManager.List_xiWin.Count >= 10)
        //    CacheManager.List_xiWin.RemoveAt(0);
        //CacheManager.List_xiWin.Add(killRoomLog.xiWin);

        //while (CacheManager.List_beiWin.Count >= 10)
        //    CacheManager.List_beiWin.RemoveAt(0);
        //CacheManager.List_beiWin.Add(killRoomLog.beiWin);
        //发牌动画
        uiPokers.DealCard(response.list_bankerPoker, killRoomLog, response.list_directionPlayers, response.bankerType, response.jackpotWin);
        CacheManager.jackpot = response.jackpot;          //奖池

        long bankerCalcScore = response.bankerScore - CacheManager.gameData.coins;


        //更新各玩家金币
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(uiRoom.ClearRoomTable(killRoomLog)));
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(ShowTips(response.list_tablePlayerScore, 10, response.calcScore, response.subCoins, response.otherSubCoins, bankerCalcScore)));

        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(uiPokers.ClosePokerFace()));     //清空扑克牌
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(uiRoom.IETimer(15f)));           //开奖时间 

        //更新走势图
        coroutines.Add(GameCanvas.gameCanvas.StartCoroutine(AddTrend(10f, response.killRoomLog)));
        
        if (CacheManager.banker.userId != 100000)
        {
            CacheManager.banker.coins = response.bankerScore;//庄家输赢
            if (CacheManager.banker.userId == CacheManager.gameData.userId)//如果自己是庄家
            {
                Debug.Log("服务器返回庄家当前金币:" + response.bankerScore + ",当前本身金币:" + CacheManager.gameData.coins + ", 金币差值:" + bankerCalcScore);
                CacheManager.gameData.coins = response.bankerScore;
            }
            else
            {
                CacheManager.gameData.coins = response.nowCoins;
            }
        }
        else
        {
            CacheManager.gameData.coins = response.nowCoins;
        }

    }
    /// <summary>
    /// 自己下注
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveKillRoomPayBet(byte[] data)
    {
        KillRoomPayBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomPayBetResponse>(data);
        switch (response.code)
        {
            case KillRoomPayBetResponse.SUCCESS:
                if (CacheManager.KillRoomTV == 0)
                {
                    BaseCanvas.PlaySound(R.AudioClip.SOUND_KILLROOMBET);
                }

                //Debug.Log("自己下注,位置:"+ response.pos+ ",response.chipNum:"+ response.chipNum);
                CacheManager.gameData.coins -= response.chipNum;
                uiRoom.UpdateSelf(response.pos, response.chipNum);
                list_directionBetNum[response.pos] += response.chipNum;
                CacheManager.killRoom.killRoomPayBet[response.pos] += response.chipNum;
                uiPokers.UpdatePosGold(response.pos);
                for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                {
                    PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];

                    if (playerSimpleData != null && playerSimpleData.userId == CacheManager.gameData.userId)   //自己在座位上
                    {
                        playerSimpleData.coins -= response.chipNum;
                        uiRoom.UpdatePosGold(i, response.pos);
                        break;
                    }
                    if (i == CacheManager.TablePlayers.Length - 1)                     //自己不在座位上
                    {
                        uiRoom.UpdatePosGold(8, response.pos);
                    }
                }
                break;
            case KillRoomPayBetResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            case KillRoomPayBetResponse.ERROR_单边下注超标:
                Debug.LogError("单边下注超标");
                break;
            default:
                Debug.LogError("通杀场下注未知错误,错误代码：" + response.code);
                break;
        }

    }
    /// <summary>
    /// 其他玩家下注
    /// </summary>
    /// <param name="data"></param>
    private void ReceivePushkillRoomPayBet(byte[] data)
    {
        Push_killRoomPayBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomPayBetResponse>(data);
        for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];

            if (playerSimpleData != null && playerSimpleData.userId == response.userId)   //在座位上
            {
                list_directionBetNum[response.payPos] += response.payNum;
                playerSimpleData.coins -= response.payNum;
                uiRoom.UpdatePosGold(i, response.payPos);
                uiPokers.UpdatePosGold(response.payPos);
                break;
            }
            if (i == CacheManager.TablePlayers.Length - 1)                     //外围玩家下注
            {
                list_directionBetNum[response.payPos] += response.payNum;
                uiRoom.UpdatePosGold(9, response.payPos);
                uiPokers.UpdatePosGold(response.payPos);
            }
        }
    }
    private void ReceiveSitDown(byte[] data)
    {
        KillRoomSitDownResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomSitDownResponse>(data);
        switch (response.code)
        {
            case KillRoomSitDownResponse.SUCCESS:
                uiRoom.SitDown(response.pos);
                break;
            case KillRoomSitDownResponse.ERROR_桌子有人:
                Debug.LogError("桌子有人");
                break;
            case KillRoomSitDownResponse.ERROR_桌子号错误:
                Debug.LogError("桌子号错误");
                break;
            case KillRoomSitDownResponse.ERROR_已经坐下:
                Debug.LogError("你已经在座位上");
                break;
            default:

                break;
        }
    }
    /// <summary>
    /// 其他玩家坐下
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveOtherSitDown(byte[] data)
    {
        Push_killRoomSitDown response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomSitDown>(data);
        int pos = response.player.killRoomPos;
        ToolClass.GetHead(response.player);
        CacheManager.TablePlayers[pos] = response.player;

        ToolClass.SetRankSprite(response.player);


        uiRoom.SetPosData(pos, true);
    }

    private void ReceiveStandUp(byte[] data)
    {
        KillRoomStandUpResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomStandUpResponse>(data);
        switch (response.code)
        {
            case KillRoomStandUpResponse.SUCCESS:
                CacheManager.TablePlayers[response.pos] = null;
                uiRoom.SetPosData(response.pos, false);
                break;
            default:
                break;
        }
    }

    private void ReceiveLeaveKillRoom(byte[] data)
    {
        LeaveKillRoomResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LeaveKillRoomResponse>(data);
        switch (response.code)
        {
            case LeaveKillRoomResponse.SUCCESS:
                CacheManager.banker = null;
                CacheManager.TablePlayers = null;
                uiRoom.Hide();
                uiPokers.Hide();

                if (CacheManager.KillRoomTV == 0)
                {
                    GetController<ShopBoxCtrl>().Hide();
                    GetController<MainSceneCtrl>().ShowUIMainScene();
                    GetController<MainSceneCtrl>().Init();
                    GetController<MainSceneCtrl>().SendMainSceneEnterKillRoomRequest();
                    GetController<MoreCtrl>().Hide();
                }

                StopCoroutine();
                break;
            default:
                Debug.LogError("离开通杀场发生未知错误 错误代码：" + response.code);
                break;
        }
    }

    private void ReciveBankerList(byte[] data)
    {
        BankerListResponse response = MySerializerUtil.DeSerializerFromProtobufNet<BankerListResponse>(data);
        switch (response.code)
        {
            case BankerListResponse.SUCCESS:
                CacheManager.List_bankerList = response.list_bankerList;
                ShowUpBankUI();
                break;
            default:
                break;
        }
    }

    public bool InUpBankerList()
    {
        if (CacheManager.List_bankerList == null || CacheManager.List_bankerList.Count <= 0)
            return false;
        foreach (PlayerSimpleData item in CacheManager.List_bankerList)
        {
            if (item.userId == CacheManager.gameData.userId)
                return true;
        }
        return false;
    }

    internal int GetLotteryTime()
    {
        if (uiRoom != null)
        {
            return uiRoom.LotteryTime;
        }
        return 0;
    }

    private void ReciveChangeBanker(byte[] data)
    {

        Push_killRoomChangeBanker response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomChangeBanker>(data);
        CacheManager.banker = response.banker;
        ToolClass.SetRankSprite(response.banker);

        if (CacheManager.List_bankerList != null)
        {
            for (int i = 0; i < CacheManager.List_bankerList.Count; i++)
            {
                PlayerSimpleData playerSimpleData = CacheManager.List_bankerList[i];
                if (response.banker.userId == playerSimpleData.userId)
                {
                    CacheManager.List_bankerList.Remove(playerSimpleData);
                    break;
                }
            }
        }
        ToolClass.GetHead(CacheManager.banker);
        CacheManager.bankerRound = 0;
        uiRoom.UpdataBaker();
        uiRoom.SetBankerRound();
        if (CacheManager.gameData.userId == response.banker.userId)//上庄的是自己
        {
            GetController<UpBankerListCtrl>().Hide();
            GetController<MoreCtrl>().HideTV();
            GetController<LotteryCtrl>().HideLottery();
        }
    }

    private void ReceiveGetJackpot(byte[] data)
    {
        GetJackpotResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetJackpotResponse>(data);
        switch (response.code)
        {
            case GetJackpotResponse.SUCCESS:
                Debug.Log("获取通杀场奖池：" + response.jackpotData.ToString());
                ShowJackpotUI(response.jackpotData);
                break;
            case GetJackpotResponse.ERROR_不在比赛中:
                break;
        }
    }

    private void ReceiveKillRoomOtherPlayerApplicationBanker(byte[] data)
    {
        Push_killRoomOtherPlayerApplicationBanker response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomOtherPlayerApplicationBanker>(data);
        CacheManager.List_bankerList.Add(response.bankerRequest);
        GetController<UpBankerListCtrl>().Init();

    }

    private void ReceiveKillRoomOtherPlayerResignBanker(byte[] data)
    {
        Push_killRoomOtherPlayerResignBanker response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomOtherPlayerResignBanker>(data);
        for (int i = 0; i < CacheManager.List_bankerList.Count; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.List_bankerList[i];
            if (response.userId == playerSimpleData.userId)
            {
                CacheManager.List_bankerList.Remove(playerSimpleData);
                GetController<UpBankerListCtrl>().Init();
                break;
            }
        }

    }

    private void ReceiveOtherStandUp(byte[] data)
    {
        Push_killRoomStandUp response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomStandUp>(data);
        CacheManager.TablePlayers[response.pos] = null;
        uiRoom.SetPosData(response.pos, false);
    }

    #endregion

    /// <summary>
    /// 通杀场推出房间
    /// </summary>
    private void CloseRoom()
    {
        if (CacheManager.gameData.userId == CacheManager.banker.userId)
        {
            GetController<MessageCtrl>().Show("你已是庄家，暂时不能退出游戏！");
            return;
        }

        bool inUpList = false;
        if (CacheManager.List_bankerList.Count > 0)
        {
            foreach (var item in CacheManager.List_bankerList)
            {
                if (item.userId == CacheManager.gameData.userId)
                {
                    inUpList = true;
                    break;
                }
            }
        }
        if (inUpList)
        {
            GetController<MessageCtrl>().Show("你在上庄列表中，暂时不能退出游戏！");
            return;
        }
        GetController<ChatCtrl>().HideUIRoomChat();
        GetController<ChatCtrl>().CloseChat();
        SendKillRoomStandUpRequest();
        GetController<MainSceneCtrl>().ShowUIMainScene();
        //SetRoomIndex(2);
        inRoom = false;
        UIRoomHide2();
        CacheManager.KillRoomTV = 2;
    }

    //退出时调用
    public void SetRoomIndex(int index)
    {
        uiRoom.Set(index);
        uiPokers.Set(index);
        if (index == 0)
        {
            SendKillRoomGetAllRedRequest();
            GetController<ShopBoxCtrl>().Show();
            inRoom = true;
            GetController<ChatCtrl>().ShowUIRoomChat();
        }
        else
        {
            GetController<ShopBoxCtrl>().Hide();
        }

        SetIsActiveRoom(true);
    }


    public void ResSelfCoins()
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.RefSelfCoins();
        }
    }


    public bool InRoom()
    {
        return inRoom;
    }

    public void RefHead()
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.RefHead();
        }
    }

    /// <summary>
    /// 通杀场判断自己是不是庄家
    /// </summary>
    /// <returns></returns>
    public bool IsBanker()
    {
        if (CacheManager.banker != null && CacheManager.banker.userId == CacheManager.gameData.userId)
            return true;
        return false;
    }

    public void SetInfoVip()
    {
        Debug.LogError("设置通杀场vip等级");
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.SetInfoVip();
        }
        else
        {
            Debug.LogError("为空");
        }
    }

    public void HideOn()
    {
        if (uiRoom != null)
            uiRoom.Hide();
        if (uiPokers != null)
            uiPokers.Hide();
        StopCoroutine();
    }

    public void Connect()
    {
        StopCoroutine();
        CacheManager.banker = null;
        CacheManager.TablePlayers = null;
        if (uiRoom != null)
        {
            uiRoom.Connect();
        }
        if (uiPokers != null)
        {
            uiPokers.Connect();
        }
    }

    public void SetNickname()
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.SetNickname();
        }
    }

    public void ClearAllCoins()
    {
        if (uiRoom != null && uiRoom.isActive())
        {
            uiRoom.ClearAllCoins();
        }
    }

    public void HideTV()
    {
        if (uiRoom != null)
        {
            uiRoom.HideTV();
        }
    }
}