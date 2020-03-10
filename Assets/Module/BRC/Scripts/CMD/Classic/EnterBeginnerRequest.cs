using ProtoBuf;

[ProtoContract]
public class EnterBeginnerRequest : Request
{
    [ProtoMember(3)]
    public int type;
	public EnterBeginnerRequest()
	{
        msgType = classic_进入新手场;
	}
}
