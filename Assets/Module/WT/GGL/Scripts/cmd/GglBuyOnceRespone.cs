using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
   public class GglBuyOnceRespone:Response
    {
    public const int ERROR_金币不足 = 0;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<int> list_luckyChess;
    [ProtoMember(6)]
    public List<GGLLotteryChessVO> list_myChess;
    [ProtoMember(7)]
    public int money;

    [ProtoMember(8)]
    public int costMoney;
    /**
	 * @param code 返回码
	 */
    public GglBuyOnceRespone()
    {
        this.msgType = MsgType.GGL_单次购买;
    }



    public override string ToString()
    {
        return "GglBuyOnceRespone [list_luckyChess=" + list_luckyChess + ", list_myChess=" + list_myChess + ", money=" + money + ", msgType=" + msgType + ", code=" + code + "]";
    }
}
