using ProtoBuf;

[ProtoContract]
public class EnterKillRoomRequest : Request
{
	public EnterKillRoomRequest()
	{
		msgType = MsgType.KillRoom_进入通杀场;
	}
}
