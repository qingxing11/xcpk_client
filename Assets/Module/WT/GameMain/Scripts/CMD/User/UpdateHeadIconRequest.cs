using ProtoBuf;

[ProtoContract]
public class UpdateHeadIconRequest : Request {

    [ProtoMember(3)]
    public byte[] headIcon;
	public UpdateHeadIconRequest() {
		this.msgType = MsgType.USER_上传自定义头像;
	}
}
