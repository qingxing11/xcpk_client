
using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_otherPlayerEnter : Response
{
    [ProtoMember(5)]
    public PlayerSimpleData playerSimpleData;
    public ClassicGamePush_otherPlayerEnter()
    {
        msgType = classic_其他玩家进入房间;
    }
}