using ProtoBuf;
[ProtoContract]
public class ComparerPokerResponse : Response
{
    public const int ERROR_不在比赛中 = 0;
    public const int ERROR_没轮到行动 = 1;
    public const int ERROR_比牌错误 = 2;

    [ProtoMember(4)]
    public int code;

    public ComparerPokerResponse()
    {
        msgType = classic_玩家比牌;
    }
}