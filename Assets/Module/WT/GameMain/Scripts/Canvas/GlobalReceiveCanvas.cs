using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WT.UI;

public class GlobalReceiveCanvas : IHandlerGlobal
{
    public static GlobalReceiveControl control;
    private static bool isDebug = false;
    public GlobalReceiveCanvas()
    {
        control = new GlobalReceiveControl
        {
            AddEventCancelReConnect = Button_CancelReConnect
        };
    }

    public void LostConnect()
    {
        Debug.Log("LostConnect");
        //BaseCanvas.GetController<NetCtrl>().ShowUINetError();


        ReConnect();
        //control.OnShowServerError("连接服务器失败,请检查网络!");
    }



    public Response RunServerReceive(Response response)
    {
        //Debug.LogWarning("GlobalReceiveCanvas->消息回应:" + response.msgType);
        if (response != null)
        {
            BaseCanvas.GetController<LoadingCtrl>().HideLoading(false) ;

            //Debug.LogWarning("GlobalReceiveCanvas->消息回应:" + response.msgType);
            switch (response.msgType)
            {
                case MsgType.PUSHUSER_另一个设备登录:
                    WTUIPage.ShowPage<UIOtherDeviceLogin>();
                    break;

                case MsgType.PUSHUSER_金币变化:
                    ReceiveChangeCoins(response.data);
                    break;

                case MsgType.PUSHUSER_VIP:
                    ReceiveVip(response.data);
                    break;

                case MsgType.KillRoom_红包公告:
                    ReceiveKillRoomRed(response.data);
                    break;

                case MsgType.Fruit_大赢家:
                    ReceiveFruitBigWin(response.data);
                    break;

                case MsgType.classic_大赢家:
                    ReceiveClassicBigWin(response.data);
                    break;

                case MsgType.manypepol_大赢家:
                    ReceiveMprBigWin(response.data);
                    break;

                case MsgType.KillRoom_大赢家:
                    ReceiveKillRoomBigWin(response.data);
                    break;

                case MsgType.MoneyTree_升级:
                    ReceiveMoneyTree(response.data);
                    break;

                case MsgType.HEARTBEAT_RESPONSECLIENT:
                    break;

                case MsgType.HEARTBEAT:
                    ResponseHearbeat();
                    break;
                case MsgType.NOTICE_服务器准备重启:
                    control.OnShowServerError("服务器重启升级中，请稍后登录重试！");
                    break;
                case MsgType.ASK_推送添加好友:
                    PushAddFriend(response.data);
                    break;
                case MsgType.Info_消息通知:
                    PushInfoMessage(response.data);
                    break;
                case MsgType.SafeBox_某人转账给玩家:
                    PushSafeBoxToOtherMessage(response.data);
                    break;
                case MsgType.Sign_签到数据:
                    PushSignDataMessage(response.data);
                    break;
                case MsgType.Sign_更新签到:
                    PushSignMessage(response.data);
                    break;
                case MsgType.PUSHUSER_等级变化:
                    ReceivePushLevelUP(response.data);
                    break;
                case MsgType.GAME_货币变化:
                    ReceiveGameMoneyChange(response.data);
                    break;

                case MsgType.RANKING:
                    ReceiveRanking(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveRanking(byte[] data)
    {
        RankingResponse response = MySerializerUtil.DeSerializerFromProtobufNet<RankingResponse>(data);
        switch (response.code)
        {
            case RankingResponse.SUCCESS:
                CacheManager.PayRank = response.payRank;
                CacheManager.CoinsRank = response.coinsRank;
                CacheManager.BigWinRank = response.bigWinRank;
                CacheManager.isGetPay = response.isGetPay;
                CacheManager.isGetWin = response.isGetWin;

                if (!CacheManager.initRanking)
                {
                    WTUIPage.ShowPage<UIRanking>();//游戏初始化时获取排行榜数据，此时不需要主动显示该ui
                }
                
                break;
            default:

                break;
        }
    }

    private void ReceiveChangeCoins(byte[] data)
    {
      
        Push_coinsChange response = MySerializerUtil.DeSerializerFromProtobufNet<Push_coinsChange>(data);
        CacheManager.gameData.coins += response.changeNum;
        Debug.Log("金币变化，值:" + response.changeNum);
        BaseCanvas.GetController<RoomCtrl>().RefreshCoin();

        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
         
        BaseCanvas.GetController<ShopCtrl>().RefreshGoldAndCry();
    }

    private void ReceiveVip(byte[] data)
    {
        Push_vipLevel response = MySerializerUtil.DeSerializerFromProtobufNet<Push_vipLevel>(data);
        CacheManager.gameData.vipLv = response.vipLevel;

        WTUIPage.GetUIPage<UIShop>().RefreshVip();
        BaseCanvas.GetController<MainSceneCtrl>().SetVip();
    }

    private void ReceiveKillRoomRed(byte[] data)
    {
        Push_killRoomRedEnvelope response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomRedEnvelope>(data);

        
             string info = "\"" + response.nickName + "\"" + "在通杀场大撒" + LongConverStr(response.value)+ "红包，真是大善人!";

        BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
        BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
        BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
        BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info);
    }

    private void ReceiveFruitBigWin(byte[] data)
    {
        GameCanvas.gameCanvas.StartCoroutine(FruitBigWinCoroutine(data));

        
    }

    private IEnumerator FruitBigWinCoroutine(byte[] data)
    {
        yield return new WaitForSeconds(15);
        FruitPush_bigWin response = MySerializerUtil.DeSerializerFromProtobufNet<FruitPush_bigWin>(data);
        Debug.Log("esponse.list_KillRoomNoticVO:" + response.list_KillRoomNoticVO.GetString());
        if (response.list_KillRoomNoticVO != null && response.list_KillRoomNoticVO.Count > 0)
        {
            string info = "水果机报喜：恭喜";
            foreach (var item in response.list_KillRoomNoticVO)
            {

                info += "\"" + item.nickName + "\"赢" + LongConverStr(item.score) + "金,";
            }
            info += "羡煞旁人！";

            BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info); ;
        }
    }

    private void ReceiveClassicBigWin(byte[] data)
    {
        ClassicGamePush_bigWin response = MySerializerUtil.DeSerializerFromProtobufNet<ClassicGamePush_bigWin>(data);
        if (response.killRoomNoticVO != null)
        {
            string info ="\"" + response.killRoomNoticVO.nickName + "\"" + "在土豪场大发神威，一把赢了" + LongConverStr(response.killRoomNoticVO.score);

            BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info);
        }
    }

    private void ReceiveMprBigWin(byte[] data)
    {
        ManyPepolPush_bigWin response = MySerializerUtil.DeSerializerFromProtobufNet<ManyPepolPush_bigWin>(data);
        if (response.killRoomNoticVO != null)
        {
            string info = "恭喜"+"\""+ response.killRoomNoticVO.nickName+ "\""+"在万人场大杀四方一把赢了"+ LongConverStr(response.killRoomNoticVO.score) + "金币，令对手闻风丧胆！";

            BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
            BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info);
        }

    }

    private void ReceiveKillRoomBigWin(byte[] data)
    {
        GameCanvas.gameCanvas.StartCoroutine(KillRoomBigWinCoroutine(data));
    }

    private IEnumerator KillRoomBigWinCoroutine(byte[] data)
    {
        yield return new WaitForSeconds(8);
        Push_killRoomBigWin response = MySerializerUtil.DeSerializerFromProtobufNet<Push_killRoomBigWin>(data);
        //Debug.Log("中奖提示:" + response.list_noticWin.GetString());
        if (response.list_noticWin != null && response.list_noticWin.Count > 0)
        {
            string info = "通杀场喜报：恭喜";
            bool isSend = false;
            foreach (var item in response.list_noticWin)
            {
                if (CacheManager.banker != null && CacheManager.banker.userId == item.userId)//是庄家
                {
                    continue;
                }
                isSend = true;
                info += "\"" + item.nickName + "\"赢" + LongConverStr(item.score) + "金,";
            }
            info += "羡煞旁人！";


            if (isSend)
            {
                Debug.Log("闲家中奖提示=" + info);
                BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
                BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
                BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
                BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info);
            }


            if (CacheManager.banker != null)
            {
                foreach (var item in response.list_noticWin)
                {
                    if (CacheManager.banker.userId == item.userId)
                    {
                        info = "恭喜庄家\"" + item.nickName + "\"在通杀场爆发，一把赢取" + LongConverStr(item.score) + "金";

                        BaseCanvas.GetController<RoomCtrl>().ShowTxtTitle(info);
                        BaseCanvas.GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
                        BaseCanvas.GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
                        BaseCanvas.GetController<FruitMechineCtrl>().ShowTxtTitle(info);
                        break;
                    }
                }
            }

        }
    }

    public static string LongConverStr(long num)
    {
        bool numLess = false;
        if (num < 0)
        {
            num = -num;
            numLess = true;
        }
        string str = "";
        if (num > 100000000)
        {
            long num3 = num / 100000000;
            long num4 = (num - num3 * 100000000) / 10000000;
            if (num4 == 0)
                str = num3 + "亿";
            else
                str = num3 + "." + num4 + "亿";

        }
        else if (num > 10000)
        {
            long num3 = num / 10000;
            long num4 = (num - num3 * 10000) / 1000;

            if (num4 == 0)
                str = num3 + "W";
            else
                str = num3 + "." + num4 + "W";
        }
        else
        {
            str = num.ToString();
        }
        if (numLess)
        {
            str = "-" + str;
        }
        return str;
    }
    private void ReceiveMoneyTree(byte[] data)
    {
        PushMoneyTreeLvResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushMoneyTreeLvResponse>(data);
        CacheManager.gameData.treeLv = response.treeLv;
    }

    private void PushSignMessage(byte[] data)
    {
        PushSignResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushSignResponse>(data);
        switch (response.code)
        {
            case PushSignResponse.SUCCESS:
                CacheManager.todayIsSign = response.todayIsSign;
                ////刷新界面
                //BaseCanvas.GetController<SignCtrl>().Refresh();
                break;
            default:
                break;
        }
    }
    private void ReceivePushLevelUP(byte[] data)
    {
        Push_LevelUP response = MySerializerUtil.DeSerializerFromProtobufNet<Push_LevelUP>(data);
        CacheManager.gameData.playerLevel = response.level;
        CacheManager.gameData.exp = response.exp;
    }

    private void ReceiveGameMoneyChange(byte[] data)
    {
        Push_GameMoneyChange response = MySerializerUtil.DeSerializerFromProtobufNet<Push_GameMoneyChange>(data);

        if (response.moneyType == Push_GameMoneyChange.MONEYTYPE_COIN)
        {
            if (response.subType == Push_GameMoneyChange.STATE_ADD)
            {
                CacheManager.gameData.coins += response.curNum + response.changeNum;
            }
            else
            {
                CacheManager.gameData.coins -= response.curNum + response.changeNum;
            }
        }
        if (response.moneyType == Push_GameMoneyChange.MONEYTYPE_CRYTSTAL)
        {
            if (response.subType == Push_GameMoneyChange.STATE_ADD)
            {
                CacheManager.gameData.crystals += response.curNum + response.changeNum;
            }
            else
            {
                CacheManager.gameData.crystals -= response.curNum + response.changeNum;
            }
        }
        //刷新界面
        //刷新主界面
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        //通杀场
        BaseCanvas.GetController<RoomCtrl>().ResSelfCoins();
        //经典场
        BaseCanvas.GetController<ClassicRoomCtrl>().RefreshCoin();
        //水果机
        BaseCanvas.GetController<FruitMechineCtrl>().ResSelfCoins();
        //万人场
        BaseCanvas.GetController<TenThousandRoomCtrl>().RefreshCoin();

        BaseCanvas.GetController<ShopCtrl>().RefreshGoldAndCry();
    }

    private void PushSignDataMessage(byte[] data)
    {
        PushSignDataResponse response =MySerializerUtil.DeSerializerFromProtobufNet<PushSignDataResponse>(data);
        switch (response.code)
        {
            case PushSignDataResponse.SUCCESS:
 
                CacheManager.InitSignList(response.list);
                CacheManager.todayIsSign = response.todayIsSign;
                //刷新界面
                BaseCanvas.GetController<SignCtrl>().Refresh();
                break;
            default:
                break;
        }

    }

    private void PushSafeBoxToOtherMessage(byte[] data)
    {
        PushSafeBoxToOtherResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushSafeBoxToOtherResponse>(data);
        switch (response.code)
        {
            case PushSafeBoxToOtherResponse.SUCCESS:
                List<SafeBoxRecordVO> po = response.po;
                CacheManager.transferAccountsPer = response.transferAccountsPer;

                if (po==null)
                {
                    return;
                }
                foreach (SafeBoxRecordVO item in po)
                {
                    CacheManager.AddSafeBoxRecord(item);
                }

                BaseCanvas.GetController<SafeBoxCtrl>().RefreshRecord();
                //List<string> info = new List<string>();
                foreach (var vo in po)
                {
                    //string infoss = "对方" + vo.userId + "在" + MyTimeUtil.TimeToStringS(vo.time) + "时间给我转了：" + vo.money + "钱";
                    //info.Add(infoss);

                    if (!response.show)
                    {
                        CacheManager.gameData.coins += vo.money;
                         Debug.Log("转账加上+"+ vo.money);
                        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                    }
                }

                //BaseCanvas.GetController<TxtCtrl>().Show(info);
                break;
            default:
                break;
        }
    }

    private void PushInfoMessage(byte[] data)
    {
        PushFriendsInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushFriendsInfoResponse>(data);
        switch (response.code)
        {
            case PushFriendsInfoResponse.SUCCESS:
                //List<FriendInfoVO> list = response.info;
                //if (list == null || list.Count == 0)
                //{
                //    return;
                //}
                //foreach (FriendInfoVO vo in list)
                //{
                //    CacheManager.AddFriendsInfo(vo);
                //}
                //BaseCanvas.GetController<FriendCtrl>().RefrashInfoList();
                //BaseCanvas.GetController<MainSceneCtrl>().ShowIcon(CacheManager.ShowIcon());
                break;
            default:
                break;
        }
    }

    private void PushAddFriend(byte[] data)
    {
 
        PushAddFriendsEventResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushAddFriendsEventResponse>(data);
        switch (response.code)
        {
            case PushAddFriendsEventResponse.SUCCESS:
                List<AddFriendsVO> list = response.list;
                if (list==null||list.Count==0)
                {
                    return;
                }
                foreach (AddFriendsVO vo in list)
                {
                    CacheManager.AddFriendEvent(vo);
                }
                BaseCanvas.GetController<FriendCtrl>().RefrashInfoList();
                BaseCanvas.GetController<MainSceneCtrl>().ShowIcon(CacheManager.ShowIcon());
                break;
            default:
                break;
        }
    }

 

    private void Button_CancelReConnect()
    {

        //ReConnect();
    }

    private void ResponseHearbeat()
    {
        Request request = new Request
        {
            msgType = -999,
        };
        NetWorkClient.sendRequest(request);
    }


    private void ReConnect()
    {

        Debug.Log("AutoReConnect : " + SceneManager.GetActiveScene().name);

#if !UNITY_IOS
        NetWorkClient.Disconnect();
#endif

        SendReconenct();
    }

    public void SendReconenct()
    {
        NetWorkClient.InitConnect(InitGameCanvas.ClientConfig.gameIp, InitGameCanvas.ClientConfig.gamePort, InitGameCanvas.ClientConfig.serializerUtil);
        PlayerReConnectRequest request = new PlayerReConnectRequest
        {
            tokenVO = CacheManager.tokenVO,
            isPing = true,

        };
        bool isSuccess = NetWorkClient.sendRequest(request);
        Debug.Log("isSuccess:"+ isSuccess);
        if (!isSuccess)
        {
            BaseCanvas.GetController<NetCtrl>().ShowUINetError();
        }
    }
}