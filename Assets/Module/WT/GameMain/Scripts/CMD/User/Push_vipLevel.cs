using ProtoBuf;

[ProtoContract]
public class Push_vipLevel : Response
{

    [ProtoMember(5)]
    public int vipLevel;
	public Push_vipLevel()
	{
		msgType = MsgType.PUSHUSER_VIP;
	}

    public override string  ToString()
    {
        return "Push_vipLevel [vipLevel=" + vipLevel + ", msgType=" + msgType +"]";
    }
}
