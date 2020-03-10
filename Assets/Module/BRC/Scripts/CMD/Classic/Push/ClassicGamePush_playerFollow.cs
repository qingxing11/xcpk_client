using ProtoBuf;
/// <summary>
/// 其他玩家下注
/// </summary>
[ProtoContract]
public class ClassicGamePush_playerFollow : Response
{
    /**
	 * 玩家位置
	 */
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ClassicGamePush_playerFollow()
    {
        msgType = classic_有玩家跟注;
    }

}
