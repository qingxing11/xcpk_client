using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_playerLeave : Response
{
    [ProtoMember(5)]
    public int pos;
    public ClassicGamePush_playerLeave()
    {
        msgType =classic_其他玩家离开;
    }

}