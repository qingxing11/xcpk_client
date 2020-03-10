using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskLotteryTimeRequest:Request
{
    public AskLotteryTimeRequest()
    {
        this.msgType = MsgType.Lottery_同步时间;
    }

    public override string ToString()
    {
        return "AskLotteryTimeRequest [msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
