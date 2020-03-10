using ProtoBuf;
/// <summary>
/// 玩家加注
/// </summary>
[ProtoContract]
public class RaiseBetRequest : Request
{
    [ProtoMember(3)]
    public int betNum;
	public RaiseBetRequest()
	{
		msgType = classic_玩家加注;
	}
}
