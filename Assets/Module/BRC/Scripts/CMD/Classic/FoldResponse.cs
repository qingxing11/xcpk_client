using ProtoBuf;

[ProtoContract]
public class FoldResponse : Response
{
    public const int ERROR_不在比赛中 = 0;
    [ProtoMember(4)]
    public int code;
    public FoldResponse()
    {
        msgType = classic_玩家弃牌;
    }

}