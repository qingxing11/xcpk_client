using ProtoBuf;

[ProtoContract]
public class UserValidationLoginResponse : Response
{
	public const int ERROR_登陆失败 = 0;
	public const int ERROR_TOKEN空 = 1;
	public const int ERROR_没有申请过登陆 = 2;
	public const int ERROR_TOKEN验证失败 = 3;
    public const int ERROR_已被封号 = 4;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public GameData gameData;
	public UserValidationLoginResponse()
	{
		this.msgType =MsgType.USER_VALIDATION_TOKEN;
	}
}
