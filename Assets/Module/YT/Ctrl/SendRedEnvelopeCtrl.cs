using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
public class SendRedEnvelopeCtrl : BaseController, IHandlerReceive
{
    private int redState = 1;
    private const int SendRedEnveloped = 1; // 发红包结束
    private const int SendRedEnveloping = 2; // 发红包中

    private UIRedEnvelope uIRedEnvelope;//打开发红包界面
    private ShowTips showTips;//飘字
    private List<UIClickRedEnvelope> list_clickRedEnvelope = new List<UIClickRedEnvelope>();
    public override void InitAction()
    {
        uIRedEnvelope = GetUIPage<UIRedEnvelope>();
        uIRedEnvelope.sendRedEnvelope = SendRedEnvelopeToServer;

        showTips = GetUIPage<ShowTips>();
    }

    private void SendRedEnvelopeToServer(int userId, int coins)
    {
        PlayerSimpleData banker = CacheManager.banker;
        if (banker == null || banker.userId != userId)
        {
            GetController<MessageCtrl>().Show("您不是当前庄家 不能发红包！");
            return;
        }
        if (banker.coins < coins)
        {
            Debug.Log("庄家的金币数量为 ：" + banker.coins);
            BaseCanvas.GetController<MessageCtrl>().Show("您当前的余额不够发红包 ！");
            return;
        }
        if (redState == SendRedEnveloping)
        {
            BaseCanvas.GetController<MessageCtrl>().Show("当前红包未被抢完 不能发红包！");

            return;
        }
       // banker.coins -= coins;
        KillRoomSendRedEnvelopeRequest request = new KillRoomSendRedEnvelopeRequest(userId, coins);
        SendMessage(request);
        Debug.Log("玩家 userId :" + userId + ",发红包金额 coins:" + coins);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.KillRoom_发红包:
                    ReciveRedEnvelopeInfo(response.data);
                    break;
                case MsgType.KillRoom_抢红包:
                    ReciveGardRenEnvelopeInfo(response.data);
                    break;
                case MsgType.KillRoom_抢红包结束:
                    ReciveGardRenEnvelopeOverInfo(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReciveGardRenEnvelopeOverInfo(byte[] data)
    {
        KillRoomSendRedEnvelopeOverResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomSendRedEnvelopeOverResponse>(data);
        if (list_clickRedEnvelope!=null&&list_clickRedEnvelope.Count>0)
        {
            for (int i = 0; i < list_clickRedEnvelope.Count; i++)
            {
                list_clickRedEnvelope[i].Hide();
            }
        }
        redState = SendRedEnveloped;
    }

    private void ReciveGardRenEnvelopeInfo(byte[] data)
    {
        KillRoomGardRedEnvelopeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomGardRedEnvelopeResponse>(data);
        switch (response.code)
        {
            case KillRoomGardRedEnvelopeResponse.SUCCESS:
                SetGardRenEnvelopeInfo(response.userId, response.redEnvelope);
                break;
            case KillRoomGardRedEnvelopeResponse.您的手慢了_当前红包被抢走了:
                GetController<MessageCtrl>().Show("您的手慢了_当前红包被抢走了");
                break;
            case KillRoomGardRedEnvelopeResponse.您的手慢了_红包已被抢完:
                GetController<MessageCtrl>().Show("您的手慢了_红包已被抢完");
                break;
            case KillRoomGardRedEnvelopeResponse.请求错误_您当前抢的红包不存在:
                GetController<MessageCtrl>().Show("请求错误_您当前抢的红包不存在");
                break;
            default:
                break;
        }
    }

    private void SetGardRenEnvelopeInfo(int userId, RedEnvelopeInfo redEnvelope)
    {
        foreach (UIClickRedEnvelope item in list_clickRedEnvelope)
        {
            if (redEnvelope.redEnvelopeIndex == item.redEnvelopeIndex)
            {
                item.Hide();
                break;
            }
        }
        if (CacheManager.gameData.userId == userId)
        {
            //GetController<FruitMechineCtrl>().ShowTips("金币+" + redEnvelope.redEnvelopeValue);
            showTips = ShowUI<ShowTips>();
            showTips.ShowCoins(redEnvelope.redEnvelopeValue);
            CacheManager.gameData.coins += redEnvelope.redEnvelopeValue;

            //调用通杀场刷新金币的方法
            GetController<RoomCtrl>().ResSelfCoins();
            BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        }
    }
    public void HideAllRed()
    {
        if (list_clickRedEnvelope != null && list_clickRedEnvelope.Count > 0)
        {
            for (int i = 0; i < list_clickRedEnvelope.Count; i++)
            {
                list_clickRedEnvelope[i].Hide();
            }
        }
    }
    private void ReciveRedEnvelopeInfo(byte[] data)
    {
        KillRoomSendRedEnvelopeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<KillRoomSendRedEnvelopeResponse>(data);
        switch (response.code)
        {
            case KillRoomSendRedEnvelopeResponse.SUCCESS:
                if(CacheManager.gameData.userId==response.userId)
                    GetController<MessageCtrl>().Show("发红包成功！");
                //Debug.LogError("发红包成功发红包的id:" + response.userId);
                //Debug.LogError("CacheManager.RunRoomId:" + CacheManager.RunRoomId+ ".CacheManager.KillRoomTV ：" + CacheManager.KillRoomTV);
                if (CacheManager.RunRoomId == 0 && CacheManager.KillRoomTV == 0)
                {
                    redState = response.redEnvelopeState;
                    SetRedEnvelopeInfo(response.redEnvelopeInfo, response.userId);
                }
                break;
            case KillRoomSendRedEnvelopeResponse.玩家金币不足:
                PlayerSimpleData banker = CacheManager.banker;
                if (banker == null || banker.userId != CacheManager.gameData.userId)
                {
                    return;
                }
                GetController<MessageCtrl>().Show("您当前的金币不足红包金额！");
                break;
            case KillRoomSendRedEnvelopeResponse.您不是当前庄家_不能发红包:
                GetController<MessageCtrl>().Show("您不是当前庄家_不能发红包！");
                break;
            case KillRoomSendRedEnvelopeResponse.本轮红包未结束_不能发红包:
                GetController<MessageCtrl>().Show("本轮红包未结束_不能发红包！");
                break;
            default:
                break;
        }
    }

    private void SetRedEnvelopeInfo(List<RedEnvelopeInfo> redEnvelopeInfos, int userId)
    {
        list_clickRedEnvelope.Clear();
        if (userId != CacheManager.gameData.userId)
        {
            for (int i = 0; i < redEnvelopeInfos.Count; i++)
            {
                UIClickRedEnvelope uIClickRedEnvelope = uIRedEnvelope.ReturnUIClickRedEnvelope(i);
                uIClickRedEnvelope.SetRedIndexAndValue(redEnvelopeInfos[i].redEnvelopeIndex, redEnvelopeInfos[i].redEnvelopeValue);
                uIClickRedEnvelope.sendGardRedEnvelope = SendGardRedEnvelope;
                list_clickRedEnvelope.Add(uIClickRedEnvelope);
                Vector3 startPos = ReturnStartPos();
                Vector3 endPos = ReturnEndPos();
                uIClickRedEnvelope.SetPosition(startPos.x, startPos.y, startPos.z);
                uIClickRedEnvelope.Move(endPos);
            }
        }

        if (userId == -1)
        {
            return;
        }
        if (CacheManager.gameData.userId == userId)
        {
            long value = 0;
            foreach (RedEnvelopeInfo item in redEnvelopeInfos)
            {
                value += item.redEnvelopeValue;
            }
            CacheManager.gameData.coins -= value;
            GetController<RoomCtrl>().ResSelfCoins();
        }
    }



    public Vector3 ReturnStartPos()
    {
        int x1 = UnityEngine.Random.Range(-200, 0);
        int x2 = UnityEngine.Random.Range(0, 800);
        int x3 = UnityEngine.Random.Range(800, 1000);
        int y1 = UnityEngine.Random.Range(-200, 0);
        int y2 = UnityEngine.Random.Range(0, 480);
        int y3 = UnityEngine.Random.Range(480, 680);
        int ran = UnityEngine.Random.Range(0, 8);
        switch (ran)
        {
            case 0:
                return new Vector3(x1, y1, 0);
            case 1:
                return new Vector3(x1, y2, 0);
            case 2:
                return new Vector3(x1, y3, 0);
            case 3:
                return new Vector3(x2, y1, 0);
            case 4:
                return new Vector3(x2, y3, 0);
            case 5:
                return new Vector3(x3, y1, 0);
            case 6:
                return new Vector3(x3, y2, 0);
            case 7:
                return new Vector3(x3, y3, 0);
            default:
                break;
        }
        return Vector3.zero;
    }



    public Vector3 ReturnEndPos()
    {
        int x = UnityEngine.Random.Range(0 + 100, 800 - 100);
        int y = UnityEngine.Random.Range(0 + 100, 480 - 100);
        return new Vector3(x, y, 0);
    }
    private void SendGardRedEnvelope(int redEnvelopeIndex, long redEnvelopeValue)
    {
        KillRoomGardRedEnvelopeRequest request = new KillRoomGardRedEnvelopeRequest(redEnvelopeIndex, redEnvelopeValue);
        Debug.Log("抢到红包 ：" + request.ToString());
        SendMessage(request);
    }

    public void ShowSendRedEnvelope(int userId)
    {
        if (redState == SendRedEnveloping)
        {
            GetController<MessageCtrl>().Show("当前红包未被抢完 不能发红包！");
            return;
        }
        Debug.Log("redState :" + redState);
        uIRedEnvelope.SetUserIdPanle(userId);
        uIRedEnvelope = ShowUI<UIRedEnvelope>();
    }
}