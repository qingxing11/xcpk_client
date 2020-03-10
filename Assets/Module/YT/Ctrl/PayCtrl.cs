using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PayCtrl : BaseController, IHandlerReceive
{
    private int payIndex;

    private UIpay uIpay;
    public override void InitAction()
    {
        uIpay = GetUIPage<UIpay>();
        uIpay.weiXin = SendWeiXin;
        uIpay.zhiFuBao = SendZhiFuBao;
    }

    private void SendZhiFuBao()
    {
        Debug.Log("支付宝支付");

#if UNITY_IPHONE
        //Application.OpenURL("http://47.100.229.107/webpay/pay.html?userId="+CacheManager.gameData.userId);

        GetAliPayWebOrderRequest webRequest = new GetAliPayWebOrderRequest
        {
            payId = payIndex,
        };
        SendMessage(webRequest);
        return;
#endif
        GetAliPayOrderRequest request = new GetAliPayOrderRequest
        {
            payId = payIndex,
        };
        SendMessage(request);
    }

    private void SendWeiXin()
    {


        Debug.Log("微信支付");
        GetWxPayOrderRequest request = new GetWxPayOrderRequest
        {
            payId = payIndex
        };
        SendMessage(request);
    }
     
    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.PAY_微信网页支付下单:
                    ReceiveWxWebPay(response.data);
                    break;

                case MsgType.PAY_支付宝网页支付下单:
                    ReceiveAliWebOrder(response.data);
                    break;

                case MsgType.PAY_支付宝支付下单:

                    ReceiveAliPay(response.data);
                    break;

                case MsgType.PAY_微信支付下单:
                    ReceiveWxPay(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveWxWebPay(byte[] data)
    {
        GetWxWebPayOrderRespone response = MySerializerUtil.DeSerializerFromProtobufNet<GetWxWebPayOrderRespone>(data);
        switch (response.code)
        {
            case GetWxWebPayOrderRespone.SUCCESS:
                Application.OpenURL(response.wxPayOrder);
                break;

            default:
                break;
        }
    }

    private void ReceiveAliWebOrder(byte[] data)
    {
        GetAliPayWebOrderRespone response = MySerializerUtil.DeSerializerFromProtobufNet<GetAliPayWebOrderRespone>(data);
        switch (response.code)
        {
            case GetAliPayWebOrderRespone.SUCCESS:
                Debug.Log("支付宝网页下单成功，打开网页:"+ response.payOrder);
               
                Application.OpenURL(WWW.UnEscapeURL(response.payOrder));
                break;

            default:
                break;
        }
    }

    private void ReceiveWxPay(byte[] data)
    {
        uIpay.Hide();
        GetWxPayOrderRespone response = MySerializerUtil.DeSerializerFromProtobufNet<GetWxPayOrderRespone>(data);
        switch (response.code)
        {
            case GetWxPayOrderRespone.SUCCESS:
                Debug.Log("微信下单成功,wxPayOrder:"+ response.wxPayOrder);
#if UNITY_IPHONE
      
        return;
#endif
                AndroidAndiOS.inst.WxPay(response.wxPayOrder);
                break;

            default:
                Debug.Log("微信下单失败");
                break;
        }
    }

    public void ShowUI(int num,int price,int payIndex)
    {
        uIpay = ShowUI<UIpay>();
        uIpay.SetInfo(num,price);
        this.payIndex = payIndex;
    }

    private void ReceiveAliPay(byte[] data)
    {
        uIpay.Hide();
        GetAliPayOrderRespone response = MySerializerUtil.DeSerializerFromProtobufNet<GetAliPayOrderRespone>(data);
        switch (response.code)
        {
            case GetAliPayOrderRespone.SUCCESS:
                Debug.Log("支付宝下单成功，aliPayOrderInfo:" + response.aliPayOrderInfo);
                AndroidAndiOS.inst.AliPay(response.aliPayOrderInfo.orderInfo);
                break;

            default:
                Debug.Log("支付宝下单失败");
                break;
        }
    }
}