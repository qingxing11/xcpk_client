using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ProtoContract]
public class GameRoundDataVO
{
    /**豹子*/
    public const int CARD_TYPE_豹子 = 1;
    /**顺金*/
    public const int CARD_TYPE_顺金 = 2;
    /**金花 */
    public const int CARD_TYPE_金花 = 3;
    /**顺子*/
    public const int CARD_TYPE_顺子 = 4;
    /**对子带单*/
    public const int CARD_TYPE_对子带单 = 5;
    /**单张*/
    public const int CARD_TYPE_单张 = 6;
    /**特殊，也是单张*/
    public const int CARD_TYPE_特殊 = 7;

    [ProtoMember(1)]
    public int pos;
    /// <summary>
    /// 本剧输赢
    /// </summary>
    [ProtoMember(2)]
    public long roundBet;
    [ProtoMember(3)]
    public List<PokerVO> list_handPoker;
    [ProtoMember(4)]
    public int pokerType;
    [ProtoMember(5)]
    public int userId;
    [ProtoMember(6)]
    public long jackpotWin;
    [ProtoMember(7)]
    public long newCoins;
    
    public Sprite headIcon;

}