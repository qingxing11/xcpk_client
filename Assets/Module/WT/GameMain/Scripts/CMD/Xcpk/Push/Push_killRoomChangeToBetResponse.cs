using ProtoBuf;

[ProtoContract]
public class Push_killRoomChangeToBetResponse : Response
{

    public Push_killRoomChangeToBetResponse()
    {
        this.msgType = MsgType.KillRoom_通杀场下注时间;
    }
}