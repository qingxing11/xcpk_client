using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskSafeBoxRecordRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    public AskSafeBoxRecordRequest()
    {
        this.msgType = MsgType.SafeBox_银行记录;
    }

    public AskSafeBoxRecordRequest(int userId)
    {
        this.msgType = MsgType.SafeBox_银行记录;
        this.userId = userId;
    }



    public override string ToString()
    {
        return "AskSafeBoxRecordRequest [userId=" + userId + ", msgType=" + msgType + ", callBackId=" + callBackId
                + "]";
    }
}
