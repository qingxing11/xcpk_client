using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class GetMoneyTreeRequest:Request
{
    public GetMoneyTreeRequest()
    {
        this.msgType = MsgType.MoneyTree_领取;
    }

    public override string ToString()
    {
        return "GetMoneyTreeRequest [msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
