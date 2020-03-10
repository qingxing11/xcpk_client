using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HornCtrl : BaseController, IHandlerReceive
{
    private UIHornCom uiHornCom;
    public override void InitAction()
    {
        uiHornCom = GetUIPage<UIHornCom>();
        uiHornCom.sendInfo = SendInfo;
    }

    /// <summary>
    /// 发送喇叭消息
    /// </summary>
    /// <param name="info"></param>
    private void SendInfo(string info)
    {
        SendHornInfoRequest request = new SendHornInfoRequest(info);
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.Horn_喇叭消息:
                    SendHornInfoMessage(response.data);
                    break;
                default:
                   return response;
            }
        }

        return null;
    }

    private void SendHornInfoMessage(byte[] data)
    {
        SendHornInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<SendHornInfoResponse>(data);
        switch (response.code)
        {
            case SendHornInfoResponse.SUCCESS:
                CacheManager.AddHorn(response.vo);
                Debug.Log("发送喇叭设置金币.subMoney:"+ response.subMoney);
                if (response.vo.userId == CacheManager.gameData.userId)
                {
                    CacheManager.gameData.coins -= Math.Abs(response.subMoney);
                    GetController<RoomCtrl>().ResSelfCoins();
                }
                

                GetUIPage<UIGlobalNotic>().NoticPlay(response.vo);//广播

                GetController<RoomCtrl>().ShowTxtTitle(response.vo);
               

                GetController<ClassicRoomCtrl>().ShowTxtTitle(response.vo);
                //GetController<ClassicRoomCtrl>().ResSelfCoins();

                GetController<TenThousandRoomCtrl>().ShowTxtTitle(response.vo);

                GetController<MainSceneCtrl>().ShowTxtTitle(response.vo);
                GetController<MainSceneCtrl>().ResSelfCoins();

                GetController<FruitMechineCtrl>().ShowTxtTitle(response.vo);
                GetController<FruitMechineCtrl>().ResSelfCoins();

                if (uiHornCom.isActive())
                {
                    uiHornCom.Hide();
                }
                break;
            case SendHornInfoResponse.Error_金币不足:
                GetController<TxtCtrl>().Show("金币不足！");
                break;
            default:
                break;
        }
    }

    public void ShowUIHornCom()
    {
        ShowUI<UIHornCom>();
    }
}
