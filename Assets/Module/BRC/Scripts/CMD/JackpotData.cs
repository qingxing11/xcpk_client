using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class JackpotData
{
    /**
	 * 当前奖池
	 */
    [ProtoMember(1)]
    public long allJackpot;

    /**
	 * 上次大奖
	 */
    [ProtoMember(2)]
    public long lastJackpot;

    /**
	 * 上次中将玩家名字
	 */
    [ProtoMember(3)]
    public string lastName;
    [ProtoMember(4)]
    public int roleId;
    [ProtoMember(5)]
    public string lastHeadIconUrl;
    [ProtoMember(6)]
    public int jackpotType;
    [ProtoMember(7)]
    public long jackpotTime;
    [ProtoMember(8)]
    public List<PokerVO> list_pokers;

    public override string ToString()
    {
         return "JackpotData [allJackpot=" + allJackpot + ", lastJackpot=" + lastJackpot + ", lastName=" + lastName + ", roleId=" + roleId  + ", jackpotType=" + jackpotType + ", jackpotTime=" + jackpotTime + "]";
    }
}