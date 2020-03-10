using ProtoBuf;

[ProtoContract]
public class FindPasswordResponse : Response 
{
	public const int ERROR_账号密码错误 = 0;
	public const int ERROR_验证码错误 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string password;

    [ProtoMember(6)]
    public int userId;
	
	 public  FindPasswordResponse()
	 {
        msgType = MsgType.SET_找回密码;
	}
	
	 
	public override string ToString()
	{
		return "FindPasswordResponse [password=" + password + ", userId=" + userId + ", msgType=" + msgType + ", code=" + code + "]";
	}
}
