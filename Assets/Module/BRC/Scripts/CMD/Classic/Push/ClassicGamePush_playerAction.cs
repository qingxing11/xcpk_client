using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_playerAction : Response
{
    /// <summary>
    /// 位置
    /// </summary>
    [ProtoMember(5)]
    public int pos;
    /// <summary>
    /// 现在筹码
    /// </summary>
    [ProtoMember(6)]
    public int nowBet;

    /// <summary>
    /// 是否看过牌
    /// </summary>
    [ProtoMember(7)]
    public bool isCheckPoker;

    /// <summary>
    /// 轮数
    /// </summary>
    [ProtoMember(8)]
    public int round;

    /**0:不显示全压  1:显示全压  2:强制全压*/
    [ProtoMember(9)]
    public int allInState;
    public ClassicGamePush_playerAction()
    {
        msgType = classic_玩家行动;
    }


    public override string ToString()
    {
        return "ClassicGamePush_playerAction [pos=" + pos + ", nowBet=" + nowBet + ", isCheckPoker=" + isCheckPoker + ", round=" + round + ", allInState=" + allInState + "]";
    }
}