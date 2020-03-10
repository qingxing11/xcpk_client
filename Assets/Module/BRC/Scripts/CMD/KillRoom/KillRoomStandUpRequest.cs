using ProtoBuf;


[ProtoContract]

public class KillRoomStandUpRequest : Request
{
    public KillRoomStandUpRequest()
    {
        msgType = KillRoom_从座位站起;
    }
}