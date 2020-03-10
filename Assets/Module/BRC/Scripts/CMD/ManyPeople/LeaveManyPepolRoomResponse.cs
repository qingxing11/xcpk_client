using ProtoBuf;


[ProtoContract]
public class LeaveManyPepolRoomResponse : Response
{
    public const int ERROR_不在游戏中 = 0;
    public const int ERROR_坐下时不能离开 = 1;
    [ProtoMember(4)]
    public int code;
    public LeaveManyPepolRoomResponse()
    {
        msgType = manypepol_玩家离开;
    }
}