using ProtoBuf;


[ProtoContract]
public class RankVO
{
    [ProtoMember(1)]
    public int userId;
    [ProtoMember(2)]
    public string nickName;
    [ProtoMember(3)]
    public long score;
    /// <summary>
    /// 名次
    /// </summary>
    [ProtoMember(4)]
    public int rank;
    /// <summary>
    /// 等级
    /// </summary>
    [ProtoMember(5)]
    public int level;

    public RankVO() { }

    public override string ToString()
    {
        return "RankVO [userId=" + userId + ", nickName=" + nickName + ", score=" + score + ", rank=" + rank + "]";
    }
}