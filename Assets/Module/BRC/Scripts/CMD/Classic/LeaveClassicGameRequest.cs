
using ProtoBuf;

[ProtoContract]
public class LeaveClassicGameRequest : Request
{
	public LeaveClassicGameRequest()
	{
		msgType = classic_玩家离开;
	}
}
