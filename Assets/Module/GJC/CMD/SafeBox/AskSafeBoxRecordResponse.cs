using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskSafeBoxRecordResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<SafeBoxRecordVO> list;

    public AskSafeBoxRecordResponse()
    {
    }

    public override string ToString()
    {
        return "AskSafeBoxRecordResponse [list=" + list + ", msgType=" + msgType+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}