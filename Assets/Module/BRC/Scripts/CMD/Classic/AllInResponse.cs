using ProtoBuf;

[ProtoContract]
public class AllInResponse : Response
{
    public const int ERROR_不在比赛中 = 0;
    public const int ERROR_没轮到行动 = 1;
    public const int ERROR_不在可全压人数 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public long betNum;
    public AllInResponse()
    {
        msgType = classic_玩家全压;
    }

}