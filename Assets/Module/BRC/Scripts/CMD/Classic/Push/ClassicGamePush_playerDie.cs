using ProtoBuf;
/// <summary>
/// 其他玩家弃牌
/// </summary>
[ProtoContract]
public class ClassicGamePush_playerDie : Response
{
    [ProtoMember(5)]
    public int pos;

    public ClassicGamePush_playerDie()
    {
        msgType = classic_有玩家弃牌;
    }
}