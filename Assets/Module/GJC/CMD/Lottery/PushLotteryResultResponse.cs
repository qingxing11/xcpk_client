using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushLotteryResultResponse:Response
{
    public const int Error_没有赢家 = 0;
    public const int Error_没有下注 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public bool win;

    [ProtoMember(6)]
    public long winnerMoney;

    [ProtoMember(7)]
    public int type;

    [ProtoMember(8)]
    public PokerVO card1;

    [ProtoMember(9)]
    public PokerVO card2;

    [ProtoMember(10)]
    public PokerVO card3;

    public PushLotteryResultResponse()
    {
       
    }


    public override string ToString()
    {
        return "PushLotteryResultResponse [win=" + win + ", winnerMoney=" + winnerMoney + ", type=" + type + ", card=" + card1 + ", card2=" + card2 + ", card3=" + card3 + ", msgType=" + msgType  + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
