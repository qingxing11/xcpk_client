using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 经典场断线重连
/// </summary>
[ProtoContract]
public class ClassicGamePush_reconnect : Response
{
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
    public ClassicGamePush_reconnect()
    {
        msgType = classic_断线重连;
    }


}