using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摇钱树
/// </summary>
public class TreeCtrl : BaseController,IHandlerReceive
{
    public UITree uiTree;
    private const int hour = 8;//每隔八个小时领取一次
    private const int baseMoneyInHour = 1000;//基本金币
    private const float baseOutputfficiency = 100 / 100f;//基本效率
    private const int lvAddMoneyInHour = 50;//基本等级增加，每小时增加金币量
    private const int improveLvNeedExp = 20;//提升一等级，需要的经验
    private const int topUpAddExp = 1;//每充值一元增加的经验值
    private const float improveLvAddOutput = 0.01f;//每提升一级增加的产出效率
    private const float improveVipLvAddOutput = 0.2f;//VIp每级增加的产出效率
    //private bool isFirst;
    public override void InitAction()
    {
        uiTree = GetUIPage<UITree>();
        uiTree.getMoney = GetMoney;
    }

    private void GetMoney()
    {
        GetMoneyTreeRequest request = new GetMoneyTreeRequest();
        SendMessage(request);
        Debug.Log(request.ToString());
    }
    private void AskMoneTree()
    {
        AskMonetTreeRequest request = new AskMonetTreeRequest();
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    private void AskMoneTreeNotSend()
    {
        long curTime = MyTimeUtil.GetCurrTimeMM;
        long startTime = CacheManager.gameData.startOutPutTime;
        long money = calculateCurTimeMoney(CacheManager.gameData.treeLv, CacheManager.gameData.vipLv, CacheManager.gameData.playerLevel, curTime, startTime);
        long mm = 8 * 60 * 60 * 1000 - (curTime - startTime);
        mm = mm >= 0 ? mm : 0;
        Debug.Log("askMonetTree,mm:" + mm);
        TimeAndBtnAndMoney(mm,money);
    }

    private long calculateCurTimeMoney(int treeLv, int vipLv, int lv, long lastTime, long startTime)
    {
        long money = 0;
        long margin = lastTime - startTime;
        long hour = margin / 1000 / 60 / 60;

        Debug.Log("当前时间：" + lastTime + ",上次产出时间：" + startTime + "产出时间相差：" + margin + ",相差小时数：" + hour);

        if (hour >= 1)
        {
            hour = hour > 8 ? 8 : hour;

            float effect = baseOutputfficiency + improveVipLvAddOutput * vipLv + (lv) * improveLvAddOutput;
            Debug.Log("效率：" + effect);
            long moneyPre = baseMoneyInHour + (treeLv) * lvAddMoneyInHour;
            Debug.Log("金币：" + money);
            long hourMoney = (long)(moneyPre * effect);
            Debug.Log("calculateCurTimeMoney   -----> hourMoney:" + hourMoney);
            money = hourMoney * hour;
        }
        return money;
    }

    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.MoneyTree_领取:
                    GetMoneyTreeMessage(response.data);
                    break;
                case MsgType.MoneyTree_推送产出:
                  
                    PushMoneyTreeMessage(response.data);
                    break;
                case MsgType.MoneyTree_同步:
                    AskMonetTreeMessage(response.data);
                    break;
                default:
                    return response;
            }
        }

        return null;
    }

    private void AskMonetTreeMessage(byte[] data)
    {
        AskMonetTreeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskMonetTreeResponse>(data);
        switch (response.code)
        {
            case AskMonetTreeResponse.SUCCESS:
                //ShowTime(response.time);
                TimeAndBtnAndMoney(response.time, response.moneyTree);
                break;
            default:
                break;
        }
    }

    private void PushMoneyTreeMessage(byte[] data)
    {
        PushMoneyTreeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushMoneyTreeResponse>(data);
        Debug.Log(response.ToString());
        switch (response.code)
        {
            case PushMoneyTreeResponse.SUCCESS:
                //ShowTime(response.time);
                TimeAndBtnAndMoney(response.time,response.moneyTree);
                break;
            default:
                break;
        }
    }

    private void GetMoneyTreeMessage(byte[] data)
    {
        GetMoneyTreeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetMoneyTreeResponse>(data);
        switch (response.code)
        {
            case GetMoneyTreeResponse.SUCCESS:
                CacheManager.gameData.coins += response.money;
                CacheManager.gameData.startOutPutTime = MyTimeUtil.GetCurrTimeMM;
                //GetController<TxtCtrl>().Show("领取成功！");
                ShowBtnOk(0);
                ShowMoney(0);
                ShowTime(hour * 1000*60*60);
                //UItreeHide();
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(response.money);
                PlayMusic();
                break;
            case GetMoneyTreeResponse.No_Money:
                //UItreeHide();
                //GetController<TxtCtrl>().Show("没有金币可以领取！");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 播放领取音效
    /// </summary>
    private void PlayMusic()
    {
        BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
    }




    private void TimeAndBtnAndMoney(long mm,long money)
    {
        ShowTime(mm);
        ShowBtnOk(money);
        ShowMoney(money);
    }

    private void ShowMoney(long money)
    {
        if (uiTree.isActive())
        {
            uiTree.GetCoin(money);
        }
    }

    private void ShowTime(long mm)
    {
        if (uiTree.isActive())
        {
            uiTree.ShowTime(mm);
        }
    }
    private void ShowBtnOk(long money)
    {
        if (uiTree.isActive())
        {
            uiTree.BtnOk(money);
        }
    }


    private void UItreeHide()
    {
        if (uiTree.isActive())
        {
            uiTree.Hide();
        }
    }

    public void ShowUI()
    {
        ShowUI<UITree>();
        //AskMoneTree();
        AskMoneTreeNotSend();
    }
}
