using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

public class FruitMechineCtrl : BaseController, IHandlerReceive
{
    private static bool isDebug = true;
    private const int state_XiaZhu = 0;
    private const int state_KaiJiang = 1;

    private int state = 0;

    private bool isContinueXiaZhu = false;

    private UIFruitMechine uIFruitMechine;
    private UIShowTips uIShowTips;
    private UIFruitUpBankerList uiFruitUpBankerList;
    public PlayerSimpleData playerBanker;
    public List<PlayerSimpleData> players = new List<PlayerSimpleData>();
    private Dictionary<int, int> dic_currentJuSumXiaZhu = new Dictionary<int, int>();


    private UIHornRecord uiHornRecord;//消息记录面板

    private int roundIndex;
    public override void InitAction()
    {
        uIFruitMechine = GetUIPage<UIFruitMechine>();
        uIFruitMechine.enterRoom = EnterRoom;
        uIFruitMechine.leaveRoom = LeaveRoom;
        uIFruitMechine.fruitTypeAndValue = SendFruitTypeAndValue;
        uIFruitMechine.requestBankerList = RequestBankerList;
        uIFruitMechine.continueXiaZhu = ContinueXiaZhu;
        uIFruitMechine.cancleContinueXiaZhu = CancleContiuneXiaZhu;
        uIFruitMechine.hornRecord = HornRecord;
        uIFruitMechine.showHorn = ShowHorn;
        uIFruitMechine.hideUI = HideUI;
        uIFruitMechine.btnLottery = ShowUILottery;
        uIFruitMechine.btnFriend = ShowUIFriend;
        uIFruitMechine.btnChat = ShowChat;
        uIFruitMechine.ActionOnClick = UIpageOnClick;
        uIFruitMechine.buttonMore = ShowMore;

        uiFruitUpBankerList = GetUIPage<UIFruitUpBankerList>();
        uiFruitUpBankerList.requestUpBanker = RequestUpBanker;
        uiFruitUpBankerList.requestDownBanker = RequestDownBanker;

        uIShowTips = GetUIPage<UIShowTips>();

        uiHornRecord = GetUIPage<UIHornRecord>();
    }

    private void ShowMore()
    {
        if (playerBanker == null || playerBanker.userId != CacheManager.gameData.userId)
            BaseCanvas.GetController<MoreCtrl>().Show(1);
    }

    internal void HideTV()
    {
        if (uIFruitMechine != null)
        {
            uIFruitMechine.HideTV();
        }
    }

    private void ShowChat()
    {
        GetController<ChatCtrl>().ShowUIChat2(4);
    }

    private void UIpageOnClick()
    {
        GetController<MoreCtrl>().Hide2();
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
        if (uIFruitMechine.isActive())
        {
            uIFruitMechine.ShowAddFriendIcon(show);
        }
    }

    private void HideUI()
    {
        HideHornRecordCom();
        GetController<MainSceneCtrl>().HideHornRecordCom();
    }

    private void ShowHorn()
    {
        GetController<HornCtrl>().ShowUIHornCom();
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
            Debug.Log("位置：" + pos);
        }
    }

    /// <summary>
    /// 刷新金币
    /// </summary>
    public void ResSelfCoins()
    {
        if (uIFruitMechine != null)
            uIFruitMechine.UpdatePlayerCoins();
    }

    public void RefreshHornRecordList()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.RefreshList();
        }
    }

    public void HideHornRecordCom()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.Hide();
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
        if (uIFruitMechine.isActive())
        {
            CacheManager.AddHorn(vo);
            GetUIPage<UIGlobalNotic>().NoticPlay(vo);
        }
        RefreshHornRecordList();
    } 


    private void ShowUILottery()
    {
        GetController<LotteryCtrl>().ShowUILottery();
    }

    public void ShowLotteryNum(int num)
    {
        if (uIFruitMechine.isActive())
        {
            uIFruitMechine.ShowCurBuyLotteryNum(num);
        }
    }
    public void ShowLotteryWin(bool play)
    {
        if (uIFruitMechine.isActive())
        {
            uIFruitMechine.LotteryWinPlay(play);
        }
    }
    public void ShowLotteryTime(int time)
    {
        if (uIFruitMechine.isActive())
        {
            uIFruitMechine.ShowLotteryTime(time);
        }
    }
 

    private void SetIsContinueXiaZhu(bool isContinueXiaZhu)
    {
        this.isContinueXiaZhu = isContinueXiaZhu;
    }
    public bool GetIsContinueXiaZhu()
    {
        return this.isContinueXiaZhu;
    }
    private void CancleContiuneXiaZhu()
    {
        CancleContinueXiaZhuRequest request = new CancleContinueXiaZhuRequest();
        SendMessage(request);
    }

    private void ContinueXiaZhu()
    {
        IsContinueXiaZhuRequest request = new IsContinueXiaZhuRequest();
        SendMessage(request);
    }

    private void RequestBankerList()
    {
        ShowUI<UIFruitUpBankerList>();
        FruitBankerListRequest request = new FruitBankerListRequest();
        SendMessage(request);
    }

    private void RequestDownBanker()
    {
        //if (this.playerBanker == null)
        //{
        //    if (isDebug) Debug.Log("******当前庄家为空！不能申请下庄！******");
        //    GetController<MessageCtrl>().Show("当前庄家为空！不能申请下庄！");
        //    return;
        //}
        //if (this.playerBanker.userId != CacheManager.gameData.userId)
        //{
        //    if (isDebug) Debug.Log("******您不是当前庄家！不能申请下庄！******");
        //    GetController<MessageCtrl>().Show("您不是当前庄家！不能申请下庄！！");
        //    return;
        //}
         
        if (this.playerBanker != null && this.playerBanker.userId == CacheManager.gameData.userId)//是庄家是请求下庄
        {
            SendMessage(new FruitDownBankerRequest());
            return;
        }
            


        if (players == null || players.Count <= 0)
        {
            if (isDebug) Debug.Log("******您不是当前庄家！不能申请下庄！******");
            GetController<MessageCtrl>().Show("您不是当前庄家！不能申请下庄！！");
            return;
        }

        bool isExistsBankerList = false;
        foreach (var item in players)
        {
            if (item.userId == CacheManager.gameData.userId)
            {
                isExistsBankerList = true;
                break;
            }
        }
        if (!isExistsBankerList)
        {
            if (isDebug) Debug.Log("******不在庄家列表！不能申请下庄！******");
            return;
        }


        FruitDownBankerRequest request = new FruitDownBankerRequest();
        SendMessage(request);
    }

    private void RequestUpBanker()
    {
        if (this.playerBanker != null)
        {
            if (this.playerBanker.userId == CacheManager.gameData.userId)
            {
                if (isDebug) Debug.Log("******您已是当前庄家！不能再申请上庄！******");
                GetController<MessageCtrl>().Show("您已是当前庄家！不能再申请上庄！");
                return;
            }
        }
        if (CacheManager.gameData.coins < 50000000)
        {
            if (isDebug) Debug.Log("****您当前的金币不够上庄条件(上庄金币需大于等于5000万)*****");
            GetController<MessageCtrl>().Show("您当前的金币不够上庄条件(上庄金币需大于等于5000万)");
            return;
        }
        if (isDebug) Debug.Log("******申请上庄******");
        FruitUpBankerRequest request = new FruitUpBankerRequest();
        SendMessage(request);
    }

    private void SendFruitTypeAndValue(int type, int value)
    {
        if (playerBanker != null)
        {
            if (playerBanker.userId == CacheManager.gameData.userId)
            {
                if (isDebug) Debug.Log("您是当前房间内庄家  不可以下注 ！");
                GetController<MessageCtrl>().Show("您是当前房间内庄家,不可以下注 ！");
                return;
            }
        }
        //long coins = CacheManager.gameData.coins;
        //CacheManager.gameData.coins -= value;
        FruitMachineXiaZhuRequest request = new FruitMachineXiaZhuRequest(type, value);
        SendMessage(request);
        uIFruitMechine.UpdatePlayerCoins();
    }

    /// <summary>
    /// 刷新金币
    /// </summary>
    public void RefreshCoin()
    {

    }

    public void LeaveRoom()
    {
        LeaveFruitMachineRequest request = new LeaveFruitMachineRequest();
        SendMessage(request);
    }

    private void EnterRoom()
    {
        EnterFruitMachineRequest request = new EnterFruitMachineRequest();
        SendMessage(request);
    }

    /// <summary>
    /// 显示电视机或者水果机  1为水果机 2为电视机中的水果机
    /// </summary>
    /// <param name="showWatchOrFruit"></param>
    public void ShowUIFruitMechine(int showWatchOrFruit)
    {
        GameCanvas.gameCanvas.ChangeRoomToFruit();
        if (showWatchOrFruit == 2)
        {
            CacheManager.FruitRoomTV = 1;
            uIFruitMechine.ChangeRoot(UIType.PopUp);
        }
        else
        {
            CacheManager.RunRoomId = 6;
            uIFruitMechine.ChangeRoot(UIType.Normal);
        }
        uIFruitMechine = ShowUI<UIFruitMechine>();
        if (GameObject.Find("Main Camera").GetComponent<HelpClass>() == null)
        {
            GameObject.Find("Main Camera").AddComponent<HelpClass>();
        }
        uIFruitMechine.SetOpenIsWatchOrFruit(showWatchOrFruit);

        GetController<MainSceneCtrl>().HideHornRecordCom();

        GetController<LotteryCtrl>().SendAskTime();
    }


    public void ShowReturn()
    {
        if (uIFruitMechine != null && uIFruitMechine.isActive())
        {
            uIFruitMechine.ShowReturnUI();
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    private long startTime = MyTimeUtil.GetCurrTimeMM;
    private int updateTime = 15;
    // Update is called once per frame
    public void UpdateDaoJiShi()
    {
        uIFruitMechine.UpdateCountDownTime();
    }

    private bool isXiaZhu()
    {
        return state == state_XiaZhu;
    }
    private void setState(int state)
    {
        this.state = state;
    }
    public int GetState()
    {
        return this.state;
    }
    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
 
            switch (response.msgType)
            {
                case MsgType.EnterFruitMechine:
                    GetRoomInfo(response.data);
                    break;
                case MsgType.LeaveFruitMechine:
                    Debug.LogError("离开水果机");
                    break;
                case MsgType.FruitMechine_开始下注:
                    //改变玩家下注状态
                    setState(state_XiaZhu);
                    uIFruitMechine.SetStartTime(MyTimeUtil.GetCurrTimeMM);
                    uIFruitMechine.setBtnUnEabled(true, false);
                    uIFruitMechine.ClearAllXiaZhuInfo();
                    uIFruitMechine.SetXiaZhuInfo();
                    dic_currentJuSumXiaZhu.Clear();
                    Debug.Log("切换开始下注状态！！！！");
                    break;
                case MsgType.FruitMechine:
                    //投注
                    SetFruitXiaZhuInfo(response.data);
                    break;
                case MsgType.Push_FruitMechine_结算:
                    //结算结果
                    SetSettlementRewardInfo(response.data);
                    Debug.Log("切换开始开奖状态！！！！");
                    break;
                case MsgType.Fruit_requestBankerList:
                    SetBankerListInfo(response.data);
                    break;
                case MsgType.FruitUpBanker:
                    //请求上庄
                    SetUpBankerResponse(response.data);
                    break;
                case MsgType.Fruit_bankerListChange:
                    SetChangeBankerInfo(response.data);
                    break;
                case MsgType.FruitDownBanker:
                    SetDownBankerInfo(response.data);
                    break;

                case MsgType.Fruit_bankerWining:
                    SetBankerWininginfo(response.data);
                    break;
                case MsgType.Fruit_JiangPool:
                    SetRoomJiangPoolInfo(response.data);
                    break;
                case MsgType.Fruit_断线重连:
                    SetFruitNotConnectInfo(response.data);
                    break;
                case MsgType.Fruit_下注:
                    SetFruitPushXiaZhuInfo(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void SetFruitPushXiaZhuInfo(byte[] data)
    {
        FruitPush_XiaZhu response = MySerializerUtil.DeSerializerFromProtobufNet<FruitPush_XiaZhu>(data);
        if (response.userId == CacheManager.gameData.userId)
        {
            CacheManager.gameData.coins -= response.value;
        }
        if (dic_currentJuSumXiaZhu.ContainsKey(response.type))
        {
            dic_currentJuSumXiaZhu[response.type] += response.value;
        }
        else
        {
            dic_currentJuSumXiaZhu.Add(response.type, response.value);
        }
        uIFruitMechine.UpdateXiaZhuInfo(dic_currentJuSumXiaZhu);
    }

    private void SetFruitNotConnectInfo(byte[] data)
    {
        FruitPush_reconnect response = MySerializerUtil.DeSerializerFromProtobufNet<FruitPush_reconnect>(data);
        if (CacheManager.RunRoomId == 6)
        {
            ShowUIFruitMechine(1);
        }

        GetAndSetRoomInFo(response.roomState, response.stateTime, response.playerBankerData, response.jiangPoolCoins,response.roundIndex);
        SetXiaZhuInfo(response.list_xiaZhuKey, response.list_xiaZhuValue);
        uIFruitMechine.SetHistoryNum(response.list_history);
    }

    private void SetRoomJiangPoolInfo(byte[] data)
    {
        JiangPoolResponse response = MySerializerUtil.DeSerializerFromProtobufNet<JiangPoolResponse>(data);
        uIFruitMechine.SetJiangPoolCoin(response.jiangPoolValue);
    }

    public PlayerSimpleData GetCurrentBanker()
    {
        return this.playerBanker;
    }
    private void SetBankerWininginfo(byte[] data)
    {
        Push_BankerWiningResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_BankerWiningResponse>(data);
        if (isDebug) Debug.Log("推送庄家的结算结果 :" + response.ToString());
        switch (response.code)
        {
            case FruitDownBankerResponse.SUCCESS:
                uIFruitMechine.SetBankerWiningInfo(response.playerBanker, response.winingValue);

                break;
            default:
                break;
        }
    }

    private void SetDownBankerInfo(byte[] data)
    {
        FruitDownBankerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FruitDownBankerResponse>(data);
        // if (isDebug)
        Debug.Log("下庄请求回应 :" + response.ToString());
        switch (response.code)
        {
            case FruitDownBankerResponse.SUCCESS:
                GetController<MessageCtrl>().Show("申请下庄成功！");
                break;
            case FruitDownBankerResponse.你不是当前庄家_不能申请下庄:
                if (isDebug) Debug.Log("****你不是当前庄家_不能申请下庄******");
                GetController<MessageCtrl>().Show("你不是当前庄家_不能申请下庄！");
                break;
            default:
                break;
        }
    }

    private void SetChangeBankerInfo(byte[] data)
    {
        Push_ChangeBankerListInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_ChangeBankerListInfoResponse>(data);
        players = response.bankers;
        this.playerBanker = response.nextBanker;
        uiFruitUpBankerList.UpdateBankerList(players);
        uIFruitMechine.SetPlayerInfo(response.nextBanker);
        if (response.nextBanker == null)
        {
            return;
        }
        if (playerBanker.userId == CacheManager.gameData.userId)
        {
            GetController<UpBankerListCtrl>().Hide();
            GetController<MoreCtrl>().HideTV();
            GetController<LotteryCtrl>().HideLottery();
        }

        this.playerBanker = response.nextBanker;
        uIFruitMechine.SetPlayerInfo(response.nextBanker);
        players = response.bankers;
        uiFruitUpBankerList.UpdateBankerList(players);
    }

    /// <summary>
    ///  处理 请求上庄成功后的消息
    /// </summary>
    /// <param name="data"></param>
    private void SetUpBankerResponse(byte[] data)
    {
        FruitUpBankerResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FruitUpBankerResponse>(data);
        switch (response.code)
        {
            case FruitUpBankerResponse.SUCCESS:
                GetController<MessageCtrl>().Show("申请上庄成功！");
                SetBankerList(response.requestPlayer);
                break;
            case FruitUpBankerResponse.您已是当前房间庄家:
                if (isDebug) Debug.Log("****您已是当前房间庄家****");
                GetController<MessageCtrl>().Show("您已是当前房间庄家！");
                break;
            case FruitUpBankerResponse.未达到上装条件:
                if (isDebug) Debug.Log("****未达到上装条件****");
                GetController<MessageCtrl>().Show("未达到上装条件！");
                break;
            case FruitUpBankerResponse.申请上庄失败:
                if (isDebug) Debug.Log("****申请上庄失败****");
                GetController<MessageCtrl>().Show("申请上庄失败！");
                break;
            case FruitUpBankerResponse.申请人数已达上限:
                if (isDebug) Debug.Log("****申请人数已达上限****");
                GetController<MessageCtrl>().Show("申请人数已达上限！");
                break;
            default:
                break;
        }
    }

    private void SetBankerList(PlayerSimpleData requestPlayer)
    {
        //if (this.playerBanker == null)
        //{
        //    this.playerBanker = requestPlayer;
        //    uIFruitMechine.SetPlayerInfo(playerBanker);
        // uiFruitUpBankerList.ChangeZhungjiaBtn();
        //}
        //else
        //{
        //    if (this.playerBanker.userId == requestPlayer.userId)
        //    {
        //        uiFruitUpBankerList.ChangeZhungjiaBtn();
        //        return;
        //    }
        //    if (isDebug) Debug.Log("当前庄家不为空 ：" + playerBanker);
        //    if (players == null)
        //    {
        //        players = new List<PlayerSimpleData>();
        //    }
        //    players.Add(requestPlayer);
        //    if (isDebug) Debug.Log("players count:" + players.Count);
        //    uiFruitUpBankerList.UpdateBankerList(players);
        //    uiFruitUpBankerList.ChangeZhungjiaBtn();
        //}
    }

    private void SetBankerListInfo(byte[] data)
    {
        FruitBankerListResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FruitBankerListResponse>(data);
        switch (response.code)
        {
            case FruitBankerListResponse.SUCCESS:
                SetFruitBankerListInfo(response.list_bankerPlayers);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 设置上庄列表信息
    /// </summary>
    /// <param name="list_bankerPlayers"></param>
    private void SetFruitBankerListInfo(List<PlayerSimpleData> list_bankerPlayers)
    {
        Debug.Log("SetFruitBankerListInfo  ->  list_bankerPlayers:" + list_bankerPlayers.GetString());
        players = list_bankerPlayers;
        uiFruitUpBankerList.UpdateBankerList(list_bankerPlayers);
    }
    /// <summary>
    /// 获取房间信息
    /// </summary>
    /// <param name="data"></param>
    private void GetRoomInfo(byte[] data)
    {
        EnterFruitMachineResponse response = MySerializerUtil.DeSerializerFromProtobufNet<EnterFruitMachineResponse>(data);
        switch (response.code)
        {
            case EnterFruitMachineResponse.SUCCESS:
                Debug.Log("进入水果机,CacheManager.FruitRoomTV:"+ CacheManager.FruitRoomTV);

                if (CacheManager.FruitRoomTV == 0)
                {

                    CacheManager.LeaveKillRoom();
                    GetController<RoomCtrl>().HideOn();
                    GetController<RoomCtrl>().ClearAllCoins();
                }
                this.roundIndex = response.roundIndex;//进入时
                GetAndSetRoomInFo(response.roomState, response.stateTime, response.playerBankerData, response.jiangPoolCoins, response.roundIndex);
                SetXiaZhuInfo(response.list_xiaZhuKey, response.list_xiaZhuValue);//进入房间时获取总注
                uIFruitMechine.SetHistoryNum(response.list_history);
                BaseCanvas.PlayBGM(R.AudioClip.ENTERFRUITMECHINE);
                break;
            default:
                break;
        }
    }

    private void SetXiaZhuInfo(List<int> list_xiaZhuKey, List<int> list_xiaZhuValue)
    {
        Debug.Log("进入房间时更新总注信息,key:"+list_xiaZhuKey.GetString() + ",value:"+list_xiaZhuValue.GetString());
        if (dic_currentJuSumXiaZhu.Count != 0)
        {
            dic_currentJuSumXiaZhu.Clear();
        }
        if (list_xiaZhuKey == null || list_xiaZhuKey.Count <= 0)
        {
            uIFruitMechine.UpdateXiaZhuInfo(dic_currentJuSumXiaZhu);//进入房间时获取
            return;
        }
      
        for (int i = 0; i < list_xiaZhuKey.Count; i++)
        {
            int key = list_xiaZhuKey[i];
            int value = list_xiaZhuValue[i];
            dic_currentJuSumXiaZhu.Add(key, value);
        }
        uIFruitMechine.UpdateXiaZhuInfo(dic_currentJuSumXiaZhu);
    }

    private void GetAndSetRoomInFo(int roomState, long stateTime, PlayerSimpleData playerBanker, long jiangPoolCoins,int roundIndex)
    {
        this.playerBanker = playerBanker;
        uIFruitMechine.SetPlayerInfo(playerBanker);
        uIFruitMechine.SetJiangPoolCoin(jiangPoolCoins);
        uIFruitMechine.ShowPoolValue();
        switch (roomState)
        {
            case state_XiaZhu:
                setState(roomState);
                uIFruitMechine.SetStartTime(stateTime);
                uIFruitMechine.ResetFruitInfo(true, false);
                if(roundIndex != this.roundIndex)
                    uIFruitMechine.ClearAllXiaZhuInfo();
                this.roundIndex = roundIndex;//重连时
                break;
            case state_KaiJiang:
                setState(roomState);
                uIFruitMechine.SetStartTime(stateTime);
                uIFruitMechine.ResetFruitInfo(false, true);
               
                uIFruitMechine.OnClickBtnXuYa(true, false);

                if (roundIndex != this.roundIndex)
                    uIFruitMechine.ClearAllXiaZhuInfo();
                this.roundIndex = roundIndex;
                break;
        }
    }

    /// <summary>
    /// 处理结算信息
    /// </summary>
    /// <param name="data"></param>
    private void SetSettlementRewardInfo(byte[] data)
    {
        Push_FruitSettlementRewardResponse response = MySerializerUtil.DeSerializerFromProtobufNet<Push_FruitSettlementRewardResponse>(data);
        this.roundIndex = response.roundIndex;
        setState(state_KaiJiang);
        uIFruitMechine.SetStartTime(MyTimeUtil.GetCurrTimeMM);
        if (isKaiJiang())
        {
            //if (isDebug) Debug.Log("开奖时  state:" + state);
            //if (isDebug) Debug.Log("response :" + response.ToString());
            uIFruitMechine.SetMachineStartScroll(response.fruitType, response.fruitRewardType, response.isSpecialRewardType, response.fruitNum, response.playerwining);
        }
    }

    private bool isKaiJiang()
    {
        return state == state_KaiJiang;
    }

    private void SetFruitXiaZhuInfo(byte[] data)
    {
        FruitMachineXiaZhuResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FruitMachineXiaZhuResponse>(data);
        switch (response.code)
        {
            case FruitMachineXiaZhuResponse.SUCCESS:
                break;
        }
    }


    public void ShowTips(string content, int index = 1)
    {
        ShowUI<UIShowTips>();
        uIShowTips.ShowTips(content, index);
    }
}
