using ProtoBuf;

/// <summary>
/// 有玩家加注
/// </summary>
[ProtoContract]
public class ClassicGamePush_playerRaiseBet : Response
{
    /**
	 * 玩家位置
	 */
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ClassicGamePush_playerRaiseBet()
    {
        msgType = classic_有玩家加注;
    }
}