
using ProtoBuf;

[ProtoContract]
public class GglRewardRequest  : Request
{
	public GglRewardRequest()
	{
		msgType = MsgType.GGL_兑奖;
	}
}