using ProtoBuf;


[ProtoContract]
public class GetJackpotResponse : Response
{
    public const int ERROR_不在比赛中 = 0;


    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public JackpotData jackpotData;
    public GetJackpotResponse()
    {
        msgType = KillRoom_获取奖池;
    }
}