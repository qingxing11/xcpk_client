using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SignDayRequest:Request
{
    [ProtoMember(3)]
    public int day;//第几天
    public SignDayRequest()
    {
        this.msgType = MsgType.Sign_签到;
    }
    public SignDayRequest(int day)
    {
        this.msgType = MsgType.Sign_签到;
        this.day = day;
    }

    public override string ToString()
    {
        return "SignDayRequest [day=" + day + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
