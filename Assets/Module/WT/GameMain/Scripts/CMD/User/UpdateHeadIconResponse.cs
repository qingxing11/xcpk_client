using ProtoBuf;

[ProtoContract]
public class UpdateHeadIconResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public string headIconUrl;

    public UpdateHeadIconResponse()
	{
		this.msgType = MsgType.USER_上传自定义头像;
	}

	public UpdateHeadIconResponse(int code)
	{
		this.msgType = MsgType.USER_上传自定义头像;
		this.code = code;
	}
}
