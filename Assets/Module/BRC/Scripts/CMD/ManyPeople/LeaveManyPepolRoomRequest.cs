using ProtoBuf;


[ProtoContract]
public class LeaveManyPepolRoomRequest:Request
{
    [ProtoMember(3)]
    public bool isTV;
    public LeaveManyPepolRoomRequest()
    {
        msgType =manypepol_玩家离开;
    }

}