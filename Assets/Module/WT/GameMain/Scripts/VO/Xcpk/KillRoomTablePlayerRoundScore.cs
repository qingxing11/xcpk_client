using ProtoBuf;

[ProtoContract]
public class KillRoomTablePlayerRoundScore
{
    [ProtoMember(1)]
    public int pos;

    [ProtoMember(2)]
    public long score;

    [ProtoMember(3)]
    public int userId;
    public override string ToString()
    {
        return "pos:" + pos + "score:" + score + ",userId:" + userId;
    }
}
