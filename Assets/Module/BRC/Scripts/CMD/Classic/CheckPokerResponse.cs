using ProtoBuf;
using System.Collections.Generic;
/// <summary>
/// 玩家看牌
/// </summary>
[ProtoContract]
public class CheckPokerResponse : Response
{
    public const int ERROR_没轮到行动 = 0;
    public const int ERROR_不在比赛中 = 1;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PokerVO> list_poker;
    [ProtoMember(6)]
    public int pokerType;
    public CheckPokerResponse()
    {
        msgType = classic_玩家看牌;
    }
}