using ProtoBuf;

[ProtoContract]
public class AllInRequest : Request
{
	public AllInRequest()
	{
		msgType = classic_玩家全压;
	}
}
