using ProtoBuf;

[ProtoContract]
public class PlayerReConnectResponse : Response
{
	public const int ERROR_TOKEN空 = 1;
	public const int ERROR_没有申请过登陆 = 2;
	public const int ERROR_TOKEN验证失败 = 3;
	public const int ERROR_不存在的用户 = 4;
    public const int ERROR_不在任何房间中 = 5;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public GameData gameData;

    [ProtoMember(6)]
    public bool isPing;

    public PlayerReConnectResponse()
	{
        msgType = MsgType.GAME_客户端要求断线重连;
    }
}