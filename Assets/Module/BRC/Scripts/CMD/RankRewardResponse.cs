using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 赢金榜奖励
/// </summary>
[ProtoContract]
public class RankRewardResponse : Response
{
    public const int ERROR_未上榜 = 0;
    public const int ERROR_已领取 = 1;
    public const int ERROR_统计中 = 2;
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int type;

    [ProtoMember(6)]
    public long coins;
    public RankRewardResponse()
    {
        msgType = RANKINGREWARD;
    }
}