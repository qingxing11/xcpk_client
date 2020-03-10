
using ProtoBuf;
[ProtoContract]
public class ComparerPokerRequest : Request
{
    [ProtoMember(3)]
    public int pos;
	public ComparerPokerRequest()
	{
		msgType =classic_玩家比牌; 
    }
}
