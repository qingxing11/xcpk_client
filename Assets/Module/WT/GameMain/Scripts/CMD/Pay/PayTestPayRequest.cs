using ProtoBuf;

[ProtoContract]
public class PayTestPayRequest : Request
{
    [ProtoMember(3)]
    public int payNum;
	public PayTestPayRequest()
	{
        msgType = MsgType.PAY_TestPay;

    }
	
}