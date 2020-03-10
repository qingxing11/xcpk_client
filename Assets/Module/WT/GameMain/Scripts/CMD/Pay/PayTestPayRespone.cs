using ProtoBuf;

[ProtoContract]
public class PayTestPayRespone : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int reward;
	public PayTestPayRespone() {
        msgType = MsgType.PAY_TestPay;
    }
     
}