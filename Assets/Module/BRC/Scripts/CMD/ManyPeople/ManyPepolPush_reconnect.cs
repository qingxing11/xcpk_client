using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ManyPepolPush_reconnect : Response
{
    /// <summary>
    /// 房间状态
    /// </summary>
    [ProtoMember(5)]
    public int state;
    [ProtoMember(6)]
    public List<PlayerSimpleData> list_tablePlayer;
    [ProtoMember(7)]
    public int bankerPos;
    [ProtoMember(8)]
    public int pos;
    [ProtoMember(9)]
    public int roundNum;
    [ProtoMember(10)]
    public List<int> list_allBet;

    /**
	 * 当前行动玩家
	 */
    [ProtoMember(11)]
    public int actionPos;

    /**
	 * 当前状态剩余时间
	 */
    [ProtoMember(12)]
    public int actionTime;

    /**
	 * 玩家当前手牌，如果有
	 */
    [ProtoMember(13)]
    public List<PokerVO> list_pokers;
    //自己牌型
    [ProtoMember(14)]
    public int pokerType;


    /// <summary>
    /// 奖池
    /// </summary>
    [ProtoMember(15)]
    public long jackpotNum;
    /// <summary>
    /// 当前注
    /// </summary>
    [ProtoMember(16)]
    public int nowBet;
    /**0:不显示全压  1:显示全压  2:强制全压 3:第一回合*/
    [ProtoMember(17)]
    public int allinState;

    public ManyPepolPush_reconnect()
    {
        msgType = manypepol_断线重连;
    }
}
