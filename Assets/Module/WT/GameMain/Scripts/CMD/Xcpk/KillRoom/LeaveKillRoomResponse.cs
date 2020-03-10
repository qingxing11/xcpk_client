using ProtoBuf;

[ProtoContract]

public class LeaveKillRoomResponse : Response
{
    [ProtoMember(4)]
    public int code;

    public LeaveKillRoomResponse()
    {
        msgType = MsgType.KillRoom_离开通杀场;
    }
}
 
