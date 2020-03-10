using ProtoBuf;

[ProtoContract]
public class KillRoomPayBetRequest : Request
{
    [ProtoMember(3)]
    public int pos;

    [ProtoMember(4)]
    public int chipNum;
	public KillRoomPayBetRequest()
	{
		msgType = MsgType.KillRoom_通杀场下注;
	}
}
