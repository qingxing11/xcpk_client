using System;
using ProtoBuf;

[ProtoContract]
public class PokerVO :IComparable
{
    /**
	 * 牌值
	 */
    [ProtoMember(1)]
    public int value = 0;

    /**
	 * 牌型
	 */
    [ProtoMember(2)]
    public int type = 0;

    /**
	 * 花色
	 */
    [ProtoMember(3)]
    public int color = 0;

    public int CompareTo(object obj)
    {
        return value.CompareTo(((PokerVO)obj).value);
    }
}