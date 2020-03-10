using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class EnterManyPepolRoomResponse : Response
{

    [ProtoMember(4)]
    public int code;
    /**0:待机  1:等待开始 2:发牌  3:等待玩家思考*/
    [ProtoMember(5)]
    public int state;
    [ProtoMember(6)]
    public List<PlayerSimpleData> list_tablePlayer;
    [ProtoMember(7)]
    public int bankerPos;
    /// <summary>
    /// 等待开始时间
    /// </summary>
    [ProtoMember(8)]
    public int waitStartTime;//9秒
    /// <summary>
    /// 思考时间
    /// </summary>
    [ProtoMember(9)]
    public int waitPlayerThink;
    /// <summary>
    /// 下注时间
    /// </summary>
    [ProtoMember(10)]
    public int waitPayBetTime;
    /// <summary>
    /// 总注
    /// </summary>
    [ProtoMember(11)]
    public int allBet;
    /// <summary>
    /// 奖池
    /// </summary>
    [ProtoMember(12)]
    public long jackpotNum;

    /// <summary>
    /// 当前注数
    /// </summary>
    [ProtoMember(13)]
    public int roundNum;
    [ProtoMember(14)]
    public List<int> list_allBet;
    public EnterManyPepolRoomResponse()
    {
        msgType = MsgType.manypepol_玩家进入;
    }

    public override string ToString()
    {
        return "EnterManyPepolRoomResponse [state=" + state + ", list_tablePlayer=" + list_tablePlayer + ", bankerPos=" + bankerPos + "]";
    }
}