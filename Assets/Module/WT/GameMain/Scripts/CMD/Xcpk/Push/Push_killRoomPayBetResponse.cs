using ProtoBuf;

[ProtoContract]
public class Push_killRoomPayBetResponse : Response
{
    [ProtoMember(5)]
    public int userId;

    /// <summary>
    /// 东西南北
    /// </summary>
    [ProtoMember(6)]
    public int payPos;

    [ProtoMember(7)]
    public int payNum;
	
	public Push_killRoomPayBetResponse()
	{
        this.msgType = MsgType.KillRoom_其他玩家下注;
	}
 
}
