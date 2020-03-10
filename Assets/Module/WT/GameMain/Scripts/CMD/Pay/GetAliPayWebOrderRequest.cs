using ProtoBuf;

[ProtoContract]
public class GetAliPayWebOrderRequest  : Request
{
    [ProtoMember(3)]
    public int payId;
	public GetAliPayWebOrderRequest()
	{
		msgType = MsgType.PAY_支付宝网页支付下单;
	}
	
	public GetAliPayWebOrderRequest(int payId)
	{
		msgType = MsgType.PAY_支付宝网页支付下单;
		this.payId = payId;
	}
}