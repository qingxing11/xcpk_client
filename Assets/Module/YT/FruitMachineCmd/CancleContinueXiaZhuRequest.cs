using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;
[ProtoContract]
public class CancleContinueXiaZhuRequest : Request
{
    public CancleContinueXiaZhuRequest()
    {
        this.msgType = MsgType.Fruit_CancelContinueXiaZhu;
    }
    public override string ToString()
    {
        return "CancleContinueXiaZhuRequest [msgType=" + msgType + "]";
    }
}