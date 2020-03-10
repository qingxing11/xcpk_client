using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;
[ProtoContract]
public class CancleContinueXiaZhuResponse : Response
{
    [ProtoMember(4)]
    public int code;
    public CancleContinueXiaZhuResponse()
    {
        this.msgType = MsgType.Fruit_CancelContinueXiaZhu;
    }

    public override string ToString()
    {
        return "CancleContinueXiaZhuResponse [msgType=" + msgType + ", code=" + code + "]";
    }
}
