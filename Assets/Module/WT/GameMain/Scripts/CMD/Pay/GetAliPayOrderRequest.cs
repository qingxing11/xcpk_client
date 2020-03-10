using ProtoBuf;

[ProtoContract]
public class GetAliPayOrderRequest  : Request
{
    [ProtoMember(3)]
    public int payId;
	public GetAliPayOrderRequest()
	{
		msgType = MsgType.PAY_支付宝支付下单;
	}
	
	public GetAliPayOrderRequest(int payId)
	{
		msgType = MsgType.PAY_支付宝支付下单;
		this.payId = payId;
	}
}