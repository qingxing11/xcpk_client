using ProtoBuf;

[ProtoContract]
public class BuyItemRespone : Response
{
	 
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int payIndex;
	public BuyItemRespone() {
        msgType = MsgType.PAY_BUYITEM;
    }
	 
}