using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 排行榜
/// </summary>
[ProtoContract]
public class RankingResponse : Response
{
    [ProtoMember(4)]
    public int code;

    /// <summary>
    /// 充值榜显示前20名-每日充值榜前三次名，分别获取充值所得钻石100%50%30%金币奖励，次日直接到账（奖励按1元=1钻石=1万金币结算）
    /// </summary>
    [ProtoMember(5)]
    public List<RankVO> payRank;
    /**
	 * 土豪榜：显示前20名账号金币最多的玩家
	 */
    [ProtoMember(6)]
    public List<RankVO> coinsRank;
    /**
	 * 赢金榜：显示赢金榜最多的前20名。奖励规则参考友乐
	 */
    [ProtoMember(7)]
    public List<RankVO> bigWinRank;

    /// <summary>
    /// 是否领取充值榜
    /// </summary>
    [ProtoMember(8)]
    public bool isGetPay;

    /// <summary>
    /// 是否领取赢金榜
    /// </summary>
    [ProtoMember(9)]
    public bool isGetWin;

    public RankingResponse()
    {
        msgType = RANKING;
    }
}