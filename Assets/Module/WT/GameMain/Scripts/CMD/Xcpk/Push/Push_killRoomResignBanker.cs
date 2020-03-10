using ProtoBuf;

[ProtoContract]

public class Push_killRoomResignBanker : Response
{
	public Push_killRoomResignBanker()
	{
		this.msgType = MsgType.KillRoom_自己下庄;
	}
}
