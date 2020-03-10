using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_comparerPoker : Response
{
    /**发起方*/
    [ProtoMember(5)]
    public int pos0;

    /**被比方*/
    [ProtoMember(6)]
    public int pos1;

    /**输方*/
    [ProtoMember(7)]
    public int lossPos;

    [ProtoMember(8)]
    public int subCoins;
    public ClassicGamePush_comparerPoker()
    {
        msgType = classic_其他玩家比牌;
    }
}