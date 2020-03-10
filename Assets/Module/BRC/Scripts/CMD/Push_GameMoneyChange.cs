using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class Push_GameMoneyChange : Response
{
    /// <summary>
    /// 金币
    /// </summary>
    public const int MONEYTYPE_COIN = 0; // 金币

    /// <summary>
    /// 砖石
    /// </summary>
    public const int MONEYTYPE_CRYTSTAL = 1;// 钻石

    /// <summary>
    /// 加
    /// </summary>
    public const int STATE_ADD = 0;

    /// <summary>
    /// 减
    /// </summary>
    public const int STATE_SUB = 1;

    /**
	 * 改变的货币:金币或钻石
	 */
    [ProtoMember(5)]
    public int moneyType; // 改变的货币:豆子或金币
    [ProtoMember(6)]
    public int subType; // 改变方式:
    [ProtoMember(7)]
    public int changeNum; // 改变数量
    [ProtoMember(8)]
    public int curNum; // 现有数量
    public Push_GameMoneyChange()
    {
        msgType = GAME_货币变化;
    }
}