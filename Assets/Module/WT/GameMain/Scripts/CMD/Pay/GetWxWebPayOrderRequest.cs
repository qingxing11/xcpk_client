using ProtoBuf;

[ProtoContract]


public class GetWxWebPayOrderRequest : Request
{
    [ProtoMember(3)]
    public int payId;
	public GetWxWebPayOrderRequest()
	{
		msgType = MsgType.PAY_微信网页支付下单;
	}
	
	public GetWxWebPayOrderRequest(int payId)
	{
		msgType = MsgType.PAY_微信网页支付下单;
		this.payId = payId;
	}
}