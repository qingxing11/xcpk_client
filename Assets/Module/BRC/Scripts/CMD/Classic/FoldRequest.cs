using ProtoBuf;

[ProtoContract]
public class FoldRequest : Request
{
	public FoldRequest()
	{
		msgType = classic_玩家弃牌;
	}
}
