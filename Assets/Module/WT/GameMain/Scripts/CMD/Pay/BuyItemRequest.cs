using ProtoBuf;

[ProtoContract]
public class BuyItemRequest  : Request
{
    [ProtoMember(3)]
    public int payIndex;
	public BuyItemRequest()
	{
        msgType = MsgType.PAY_BUYITEM;
    }

    public BuyItemRequest(int payIndex)
    {
        msgType = MsgType.PAY_BUYITEM;
        this.payIndex = payIndex;
    }

}