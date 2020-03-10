using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class PushSignDataResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<bool> list;

    [ProtoMember(6)]
    public bool todayIsSign;//可以签到

    public PushSignDataResponse()
    {

    }
    public override string ToString()
    {
        return "PushSignDataResponse [list=" + list + ", todayIsSign=" + todayIsSign + ", msgType=" + msgType+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
