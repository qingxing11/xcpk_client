using ProtoBuf;

[ProtoContract]

public class KillRoomPayBetResponse : Response
{
    public const int ERROR_金币不足 = 0;
    public const int ERROR_单边下注超标 = 1;

    [ProtoMember(4)]
    public int code;

    /// <summary>
    /// 结束位置
    /// </summary>
    [ProtoMember(5)]
    public int pos;

    [ProtoMember(6)]
    public int chipNum;
	
	public KillRoomPayBetResponse()
	{
		msgType = MsgType.KillRoom_通杀场下注;
	}
}
