using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_allin : Response
{
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ClassicGamePush_allin()
    {
        msgType = classic_其他玩家全压;
    }

}