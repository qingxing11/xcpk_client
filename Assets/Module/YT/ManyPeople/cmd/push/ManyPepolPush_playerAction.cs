using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

/// <summary>
/// 玩家行动
/// </summary>
[ProtoContract]
public class ManyPepolPush_playerAction : Response
{
   
    [ProtoMember(4)]
    public int code;
    /// <summary>
    /// 位置
    /// </summary>
    [ProtoMember(5)]
    public int pos;
    /// <summary>
    ///  现在筹码
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
    /**0:不显示全压  1:显示全压  2:强制全压  3:万人场第一个玩家操作*/
    [ProtoMember(9)]
    public int allinState;
    public ManyPepolPush_playerAction()
    {
        msgType =manypepol_玩家行动;
    }

    public override string ToString()
    {
        return "ManyPepolPush_playerAction [pos=" + pos + ", nowBet=" + nowBet + ", isCheckPoker=" + isCheckPoker + ", round=" + round + ", allinState=" + allinState + "]";
    }
}