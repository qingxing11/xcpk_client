using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class AskAutoLotteryRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    [ProtoMember(4)]
    public int num;
    public AskAutoLotteryRequest()
    {
        this.msgType = MsgType.Lottery_自动下注;
    }

    public AskAutoLotteryRequest(int userId,int num)
    {
        this.msgType = MsgType.Lottery_自动下注;
        this.userId = userId;
        this.num = num;
    }



    public override string ToString()
    {
        return "AskAutoLotteryRequest [userId=" + userId + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
