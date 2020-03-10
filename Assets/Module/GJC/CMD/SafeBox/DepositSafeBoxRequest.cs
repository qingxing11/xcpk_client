using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class DepositSafeBoxRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    [ProtoMember(4)]
    public long money;

    public DepositSafeBoxRequest()
    {
        this.msgType = MsgType.SafeBox_存入银行;
    }

    public DepositSafeBoxRequest(int userId, long money)
    {
        this.msgType = MsgType.SafeBox_存入银行;
        this.userId = userId;
        this.money = money;
    }



    public override string ToString()
    {
        return "DepositSafeBoxRequest [userId=" + userId + ", money=" + money + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }

}
