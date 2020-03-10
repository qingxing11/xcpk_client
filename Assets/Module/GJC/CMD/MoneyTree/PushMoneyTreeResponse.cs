using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushMoneyTreeResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long time;//剩余时间（毫秒）

    [ProtoMember(6)]
    public long moneyTree;

    public PushMoneyTreeResponse()
    {

    }

    public override string ToString()
    {
        return "PushMoneyTreeResponse [time=" + time + ", moneyTree=" + moneyTree + ", msgType=" + msgType  + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
