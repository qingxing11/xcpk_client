using ProtoBuf;

[ProtoContract]
public class FindPasswordGetCodeResponse : Response 
{
	public const int ERROR_还未完善账号 = 0;
	public const int ERROR_还未绑定手机 = 1;
	public const int ERROR_获取验证码失败 = 2;

    [ProtoMember(4)]
    public int code;
     
	 public  FindPasswordGetCodeResponse()
	 {
        msgType = MsgType.SET_找回密码获取验证码;
	}
	 
	public override string ToString()
	{
		return "FindPasswordGetCodeResponse [msgType=" + msgType + ", code=" + code + "]";
	}
}
