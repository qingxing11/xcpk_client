using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushSignResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public bool todayIsSign;//可以签到

    public PushSignResponse()
    {

    }
    public override string ToString()
    {
        return "PushSignResponse [todayIsSign=" + todayIsSign + ", msgType=" + msgType  + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
