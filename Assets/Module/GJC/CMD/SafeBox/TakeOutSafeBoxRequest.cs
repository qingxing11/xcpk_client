using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class TakeOutSafeBoxRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    [ProtoMember(4)]
    public long money;

    public TakeOutSafeBoxRequest()
    {
        this.msgType = MsgType.SafeBox_取出银行;
    }

    public TakeOutSafeBoxRequest(int userId, long money)
    {
        this.msgType = MsgType.SafeBox_取出银行;
        this.userId = userId;
        this.money = money;
    }



    public override string ToString()
    {
        return "TakeOutSafeBoxRequest [userId=" + userId + ", money=" + money + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }

}
