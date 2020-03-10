using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class PushTitleMoneyResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long titleMoney;

    public PushTitleMoneyResponse()
    {

    }
    public override string ToString()
    {
        return "PushTitleMoneyResponse [titleMoney=" + titleMoney + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
