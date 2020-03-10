using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SignDayResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public bool sign;//签到成功

    [ProtoMember(6)]
    public int day;//第几天

    public SignDayResponse()
    {

    }

    public override string ToString()
    {
        return "SignDayResponse [sign=" + sign + ", day=" + day + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
