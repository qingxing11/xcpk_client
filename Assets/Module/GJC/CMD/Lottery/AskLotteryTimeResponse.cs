using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskLotteryTimeResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int residueBuyTime;//剩余押注时间

    [ProtoMember(6)]
    public int residueWinTime;//剩余开奖时间

    [ProtoMember(7)]
    public List<int> recordWinType;//开奖记录

    [ProtoMember(8)]
    public int curType = -1;

    [ProtoMember(9)]
    public int curNum = -1;

    public AskLotteryTimeResponse()
    {
      
    }
    public override string ToString()
    {
        return "AskLotteryTimeResponse [residueBuyTime=" + residueBuyTime + ", residueWinTime=" + residueWinTime+ ", recordWinType=" + recordWinType + ", msgType=" + msgType  + ", callBackId=" + callBackId + ", code="+ code + "]";
    }

}