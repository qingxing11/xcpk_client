using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WT.UI;

public class GameCanvas : BaseCanvas, IHandlerReceive
{
    public const int ROOMSTATE_Main = 0;
    public const int ROOMSTATE_KillRoom = 1;
    public const int ROOMSTATE_Fruit = 2;
    public const int ROOMSTATE_ClassicRoom = 3;
    public const int ROOMSTATE_Manypepol = 4;
    public int roomState;

    public static GameCanvas gameCanvas;

    public void RefCoins(int coins)
    {

    }

    private void Awake()
    {
        EventCenter.AddListener<int>(EventDefine.CoinsChange, RefCoins);

        ActivationInputEventCenter();
        gameCanvas = this;
        AddAudioControl();
        AddHandlerGlobalReceiveEvent<GlobalReceiveCanvas>();
        AddHandlerReceiveEvent(this);


        GetController<MainSceneCtrl>().ShowUIMainScene();
        PlayerInGame();

        ActivationConntroller<MainSceneCtrl>();
        ActivationConntroller<FriendCtrl>();
        ActivationConntroller<LotteryCtrl>();
        ActivationConntroller<SendRedEnvelopeCtrl>();
        ActivationConntroller<FruitMechineCtrl>();
        ActivationConntroller<TxtCtrl>();
        ActivationConntroller<TenThousandRoomCtrl>();
        ActivationConntroller<TaskCtrl>();
        ActivationConntroller<HornCtrl>();
        ActivationConntroller<GGLCtrl>();
        ActivationConntroller<GifCtrl>();
        ActivationConntroller<NetCtrl>();

        //GetController<MessageCtrl>().Show("恭喜你，本局赢得");

        GetController<MainSceneCtrl>().Init();
        GetController<NetCtrl>().SendRankingRequest(true);
    }

    private void PlayerInGame()
    {
        AskPlayerInGameRequest request = new AskPlayerInGameRequest();
        SendMessage(request);
    }

    public void AddReuqestMission(Request request)
    {
        Debug.Log("增加一个外部事件待处理任务,msgType:" + request.msgType);
        list_focusRquest.Add(request);
    }

    protected override void Update()
    {
        base.Update();
        GetController<FruitMechineCtrl>().UpdateDaoJiShi();
        GetController<TaskCtrl>().RunTime();

        GetController<LotteryCtrl>().Update();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogError("AAAAAAAAAA;返回按钮："+ CacheManager.RunRoomId+ "   CacheManager.KillRoomTV:"+ CacheManager.KillRoomTV);
            if (CacheManager.RunRoomId == 0)    //通杀场
            {
                if (CacheManager.KillRoomTV == 0)  //正常打开通杀场
                    GetController<RoomCtrl>().ShowReturnPanelUI();
                else
                    GetController<ExitCtrl>().Show();
            }
            else if (CacheManager.RunRoomId == 5) //万人场
            {
                GetController<TenThousandRoomCtrl>().ShowReturnUI(true);
            }
            else if (CacheManager.RunRoomId == 6)
            {
                GetController<FruitMechineCtrl>().ShowReturn();
            }
            else if (CacheManager.RunRoomId == 1)        //经典场
            {
                GetController<ClassicRoomCtrl>().Return();
            }
            else
            {
                GetController<ExitCtrl>().Show();
            }
        }

        RunApplicationFocusMission();
    }

    private bool updateFocusMission;
    /// <summary>
    /// 玩家外部事件期间任务
    /// </summary>
    private void RunApplicationFocusMission()
    {
        if (updateFocusMission)//外部事件切入
        {
            //Debug.Log("剩余发送任务:" + list_focusRquest.Count);
            if (list_focusRquest.Count > 0)
            {

                foreach (var item in list_focusRquest)
                {
                    SendMessage(item);
                }
                list_focusRquest.Clear();
                updateFocusMission = false;
            }
        }
    }

    private List<Request> list_focusRquest = new List<Request>();
    private bool isQuit = false;
    private long startQuitTime;
    protected override void OnApplicationFocus()
    {
        base.OnApplicationFocus();

        return;
        //Debug.Log("isQuit:"+ isQuit);
        if (isQuit)
        {
            long use = MyTimeUtil.GetCurrTimeMM - startQuitTime;
            //Debug.Log("use:" + use);
            if (use  < 5000)
            {
                return;
            }
 #if !UNITY_STANDALONE && !UNITY_EDITOR//unity编辑器模式下断线重连不要打开，不准确
            NetWorkClient.InitConnect(InitGameCanvas.ClientConfig.gameIp, InitGameCanvas.ClientConfig.gamePort, InitGameCanvas.ClientConfig.serializerUtil);
            PlayerReConnectRequest request = new PlayerReConnectRequest
            {
                tokenVO = CacheManager.tokenVO,
                isPing = isQuit,

            };
            SendMessage(request);

            GetController<LoadingCtrl>().ShowLoading(true);
#endif

        }
        startQuitTime = MyTimeUtil.GetCurrTimeMM;

        isQuit = !isQuit;
    }

   

    protected override void OnApplicationPause()
    {
        base.OnApplicationPause();
        Debug.Log("OnApplicationPause");
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {


            switch (response.msgType)
            {

                case MsgType.GAME_客户端要求断线重连:
                    Debug.Log("GameCanvas收到断线重连消息。。。");
                    ReceiveReconnect(response.data);
                    break;


                default:
                    return response;
            }
        }
       
        return null;
    }



    private void ReceiveReconnect(byte[] data)
    {
      
        GetController<LoadingCtrl>().HideLoading(true);
        //334
        updateFocusMission = true;
        PlayerReConnectResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PlayerReConnectResponse>(data);

        Debug.Log("断线重连切入，response："+ response);
        switch (response.code)
        {
            case PlayerReConnectResponse.SUCCESS:
                if (response.isPing)//断线重连切入
                {
                    CacheManager.gameData = response.gameData;
                }

                //TODO 刷新面板金币
                //Debug.Log("断线重连成功，response.isPing：" + response.isPing);
                break;

            case PlayerReConnectResponse.ERROR_不在任何房间中:
                Debug.Log("断线重连不在任何房间中，");
                CacheManager.gameData = response.gameData;
                GetController<RoomCtrl>().Connect();
                if (CacheManager.RunRoomId == 0 && CacheManager.KillRoomTV == 0)
                {
                    CacheManager.KillRoomTV = 0;
                    EnterKillRoomRequest request = new EnterKillRoomRequest();
                    SendMessage(request);
                }
                else
                {
                    GetController<MainSceneCtrl>().ShowUIMainScene();
                    CacheManager.KillRoomTV = 2;
                    EnterKillRoomRequest request = new EnterKillRoomRequest();
                    SendMessage(request);
                }
                break;

            default:
                Debug.Log("断线重连失败:" + response.code);
                GetController<TenThousandRoomCtrl>().ClearManyTableData();
                GetController<RoomCtrl>().HideOn();
                SceneManager.LoadScene("InitScene");

                break;
        }
    }

    public void ChangeRoomToFruit()
    {
        roomState = ROOMSTATE_Fruit;
    }

    public void ChangeToMain()
    {
        roomState = ROOMSTATE_Main;
    }

    public bool InFruit()
    {
        return roomState == ROOMSTATE_Fruit;
    }
}