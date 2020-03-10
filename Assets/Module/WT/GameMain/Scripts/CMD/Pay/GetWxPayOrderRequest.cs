using ProtoBuf;

[ProtoContract]

public class GetWxPayOrderRequest  : Request
{
    [ProtoMember(3)]
    public int payId;
	public GetWxPayOrderRequest()
	{
		msgType = MsgType.PAY_微信支付下单;
	}
	
	public GetWxPayOrderRequest(int payId)
	{
		msgType = MsgType.PAY_微信支付下单;
		this.payId = payId;
	}
}