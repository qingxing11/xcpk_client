using ProtoBuf;

[ProtoContract]
public class ChangeAccountResponse : Response 
{
	public const int ERROR_账号密码错误 = 0;
    public const int ERROR_账号不存在 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string account;

    [ProtoMember(6)]
    public string password;

    [ProtoMember(7)]
    public int userId;
	
	 public  ChangeAccountResponse()
	 {
        msgType = MsgType.SET_切换账号;
	}
	
	 
	public override string ToString()
	{
		return "ChangeAccountResponse [account=" + account + ", password=" + password + ", userId=" + userId + ", msgType=" + msgType + ", code=" + code + "]";
	}
}
