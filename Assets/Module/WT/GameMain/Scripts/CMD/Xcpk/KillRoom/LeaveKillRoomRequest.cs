using ProtoBuf;

[ProtoContract]
public class LeaveKillRoomRequest : Request
{
	public LeaveKillRoomRequest()
	{
        msgType = MsgType.KillRoom_离开通杀场;
	}
}
