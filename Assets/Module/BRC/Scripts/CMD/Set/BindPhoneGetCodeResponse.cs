using ProtoBuf;

[ProtoContract]
public class BindPhoneGetCodeResponse : Response 
{
	public const int ERROR_已绑定手机号 = 0;
    public const int ERROR_获取验证码失败 = 1;
    public const int ERROR_未完善账号 = 2;

    [ProtoMember(4)]
    public int code;
	public BindPhoneGetCodeResponse()
	{
		msgType =BINDPHONE_GETCODE;
	}
}
