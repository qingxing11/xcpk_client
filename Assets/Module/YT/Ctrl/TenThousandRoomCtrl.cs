using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Config;
using System.Collections;
using WT.UI;

public class TenThousandRoomCtrl : BaseController, IHandlerReceive
{
    private UIManyPeople uiManyPeople;
    private UIReturnPanelManyPeople uiReturnPanelManyPeople;
    private UITenThousandUpDeskList uITenThousandUpDeskList;
    private UIWin uIWin;
    private UIComparePoker uIComparePoker;
    private UIBackSee uiBackSee;//上局回顾
    private UIHornRecord uiHornRecord;//消息记录面板


    private List<int> list_allChouMaSort;
    private List<BackSeeRoundData> list_backSeeRoundData = new List<BackSeeRoundData>();


    public List<PlayerSimpleData> list_upBankerList = new List<PlayerSimpleData>();

    /// <summary>
    /// 是否弹出返回面板
    /// </summary>
    public bool isReturnPanel;


    bool[] isLookPokers = new bool[5];

    List<PokerVO> list_poker;

    public override void InitAction()
    {
        uiManyPeople = GetUIPage<UIManyPeople>();
        uiManyPeople.ActionChat = OpenChatUI;
        uiManyPeople.ActionHorn = ShowHorn;
        uiManyPeople.ActionShowReturn = ShowReturnUI;
        uiManyPeople.hornRecord = HornRecord;
        uiManyPeople.lottery = ShowUILottery;
        uiManyPeople.hide = HideuiManyPeople;
        uiManyPeople.ActionFriend = ShowUIFriend;
        uiManyPeople.ActionCall = SendManyPepolFollowBetRequest;     //跟注
        uiManyPeople.ActionSee = SendManyPepolRoomCheckPokerRequest; //看牌
        uiManyPeople.ActionRaise = SendManyPepolRoomRaiseBetRequest; //加注
        uiManyPeople.ActionComparer = SendManyPepolRoomComparerPokerRequest; //比牌
        uiManyPeople.ActionFold = SendManyPepolRoomFoldRequest;     //弃牌
        uiManyPeople.ActionAllin = SendManyPepolRoomAllInRequest;   //全压
        uiManyPeople.ActionUpTable = SendManyPepolRoomTableListRequest; //请求上桌列表
        uiManyPeople.ActionCloseTV = SendLeaveManyPepolRoomRequest;
        uiManyPeople.ActionFastBuy = FastBuyOnClick;
        uiManyPeople.ActionBackSee = ShowBackSeeUI;
        uiManyPeople.ActionInfo = ShowInfoUI;
        uiManyPeople.ActionJackPot = SendMprGetJackpotRequest;
        uiManyPeople.ActionMore = ShowMoreUI;
        uiManyPeople.ActionOnClick = UIpageOnClick;

        uITenThousandUpDeskList = GetUIPage<UITenThousandUpDeskList>();
        uITenThousandUpDeskList.requestUpBanker = RequestUpBanker;
        uITenThousandUpDeskList.requestDownBanker = SendManyPepolRoomStandUpRequest;
        InitListChouMaInfo();

        uIWin = GetUIPage<UIWin>();

        uIComparePoker = GetUIPage<UIComparePoker>();

        uiHornRecord = GetUIPage<UIHornRecord>();

        uiReturnPanelManyPeople = GetUIPage<UIReturnPanelManyPeople>();
        uiReturnPanelManyPeople.ActionLeave = SendLeaveManyPepolRoomRequest;
        uiReturnPanelManyPeople.ActionSet = ShowSetUI;
        uiReturnPanelManyPeople.ActionHelp = ShowHelp;

        uiBackSee = GetUIPage<UIBackSee>();
    }

    internal void HideTV()
    {
        if (uiManyPeople != null)
        {
            uiManyPeople.HideTV();
        }
    }

    private void ShowUIFriend()
    {
        GetController<FriendCtrl>().ShowUIFriend();
    }


    /// <summary>
    /// 刷新红点图标
    /// </summary>
    /// <param name="show"></param>
    public void RefreshRedPonit(bool show)
    {
        if (uiManyPeople.isActive())
        {
            uiManyPeople.ShowAddFriendIcon(show);
        }
    }




    private void ShowUILottery()
    {
        GetController<LotteryCtrl>().ShowUILottery();
    }


    private void ShowBackSeeUI()
    {
        if (list_backSeeRoundData != null && list_backSeeRoundData.Count > 0)
        {
            ShowUI<UIBackSee>();
            uiBackSee.Init(list_backSeeRoundData);
        }
    }

    private void ShowMoreUI()
    {
        GetController<MoreCtrl>().Show(3);
    }

    private void ShowInfoUI(int index)
    {
        if (index == 0 && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            GetController<UserInfoCtrl>().ShowSelfInfoUI();
        }
        else
        {
            GetController<UserInfoCtrl>().ShowOtherInfoUI(CacheManager.ManyPeopleRoomPlayers[index]);
        }
    }

    private void ShowJackpotUI(JackpotData jackpotData)
    {
        GetController<JackpotCtrl>().Show(jackpotData, CacheManager.manyPeopleJackpot);
    }

    private void UIpageOnClick()
    {
        GetController<MoreCtrl>().Hide2();
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
    /// 滚动条消息
    /// </summary>
    /// <param name="vo"></param>
    public void ShowTxtTitle(HornInfoVO vo)
    {
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
        if (uiManyPeople.isActive())
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
    private void ShowHelp()
    {
        GetController<HelpCtrl>().ShowHelpClassicUI();
    }
    public void ShowReturnUI(bool isTrue)
    {
        if (isTrue)
        {
            ShowUI<UIReturnPanelManyPeople>();
            uiReturnPanelManyPeople.Init();
        }
        else
        {
            uiReturnPanelManyPeople.Hide();
        }
    }
    //万人场打开音量设置
    private void ShowSetUI()
    {
        GetController<SetCtrl>().ShowSetUI2();
    }

    private Coroutine showComparePoker;
    public void ShowComparerUI(int pos0, int pos1, int lossPos, bool isLook = false, List<PokerVO> pokerVOs = null, int selfPos = 0)
    {
        ShowUI<UIComparePoker>();
        if (showComparePoker != null)
        {
            GameCanvas.gameCanvas.StopCoroutine(showComparePoker);
        }
        showComparePoker = GameCanvas.gameCanvas.StartCoroutine(uIComparePoker.Init(pos0, pos1, lossPos, isLook, pokerVOs, selfPos));
    }
    private void HideuiManyPeople()
    {
        Debug.Log("万人场界面关闭");
        HideHornRecordCom();
        GetController<ChatCtrl>().HideUITenCom();
        GetController<ChatCtrl>().HideUIClassCom();
    }

    private void HideHornRecordCom()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.Hide();
        }
    }

    private void OpenChatUI()
    {
        GetController<ChatCtrl>().ShowUIChat2(2);
    }


    /// <summary>
    /// 打开万人场ui界面
    /// </summary>
    public void ShowTenThousandUI()
    {
        ShowUI<UIManyPeople>();
        if (CacheManager.manyPeopleId == 0)
        {
            GetController<ShopBoxCtrl>().Show();
            uiManyPeople.ChangeRoot(UIType.Normal);
        }
        else
        {
            uiManyPeople.ChangeRoot(UIType.PopUp);
        }
        GetController<ChatCtrl>().ShowUIClassChat();

        GetController<LotteryCtrl>().SendAskTime();
    }

    public void ShowUIWin()
    {
        ShowUI<UIWin>();
    }
    private IEnumerator HideUIWin()
    {
        yield return new WaitForSeconds(3f);
        if (uIWin != null && uIWin.isActive())
        {
            uIWin.Hide();
        }
        yield return null;
    }
    private void InitListChouMaInfo()
    {
        int[] allValue = EnumChouMaType.Values;
        for (int i = 0; i < allValue.Length; i++)
        {
            if (list_allChouMaSort == null)
            {
                list_allChouMaSort = new List<int>();
            }
            list_allChouMaSort.Add(allValue[i]);
        }
        list_allChouMaSort.Sort();
        list_allChouMaSort.Reverse();
    }

    #region  请求消息发送

    /// <summary>
    /// 全押请求
    /// </summary>
    private void SendManyPepolRoomAllInRequest()
    {
        ManyPepolRoomAllInRequest request = new ManyPepolRoomAllInRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 弃牌请求
    /// </summary>
    private void SendManyPepolRoomFoldRequest()
    {
        ManyPepolRoomFoldRequest request = new ManyPepolRoomFoldRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 比牌请求  *************** 比牌对方的pos怎么设置？？？？？？？
    /// </summary>
    /// <param name="pos"></param>
    private void SendManyPepolRoomComparerPokerRequest(int pos)
    {
        ManyPepolRoomComparerPokerRequest request = new ManyPepolRoomComparerPokerRequest();
        request.pos = ToolClass.RelToAbsThous(pos);
        SendMessage(request);
    }

    internal void RefreshCoin()
    {
        if (uiManyPeople != null && uiManyPeople.isActive())
            uiManyPeople.RefSelfConis();
    }

    internal void RefreshPosCoin(int pos)
    {
        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.RefPosCoins(pos);
        }
    }



    /// <summary>
    /// 跟注请求
    /// </summary>
    private void SendManyPepolFollowBetRequest()
    {
        ManyPepolFollowBetRequest request = new ManyPepolFollowBetRequest();
        SendMessage(request);
    }


    /// <summary>
    /// 加注请求
    /// </summary>
    /// <param name="obj"></param>
    private void SendManyPepolRoomRaiseBetRequest(int betNum)
    {
        ManyPepolRoomRaiseBetRequest request = new ManyPepolRoomRaiseBetRequest();
        request.betNum = betNum;
        SendMessage(request);
    }

    /// <summary>
    /// 看牌请求
    /// </summary>
    private void SendManyPepolRoomCheckPokerRequest()
    {
        ManyPepolRoomCheckPokerRequest request = new ManyPepolRoomCheckPokerRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 请求上桌列表  收到消息后 打开上桌列表界面 刷新数据
    /// </summary>
    private void SendManyPepolRoomTableListRequest()
    {
        ManyPepolRoomTableListRequest request = new ManyPepolRoomTableListRequest();
        SendMessage(request);
    }

    private void ShowTenThousandUpDeskListUI()
    {
        ShowUI<UITenThousandUpDeskList>();
        uITenThousandUpDeskList.SetPlayerListInfo();
    }
    /// <summary>
    /// 请求下桌
    /// </summary>
    private void SendManyPepolRoomStandUpRequest()
    {
        ManyPepolRoomStandUpRequest request = new ManyPepolRoomStandUpRequest();
        SendMessage(request);
    }

    private void SendLeaveManyPepolRoomRequest(bool isTV)
    {
        bool inTable = false;
        foreach (PlayerSimpleData item in CacheManager.ManyPeopleRoomPlayers)
        {
            if (item != null && item.userId == CacheManager.gameData.userId)
            {
                inTable = true;
                break;
            }
        }
        if (inTable)
        {
            GetController<MessageCtrl>().Show("坐下时不能离开,请先站起");
            return;
        }

        bool inUpList = false;
        if (list_upBankerList != null)
        {
            foreach (var item in list_upBankerList)
            {
                if (item.userId == CacheManager.gameData.userId)
                {
                    inUpList = true;
                    break;
                }
            }
            if (inUpList)
            {
                GetController<MessageCtrl>().Show("在上庄列表中不能离开游戏,请先申请下庄！");
                return;
            }
        }

        LeaveManyPepolRoomRequest request = new LeaveManyPepolRoomRequest();
        request.isTV = isTV;
        SendMessage(request);
    }

    /// <summary>
    /// 请求上桌
    /// </summary>
    private void RequestUpBanker()
    {
        ManyPepolRoomSitdownRequest request = new ManyPepolRoomSitdownRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 发送请求进入万人场信息
    /// </summary>
    public void SendEnterManyPeopleRoom()
    {
        EnterManyPepolRoomRequest request = new EnterManyPepolRoomRequest();
        SendMessage(request);
    }

    public void SendMprGetJackpotRequest()
    {
        MprGetJackpotRequest request = new MprGetJackpotRequest();
        SendMessage(request);
    }
    #endregion

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            //Debug.Log("万人场response.msgType=" + response.msgType);
            switch (response.msgType)
            {
                case MsgType.manypepol_发牌:
                    ReceiveDealPoker(response.data);
                    break;
                case MsgType.manypepol_有玩家上桌:
                    SetUpDeskPlayerInfo(response.data);
                    break;
                case MsgType.manypepol_申请上桌:
                    SetPlayerUpDeskIngo(response.data);
                    break;
                case MsgType.manypepol_玩家进入:
                    SetPlayerEnterTenThousandRoom(response.data);
                    break;
                case MsgType.manypepol_玩家行动:
                    ReceivePlayerAction(response.data);
                    break;
                case MsgType.manypepol_有玩家弃牌:
                    SetOtherPlayerQiPaiInfo(response.data);
                    break;
                case MsgType.manypepol_玩家看牌:
                    SetSelfPlayerLookPaiInfo(response.data);
                    break;
                case MsgType.manypepol_有玩家看牌:
                    SetOtherPlayerLookPaiInfo(response.data);
                    break;
                case MsgType.manypepol_玩家跟注:
                    SetSelfGenZhuInfo(response.data);
                    break;
                case MsgType.manypepol_其他玩家跟注:
                    SetOtherPlayerGenZhuInfo(response.data);
                    break;
                case MsgType.manypepol_玩家加注:
                    ReceiveManyPepolRoomRaiseBet(response.data);
                    break;
                case MsgType.manypepol_其他玩家加注:
                    SetOtherPlayerAddZhuInfo(response.data);
                    break;
                case MsgType.manypepol_闲家下注:
                    SetXianJiaXiaZhuInfo(response.data);
                    break;
                case MsgType.manypepol_有闲家下注:
                    SetOtherXianJiaPlayerXiaZhuInfo(response.data);
                    break;
                case MsgType.manypepol_上桌列表:
                    SetUpDeskListInfo(response.data);
                    break;
                case MsgType.manypepol_其他玩家比牌:
                    SetBiPaiPushInfo(response.data);
                    break;
                case MsgType.manypepol_玩家比牌:
                    SetSelfBiPaiInfo(response.data);
                    break;
                case MsgType.manypepol_玩家弃牌:
                    SetPlayerQiPaiInfo(response.data);
                    break;
                case MsgType.manypepol_玩家全压:
                    ReceiveManyPepolRoomAllIn(response.data);
                    break;
                case MsgType.manypepol_申请下桌:
                    SetPlayerDownDeskInfo(response.data);
                    break;
                case MsgType.manypepol_玩家下桌:
                    SetOtherPlayerDownDeskInfo(response.data);
                    break;
                case MsgType.manypepol_其他玩家全压:
                    ReceiveManyPeopleAllin(response.data);
                    break;
                case MsgType.manypepol_开始下注:
                    SetPlayerCanStartXiaZhu(response.data);
                    break;
                case MsgType.manypepol_玩家胜利:
                    SetPlayerWinInfo(response.data);
                    break;
                case MsgType.manypepol_开始下注_等待比赛开始:
                    SetPlayerWaintGameBegin(response.data);
                    break;
                case MsgType.manypepol_玩家离开:
                    ReceiveLeaveManyPepolRoom(response.data);
                    break;
                case MsgType.manypepol_断线重连:
                    ReceiveReconnect(response.data);
                    break;
                case MsgType.manypepol_获取奖池:
                    ReceiveMprGetJackpotResponse(response.data);
                    break;
                case MsgType.manypepol_其他玩家上庄:
                    ReceiveOtherPlayerApplicationBanker(response.data);
                    break;
                case MsgType.manypepol_其他玩家下庄:
                    ReceiveOtherPlayerResignBanker(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

    private void SetPlayerWaintGameBegin(byte[] data)
    {
        ManyPepolPush_waiStart response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_waiStart>(data);
        foreach (var item in CacheManager.ManyPeopleRoomPlayers)
        {
            if (item != null)
                item.betNum = 0;
        }
        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.SetCallAllBtnStateFalse();
        }
    }

    public void SetManyPeoleIcon(GameRoundDataVO gameRoundDataVO)
    {
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            if (CacheManager.ManyPeopleRoomPlayers[i] != null && CacheManager.ManyPeopleRoomPlayers[i].userId == gameRoundDataVO.userId)
            {
                gameRoundDataVO.headIcon = CacheManager.ManyPeopleRoomPlayers[i].headIcon;
            }
        }
    }

    /// <summary>
    /// 玩家胜利
    /// </summary>
    /// <param name="data"></param>
    private void SetPlayerWinInfo(byte[] data)
    {
        ManyPepolPush_playerWin response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerWin>(data);
        CacheManager.manyPeopleJackpot = response.jackpotNum;
        if (uiManyPeople == null || !uiManyPeople.isActive())
        {
            return;
        }
        CacheManager.stateManypeople = 0;
        uiManyPeople.UpdateJackPot();
        uiManyPeople.HideAddCoins();

        if (response.list_roundData != null)
        {
            foreach (GameRoundDataVO gameRoundDataVO in response.list_roundData)
            {
                if (gameRoundDataVO != null)
                    SetManyPeoleIcon(gameRoundDataVO);
            }
        }

        GameCanvas.gameCanvas.StartCoroutine(DelayShowWinUI(response.list_roundData));
        uiManyPeople.SetStateText("等待比赛开始，比拼预热中~");
        int pos = 0;
        list_backSeeRoundData.Clear();
        for (int i = 0; i < response.list_roundData.Count; i++)
        {
            GameRoundDataVO gameRoundDataVO = response.list_roundData[i];
            BackSeeRoundData backSeeRoundData = new BackSeeRoundData();
            pos = ToolClass.AbsToRelThous(gameRoundDataVO.pos);
            backSeeRoundData.icon = CacheManager.ManyPeopleRoomPlayers[pos].headIcon;
            backSeeRoundData.roundBet = gameRoundDataVO.roundBet;
            backSeeRoundData.list_handPoker = gameRoundDataVO.list_handPoker;
            backSeeRoundData.pokerType = gameRoundDataVO.pokerType;
            backSeeRoundData.nickName = CacheManager.ManyPeopleRoomPlayers[pos].nickName;
            list_backSeeRoundData.Add(backSeeRoundData);

            if (CacheManager.ManyPeopleRoomPlayers[pos].userId == CacheManager.gameData.userId)
            {
                CacheManager.gameData.coins = gameRoundDataVO.newCoins;
                if (gameRoundDataVO.jackpotWin > 0)
                {
                    GetController<TaskCtrl>().ShowUIWinShow(gameRoundDataVO.jackpotWin);
                }
            }


            CacheManager.ManyPeopleRoomPlayers[pos].coins = gameRoundDataVO.newCoins;
            uiManyPeople.UpdateUserCoins(pos);
            if (backSeeRoundData.roundBet > 0)
                uiManyPeople.PlayWinAnim(pos);
            uiManyPeople.SetPokerType(pos, gameRoundDataVO.pokerType);
        }
        uiManyPeople.SetBtn(false);
        uiManyPeople.StopPlayerActionTimer();
        BaseCanvas.PlaySound(R.AudioClip.SOUND_JINBI);
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            if (CacheManager.ManyPeopleRoomPlayers[i] != null)
                CacheManager.ManyPeopleRoomPlayers[i].gameState = 0;
        }
        GameCanvas.gameCanvas.StartCoroutine(ClearPokers(pos, response.list_roundData));
    }
    private IEnumerator ClearPokers(int pos, List<GameRoundDataVO> list_roundData)
    {
        for (int i = 0; i < list_roundData.Count; i++)
        {
            GameRoundDataVO gameRoundDataVO = list_roundData[i];
            int pos2 = ToolClass.AbsToRelThous(gameRoundDataVO.pos);
            uiManyPeople.SetResults(pos2, gameRoundDataVO.roundBet);
            if (gameRoundDataVO.list_handPoker != null)
            {
                uiManyPeople.SetPoker(gameRoundDataVO.list_handPoker, pos2);
            }
        }
        yield return new WaitForSeconds(1f);
        uiManyPeople.ChipAnim2(pos);
        yield return new WaitForSeconds(1f);
        uiManyPeople.PlayResults();

    }

    public void ShowLotteryNum(int num)
    {
        if (uiManyPeople.isActive())
        {
            uiManyPeople.ShowCurBuyLotteryNum(num);
        }
    }

    public void ShowLotteryTime(int time)
    {
        if (uiManyPeople.isActive())
        {
            uiManyPeople.ShowLotteryTime(time);
        }
    }
    public void ShowLotteryWin(bool play)
    {
        if (uiManyPeople.isActive())
        {
            uiManyPeople.LotteryWinPlay(play);
        }
    }

    private IEnumerator DelayShowWinUI(List<GameRoundDataVO> list_roundData)
    {
        yield return new WaitForSeconds(5f);
        ShowUIWin();
        uIWin.SetPlayerWinOrLossInfo(list_roundData);
        GameCanvas.gameCanvas.StopCoroutine(DelayShowWinUI(list_roundData));
        GameCanvas.gameCanvas.StartCoroutine(HideUIWin());
    }
    #region 闲家开始下注
    private void SetPlayerCanStartXiaZhu(byte[] data)
    {
        ManyPepolPush_waiPayBet response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_waiPayBet>(data);
        GameCanvas.gameCanvas.StartCoroutine(uiManyPeople.Clock(5));
    }
    #endregion

    #region 下桌

    /// <summary>
    /// 有玩家下桌
    /// </summary>
    /// <param name="data"></param>
    private void SetOtherPlayerDownDeskInfo(byte[] data)
    {
        ManyPepolPush_playerStandUp response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerStandUp>(data);
        Debug.Log("万人场其他玩家站起:" + response);
        int pos = ToolClass.AbsToRelThous(response.pos);
        if (pos == 0 && CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId) //自己下桌
        {
            Debug.Log("万人场其他玩家站起,自己下桌");
            uiManyPeople.SetPlayerDownDesk(true);
            uiManyPeople.HideBtn(false);
            uiManyPeople.setSelfLevelTable(true);

            GetController<MessageCtrl>().HideTipesUI();
        }
        CacheManager.ManyPeopleRoomPlayers[pos] = null;
        uiManyPeople.OtherPlayerLeave(pos);
    }

    /// <summary>
    /// 申请下桌
    /// </summary>
    /// <param name="data"></param>
    private void SetPlayerDownDeskInfo(byte[] data)
    {
        ManyPepolRoomStandUpResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomStandUpResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomStandUpResponse.SUCCESS:
                GetController<MessageCtrl>().Show("申请下桌成功，等待本局结束下桌");
                break;
            case ManyPepolRoomStandUpResponse.ERROR_还未坐下:
                Debug.LogError("还未坐下");
                break;
            case ManyPepolRoomStandUpResponse.ERROR_不在游戏中:
                Debug.LogError("不在游戏中");
                break;
            default:
                Debug.LogError("申请下桌未知错误");
                break;
        }
    }

    #endregion


    #region  全押

    private void ReceiveManyPeopleAllin(byte[] data)
    {
        ManyPepolPush_allin response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_allin>(data);
        int pos = ToolClass.AbsToRelThous(response.pos);

        if (CacheManager.ManyPeopleRoomPlayers[pos] != null && CacheManager.ManyPeopleRoomPlayers[pos].roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA1);

        List<int> betNums = ToolClass.CoinCconversionManyPeople(response.betNum);
        uiManyPeople.ChipAnim(pos, betNums);
        uiManyPeople.SetAllBet(response.betNum);
        CacheManager.ManyPeopleRoomPlayers[pos].betNum += response.betNum;
        CacheManager.ManyPeopleRoomPlayers[pos].coins -= response.betNum;
        uiManyPeople.UpdateUserCoins(pos);
    }

    /// <summary>
    /// 玩家全压
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveManyPepolRoomAllIn(byte[] data)
    {
        ManyPepolRoomAllInResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomAllInResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomAllInResponse.SUCCESS:
                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QUANYA1);

                List<int> betNums = ToolClass.CoinCconversionManyPeople(response.betNum);
                uiManyPeople.ChipAnim(0, betNums);
                uiManyPeople.SetAllBet(response.betNum);
                CacheManager.ManyPeopleRoomPlayers[0].betNum += response.betNum;
                CacheManager.gameData.coins -= response.betNum;
                CacheManager.ManyPeopleRoomPlayers[0].coins -= response.betNum;
                uiManyPeople.UpdateUserCoins(0);
                break;
            case ManyPepolRoomAllInResponse.ERROR_不在比赛中:
                break;
            case ManyPepolRoomAllInResponse.ERROR_没轮到行动:
                break;
            case ManyPepolRoomAllInResponse.ERROR_不在可全压人数:
                break;
        }
    }

    #endregion

    #region 加注

    /// <summary>
    /// 其他玩家加注
    /// </summary>
    /// <param name="data"></param>
    private void SetOtherPlayerAddZhuInfo(byte[] data)
    {
        ManyPepolPush_playerRaiseBet response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerRaiseBet>(data);
        int pos = ToolClass.AbsToRelThous(response.pos);

        if (CacheManager.ManyPeopleRoomPlayers[pos].roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU1);
        List<int> allBet;
        if (isLookPokers[pos])
        {
            allBet = ToolClass.CoinCconversionManyPeople(response.betNum / 2);
            uiManyPeople.ChipAnim(pos, allBet);
            uiManyPeople.ChipAnim(pos, allBet);
            uiManyPeople.SetOneBet(response.betNum / 2);
        }
        else
        {
            allBet = ToolClass.CoinCconversionManyPeople(response.betNum);
            uiManyPeople.ChipAnim(pos, allBet);
            uiManyPeople.SetOneBet(response.betNum);
        }

        uiManyPeople.SetAllBet(response.betNum);
        CacheManager.ManyPeopleRoomPlayers[pos].coins -= response.betNum;
        CacheManager.ManyPeopleRoomPlayers[pos].betNum += response.betNum;
        uiManyPeople.UpdateUserCoins(pos);
    }

    #endregion 


    #region 跟注
    private void SetOtherPlayerGenZhuInfo(byte[] data)
    {
        ManyPepolPush_playerFollow response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerFollow>(data);
        int pos = ToolClass.AbsToRelThous(response.pos);
        if (CacheManager.ManyPeopleRoomPlayers[pos].roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN1);

        List<int> allBet;
        if (isLookPokers[pos])
        {
            allBet = ToolClass.CoinCconversionManyPeople(response.betNum / 2);
            uiManyPeople.ChipAnim(pos, allBet);
            uiManyPeople.ChipAnim(pos, allBet);
        }
        else
        {
            allBet = ToolClass.CoinCconversionManyPeople(response.betNum);
            uiManyPeople.ChipAnim(pos, allBet);
        }
        CacheManager.ManyPeopleRoomPlayers[pos].coins -= response.betNum;
        CacheManager.ManyPeopleRoomPlayers[pos].betNum += response.betNum;
        uiManyPeople.UpdateUserCoins(pos);
        uiManyPeople.SetAllBet(response.betNum);
    }

    private void SetSelfGenZhuInfo(byte[] data)
    {
        ManyPepolFollowBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolFollowBetResponse>(data);
        switch (response.code)
        {
            case ManyPepolFollowBetResponse.SUCCESS:
                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_GEN1);

                List<int> betNums;

                if (isLookPokers[0])
                {
                    betNums = ToolClass.CoinCconversionManyPeople(response.betNum / 2);
                    uiManyPeople.ChipAnim(0, betNums);
                    uiManyPeople.ChipAnim(0, betNums);
                }
                else
                {
                    betNums = ToolClass.CoinCconversionManyPeople(response.betNum);
                    uiManyPeople.ChipAnim(0, betNums);
                }
                CacheManager.ManyPeopleRoomPlayers[0].betNum += response.betNum;
                CacheManager.gameData.coins -= response.betNum;
                CacheManager.ManyPeopleRoomPlayers[0].coins -= response.betNum;
                uiManyPeople.SetAllBet(response.betNum);


                uiManyPeople.UpdateUserCoins(0);
                break;
            case ManyPepolFollowBetResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            case ManyPepolFollowBetResponse.ERROR_不在比赛中:
                Debug.LogError("不在比赛中");
                break;
            case ManyPepolFollowBetResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
        }
    }
    #endregion

    #region  看牌
    private void SetOtherPlayerLookPaiInfo(byte[] data)
    {
        ManyPepolPush_checkPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_checkPoker>(data);
        int pos = ToolClass.AbsToRelThous(response.pos);
        isLookPokers[pos] = true;
        PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[pos];
        if (playerSimpleData != null)
        {
            playerSimpleData.isCheckPoker = true;
            if (playerSimpleData.roleId == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI0);
            else
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI1);
        }
        uiManyPeople.OtherCheckPoker(pos);
    }

    private void SetSelfPlayerLookPaiInfo(byte[] data)
    {
        ManyPepolRoomCheckPokerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomCheckPokerResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomCheckPokerResponse.SUCCESS:
                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_KANPAI1);
                isLookPokers[0] = true;
                uiManyPeople.SelfCheckPoker(response.list_poker, response.pokerType);//万人场玩家看牌显示牌型
                this.list_poker = response.list_poker;
                break;
            default:
                break;
        }

    }
    #endregion


    #region  比牌消息处理
    private Coroutine comparePoker0, comparePoker1;
    /// <summary>
    /// 比牌推送 包括玩家自己
    /// </summary>
    /// <param name="data"></param>
    private void SetBiPaiPushInfo(byte[] data)
    {
        ManyPepolPush_comparerPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_comparerPoker>(data);
        Debug.Log("其他玩家比牌");
        int pos0 = ToolClass.AbsToRelThous(response.pos0);
        int pos1 = ToolClass.AbsToRelThous(response.pos1);
        int lossPos = ToolClass.AbsToRelThous(response.lossPos);
        uiManyPeople.roomPeople--;
        List<int> betNums = ToolClass.CoinCconversionManyPeople(response.subCoins);


        if (CacheManager.ManyPeopleRoomPlayers[pos0].userId == CacheManager.gameData.userId && pos0 == 0)
        {
            CacheManager.gameData.coins -= response.subCoins;

        }
        uiManyPeople.ChipAnim(pos0, betNums);

        CacheManager.ManyPeopleRoomPlayers[pos0].coins -= response.subCoins;
        CacheManager.ManyPeopleRoomPlayers[pos0].betNum += response.subCoins;
        uiManyPeople.UpdateUserCoins(pos0);




        uiManyPeople.PlayerAct(pos0, 6);
        uiManyPeople.StopPlayerActionTimer();

        if (isLookPokers[0] && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
        {
            if (pos0 == 0)
                ShowComparerUI(pos0, pos1, lossPos, true, list_poker, pos0);
            else if (pos1 == 0)
                ShowComparerUI(pos0, pos1, lossPos, true, list_poker, pos1);
        }
        else
        {
            ShowComparerUI(pos0, pos1, lossPos);
        }

        if (!uiManyPeople.isAllin)
        {
            if (CacheManager.ManyPeopleRoomPlayers[pos0].roleId == 0)
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAI0);
            else
                BaseCanvas.PlaySound(R.AudioClip.CLASSIC_BIPAI1);
        }
        if (comparePoker0 != null)
        {
            GameCanvas.gameCanvas.StopCoroutine(comparePoker0);
        }
        if (comparePoker1 != null)
        {
            GameCanvas.gameCanvas.StopCoroutine(comparePoker1);

        }
        comparePoker0 = GameCanvas.gameCanvas.StartCoroutine(uiManyPeople.PlayComparerPokerAnim(pos0, pos1));
        comparePoker1 = GameCanvas.gameCanvas.StartCoroutine(CloseUIComparerPoker(lossPos));
        if (lossPos == 0)
        {
            uiManyPeople.SetBtn(false);
        }
    }


    private IEnumerator CloseUIComparerPoker(int lossPos)
    {
        yield return new WaitForSeconds(2f);
        uiManyPeople.PokerLoser(lossPos);
        yield return null;
    }
    /// <summary>
    /// 玩家自己主动比牌 等待推送
    /// </summary>
    /// <param name="data"></param>
    private void SetSelfBiPaiInfo(byte[] data)
    {
        ManyPepolRoomComparerPokerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomComparerPokerResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomComparerPokerResponse.SUCCESS:

                break;
            case ManyPepolRoomComparerPokerResponse.ERROR_不在比赛中:
                break;
            case ManyPepolRoomComparerPokerResponse.ERROR_没轮到行动:
                break;
            case ManyPepolRoomComparerPokerResponse.ERROR_比牌错误:
                break;
            default:
                break;
        }
    }
    #endregion


    #region  弃牌逻辑处理
    private void SetPlayerQiPaiInfo(byte[] data)
    {
        ManyPepolRoomFoldResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomFoldResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomFoldResponse.SUCCESS:
                if (CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
                    GetController<MessageCtrl>().ShowTips();
                uiManyPeople.Fold();
                uiManyPeople.SetBtn(false);
                uiManyPeople.HideBtn(false);

                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
                else
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);

                break;
            case ManyPepolRoomFoldResponse.ERROR_不在比赛中:
                break;
        }
    }
    private void SetOtherPlayerQiPaiInfo(byte[] data)
    {

        ManyPepolPush_playerDie response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerDie>(data);

        if (response.pos == -1)
            return;

        int pos = ToolClass.AbsToRelThous(response.pos);

        uiManyPeople.PlayerAct(pos, 2);

        uiManyPeople.OtherDealPoker(pos);

        Debug.Log("弃牌者:" + response.pos + "，万人当前活动位置:" + CacheManager.manyPeopleActionPos + ",nickName:" + CacheManager.ManyPeopleRoomPlayers[CacheManager.manyPeopleActionPos].nickName + ",自己位置:" + CacheManager.ManyPeopleRoomPlayers[CacheManager.selfPosThous]);
        if (CacheManager.manyPeopleActionPos == response.pos) //活动人是弃牌人，关闭玩家倒计时转圈
        {
            Debug.Log("自己pos:" + CacheManager.selfPosThous + ",弃牌者:" + response.pos);
            uiManyPeople.StopPlayerActionTimer();

        }

        //弃牌人是自己，改变按钮
        if (response.pos == CacheManager.selfPosThous)
        {
            Debug.Log("万人场自己弃牌 ：" + response.pos);
            uiManyPeople.Fold();
        }

        PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[pos];
        //播放弃牌音效
        if (playerSimpleData == null)
            return;
        playerSimpleData.gameState = 2;
        if (playerSimpleData.roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_QIPAI1);
    }


    #endregion


    #region   闲家下注消息处理
    private void SetOtherXianJiaPlayerXiaZhuInfo(byte[] data)
    {
        ManyPepolPush_payBet response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_payBet>(data);
    }

    /// <summary>
    /// 闲家请求下注消息回应处理
    /// </summary>
    /// <param name="data"></param>
    private void SetXianJiaXiaZhuInfo(byte[] data)
    {
        ManyPepolRoomPayBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomPayBetResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomPayBetResponse.SUCCESS:
                break;
            case ManyPepolRoomPayBetResponse.ERROR_金币不足:
                break;
            case ManyPepolRoomPayBetResponse.ERROR_不在下注时间:
                break;
            case ManyPepolRoomPayBetResponse.ERROR_下注位置错误:
                break;
            case ManyPepolRoomPayBetResponse.ERROR_不在比赛中:
                break;
            default:
                break;
        }
    }

    #endregion


    #region 上桌列表信息
    /// <summary>
    /// 上桌列表消息处理
    /// </summary>
    /// <param name="data"></param>
    private void SetUpDeskListInfo(byte[] data)
    {
        ManyPepolRoomTableListResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomTableListResponse>(data);
        Debug.Log("万人场上座列表");
        switch (response.code)
        {
            case ManyPepolRoomTableListResponse.SUCCESS:
                list_upBankerList = response.list_players;
                if (response.list_players != null)
                {
                    list_upBankerList = response.list_players;
                }
                ShowTenThousandUpDeskListUI();


                break;
            case ManyPepolRoomTableListResponse.ERROR_不在比赛中:
                break;
            default:
                break;
        }
    }
    #endregion


    #region  玩家行动
    private void ReceivePlayerAction(byte[] data)
    {
        ManyPepolPush_playerAction response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerAction>(data);
        int pos = ToolClass.AbsToRelThous(response.pos);
        uiManyPeople.PlayerAction(pos, response.nowBet, response.isCheckPoker, response.round, response.allinState);

        uiManyPeople.PlayPlayerActionTimer(pos, 0);
    }

    #endregion

    Coroutine fapaiCoroutine;
    /// <summary>
    /// 处理发牌信息
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveDealPoker(byte[] data)
    {
        ManyPepolPush_dealPoker response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_dealPoker>(data);
        CacheManager.manyPeopleActionPos = response.playPos;
        if (CacheManager.gameData.roleId == 0)
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_FAPAI0);
        else
            BaseCanvas.PlaySound(R.AudioClip.CLASSIC_FAPAI1);
        for (int i = 0; i < isLookPokers.Length; i++)
        {
            isLookPokers[i] = false;
        }
        uiManyPeople.StartChipAnim(response.betNum);
        for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
        {
            PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[i];
            if (playerSimpleData != null)
            {
                CacheManager.ManyPeopleRoomPlayers[i].betNum += response.betNum;
                playerSimpleData.coins -= response.betNum;
                if (playerSimpleData.userId == CacheManager.gameData.userId)
                    CacheManager.gameData.coins -= response.betNum;
                uiManyPeople.UpdateUserCoins(i);
                uiManyPeople.SetAllBet(response.betNum);
                //设置该玩家得状态为普通
                playerSimpleData.gameState = 1;
            }
        }
        uiManyPeople.SetStateText("正在火热比拼中~");
        GetController<MessageCtrl>().HideTipesUI();
        List<int> listAllYazhu = ToolClass.CoinCconversionManyPeople(response.betNum);
        int bankerPos = ToolClass.AbsToRelThous(response.bankerPos);
        fapaiCoroutine = GameCanvas.gameCanvas.StartCoroutine(uiManyPeople.DealPokerAnim(bankerPos));
        CacheManager.stateManypeople = 3;
    }

    #region  处理上桌等信息


    /// <summary>
    /// 成功上桌的人的信息
    /// </summary>
    /// <param name="data"></param>
    private void SetUpDeskPlayerInfo(byte[] data)
    {
        ManyPepolPush_playerSitdown response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_playerSitdown>(data);
        if (response.playerSimpleData.userId == CacheManager.gameData.userId) //上桌的是自己
        {
            CacheManager.selfPosThous = response.playerSimpleData.manyGamepos;

            CacheManager.manyPeopleActionPos = ToolClass.AbsToRelThous(CacheManager.manyPeopleActionPos);

            if (fapaiCoroutine != null)
                GameCanvas.gameCanvas.StopCoroutine(fapaiCoroutine);

            uiManyPeople.HideBtn(true);
            uiManyPeople.StopPlayerActionTimer();
            List<PlayerSimpleData> playerSimpleDatas = new List<PlayerSimpleData>();
            for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
            {
                if (CacheManager.ManyPeopleRoomPlayers[i] != null)
                {
                    playerSimpleDatas.Add(CacheManager.ManyPeopleRoomPlayers[i]);
                    CacheManager.ManyPeopleRoomPlayers[i] = null;
                }
            }
            playerSimpleDatas.Add(response.playerSimpleData);

            response.playerSimpleData.gameState = 0;
            for (int i = 0; i < playerSimpleDatas.Count; i++)
            {
                PlayerSimpleData playerSimpleData = playerSimpleDatas[i];

                CacheManager.ManyPeopleRoomPlayers[ToolClass.AbsToRelThous(playerSimpleData.manyGamepos)] = playerSimpleData;
                ToolClass.SetRankSprite(playerSimpleData);
                ToolClass.GetHead(playerSimpleData);
            }

            uiManyPeople.SetPlayerDownDesk(false);
            uiManyPeople.RefPosData();
            uiManyPeople.setSelfLevelTable(false);
            GetController<MessageCtrl>().ShowTips();
            uiManyPeople.StopPlayerActionTimer();
            if (CacheManager.stateManypeople == 2 || CacheManager.stateManypeople == 3)
            {
                uiManyPeople.PlayPlayerActionTimer(CacheManager.manyPeopleActionPos, CacheManager.manyPeopleActionTime);
            }
            uiManyPeople.RefSetPoker();

        }
        for (int i = 0; list_upBankerList != null && i < list_upBankerList.Count; i++)
        {
            if (response.playerSimpleData.userId == list_upBankerList[i].userId)
            {
                list_upBankerList.RemoveAt(i);
                if (uITenThousandUpDeskList != null)
                {
                    uITenThousandUpDeskList.SetPlayerListInfo();
                }
                break;
            }
        }

        int pos = ToolClass.AbsToRelThous(response.playerSimpleData.manyGamepos);

        CacheManager.ManyPeopleRoomPlayers[pos] = response.playerSimpleData;
        ToolClass.SetRankSprite(response.playerSimpleData);
        ToolClass.GetHead(response.playerSimpleData);
        uiManyPeople.SetPosData(pos);
    }


    /// <summary>
    /// 申请上桌的消息回应
    /// </summary>
    /// <param name="data"></param>
    private void SetPlayerUpDeskIngo(byte[] data)
    {
        ManyPepolRoomSitdownResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomSitdownResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomSitdownResponse.SUCCESS:
                GetController<MessageCtrl>().Show("申请上桌成功");
                break;
            case ManyPepolRoomSitdownResponse.ERROR_金币不足:
                break;
            case ManyPepolRoomSitdownResponse.ERROR_已经坐下:
                break;
            case ManyPepolRoomSitdownResponse.ERROR_列表满:
                break;
            case ManyPepolRoomSitdownResponse.ERROR_已在列表:
                break;
        }
    }
    /// <summary>
    /// 处理进入万人场的信息
    /// </summary>
    /// <param name="data"></param>
    private void SetPlayerEnterTenThousandRoom(byte[] data)
    {
        EnterManyPepolRoomResponse response = MySerializerUtil.DeSerializerFromProtobufNet<EnterManyPepolRoomResponse>(data);
        switch (response.code)
        {
            case EnterManyPepolRoomResponse.SUCCESS:
                if (CacheManager.manyPeopleId != 1)//正常打开万人场
                {
                    CacheManager.LeaveKillRoom();
                    GetController<RoomCtrl>().HideOn();
                    GetController<RoomCtrl>().ClearAllCoins();
                    GetController<MainSceneCtrl>().HideMainMenu();
                }
                if (response.list_tablePlayer != null)
                {
                    foreach (PlayerSimpleData item in response.list_tablePlayer)
                    {
                        if (item != null)
                        {
                            int pos = ToolClass.AbsToRelThous(item.manyGamepos);


                            CacheManager.ManyPeopleRoomPlayers[pos] = item;
                            ToolClass.GetHead(item);
                        }
                    }
                }
                CacheManager.bankerPos = response.bankerPos;
                CacheManager.stateManypeople = response.state;
                CacheManager.manyPeopleActionTime = response.waitStartTime;
                CacheManager.manyPeopleJackpot = response.jackpotNum;

                CacheManager.list_allBetManyPeople = response.list_allBet;

                BaseCanvas.PlayBGM(R.AudioClip.GAME_BGM);

                ShowTenThousandUI();

                break;
            default:
                break;
        }

    }

    /// <summary>
    /// 离开万人场
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveLeaveManyPepolRoom(byte[] data)
    {
        LeaveManyPepolRoomResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LeaveManyPepolRoomResponse>(data);
        switch (response.code)
        {
            case LeaveManyPepolRoomResponse.SUCCESS:
                Debug.Log("离开万人场成功");
                uiManyPeople.Hide();

                CacheManager.RunRoomId = 0;
                if (CacheManager.manyPeopleId == 0)//正常打开万人场
                {
                    uiReturnPanelManyPeople.HideNow();
                    CacheManager.KillRoomTV = 2;
                    BaseCanvas.GetController<MainSceneCtrl>().CloseSelectRoom();
                    ShowUI<UIMainScene>();
                    BaseCanvas.GetController<MainSceneCtrl>().SendMainSceneEnterKillRoomRequest();
                }
                break;
            case LeaveManyPepolRoomResponse.ERROR_不在游戏中:
                Debug.LogError("不在游戏中");
                GetController<MessageCtrl>().Show("不在游戏中");
                break;
            case LeaveManyPepolRoomResponse.ERROR_坐下时不能离开:
                GetController<MessageCtrl>().Show("坐下时不能离开");
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 自己加注
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveManyPepolRoomRaiseBet(byte[] data)
    {
        ManyPepolRoomRaiseBetResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolRoomRaiseBetResponse>(data);
        switch (response.code)
        {
            case ManyPepolRoomRaiseBetResponse.SUCCESS:
                int betNum = response.betNum;
                List<int> betNums;

                if (isLookPokers[0])
                {
                    betNum /= 2;
                    betNums = ToolClass.CoinCconversionManyPeople(response.betNum / 2);
                    uiManyPeople.ChipAnim(0, betNums);
                    uiManyPeople.ChipAnim(0, betNums);
                }
                else
                {
                    betNums = ToolClass.CoinCconversionManyPeople(response.betNum);
                    uiManyPeople.ChipAnim(0, betNums);
                }
                uiManyPeople.SetOneBet(betNum);
                uiManyPeople.SetAllBet(response.betNum);
                CacheManager.gameData.coins -= response.betNum;
                CacheManager.ManyPeopleRoomPlayers[0].coins -= response.betNum;
                CacheManager.ManyPeopleRoomPlayers[0].betNum += response.betNum;
                uiManyPeople.UpdateUserCoins(0);
                if (CacheManager.gameData.roleId == 0)
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU0);
                else
                {
                    BaseCanvas.PlaySound(R.AudioClip.CLASSIC_JIAZHU1);
                }
                break;
            case ManyPepolRoomRaiseBetResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            case ManyPepolRoomRaiseBetResponse.ERROR_不在比赛中:
                Debug.LogError("不在比赛中");
                break;
            case ManyPepolRoomRaiseBetResponse.ERROR_没轮到行动:
                Debug.LogError("没轮到行动");
                break;
            case ManyPepolRoomRaiseBetResponse.ERROR_加注不能低于底注:
                Debug.LogError("加注不能低于底注");
                break;

            default: break;
        }
    }

    public void ClearManyTableData()
    {
        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.ClearInfo();
        }
        CacheManager.ManyPeopleRoomPlayers = null;
        CacheManager.list_allBetManyPeople = new List<int>();
    }


    /// <summary>
    /// 断线重连
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveReconnect(byte[] data)
    {

        ClearManyTableData();
        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.Hide();
        }


        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA万人场断线重连");

        ManyPepolPush_reconnect response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_reconnect>(data);
        CacheManager.stateManypeople = response.state;

        if (fapaiCoroutine != null)
            GameCanvas.gameCanvas.StopCoroutine(fapaiCoroutine);


        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.StopPlayerActionTimer();
            uiManyPeople.ClearMatherBackCards();
            uiManyPeople.ClearAnim();
            uiManyPeople.SetBtn(false);
            uiManyPeople.ClearAllPoker();
            uiManyPeople.ClearEffect();
        }
        if (uiManyPeople != null && uiManyPeople.isActive())
        {
            uiManyPeople.Hide();
        }
        if (uITenThousandUpDeskList != null && uITenThousandUpDeskList.isActive())
        {
            uITenThousandUpDeskList.Hide();
        }
        CacheManager.LeaveKillRoom();
        GetController<MainSceneCtrl>().HideMainMenu();
        CacheManager.list_pokersManyPeople = response.list_pokers;
        if (response.list_allBet != null)
            CacheManager.list_allBetManyPeople = response.list_allBet;

        CacheManager.RunRoomId = 5;
        if (response.pos != -1)
            CacheManager.selfPosThous = response.pos;
        else
            CacheManager.selfPosThous = 0;

        CacheManager.manyPeopleActionPos = ToolClass.AbsToRelThous(response.actionPos);
        CacheManager.manyPeopleActionTime = response.actionTime;
        for (int i = 0; i < 5; i++)
        {
            CacheManager.ManyPeopleRoomPlayers[i] = null;
        }

        uiManyPeople.roomPeople = 0;

        for (int i = 0; (response.list_tablePlayer != null) && (i < response.list_tablePlayer.Count); i++)
        {
            PlayerSimpleData playerSimpleData = response.list_tablePlayer[i];
            if (playerSimpleData != null)
            {
                if (playerSimpleData.gameState == 1)
                    uiManyPeople.roomPeople++;
                int pos = ToolClass.AbsToRelThous(playerSimpleData.manyGamepos);
                CacheManager.ManyPeopleRoomPlayers[pos] = playerSimpleData;
                ToolClass.SetRankSprite(playerSimpleData);
                ToolClass.GetHead(playerSimpleData);
            }
        }

        CacheManager.bankerPos = response.bankerPos;
        ShowTenThousandUI();

        uiManyPeople.SetOneBet(response.nowBet);//2

        PlayerSimpleData playerSimple = CacheManager.ManyPeopleRoomPlayers[CacheManager.manyPeopleActionPos];

        uiManyPeople.Reconnection(response.pokerType, response.allinState, playerSimple, response.roundNum);
        GetController<ChatCtrl>().setHideUIMain(false);
    }

    private void ReceiveMprGetJackpotResponse(byte[] data)
    {
        MprGetJackpotResponse response = MySerializerUtil.DeSerializerFromProtobufNet<MprGetJackpotResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                ShowJackpotUI(response.jackpotData);
                break;
            case MprGetJackpotResponse.ERROR_不在比赛中:
                Debug.LogError("不在游戏中");
                break;
        }
    }
    private void ReceiveOtherPlayerApplicationBanker(byte[] data)
    {
        ManyPepolPush_otherPlayerApplicationBanker response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_otherPlayerApplicationBanker>(data);
        if (list_upBankerList == null)
            list_upBankerList = new List<PlayerSimpleData>();
        if (response.bankerRequest != null)
            list_upBankerList.Add(response.bankerRequest);


        if (uITenThousandUpDeskList != null)
        {
            uITenThousandUpDeskList.SetPlayerListInfo();
        }
    }

    private void ReceiveOtherPlayerResignBanker(byte[] data)
    {
        ManyPepolPush_otherPlayerResignBanker response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_otherPlayerResignBanker>(data);
        if (uITenThousandUpDeskList != null)
        {
            for (int i = 0; i < list_upBankerList.Count; i++)
            {
                if (response.userId == list_upBankerList[i].userId)
                {
                    list_upBankerList.RemoveAt(i);
                    uITenThousandUpDeskList.SetPlayerListInfo();
                    break;
                }
            }
        }
    }
    #endregion



    #region   递归 筹码列表
    private List<int> CompareValue(long value, ref int index)
    {
        if (index >= list_allChouMaSort.Count)
        {
            return null;
        }
        if (list_allChouMaSort[index] <= value)
        {
            value = value - list_allChouMaSort[index];
            List<int> list_allYaZhu = new List<int>();
            list_allYaZhu.Add(list_allChouMaSort[index]);
            if (value < list_allChouMaSort[index])
            {
                index++;
            }
            if (value > 0)
            {
                List<int> list = CompareValue(value, ref index);
                if (list != null)
                {
                    list_allYaZhu.AddRange(list);
                }
            }
            return list_allYaZhu;
        }
        else
        {
            index++;
            return CompareValue(value, ref index);
        }
    }

    /// <summary>
    /// 返回所有的筹码值
    /// </summary>
    /// <param name="betNum"> 筹码</param>
    /// <returns></returns>
    public List<int> GetAllXiaZhuInfo(long betNum)
    {
        int index = 0;
        List<int> list = CompareValue(betNum, ref index);
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log("元素：i" + i + "," + list[i]);
            }
        }
        Debug.Log("list:" + list);
        return list;
    }

    #endregion
}
