using ProtoBuf;

/// <summary>
/// 玩家加注
/// </summary>
[ProtoContract]
public class RaiseBetResponse : Response
{
    public const int ERROR_金币不足 = 0;
    public const int ERROR_不在比赛中 = 1;
    public const int ERROR_没轮到行动 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int betNum;
    public RaiseBetResponse()
    {
        msgType = classic_玩家加注;
    }

}