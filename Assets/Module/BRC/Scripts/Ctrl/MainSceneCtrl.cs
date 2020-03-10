using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MainSceneCtrl : BaseController, IHandlerReceive
{
    private UIMainScene uiMainScene;
    private UISelectRoom uiSelectRoom;

    private UIHornRecord uiHornRecord;//消息记录面板
    public override void InitAction()
    {
        uiMainScene = GetUIPage<UIMainScene>();
        uiMainScene.ActionShop = ShowShopUI;
        uiMainScene.ActionMore = BtnMore;
        uiMainScene.ActionTask = ShowTaskUI;
        uiMainScene.safebox = BtnSafebox;
        uiMainScene.ActionRank = ShowRankingUI;
        uiMainScene.fruitMachine = BtnFruitMachine;
        uiMainScene.ActionTree = ShowTreeUI;
        uiMainScene.ActionMail = SendGetAllMailRequest;
        uiMainScene.ActionAllKill = ShowKillRoomUI;
        uiMainScene.ActionClassic = ShowSelectClassicUI;
        uiMainScene.ActionHead = ShowUserInfo;
        uiMainScene.ActionFriend = ShowFriendUI;
        uiMainScene.freeMoney = ShowUISignInCom;
        uiMainScene.ActionSelect = ShowSelectRoomUI;
        uiMainScene.tenThousand = ShowTenThousandUI;
        uiMainScene.hornRecord = HornRecord;
        uiMainScene.showHorn = ShowHorn;
        uiMainScene.ActionLow = SendLowRequest;

        uiSelectRoom = GetUIPage<UISelectRoom>();
        uiSelectRoom.ActionAllKill = ShowKillRoomUI;
        uiSelectRoom.ActionFruit = BtnFruitMachine;
        uiSelectRoom.ActionClose = CloseSelectRoom;
        uiSelectRoom.ActionClassic = ShowSelectClassicUI;
        uiSelectRoom.ActionManyPeople = ShowTenThousandUI;
        uiSelectRoom.ActionYule = () =>
        {
            ClickGGL();
        };

        ShowLuckyUI();


        uiHornRecord = GetUIPage<UIHornRecord>();
    }

    private void ClickGGL()
    {
        GetController<GGLCtrl>().ShowGGL();
    }

    internal void SetHeadImg(Texture2D t2d)
    {
        uiMainScene.SetHead(t2d);
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
        }
    }

    /// <summary>
    /// 刷新金币
    /// </summary>
    public void ResSelfCoins()
    {

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
        //if (uiMainScene.isActive())
        //{
        //    uiMainScene.NoticPlay(vo);
        //}


        RefreshHornRecordList();
    }
    /// <summary>
    /// 滚动条消息
    /// </summary>
    /// <param name="vo"></param>
    public void ShowTxtTitle(string info)
    {
        //HornInfoVO vo = new HornInfoVO();
        //vo.info = info;
        //vo.nikeName = "[color=#FF0000]系统[/color]";
        //if (uiMainScene.isActive())
        //{
        //    CacheManager.AddHorn(vo);
        //    uiMainScene.NoticPlay(vo);
        //}
        //RefreshHornRecordList();
    }




    #region ShowUI
    private void ShowSelectRoomUI()
    {
        ShowUI<UISelectRoom>();
    }
    /// <summary>
    /// 显示万人场
    /// </summary>
    private void ShowTenThousandUI()
    {
        GetController<ChatCtrl>().setHideUIMain(false);
        GetController<ChatCtrl>().SetRoom(2);
        CacheManager.manyPeopleId = 0;
        CacheManager.RunRoomId = 5;
        GetController<TenThousandRoomCtrl>().SendEnterManyPeopleRoom();


    }
    private void ShowUISignInCom()
    {
        GetController<SignCtrl>().ShowUISignInCom();
    }

    public void ShowIcon(bool show)
    {
        if (uiMainScene != null && uiMainScene.isActive())
        {
            uiMainScene.ShowIcon(show);
        }
    }



    private void BtnFruitMachine()
    {
        uiMainScene.Hide();
        GetController<ChatCtrl>().setHideUIMain(false);
        GetController<ChatCtrl>().SetRoom(4);
        GetController<FruitMechineCtrl>().ShowUIFruitMechine(1);

        Debug.Log("进入水果机");
    }

    private void ShowRankingUI()
    {
        GetController<NetCtrl>().SendRankingRequest(false);

    }

    private void ShowTreeUI()
    {
        GetController<TreeCtrl>().ShowUI();
    }

    private void BtnSafebox()
    {
        GetController<SafeBoxCtrl>().ShowUISafeBox();
    }

    private void ShowTaskUI()
    {
        GetController<TaskCtrl>().ShowTask();
    }

    private void BtnMore()
    {
        GetController<SetCtrl>().ShowSetUI(0);
    }

    private void ShowShopUI(int index)
    {
        GetController<ShopCtrl>().Show(index);
    }

    public void ShowUIMainScene()
    {
        GetController<ChatCtrl>().setHideUIMain(true);

        ShowUI<UIMainScene>();
        GetController<MessageCtrl>().HideTipesUI();
        SendMainSceneEnterKillRoomRequest();
    }

    public void ShowUserInfo()
    {
        GetController<UserInfoCtrl>().ShowSelfInfoUI(true);
    }
    public void ShowFriendUI()
    {
        GetController<FriendCtrl>().ShowUIFriend();
    }
    public void ShowLuckyUI()
    {
        GetController<LuckyCtrl>().Show();
    }

    #endregion

    public void Init()
    {
        uiMainScene.Init();
    }
    public void SetNickname()
    {
        uiMainScene.SetNickname();
    }
    public void SetHead()
    {
        uiMainScene.SetHead();
    }

    public void RefCoinsAndMasonry()
    {
        uiMainScene.RefCoinsAndMasonry();
    }

    public void CloseSelectRoom()
    {
        uiMainScene.SetSelectC1(0);
    }

    public void ShowKillRoomUI()
    {
        GetController<ChatCtrl>().setHideUIMain(false);
        GetController<ChatCtrl>().SetRoom(1);
        if (uiMainScene != null && uiMainScene.isActive())
            uiMainScene.Hide();
        CacheManager.KillRoomTV = 0;
        GetController<RoomCtrl>().SetRoomIndex(0);

    }
    private void ShowSelectClassicUI()
    {
        GetController<ChatCtrl>().setHideUIMain(false);
        GetController<ChatCtrl>().SetRoom(3);
        GetController<SelectClassicCtrl>().Show();
        HideMainMenu();
    }

    public void HideMainMenu()
    {
        CacheManager.LeaveKillRoom();
        if (uiMainScene != null && uiMainScene.isActive())
            uiMainScene.Hide();
        GetController<LuckyCtrl>().Hide();
    }

    #region SendRequest

    public void SendMainSceneEnterKillRoomRequest()
    {
        CacheManager.KillRoomTV = 2;
        EnterKillRoomRequest request = new EnterKillRoomRequest();
        SendMessage(request);
    }


    public void SendGetAllMailRequest()
    {
        GetAllMailRequest request = new GetAllMailRequest();
        SendMessage(request);
    }

    private void SendLowRequest()
    {
        LowRequest request = new LowRequest();
        SendMessage(request);
    }
    #endregion


    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {

            switch (response.msgType)
            {
                case MsgType.KillRoom_进入通杀场:
                    ReceiveKillRoom(response.data);
                    break;
                case MsgType.MAIL_GETALL://获取所有邮件
                    ReceiveGetAllMail(response.data);
                    break;
                case MsgType.LOW:
                    ReceiveLow(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }



    /// <summary>
    /// 进入通杀场
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveKillRoom(byte[] data)
    {
        Debug.Log("进入通杀场...");
        EnterKillRoomResponse response = MySerializerUtil.DeSerializerFromProtobufNet<EnterKillRoomResponse>(data);
        switch (response.code)
        {
            case EnterKillRoomResponse.SUCCESS:
                if (CacheManager.killRoomRoundIndex != response.roundIndex)
                {
                    ClearKillRoomBet();


                    CacheManager.killRoom.ClearPayBet();
                }

                CacheManager.killRoomRoundIndex = response.roundIndex;


                GetController<RoomCtrl>().list_bigWin = response.list_bigWin;
                GetController<RoomCtrl>().list_directionBetNum = response.list_directionBetNum;
                CacheManager.bankerRound = response.bankerRound;
                CacheManager.state = response.state;
                CacheManager.banker = response.banker;
                ToolClass.GetHead(CacheManager.banker);
                if (response.banker != null && response.banker.userId != 100000)
                {
                    ToolClass.SetRankSprite(response.banker);
                }


                if (response.list_tablePlayer != null)
                {
                    for (int i = 0; i < response.list_tablePlayer.Count; i++)
                    {
                        PlayerSimpleData playerSimpleData = response.list_tablePlayer[i];
                        ToolClass.GetHead(playerSimpleData);

                        CacheManager.TablePlayers[playerSimpleData.killRoomPos] = playerSimpleData;
                        if (playerSimpleData != null)
                        {
                            ToolClass.SetRankSprite(playerSimpleData);
                        }
                    }
                }

                if (response.list_killRoomLog != null && response.list_killRoomLog.Count > 0)
                {
                    CacheManager.List_bankerWin.Clear();
                    CacheManager.List_dongWin.Clear();
                    CacheManager.List_nanWin.Clear();
                    CacheManager.List_xiWin.Clear();
                    CacheManager.List_beiWin.Clear();
                    for (int i = 0; i < response.list_killRoomLog.Count; i++)
                    {
                        KillRoomLog killRoomLog = response.list_killRoomLog[i];
                        bool bankerWin = (!killRoomLog.dongWin && !killRoomLog.nanWin && !killRoomLog.xiWin && !killRoomLog.beiWin);
                        CacheManager.List_bankerWin.Add(bankerWin);
                        CacheManager.List_dongWin.Add(killRoomLog.dongWin);
                        CacheManager.List_nanWin.Add(killRoomLog.nanWin);
                        CacheManager.List_xiWin.Add(killRoomLog.xiWin);
                        CacheManager.List_beiWin.Add(killRoomLog.beiWin);
                    }
                }

                CacheManager.jackpot = response.jackpot;
                CacheManager.stateTime = response.stateTime / 1000;

                if (response.banker.userId == CacheManager.gameData.userId)
                {
                    CacheManager.KillRoomTV = 0;
                    CacheManager.RunRoomId = 0;
                }

                if (CacheManager.KillRoomTV == 0)
                {
                    GetController<RoomCtrl>().ShowRoomUI();
                }
                else if (CacheManager.KillRoomTV == 1)
                    GetController<RoomCtrl>().ShowRoomTVUI();
                else if (CacheManager.KillRoomTV == 2)
                    GetController<RoomCtrl>().ShowRoomMainScene();
                break;
            default:
                break;
        }
    }

    private void ClearKillRoomBet()
    {
        GetController<RoomCtrl>().ClearKillRoomBet();

    }

    private void ReceiveGetAllMail(byte[] data)
    {
        GetAllMailResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetAllMailResponse>(data);
        switch (response.code)
        {
            case GetAllMailResponse.SUCCESS:
                GetController<MailCtrl>().Show(response.userMailDataPOS);
                break;
            default:
                break;
        }
    }

    private void ReceiveLow(byte[] data)
    {
        LowResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LowResponse>(data);
        switch (response.code)
        {
            case LowResponse.SUCCESS:
                CacheManager.gameData.coins += 5000;
                uiMainScene.RefCoinsAndMasonry();
                GetController<MessageCtrl>().Show("你已破产，系统自动补助5000金币，还有" + (3 - response.number) + "次补助");
                break;
            case LowResponse.ERROR_金币较多:
                break;
            case LowResponse.ERROR_次数不足:
                break;
            default: break;
        }
    }


    /// <summary>
    /// 刷新红点图标
    /// </summary>
    /// <param name="show"></param>
    public void RefreshRedPonit(bool show)
    {
        if (uiMainScene.isActive())
        {
            uiMainScene.ShowAddFriendIcon(show);
        }
    }
    /// <summary>
    /// 刷新任务红点图标
    /// </summary>
    public void RefreshRedPoint()
    {
        if (uiMainScene.isActive())
        {
            uiMainScene.SetTaskInfoTiShi();
        }
    }
    public void SetVip()
    {
        if (uiMainScene != null && uiMainScene.isActive())
            uiMainScene.SetVip();
    }
}