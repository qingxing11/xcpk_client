using ProtoBuf;

[ProtoContract]
public class PlayerReConnectRequest : Request
{
    [ProtoMember(3)]
    public TokenVO tokenVO;

    /// <summary>
    /// 切出还是切入
    /// false 切出 true  切入
    /// </summary>
    [ProtoMember(4)]
    public bool isPing;
	public PlayerReConnectRequest()
	{
        msgType = MsgType.GAME_客户端要求断线重连;
	}
}