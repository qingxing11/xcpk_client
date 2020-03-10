using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushWinMoneyTxtResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<TxtVO> vo;

    public PushWinMoneyTxtResponse()
    {

    }
    public override string ToString()
    {
        return "PushWinMoneyTxtResponse [vo=" + vo + ", msgType=" + msgType+ ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
