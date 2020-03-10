using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushBottomPourTimeResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int time;

    public PushBottomPourTimeResponse()
    {
        msgType = Lottery_下注时间;
    }

    public override string ToString()
    {
        return "PushBottomPourTimeResponse [time=" + time + ", msgType=" + msgType + ", data="+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
