using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class DeleteInfoResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

    public DeleteInfoResponse()
    {

    }

    public override string ToString()
    {
        return "DeleteInfoResponse [userId=" + userId + ", msgType=" + msgType+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
