using ProtoBuf;
/// <summary>
/// 其他玩家看牌
/// </summary>
[ProtoContract]
public class ClassicGamePush_checkPoker : Response
{
    /**
	 * 玩家位置
	 */
    [ProtoMember(5)]
    public int pos;

    public ClassicGamePush_checkPoker()
    {
        msgType = classic_有玩家看牌;
    }

}