using ProtoBuf;

[ProtoContract]
public class ChangeAccountRequest : Request
{
    [ProtoMember(3)]
    public string account;

    [ProtoMember(4)]
    public string password;

    [ProtoMember(5)]
    public int userId;

	public ChangeAccountRequest()
	{
		msgType = MsgType.SET_切换账号;
	}
}
