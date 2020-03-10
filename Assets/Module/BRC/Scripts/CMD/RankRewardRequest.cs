using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 排行榜奖励
/// </summary>
[ProtoContract]
public class RankRewardRequest : Request
{
    /// <summary>
    /// 0:赢金 1：充值
    /// </summary>
    [ProtoMember(3)]
    public int type;
    public RankRewardRequest()
    {
        msgType = RANKINGREWARD;
    }
}