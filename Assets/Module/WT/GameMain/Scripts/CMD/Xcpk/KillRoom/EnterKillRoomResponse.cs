using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class EnterKillRoomResponse : Response
{
    [ProtoMember(4)]
    public int code;
    /// <summary>
    /// 房间状态
    /// </summary>
    [ProtoMember(5)]
    public int state;
    /// <summary>
    /// 庄家数据
    /// </summary>
    [ProtoMember(6)]
    public PlayerSimpleData banker;
    /// <summary>
    /// 座位玩家数据
    /// </summary>
    [ProtoMember(7)]
    public List<PlayerSimpleData> list_tablePlayer;
    /// <summary>
    /// 奖池
    /// </summary>
    [ProtoMember(8)]
    public long jackpot;

    [ProtoMember(9)]
    public long stateTime;

    [ProtoMember(10)]
    public List<KillRoomLog> list_killRoomLog;

    [ProtoMember(11)]
    public int bankerRound;
    [ProtoMember(12)]
    public List<KillRoomBigWinVO> list_bigWin;
    [ProtoMember(13)]
    public List<long> list_directionBetNum;

    [ProtoMember(14)]
    public int roundIndex;
 
    public EnterKillRoomResponse()
	{
		msgType = MsgType.KillRoom_进入通杀场;
	}

    public override string ToString()
    {
        return "EnterKillRoomResponse [state=" + state + ", banker=" + banker  + ", jackpot=" + jackpot + ", stateTime=" + stateTime +   ", bankerRound=" + bankerRound + ", list_bigWin=" + list_bigWin.GetString() +  ", msgType=" + msgType + ", code=" + code + "]";
    }
}
