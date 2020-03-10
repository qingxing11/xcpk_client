using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class GetMoneyTreeResponse:Response
{
    public const int No_Money = 0;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long money;

    public GetMoneyTreeResponse()
    {

    }

    public override string ToString()
    {
        return "GetMoneyTreeResponse [money=" + money + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
