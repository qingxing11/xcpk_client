using ProtoBuf;

[ProtoContract]
public class LeaveClassicGameResponse : Response
{
    public const int ERROR_不在游戏中 = 0;
    [ProtoMember(4)]
    public int code;

    public LeaveClassicGameResponse()
    {
        msgType = classic_玩家离开;
    }

}