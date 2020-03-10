using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
class AskAutoLotteryResponse:Response
{
    public const int Error_钱不够 = 0;
    public const int Error_不能押注 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long titleMoney;

    [ProtoMember(6)]
    public int type;

    [ProtoMember(7)]
    public long costMoney;

    [ProtoMember(8)]
    public int num;
    public AskAutoLotteryResponse()
    {
       
    }
   
    public override string ToString()
    {

        return "AskAutoLotteryResponse [titleMoney=" + titleMoney + ", type=" + type + ", costMoney=" + costMoney + ", num=" + num + ", msgType=" + msgType + ", code=" + code + "]";

    }
}
