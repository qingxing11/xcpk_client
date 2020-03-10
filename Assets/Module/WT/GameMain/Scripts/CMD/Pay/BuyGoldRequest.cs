using ProtoBuf;

[ProtoContract]
public class BuyGoldRequest  : Request
{
    [ProtoMember(3)]
    public int payIndex;
	public BuyGoldRequest()
	{
        msgType = MsgType.PAY_BUYGOLD;
	}
     
    public BuyGoldRequest(int payIndex)
    {
        msgType = MsgType.PAY_BUYGOLD;
        this.payIndex = payIndex;
    }
}