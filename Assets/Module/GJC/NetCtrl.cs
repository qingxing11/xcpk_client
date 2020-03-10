using System;
using UnityEngine;

public class NetCtrl : BaseController, IHandlerReceive
{
    private UINetError uiNetError;
    private UIRanking uiRanking;
    private UIRanking2 uiRanking2;

    public override void InitAction()
    {
        uiNetError = GetUIPage<UINetError>();

        uiRanking = GetUIPage<UIRanking>();
        uiRanking.ActionLingjiang = ShowRanking2UI;


        uiRanking2 = GetUIPage<UIRanking2>();
        uiRanking2.ActionLingqu = SendRankRewardRequest;
    }

    public void ShowUINetError()
    {
        ShowUI<UINetError>();
    }
    public void SendRankingRequest(bool isInit)
    {
        CacheManager.initRanking = isInit;
        RankingRequest request = new RankingRequest();
        SendMessage(request);
    }
    public void ShowRanking2UI(int selectIndex)
    {
        ShowUI<UIRanking2>();
        uiRanking2.Init(selectIndex);
    }
    private void SendRankRewardRequest(int type)
    {
        RankRewardRequest request = new RankRewardRequest
        {
            type=(type+1)%2,
        };
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
 
            switch (response.msgType)
            {
                case MsgType.RANKINGREWARD:
                    ReceiveRankReward(response.data);
                    break;
              
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveRankReward(byte[] data)
    {
        RankRewardResponse response = MySerializerUtil.DeSerializerFromProtobufNet<RankRewardResponse>(data);
        switch (response.code)
        {
            case RankRewardResponse.SUCCESS:
                CacheManager.gameData.coins += response.coins;
                GetController<RoomCtrl>().ResSelfCoins();
              
                BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
                if (response.type == 0)//赢金榜
                {
                    GetController<MessageCtrl>().Show("恭喜获得金币" + response.coins);
                    GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(response.coins);
                    CacheManager.isGetWin = true;
                }
                else if (response.type == 1)//充值榜
                {
                    GetController<MessageCtrl>().Show("恭喜获得金币" + response.coins);
                    GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(response.coins);
                    CacheManager.isGetPay = true;
                }
                uiRanking2.Hide();
                break;
            case RankRewardResponse.ERROR_未上榜:
                Debug.LogError("未上榜");
                break;
            case RankRewardResponse.ERROR_已领取:
                Debug.LogError("你已经领取过奖励");
                GetController<MessageCtrl>().Show("你已经领取过奖励");
                if (response.type == 0)
                {
                    CacheManager.isGetWin = true;
                }
                else if (response.type == 1)
                {
                    CacheManager.isGetPay = true;
                }
                break;
            case RankRewardResponse.ERROR_统计中:
                GetController<MessageCtrl>().Show("排行榜统计中,请稍后领取");
                break;
            default:
                break;
        }
    }
 
}