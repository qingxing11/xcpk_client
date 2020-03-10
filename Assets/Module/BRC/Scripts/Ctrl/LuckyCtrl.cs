using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 抽奖
/// </summary>
public class LuckyCtrl : BaseController, IHandlerReceive
{
    private UILucky uiLucky;
    public override void InitAction()
    {
        uiLucky = GetUIPage<UILucky>();
        uiLucky.ActionPoint = SendLuckyRequest;
    }

    public void Show()
    {
        ShowUI<UILucky>();
        uiLucky.Init();
    }
    public void SendLuckyRequest()
    {
        LuckyRequest request = new LuckyRequest();
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.LUCKY:
                    ReceiveLucky(response.data);
                    break;


                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveLucky(byte[] data)
    {
        LuckyResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LuckyResponse>(data);
        switch (response.code)
        {
            case LuckyResponse.SUCCESS:
                uiLucky.PlayerRoundAnim(response.luckyNum);
                CacheManager.gameData.isLucky = true;
                break;
            case LuckyResponse.ERROR_当月已经抽取:
                Debug.Log("当月已经抽取过奖励");
                break;
            default:
                break;
        }
    }

    public void Hide()
    {
        if (uiLucky != null && uiLucky.isActive())
        {
            uiLucky.Hide();
        }
    }
}