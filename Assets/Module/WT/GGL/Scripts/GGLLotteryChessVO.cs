using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class GGLLotteryChessVO
{
    public const int CHESS_兵 = 0;
    public const int CHESS_红炮 = 1;
    public const int CHESS_红车 = 2;
    public const int CHESS_红马 = 3;
    public const int CHESS_红相 = 4;
    public const int CHESS_红士 = 5;
    public const int CHESS_帅 = 6;
    public const int CHESS_卒 = 7;
    public const int CHESS_黑炮 = 8;
    public const int CHESS_黑车 = 9;
    public const int CHESS_黑马 = 10;
    public const int CHESS_黑相 = 11;
    public const int CHESS_黑士 = 12;
    public const int CHESS_将 = 13;


    /**
	 * 0-13,红色在前
	 * 0:兵 1:红炮  2:红车 3:红马 4:红相 5:红士 6:帅
	 * 7:卒 8:黑炮 9:黑车  10:黑马 11:黑相 12:黑士 13:将
	 */
    [ProtoMember(1)]
    public int chessId;
    [ProtoMember(2)]
    public int money;
    [ProtoMember(3)]
    public bool isHitReward;

    public GGLLotteryChessVO() { }
    public override string ToString()
    {
        return "GGLLotteryChessVO [chessId=" + chessId + ", money=" + money + "]";
    }
}