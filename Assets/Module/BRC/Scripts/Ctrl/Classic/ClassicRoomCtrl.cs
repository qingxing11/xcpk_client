using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicRoomCtrl : BaseController, IHandlerReceive
{
    private UIClassicRoom uiClaRoom;
    private UIComparerPoker uiComparerPoker;
    private UIReturnPanelClassic uiReturnPanel; //返回面板
    private UIHornRecord uiHornRecord;//消息记录面板

    /// <summary>
    /// 是否看牌
    /// </summary>
    public bool isLook = false;
    /// <summary>
    /// 自己手牌
    /// </summary>
    List<PokerVO> list_poker;
    public bool[] isLookPokers = new bool[5];
    Coroutine coroutineClock;
    public override void InitAction()
    {
        uiClaRoom = GetUIPage<UIClassicRoom>();
        uiClaRoom.ActionCall = SendFollowBetRequest; //跟注
        uiClaRoom.ActionSee = SendCheckPokerRequest; //看牌
        uiClaRoom.ActionRaise = SendRaiseBetRequest; //加注
        uiClaRoom.ActionComparer = SendComparerPokerRequest;    //比牌
        uiClaRoom.ActionFold = SendFoldRequest;
        uiClaRoom.ActionAllin = SendAllInRequest;     
        uiClaRoom.ActionChat = ShowUIChat;
        uiClaRoom.ActionHorn = ShowHornUI;
        uiClaRoom.ActionInfo = ShowInfoUI;
        uiClaRoom.hideClassChat = HideClassChat;
        uiClaRoom.hornRecord = HornRecord;
        uiClaRoom.lottery = ShowUILottery;      
        uiClaRoom.ActionMore = ShowMoreUI;
        uiClaRoom.ActionFriend = ShowFriend;
        uiClaRoom.ActionShowReturn = ShowReturnUI;
        uiClaRoom.ActionLuckyBox = ShowLuckyBoxUI;
        uiClaRoom.ActionFastBuy = FastBuyOnClick;
        uiClaRoom.ActionOnClick = UIPageOnClick;

        uiComparerPoker = GetUIPage<UIComparerPoker>();


        uiHornRecord = GetUIPage<UIHornRecord>();

        uiReturnPanel = GetUIPage<UIReturnPanelClassic>();
        uiReturnPanel.ActionLeave = SendLeaveClassicGameRequest;    //离开经典场
        uiReturnPanel.ActionSet = ShowSetUI;
        uiReturnPanel.ActionHuanZuo = SendChangeTableRequest;
        uiReturnPanel.ActionHelp = ShowHelp;
    }

    public void FastBuyOnClick()
    {
        GetController<ShopCtrl>().ActionShopClick(1,2);
    }

    public void UIPageOnClick()
    {
        GetController<MoreCtrl>().Hide2();
    }

    public void ShowLotteryNum(int num)
    {
        if (uiClaRoom.isActive())
        {
            uiClaRoom.ShowCurBuyLotteryNum(num);
        }
    }



    public void ShowLotteryWin(bool play)
    {
        if (uiClaRoom.isActive())
        {
            uiClaRoom.LotteryWinPlay(play);
        }
    }


    /// <summary>
    /// 刷新界面金币
    /// </summary>
    public void RefreshCoin()
    {
        if (uiClaRoom != null && uiClaRoom.isActive())
        {
            uiClaRoom.UpdateUserCoins(0);
        }
    }

    public void RefPosCoin(int pos)
    {
        uiClaRoom.UpdateUserCoins(pos);
    }
    private void ShowUILottery()
    {
        GetController<LotteryCtrl>().ShowUILottery();
    }

    //更多
    private void ShowMoreUI()
    {
        GetController<MoreCtrl>().Show(2);
    }

    private void ShowHelp()
    {
        GetController<HelpCtrl>().ShowHelpClassicUI();
    }

    private void ShowFriend()
    {
        GetController<FriendCtrl>().ShowUIFriend();
    }

    private void ShowReturnUI(bool state)
    {
        if (state)
        {
            ShowUI<UIReturnPanelClassic>();
            uiReturnPanel.Init();
        }
        else
        {
            uiReturnPanel.Hide();
        }
    }

    private void ShowLuckyBoxUI(bool state)
    {
        if (state)
        {
            GetController<LuckyBoxCtrl>().Show();
        }
        else
        {
            GetController<LuckyBoxCtrl>().Hide();
        }
    }




    public void ShowLotteryTime(int time)
    {
        if (uiClaRoom.isActive())
        {
            uiClaRoom.ShowLotteryTime(time);
        }
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
    /// 滚动条消息
    /// </summary>
    /// <param name="vo"></param>
    public void ShowTxtTitle(HornInfoVO vo)
    {
        
       GetController<RoomCtrl>().RefreshHornRecordList();
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
        if (uiClaRoom.isActive())
        {
            CacheManager.AddHorn(vo);
            GetUIPage<UIGlobalNotic>().NoticPlay(vo);//广播
        }
        GetController<RoomCtrl>().RefreshHornRecordList();
    }


    private void HideHornRecordCom()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.Hide();
        }
    }
    private void HideClassChat()
    {
        HideHornRecordCom();
        GetController<ChatCtrl>().HideUIClassCom();
    }
    //经典场打开音量设置
    private void ShowSetUI()
    {
        GetController<SetCtrl>().ShowSetUI2();
    }
    private void ShowHornUI()
    {
        GetController<HornCtrl>().ShowUIHornCom();
    }
    private void ShowUIChat()
    {
        GetController<ChatCtrl>().ShowUIChat2(3);
    }
    private void ShowInfoUI(int pos)
    {
        GetController<UserInfoCtrl>().ShowOtherInfoUI(CacheManager.ClassRoomPlayers[pos]);
    }

    /// <summary>
    /// 0 正常打开 1：断线重连
    /// </summary>
    /// <param name="index"></param>
    public void Show(int index)
    {
        ShowUI<UIClassicRoom>();
        if (index == 1)
        {
            uiClaRoom.Reconnection();
        }
        else
        {
            GetController<MessageCtrl>().ShowTips();
        }
        GetController<ChatCtrl>().ShowUIClassChat();

        GetController<MainSceneCtrl>().HideHornRecordCom();

        GetController<LotteryCtrl>().SendAskTime();
    }

    public void ShowComparerUI(int pos0, int pos1, int lossPos, bool isLook = false, List<PokerVO> pokerVOs = null,int selfPos=0)
    {
        ShowUI<UIComparerPoker>();
        GameCanvas.gameCanvas.StartCoroutine(uiComparerPoker.Init(pos0, pos1, lossPos,isLook,pokerVOs,selfPos));
    }


    private void SendFollowBetRequest()
    {
        FollowBetRequest request = new FollowBetRequest();
        SendMessage(request);
    }
    private void SendCheckPokerRequest()
    {
        CheckPokerRequest request = new CheckPokerRequest();
        SendMessage(request);
    }
    private void SendRaiseBetRequest(int betNum)
    {
        RaiseBetRequest request = new RaiseBetRequest
        {
            betNum = betNum,
        };
        SendMessage(request);
    }

    private void SendComparerPokerRequest(int pos)
    {
        ComparerPokerRequest request = new ComparerPokerRequest
        { pos = ToolClass.RelToAbs(pos), };
        SendMessage(request);
    }

    private void SendFoldRequest()
    {
        FoldRequest request = new FoldRequest();
        SendMessage(request);
    }
    private void SendAllInRequest()
    {
        AllInRequest request = new AllInRequest();
        SendMessage(request);
    }

    private void SendLeaveClassicGameRequest()
    {
        LeaveClassicGameRequest request = new LeaveClassicGameRequest();
        SendMessage(request);
    }
    private void SendChangeTableRequest()
    {
        ChangeTableRequest request = new ChangeTableRequest();
        SendMessage(request);
    }

    public void Return()
    {
        uiClaRoom.BackOnClick();
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            Debug.Log("经典场response.msgType=" + response.msgType);
            switch (response.msgType)
            {
                case MsgType.classic_其他玩家进入房间:
                    ReceiveOtherPlayerEnter(response.data);
                    break;
                case MsgType.classic_开始发牌:
                    ReceiveDealPoker(response.data);
                    break;
                case MsgType.classic_玩家行动:
                    ReceivePlayerAction(response.data);
                    break;
                case MsgType.classic_玩家跟注:        //自己跟注
                    ReceiveFollowBet(response.data);
                    break;
                case MsgType.classic_有玩家跟注:
                    ReceivePlayerFollow(response.data);
                    break;
                case MsgType.classic_玩家看牌:
                    ReceiveCheckPoker(response.data);
                    break;
                case MsgType.classic_有玩家看牌:
                    ReceiveOtherCheckPoker(response.data);
                    break;
                case MsgType.classic_玩家离开:
                    ReceivePlayerLeave(response.data);
                    break;
                case MsgType.classic_其他玩家离开:
                    ReceiveOtherLeave(response.data);
                    break;
                case MsgType.classic_玩家加注:
                    ReceiveRaiseBet(response.data);
                    break;
                case MsgType.classic_有玩家加注:
                    ReceivePlayerRaiseBet(response.data);
                    break;
                case MsgType.classic_玩家胜利:
                    ReceivePlayerWin(response.data);
                    break;
                case MsgType.classic_玩家比牌:
                    ReceiveComparerPoker(response.data);
                    break;
                case MsgType.classic_其他玩家比牌:
                    ReceiveOtherComparerPoker(response.data);
                    break;
                case MsgType.classic_玩家弃牌:
                    ReceiveFold(response.data);
                    break;
                case MsgType.classic_有玩家弃牌:
                    ReceivePlayerDie(response.data);
                    break;
                case MsgType.classic_玩家全压:
                    ReceiveAllIn(response.data);
                    break;
                case MsgType.classic_其他玩家全压:
                    ReceiveOtherAllIn(response.data);
                    break;
                case MsgType.classic_等待比赛开始:
                    ReceiveWaiStart(response.data);
                    break;
                case MsgType.classic_换桌:
                    ReceiveChangeTable(response.data);
                    break;
                case MsgType.classic_断线重连:
                    ReceiveReconnect(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

   

    private void ReceiveOtherPlayerEnter(byte[] data)
    {
        ClassicGamePush_otherPlayerEnter response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_otherPlayerEnter>(data);
        


        PlayerSimpleData playerSimpleData = response.playerSimpleData;
        ToolClass.GetHead(playerSimpleData);
        int pos = ToolClass.AbsToRel(playerSimpleData.classicGamepos);
        CacheManager.ClassRoomPlayers[pos] = playerSimpleData;
        CacheManager.ClassRoomRoleId[pos] = playerSimpleData.roleId;
        int userId = playerSimpleData.userId;
        ToolClass.SetRankSprite(playerSimpleData);
        uiClaRoom.SetPosData(pos);
    }

    internal IEnumerator PlayAudioFapai()
    {
        int i = 0;
        while (i < 5)
        {
            if (CacheManager.ClassRoomPlayers[i] != null)
            {
                 if (CacheManager.ClassRoomPlayers[i].roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_FAPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_FAPAI1);
                yield return new WaitForSeconds(0.2f);
            }
            i++;
        }
        yield return null;
    }
    Coroutine coroutineFapai;
    private void ReceiveDealPoker(byte[] data)
    {
        ClassicGamePush_dealPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_dealPoker>(data);
        CacheManager.actionPos = response.playPos;
        for (int i = 0; i < isLookPokers.Length; i++)
        {
            isLookPokers[i] = false;
        }
        uiClaRoom.StartChipAnim(response.betNum);
        uiClaRoom.SetOneBet(response.betNum);
        uiClaRoom.HideBtn(true);
        CacheManager.classicRoomState = 0;
        CacheManager.gameData.coins -= response.betNum;

        GameCanvas.gameCanvas.StartCoroutine(PlayAudioFapai());
        
        for (int i = 0; i < CacheManager.ClassRoomPlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.ClassRoomPlayers[i];
            if (playerSimpleData != null)
            {
                CacheManager.ClassRoomPlayers[i].betNum += response.betNum;
                uiClaRoom.UpdateUserCoins(i);
                uiClaRoom.SetAllBet(response.betNum);
            }
        }
        int bankerPos = ToolClass.AbsToRel(response.bankerPos);
        uiClaRoom. SetReadIcon(false);
        coroutineFapai= GameCanvas.gameCanvas.StartCoroutine(uiClaRoom.DealPokerAnim(bankerPos));
   
        GetController<MessageCtrl>().HideTipesUI();
    }

   
    private void ReceivePlayerAction(byte[] data)
    {
        ClassicGamePush_playerAction response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerAction>(data);
        //Debug.Log("经典场玩家行动"+response.ToString());
        int pos = ToolClass.AbsToRel(response.pos);
        uiClaRoom.PlayPlayerActionTimer(pos,0);
        // uiClaRoom.PlayerAction(pos, response.nowBet, response.isCheckPoker, response.round, response.allInState);
        uiClaRoom.PlayerAction(pos, response.isCheckPoker, response.round, response.allInState);
    }

    private void ReceiveFollowBet(byte[] data)
    {
        FollowBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FollowBetResponse>(data);
        switch (response.code)
        {
            case FollowBetResponse.SUCCESS:
                if(CacheManager.gameData.roleId==0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN1);
                List<int> betNums;

                if (isLook)
                {
                    betNums = ToolClass.CoinCconversion0(response.betNum / 2);
                    uiClaRoom.ChipAnim(0, betNums);
                    uiClaRoom.ChipAnim(0, betNums);
                }
                else
                {
                    betNums = ToolClass.CoinCconversion0(response.betNum);
                    uiClaRoom.ChipAnim(0, betNums);
                }
                CacheManager.ClassRoomPlayers[0].betNum += response.betNum;
                CacheManager.gameData.coins -= response.betNum;
                uiClaRoom.SetAllBet(response.betNum);

                uiClaRoom.UpdateUserCoins(0);
                break;
            case FollowBetResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            case FollowBetResponse.ERROR_不在比赛中:
                Debug.LogError("不在比赛中");
                break;
            case FollowBetResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 有玩家跟注
    /// </summary>
    /// <param name="data"></param>
    private void ReceivePlayerFollow(byte[] data)
    {
        ClassicGamePush_playerFollow response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerFollow>(data);
        uiClaRoom.SetAllBet(response.betNum);
        int pos = ToolClass.AbsToRel(response.pos);
        List<int> betNums;
        if (isLookPokers[pos])
        {
            betNums = ToolClass.CoinCconversion0(response.betNum / 2);
            uiClaRoom.ChipAnim(pos, betNums);
            uiClaRoom.ChipAnim(pos, betNums);
        }
        else
        {
            betNums = ToolClass.CoinCconversion0(response.betNum);
            uiClaRoom.ChipAnim(pos, betNums);
        }
        
        if(CacheManager.ClassRoomPlayers[pos].roleId==0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN1);
        uiClaRoom.PlayerAct(pos,4);
        CacheManager.ClassRoomPlayers[pos].betNum += response.betNum;
        CacheManager.ClassRoomPlayers[pos].coins -= response.betNum;
        uiClaRoom.UpdateUserCoins(pos);
    }

    private void ReceiveCheckPoker(byte[] data)
    {
        CheckPokerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<CheckPokerResponse>(data);
        switch (response.code)
        {
            case CheckPokerResponse.SUCCESS:
                isLook = true;
                if (CacheManager.gameData.roleId==0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI1);
                uiClaRoom.SelfCheckPoker(response.list_poker,response.pokerType);
                list_poker = response.list_poker;
                Debug.LogError("看牌成功");
                break;
            case CheckPokerResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
            case CheckPokerResponse.ERROR_不在比赛中:
                Debug.LogError("不在比赛中");
                break;
            default:
                break;
        }
    }

    private void ReceiveOtherCheckPoker(byte[] data)
    {
        ClassicGamePush_checkPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_checkPoker>(data);
        int pos = ToolClass.AbsToRel(response.pos);
        if(CacheManager.ClassRoomPlayers[pos].roleId==0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI1);
        isLookPokers[pos]=true;
        uiClaRoom.PlayerAct(pos, 1);
        uiClaRoom.OtherCheckPoker(pos);
    }
   

    private void ReceiveRaiseBet(byte[] data)
    {
        RaiseBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<RaiseBetResponse>(data);
        switch (response.code)
        {
            case RaiseBetResponse.SUCCESS:
                int betNum = response.betNum;
                if (isLook)
                    betNum /= 2;

                uiClaRoom.SetOneBet(betNum);
                uiClaRoom.SetAllBet(response.betNum);
                CacheManager.gameData.coins -= response.betNum;
                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU0);
                else
                {
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU1);
                }

                List<int> betNums;
                if (isLook)
                {
                    betNums = ToolClass.CoinCconversion0(response.betNum / 2);
                    uiClaRoom.ChipAnim(0, betNums);
                    uiClaRoom.ChipAnim(0, betNums);
                }
                else
                {
                    betNums = ToolClass.CoinCconversion0(response.betNum);
                    uiClaRoom.ChipAnim(0, betNums);
                }

                CacheManager.ClassRoomPlayers[0].betNum += response.betNum;
                uiClaRoom.UpdateUserCoins(0);

                break;
            case RaiseBetResponse.ERROR_金币不足: Debug.LogError("金币不足"); break;
            case RaiseBetResponse.ERROR_不在比赛中: Debug.LogError("不在比赛中"); break;
            case RaiseBetResponse.ERROR_没轮到行动: Debug.LogError("没轮到行动"); break;
            default:
                Debug.LogError("加注发生位置错误 错误code:" + response.code);
                break;
        }
    }
    /// <summary>
    /// 其他玩家加注
    /// </summary>
    /// <param name="data"></param>
    private void ReceivePlayerRaiseBet(byte[] data)
    {
        ClassicGamePush_playerRaiseBet response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerRaiseBet>(data);

        int pos = ToolClass.AbsToRel(response.pos);
        int betNum = response.betNum;
        if (isLook)
            betNum /= 2;
        uiClaRoom.SetOneBet(betNum);
        uiClaRoom.SetAllBet(response.betNum);
        List<int> betNums = ToolClass.CoinCconversion0(response.betNum);
        uiClaRoom.ChipAnim(pos, betNums);
        uiClaRoom.PlayerAct(pos, 3);
        PlayerSimpleData playerSimpleData = CacheManager.ClassRoomPlayers[pos];
        if (playerSimpleData.roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU0);
        else
        {
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU1);
        }
        playerSimpleData.betNum += response.betNum;
        playerSimpleData.coins -= response.betNum;
        uiClaRoom.UpdateUserCoins(pos);
    }
    //玩家胜利
    private void ReceivePlayerWin(byte[] data)
    {
        ClassicGamePush_playerWin response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerWin>(data);
        int pos = 0;
        isLook = false;
        CacheManager.classicRoomState = 1;
        for (int i = 0; i < response.list_roundData.Count; i++)
        {
            GameRoundDataVO gameRoundDataVO = response.list_roundData[i];

          
           
            if (gameRoundDataVO.roundBet > 0)
            {
                pos = ToolClass.AbsToRel(gameRoundDataVO.pos);
                CacheManager.ClassRoomPlayers[pos].coins += gameRoundDataVO.roundBet;
                if (pos == 0)
                {
                    CacheManager.gameData.coins += gameRoundDataVO.roundBet;
                }
                uiClaRoom.UpdateUserCoins(pos);
                uiClaRoom.PlayWinAnim(pos);
                uiClaRoom.SetPokerType(pos, gameRoundDataVO.pokerType);
                if (pos == 0)
                {
                    uiClaRoom.SetLuckyBtnState(true);
                }
              
                break;
            }
        }
        uiClaRoom.SetBtn(false);
        uiClaRoom.StopPlayerActionTimer();
        BaseCanvas.PlaySound(R.AudioClip.SOUND_JINBI);
        GameCanvas.gameCanvas.StartCoroutine(ClearPokers(pos, response.list_roundData));
       
    }

    private void ReceiveComparerPoker(byte[] data)
    {
        ComparerPokerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ComparerPokerResponse>(data);
        switch (response.code)
        {
            case ComparerPokerResponse.SUCCESS:
                break;
            case ComparerPokerResponse.ERROR_不在比赛中:
                Debug.LogError("不在比赛中");
                break;
            case ComparerPokerResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
            case ComparerPokerResponse.ERROR_比牌错误:
                Debug.LogError("比牌错误");
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 其他玩家比牌
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveOtherComparerPoker(byte[] data)
    {
        ClassicGamePush_comparerPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_comparerPoker>(data);
        int pos0 = ToolClass.AbsToRel(response.pos0);
        int pos1 = ToolClass.AbsToRel(response.pos1);
        int lossPos = ToolClass.AbsToRel(response.lossPos);

        List<int> betNums = ToolClass.CoinCconversion0(response.subCoins);
        if (pos0 == 0)
        {
            CacheManager.gameData.coins -= response.subCoins;   
        }
        CacheManager.ClassRoomPlayers[pos0].coins -= response.subCoins;
        CacheManager.ClassRoomPlayers[pos0].betNum += response.subCoins;
        uiClaRoom.UpdateUserCoins(pos0);
        uiClaRoom.ChipAnim(pos0, betNums);

        if (!uiClaRoom.isAllin)
        {
            if (CacheManager.ClassRoomPlayers[pos0].roleId == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAI0);
            else
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAI1);
        }
        uiClaRoom.PlayerAct(pos0, 6);
        uiClaRoom.roomPeople--;
        uiClaRoom.StopPlayerActionTimer();
        if (lossPos == 0)
        {
            CacheManager.classicRoomState = 2;
        }
        if (pos0 == 0 && isLook)
        {
            ShowComparerUI(pos0, pos1, lossPos, isLook, list_poker, pos0);
        }
        else if (pos1 == 0 && isLook)
        {
            ShowComparerUI(pos0, pos1, lossPos, isLook, list_poker,pos1);
        }
        else
        {
            ShowComparerUI(pos0, pos1, lossPos);
        }
        GameCanvas.gameCanvas.StartCoroutine(uiClaRoom.PlayComparerPokerAnim(pos0, pos1));
        GameCanvas.gameCanvas.StartCoroutine(CloseUIComparerPoker(lossPos));
        if (lossPos == 0)
        {
            uiClaRoom.SetBtn(false);
        }
    }

    private IEnumerator CloseUIComparerPoker(int lossPos)
    {
        yield return new WaitForSeconds(2f);
        uiClaRoom.PokerLoser(lossPos);
        yield return null;
    }

    private IEnumerator ClearPokers(int pos,List<GameRoundDataVO> list_roundData)
    {
        for (int i = 0; i < list_roundData.Count; i++)
        {
            GameRoundDataVO gameRoundDataVO = list_roundData[i];
            int pos2 = ToolClass.AbsToRel(gameRoundDataVO.pos);
            uiClaRoom.SetResults(pos2,gameRoundDataVO.roundBet);
            if (gameRoundDataVO.list_handPoker != null)
            {
                uiClaRoom.SetPoker(gameRoundDataVO.list_handPoker, pos2);
            }
        }
        yield return new WaitForSeconds(1f);
        uiClaRoom.ChipAnim2(pos);
        yield return new WaitForSeconds(1f);
        uiClaRoom.PlayResults();
        
    }

    private void ReceiveFold(byte[] data)
    {
        FoldResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FoldResponse>(data);
        switch (response.code)
        {
            case FoldResponse.SUCCESS:

                int pos = ToolClass.AbsToRel(CacheManager.selfPos);
                if (CacheManager.classicRoomState == 0)
                {
                    if (CacheManager.ClassRoomPlayers[pos] == null)
                    {
                        if (CacheManager.ClassRoomRoleId[pos] == 0)
                            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                        else
                            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
                    }
                    else
                    {
                        if (CacheManager.ClassRoomPlayers[pos].roleId == 0)
                            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                        else
                            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
                    }
                }
                else
                {
                    Debug.LogError("其他玩家弃牌不再游戏中不播放音效");
                }

                if (coroutineFapai != null)
                    GameCanvas.gameCanvas.StopCoroutine(coroutineFapai);
                uiClaRoom.HideBtn(false);
                GetController<MessageCtrl>().ShowTips();
                uiClaRoom.Fold();
                uiClaRoom.SetBtn(false);
                uiClaRoom.GenIconFalse();
                CacheManager.classicRoomState = 2;

                Debug.Log("自己弃牌，位置:"+ CacheManager.selfPos+",当前行动玩家："+ CacheManager.actionPos);
               if(CacheManager.selfPos == CacheManager.actionPos)
                    uiClaRoom.StopPlayerActionTimer();

              
                break;
            case FoldResponse.ERROR_不在比赛中:
                Debug.LogError("不再比赛中");
                break;
            default:
                Debug.LogError("弃牌发生未知错误");
                break;
        }
    }
    /// <summary>
    /// 其他玩家弃牌
    /// </summary>
    /// <param name="data"></param>
    private void ReceivePlayerDie(byte[] data)
    {
        ClassicGamePush_playerDie response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerDie>(data);
        if (response.pos == -1)
            return;

        Debug.Log("其他玩家弃牌,pos:" + response.pos);
        int pos = ToolClass.AbsToRel(response.pos);
        Debug.Log("其他玩家弃牌:"+ CacheManager.ClassRoomPlayers[pos].nickName);

        uiClaRoom.PlayerAct(pos, 2);

        if (CacheManager.classicRoomState == 0)
        {
            if (CacheManager.ClassRoomPlayers[pos] == null)
            {
                if (CacheManager.ClassRoomRoleId[pos] == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
            }
            else
            {
                if (CacheManager.ClassRoomPlayers[pos].roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
            }
        }
        else
        {
            Debug.LogError("其他玩家弃牌不再游戏中不播放音效");
        }

        if (CacheManager.selfPos == response.pos)
        {
            if (coroutineFapai != null)
                GameCanvas.gameCanvas.StopCoroutine(coroutineFapai);
            uiClaRoom.HideBtn(false);
            GetController<MessageCtrl>().ShowTips();
            uiClaRoom.Fold();
            uiClaRoom.SetBtn(false);
            uiClaRoom.GenIconFalse();
            CacheManager.classicRoomState = 2;

            Debug.Log("自己弃牌，位置:" + CacheManager.selfPos + ",当前行动玩家：" + CacheManager.actionPos);
            if (CacheManager.selfPos == CacheManager.actionPos)
                uiClaRoom.StopPlayerActionTimer();
        }
        else {
            if (CacheManager.ClassRoomPlayers[pos] != null)
                CacheManager.ClassRoomPlayers[pos].gameState = 2;

        }

        uiClaRoom.OtherDealPoker(pos);
        //uiClaRoom.StopPlayerActionTimer();
    }

    private void ReceiveAllIn(byte[] data)
    {
        AllInResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AllInResponse>(data);
        switch (response.code)
        {
            case AllInResponse.SUCCESS:
                uiClaRoom.isAllin = true;
                if(CacheManager.gameData.roleId==0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA1);


                List<int> betNums = ToolClass.CoinCconversion0(response.betNum);
                uiClaRoom.ChipAnim(0,betNums);
                uiClaRoom.SetAllBet(response.betNum);
                CacheManager.ClassRoomPlayers[0].betNum += response.betNum;
                CacheManager.gameData.coins -= response.betNum;
                uiClaRoom.UpdateUserCoins(0);
                break;
            case AllInResponse.ERROR_不在比赛中:
                Debug.LogError("不再比赛中");
                break;
            case AllInResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
            case AllInResponse.ERROR_不在可全压人数:
                Debug.LogError("不在可全压人数");
                break;
            default:
                break;
        }
    }

    private void ReceiveOtherAllIn(byte[] data)
    {
        ClassicGamePush_allin response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_allin>(data);
        uiClaRoom.isAllin = true;
        int pos = ToolClass.AbsToRel(response.pos);
        uiClaRoom.SetAllBet(response.betNum);
        List<int> betNums = ToolClass.CoinCconversion0(response.betNum);
        uiClaRoom.ChipAnim(pos, betNums);
        PlayerSimpleData playerSimpleData = CacheManager.ClassRoomPlayers[pos];
        playerSimpleData.betNum += response.betNum;
        playerSimpleData.coins -= response.betNum;

        if (playerSimpleData.roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA1);
        uiClaRoom.PlayerAct(pos, 5);
        uiClaRoom.UpdateUserCoins(pos);
    }

    private void ReceiveWaiStart(byte[]data)
    {
        ClassicGamePush_waiStart response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_waiStart>(data);
        uiClaRoom.SetReadIcon(true);
        if (coroutineClock != null)
        {
            GameCanvas.gameCanvas.StopCoroutine(coroutineClock);
        }
        coroutineClock =  GameCanvas.gameCanvas.StartCoroutine(uiClaRoom.Clock(response.waitPlayerTime));
        CacheManager.classicRoomState = 2;

        foreach (var item in CacheManager.ClassRoomPlayers)
        {
            if (item != null)
                item.betNum = 0;
        }
    }
    private void ReceivePlayerLeave(byte[] data)
    {
        LeaveClassicGameResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LeaveClassicGameResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                CacheManager.KillRoomTV = 2;
                CacheManager.RunRoomId = 0;
                if (CacheManager.classicRoomState == 0)
                {
                    if (CacheManager.gameData.roleId == 0)
                    {
                        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                    }
                    else
                    {
                        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
                    }
                }

                if (coroutineFapai != null)
                    GameCanvas.gameCanvas.StopCoroutine(coroutineFapai);
                uiClaRoom.Hide();
                if (uiReturnPanel != null && uiReturnPanel.isActive())
                {
                    uiReturnPanel.HideNow();
                }
                GetController<ShopBoxCtrl>().Hide2();
                ShowUI<UIMainScene>();
                GetController<MainSceneCtrl>().SendMainSceneEnterKillRoomRequest();
                break;
            case LeaveClassicGameResponse.ERROR_不在游戏中:
                Debug.LogError("不在游戏中");
                break;
            default:
                Debug.LogError("经典场离开游戏发生未知错误 错误代码："+response.code);
                break;
        }
    }

    private void ReceiveOtherLeave(byte[] data)
    {
        ClassicGamePush_playerLeave response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_playerLeave>(data);
        int pos = ToolClass.AbsToRel(response.pos);

        if (uiClaRoom.tablePokerState[pos])
        {
            if (CacheManager.ClassRoomPlayers[pos].roleId == 0)
            {
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
            }
            else
            {
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
            }
        }

        CacheManager.ClassRoomPlayers[pos] = null;
        uiClaRoom.OtherPlayerLeave(pos);
    }

    private void ReceiveChangeTable(byte[] data)
    {
        ChangeTableResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ChangeTableResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                Debug.Log("经典场换桌");
                if (coroutineFapai != null)
                    GameCanvas.gameCanvas.StopCoroutine(coroutineFapai);
                uiClaRoom.Hide2();
                if (CacheManager.classicRoomState == 0)
                {
                    if (CacheManager.gameData.roleId == 0)
                        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                    else
                        BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
                }
                uiReturnPanel.Hide();

                CacheManager.classicRoomState = 2;
                CacheManager.RunRoomId = 1;
                break;
            default:
                break;
        }
    }
    //断线重连
    private void ReceiveReconnect(byte[] data)
    {
        Debug.LogError("经典场断线重连");
        ClassicGamePush_reconnect response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_reconnect>(data);
        if (uiClaRoom != null && uiClaRoom.isActive())
        {
            uiClaRoom.ClearAllPoker();
            uiClaRoom.ClearResults();
            uiClaRoom.ClearReady();
            uiClaRoom.ClearPokerState();
        }

        this.list_poker = response.list_pokers;
        CacheManager.classRoomState = response.state;
        CacheManager.list_pokers = response.list_pokers;
        CacheManager.classicRoundNum = response.roundNum;
        if (response.list_allBet != null)
            CacheManager.list_allBet = response.list_allBet;
        GameCanvas.PlayBGM(R.AudioClip.GAME_BGM);

        CacheManager.classicRoomState = response.state;
        CacheManager.RunRoomId = 1;
        CacheManager.selfPos = response.pos;

        CacheManager.actionPos = ToolClass.AbsToRel(response.actionPos);
        CacheManager.actionTime = response.actionTime;
        for (int i = 0; i < 5; i++)
        {
            CacheManager.ClassRoomPlayers[i] = null;
        }

        for (int i = 0; i < response.list_tablePlayer.Count; i++)
        {
           
            PlayerSimpleData playerSimpleData = response.list_tablePlayer[i];
            Debug.LogError("经典场断线重连" + playerSimpleData.betNum);
            ToolClass.GetHead(playerSimpleData);
            if (playerSimpleData != null)
            {
                playerSimpleData.sprites.Clear();
                int pos = ToolClass.AbsToRel(playerSimpleData.classicGamepos);
                CacheManager.ClassRoomPlayers[pos] = playerSimpleData;
                CacheManager.ClassRoomRoleId[pos] = playerSimpleData.roleId;
                ToolClass.SetRankSprite(playerSimpleData);
            }
        }
        CacheManager.classRoomBankerPos = response.bankerPos;
        GetController<ClassicRoomCtrl>().Show(1);
        CacheManager.classicRoomState = 2;

        GetController<ChatCtrl>().setHideUIMain(false);
        GetController<ShopBoxCtrl>().Show();
    }

    public void CloseBtnLucky()
    {
        if (uiClaRoom != null && uiClaRoom.isActive())
            uiClaRoom.CloseBtnLucky();
    }
}