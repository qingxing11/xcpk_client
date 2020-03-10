using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushRunALotteryTimeResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int time;

    public PushRunALotteryTimeResponse()
    {
    }

    public override string ToString()
    {
        return "PushRunALotteryTimeResponse [time=" + time + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
