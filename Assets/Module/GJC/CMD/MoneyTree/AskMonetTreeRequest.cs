using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskMonetTreeRequest : Request
{
    public AskMonetTreeRequest()
    {
        this.msgType = MsgType.MoneyTree_同步;
    }

    public override string ToString()
    {
        return "AskMonetTreeRequest [msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
