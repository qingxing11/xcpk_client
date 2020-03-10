using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SendHornInfoResponse:Response
{
    public const int Error_金币不足 = 0;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public HornInfoVO vo;

    [ProtoMember(6)]
    public int subMoney;

    public SendHornInfoResponse()
    {

    }

    public override string ToString()
    {
        return "SendHornInfoResponse [vo=" + vo + ", subMoney=" + subMoney + ", msgType=" + msgType+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
