using ProtoBuf;

[ProtoContract]
public class FindPasswordRequest : Request
{
    [ProtoMember(3)]
    public string password;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

	public FindPasswordRequest()
	{
        msgType = MsgType.SET_找回密码;
	}
}
