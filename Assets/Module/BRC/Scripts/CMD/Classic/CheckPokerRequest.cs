using ProtoBuf;

[ProtoContract]
public class CheckPokerRequest : Request
{
	public CheckPokerRequest()
	{
		msgType = classic_玩家看牌;
	}
}
