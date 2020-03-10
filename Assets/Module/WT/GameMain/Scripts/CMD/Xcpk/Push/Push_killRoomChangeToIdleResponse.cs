using ProtoBuf;

[ProtoContract]
public class Push_killRoomChangeToIdleResponse : Response
{
    /**庄家金币*/
    //[ProtoMember(4)]
    //public long bankerScore;

    public Push_killRoomChangeToIdleResponse()
    {
        this.msgType = MsgType.KillRoom_休息时间;
    }
}
