using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
class TakeOutSafeBoxResponse :Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long money;

    public TakeOutSafeBoxResponse()
    {

    }

    public override string ToString()
    {
        return "TakeOutSafeBoxResponse [money=" + money + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
