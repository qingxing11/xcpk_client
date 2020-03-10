


using ProtoBuf;
/**
* @author 包小威
* 获取验证码
*/
[ProtoContract]
public class BindPhoneGetCodeRequest : Request
{
    [ProtoMember(3)]
    public string phoneNumber;

    public BindPhoneGetCodeRequest()
	{
		msgType = BINDPHONE_GETCODE;
	}
}
