using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskMonetTreeResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long time;//剩余时间（毫秒）

    [ProtoMember(6)]
    public long moneyTree;

    public AskMonetTreeResponse()
    {
        this.msgType = MsgType.MoneyTree_同步;
    }

    public override string ToString()
    {
        return "AskMonetTreeResponse [time=" + time + ", moneyTree=" + moneyTree + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
