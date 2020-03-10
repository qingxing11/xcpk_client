using ProtoBuf;

[ProtoContract]
public class Push_killRoomRedEnvelope : Response
{
    [ProtoMember(5)]
    public string nickName;

    [ProtoMember(6)]
    public long value;
	
	public Push_killRoomRedEnvelope()
	{
		this.msgType = MsgType.KillRoom_红包公告;
	}
	
 

	 
	public override string ToString()
	{
		return "Push_killRoomRedEnvelope [msgType=" + msgType + "]";
	}
}
