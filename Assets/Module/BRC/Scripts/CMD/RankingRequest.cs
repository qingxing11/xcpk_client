using ProtoBuf;
/// <summary>
/// 排行榜
/// </summary>
[ProtoContract]
/**
 * 排行榜
 */
public class RankingRequest : Request
{
	public RankingRequest()
	{
		msgType = MsgType.RANKING;
	}
}
