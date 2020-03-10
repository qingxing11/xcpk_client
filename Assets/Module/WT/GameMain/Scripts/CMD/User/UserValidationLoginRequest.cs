 
using ProtoBuf;

[ProtoContract]
public class UserValidationLoginRequest : Request
{
    [ProtoMember(3)]
    public TokenVO tokenVO;
	public UserValidationLoginRequest()
	{
		msgType = MsgType.USER_VALIDATION_TOKEN;
	}
	
	public UserValidationLoginRequest(TokenVO tokenVO)
	{
		msgType = MsgType.USER_VALIDATION_TOKEN;
		this.tokenVO = tokenVO;
	}
}
