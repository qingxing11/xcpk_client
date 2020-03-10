using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushPlayerOnLineResponse:Response
{

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

    [ProtoMember(6)]
    public bool state;

    public PushPlayerOnLineResponse()
    {

    }

    public override string ToString()
    {
        return "PushPlayerOnLineResponse [userId=" + userId + ", state=" + state + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
