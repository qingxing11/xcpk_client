using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SignCtrl : BaseController, IHandlerReceive
{
    private UISignInCom uiSignInCom;
    public override void InitAction()
    {
        uiSignInCom = GetUIPage<UISignInCom>();
        uiSignInCom.sign = Sign;
        uiSignInCom.showShopComInVip = ShowShopComInVip;
    }

    /// <summary>
    /// 打开商城界面，并选择VIP模块
    /// </summary>
    private void ShowShopComInVip()
    {
        //Debug.Log("打开商城界面，并选择VIP模块");
        GetController<ShopCtrl>().Show(3);
    }

    private void Sign(int day)
    {
        SignDayRequest request = new SignDayRequest(day);
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.Sign_签到:
                    Debug.Log(response.ToString());
                    SignDayMessage(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void SignDayMessage(byte[] data)
    {
        SignDayResponse response = MySerializerUtil.DeSerializerFromProtobufNet<SignDayResponse>(data);
        //Debug.LogError(response.ToString());
        switch (response.code)
        {
            case SignDayResponse.SUCCESS:
                if (response.sign)
                {
                    int addMoney = 0;
                    if (ConfigManager.Configs.DataVipSign.ContainsKey(CacheManager.gameData.vipLv))
                    {
                        addMoney = ConfigManager.Configs.DataVipSign[CacheManager.gameData.vipLv].AddMoney;
                    }
                    int addCoin = ConfigManager.Configs.DataSign[response.day].AddMoney+ addMoney;
                    CacheManager.gameData.coins += Math.Abs(addCoin);
                    Debug.Log("签到增加金币数："+ addCoin);
                    CacheManager.signList[response.day - 1] = response.sign;
                    CacheManager.todayIsSign = false;
                    //刷新界面
                    Refresh();
                    RefreshList();
                    BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
                    GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(Math.Abs(addCoin));
                    if (uiSignInCom.isActive())
                    {
                        uiSignInCom.BtnCoinIsShow();
                    }
                }
                break;
            default:
                break;
        }
    }

    private void RefreshList()
    {
        if (uiSignInCom.isActive())
        {
            uiSignInCom.RefreshList();
        }
    }

    public void ShowUISignInCom()
    {
        ShowUI<UISignInCom>();
    }

    public void Refresh()
    {
        GetController<MainSceneCtrl>().RefCoinsAndMasonry();
    }
}
