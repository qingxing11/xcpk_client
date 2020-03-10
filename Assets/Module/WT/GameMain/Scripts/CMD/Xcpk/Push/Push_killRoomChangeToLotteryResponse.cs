using System.Collections.Generic;
/**
* 开奖消息：
* 
* 庄家手牌
* 4个方位手牌
* 输赢分数：
* 		庄家输赢
* 		闲家赢分前几名，如果都输分则不显示
* 		自己输赢
* @author WangTuo
*/
using ProtoBuf;

[ProtoContract]
public class Push_killRoomChangeToLotteryResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    /**庄家手牌*/ 
    public List<PokerVO> list_bankerPoker;

    /**各方位数据：手牌，*/
    [ProtoMember(6)]
    public List<KillRoomDirectionPlayer> list_directionPlayers;

    /**庄家输赢*/
    [ProtoMember(7)]
    public long bankerScore;

    /**自己输赢*/
    [ProtoMember(8)]
    public long calcScore;

    /**
	 * 庄家手牌类型
	 */
    [ProtoMember(9)]
    public int bankerType;

    /// <summary>
    /// 座位上玩家输赢分数
    /// </summary>
    [ProtoMember(10)]
    public List<KillRoomTablePlayerRoundScore> list_tablePlayerScore;
    /// <summary>
    /// 奖池
    /// </summary>
    [ProtoMember(11)]
    public long jackpot;
    
    /// <summary>
    /// 中奖
    /// </summary>
    [ProtoMember(12)]
    public long jackpotWin;
    /// <summary>
    /// 经验
    /// </summary>
    [ProtoMember(13)]
    public int exp;

    [ProtoMember(14)]
    public KillRoomLog killRoomLog;
    /// <summary>
    /// 下的注数
    /// </summary>
    [ProtoMember(15)]
    public int subCoins;
    /**
	 * 额外扣除金币
	 */
    [ProtoMember(16)]
    public int otherSubCoins;

    /**当前金币*/
    [ProtoMember(17)]
    public long nowCoins;

    public Push_killRoomChangeToLotteryResponse()
	{
		this.msgType = MsgType.KillRoom_通杀场开奖状态;
	}

    public override string ToString()
    {
        return "Push_killRoomChangeToLotteryResponse [bankerScore=" + bankerScore + ",list_tablePlayerScore:"+ list_tablePlayerScore.GetString() + ", calcScore=" + calcScore +  ", jackpot=" + jackpot + ", jackpotWin=" + jackpotWin + ", exp=" + exp + ", subCoins=" + subCoins + ", otherSubCoins=" + otherSubCoins + ", nowCoins=" + nowCoins + "]";
    }
}
