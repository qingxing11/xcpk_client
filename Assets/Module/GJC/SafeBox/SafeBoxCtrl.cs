using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SafeBoxCtrl : BaseController, IHandlerReceive
{
    private UISafeBox uiSafeBox;
    private bool first=false;

    private UISafeBoxCom2 uiSafeBoxCom2;
    public override void InitAction()
    {
        uiSafeBox = GetUIPage<UISafeBox>();
        uiSafeBox.depositSafeBox = DepositSafeBox;
        uiSafeBox.fetchSafeBox = FetchSafeBox;
        uiSafeBox.transferSafeBox = TransferSafeBox;
        uiSafeBox.transferSureSafeBox = TransferSureSafeBox;

        uiSafeBoxCom2= GetUIPage<UISafeBoxCom2>();
        uiSafeBoxCom2.fetchSafeBox = FetchSafeBox;
    }


    /// <summary>
    /// 通杀场保险箱界面
    /// </summary>
    public void ShowUISafeBoxCom2()
    {
        ShowUI<UISafeBoxCom2>();
    }

    /// <summary>
    /// 确认转账
    /// </summary>
    /// <param name="userId"></param>
    private void TransferSureSafeBox(int userId)
    {
        SafeBoxTransferSureRequest request = new SafeBoxTransferSureRequest(userId);
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    /// <summary>
    /// 转账
    /// </summary>
    /// <param name="id"></param>
    /// <param name="money"></param>
    private void TransferSafeBox(int id, long money)
    {
        SafeBoxTransferRequest request = new SafeBoxTransferRequest(id,CacheManager.gameData.userId,money*CacheManager.unitCoin);
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    /// <summary>
    /// 取出金币
    /// </summary>
    /// <param name="obj"></param>
    private void FetchSafeBox(long money)
    {
        //发送消息
        TakeOutSafeBoxRequest request = new TakeOutSafeBoxRequest(CacheManager.gameData.userId, money * CacheManager.unitCoin);
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    /// <summary>
    /// 存入银行
    /// </summary>
    /// <param name="money"></param>
    private void DepositSafeBox(long money)
    {
        //bool inRoom = GetController<RoomCtrl>().InRoom();
        //if (inRoom)
        //{
        //    Debug.LogError("通杀场界面打开！");
        //    GetController<TxtCtrl>().Show("通杀场界面不能存入！");
        //    return;
        //}
        SendDepositSafeBox(money);
    }

    private void SendDepositSafeBox(long money)
    {
        //发送消息
        DepositSafeBoxRequest request = new DepositSafeBoxRequest(CacheManager.gameData.userId, money * CacheManager.unitCoin);
        SendMessage(request);
        Debug.Log(request.ToString());
    }

    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.SafeBox_存入银行:
                    DepositSafeBoxMessage(response.data);
                    break;
                case MsgType.SafeBox_取出银行:
                    FetchSafeBoxMessage(response.data);
                    break;
                case MsgType.SafeBox_游戏币转账:
                    SafeBoxTransferMessage(response.data);
                    break;
                case MsgType.SafeBox_游戏币转账确认:
                    SafeBoxTransferSureMessage(response.data);
                    break;
                case MsgType.SafeBox_银行记录:
                    AskSafeBoxRecordMessage(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void AskSafeBoxRecordMessage(byte[] data)
    {
        AskSafeBoxRecordResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskSafeBoxRecordResponse>(data);
        switch (response.code)
        {
            case AskSafeBoxRecordResponse.SUCCESS:
                CacheManager.AddSafeBoxRecord(response.list);
                break;
            case AskSafeBoxRecordResponse.ERROR_UNKNOWN:
                //Debug.Log("操作记录没有！！！！");
                break;
            default:
                break;
        }
    }

    private void SafeBoxTransferSureMessage(byte[] data)
    {
        SafeBoxTransferSureResponse response = MySerializerUtil.DeSerializerFromProtobufNet<SafeBoxTransferSureResponse>(data);
        switch (response.code)
        {
            case SafeBoxTransferSureResponse.SUCCESS:
                CacheManager.gameData.coins -= (long)(response.money*(1+ response.pre));
                SafeBoxRecordVO vo = new SafeBoxRecordVO(CacheManager.gameData.userId,response.otherId,response.money,response.time,response.type,response.pre);
                CacheManager.AddSafeBoxRecord(vo);
                ShowChange();
                GetController<TxtCtrl>().Show("转账成功！！！");
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                GetController<RoomCtrl>().RefreshCoin();
                Debug.Log("转账成功！！！"+"剩余金币："+ CacheManager.gameData.coins+"，减少金币："+((long)(response.money * (1 + response.pre))));
                break;
            case SafeBoxTransferSureResponse.ERROR_UNKNOWN:
                GetController<TxtCtrl>().Show("转账失败！！！！");
                //Debug.Log("转账失败！！！！");
                break;
            case SafeBoxTransferSureResponse.Error_金额不足:
                GetController<TxtCtrl>().Show("转账失败,余额不足！");
                break;
            default:
                break;
        }
    }

    private void ShowChange()
    {
        if (uiSafeBox.isActive())
        {
            uiSafeBox.TranfeSusShow();
        }
    }



    private void SafeBoxTransferMessage(byte[] data)
    {
        SafeBoxTransferResponse response = MySerializerUtil.DeSerializerFromProtobufNet<SafeBoxTransferResponse>(data);
        switch (response.code)
        {
            case SafeBoxTransferResponse.SUCCESS:
                ShowSureTransfer(response.otherNike,response.otherId, response.transferCoins);
                break;
            case SafeBoxTransferResponse.ERROR_UNKNOWN:
                //Debug.Log("转账失败！！！！");
                GetController<TxtCtrl>().Show("转账失败！！！！");
                break;
            case SafeBoxTransferResponse.Error_暂无转账功能:
                GetController<TxtCtrl>().Show("暂无转账功能！vip客户拥有");
                break;
            case SafeBoxTransferResponse.Error_转给自己:
                GetController<TxtCtrl>().Show("请输入正确账号！");
                break;
            default:
                break;
        }
    }

    private void FetchSafeBoxMessage(byte[] data)
    {
        TakeOutSafeBoxResponse response = MySerializerUtil.DeSerializerFromProtobufNet<TakeOutSafeBoxResponse>(data);
        switch (response.code)
        {
            case TakeOutSafeBoxResponse.SUCCESS:
                CacheManager.gameData.coins += response.money;
                CacheManager.gameData.bankCoins -= response.money;
                RefreshMyBox();
                GetController<TxtCtrl>().Show("取出成功!");
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                GetController<RoomCtrl>().RefreshCoin();
                break;
            case TakeOutSafeBoxResponse.ERROR_UNKNOWN:
                GetController<TxtCtrl>().Show("取出失败!");
                //Debug.Log("取出失败！！！！");
                break;
            default:
                break;
        }
    }

    private void DepositSafeBoxMessage(byte[] data)
    {
        DepositSafeBoxResponse response = MySerializerUtil.DeSerializerFromProtobufNet<DepositSafeBoxResponse>(data);
        switch (response.code)
        {
            case DepositSafeBoxResponse.SUCCESS:
                CacheManager.gameData.coins -= response.money;
                CacheManager.gameData.bankCoins += response.money;
                RefreshMyBox();
                GetController<TxtCtrl>().Show("存入成功");
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                GetController<RoomCtrl>().RefreshCoin();
                break;
            case DepositSafeBoxResponse.ERROR_UNKNOWN:
                //Debug.Log("存入失败！！！！");
                GetController<TxtCtrl>().Show("存入失败!");
                break;
            case DepositSafeBoxResponse.Error_暂无银行功能:
                GetController<TxtCtrl>().Show("暂无银行功能！vip客户拥有！");
                break;
            case DepositSafeBoxResponse.Error_存入超过上线:
                GetController<TxtCtrl>().Show("超过（当前VIP等级）银行存入上限！");
                break;
            default:
                break;
        }
    }

    public void ShowSureTransfer(string nikeName, int userId, long transferCoins)
    {
        if (uiSafeBox.isActive())
        {
            uiSafeBox.ShowSureTransfer(nikeName, userId, transferCoins);
        }
    }

    public void RefreshMyBox()
    {
        if (uiSafeBox.isActive())
        {
            uiSafeBox.RefreshMyBox();
        }
    }
    public void RefreshRecord()
    {
        if (uiSafeBox.isActive())
        {
            uiSafeBox.RefreshRecord();
        }
    }



    public void RefreshCoin()
    {
        if (uiSafeBoxCom2.isActive())
        {
            uiSafeBoxCom2.OnClickMyBox();
        }
    }

    public void ShowUISafeBox()
    {
        ShowUI<UISafeBox>();
        if (!first)
        {
            AskSafeBoxRecord();
        }
    }

    private void AskSafeBoxRecord()
    {
        AskSafeBoxRecordRequest request = new AskSafeBoxRecordRequest(CacheManager.gameData.userId);
        SendMessage(request);
        Debug.Log(request.ToString());
    }
}
