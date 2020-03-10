using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskLotteryResponse:Response
{
    public const int Error_钱不够 = 0;
    public const int Error_不能押注 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long titleMoney;

    [ProtoMember(6)]
    public long costMoney;

    [ProtoMember(7)]
    public int num;

    [ProtoMember(8)]
    public int type;

    public AskLotteryResponse()
    {
        
    }

    public override  string ToString()
    {
        return "AskLotteryResponse [titleMoney=" + titleMoney + ", costMoney=" + costMoney + ", num=" + num + ", type="
                + type + ", msgType=" + msgType + ", callBackId=" + callBackId
                + ", code=" + code + "]";
    }

}
