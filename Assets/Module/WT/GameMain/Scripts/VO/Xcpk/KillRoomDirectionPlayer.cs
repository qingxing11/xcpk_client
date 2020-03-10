using System.Collections.Generic;

using ProtoBuf;

[ProtoContract]
public class KillRoomDirectionPlayer
{
    /**
	 * 该方向手牌
	 */
    [ProtoMember(1)]
    public List<PokerVO> list_poker;

    /**东南西北*/
    [ProtoMember(2)]
    public int pos;

    [ProtoMember(3)]
    public int pokerType;

    /// <summary>
    /// 该手牌输赢
    /// </summary>
    [ProtoMember(4)]
    public bool isWin;

    /**
	 * 该方向筹码,每个玩家的筹码有限制
	 */
    public Dictionary<int, int> map_gameChips;
    public int directionChips;
	
	public KillRoomDirectionPlayer()
	{
		list_poker = new List<PokerVO>();
		
		map_gameChips = new Dictionary<int, int>();
	}

	public void clearDirection()
	{
		directionChips = 0;
		list_poker.Clear();
		map_gameChips.Clear();
	}
	
	public int getDirectionChips()
	{
		return directionChips;
	}
	 
	public Dictionary<int, int> getAllPlayerAndChip()
	{
		return map_gameChips;
	}
	
	 

	public List<PokerVO> getPokers()
	{
		return list_poker;
	}

	public bool isPlayerEmpty()
	{
		return map_gameChips == null || map_gameChips.Count == 0;
	}

    public override string ToString()
    {
        return "pos:"+pos+"   isWin:"+isWin;
    }
}
