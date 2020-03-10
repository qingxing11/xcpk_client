using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskLotteryRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    [ProtoMember(4)]
    public int number;

    [ProtoMember(5)]
    public int type;

    public AskLotteryRequest()
    {
        this.msgType = MsgType.Lottery_下注;
    }

    public AskLotteryRequest(int userId, int number, int type)
    {
        this.msgType = MsgType.Lottery_下注;
        this.userId = userId;
        this.number = number;
        this.type = type;
    }



   
        public override  string ToString()
    {
        return "AskLotteryRequest [userId=" + userId + ", number=" + number + ", type=" + type + ", msgType="
                + msgType + ", callBackId=" + callBackId + "]";
    }
}
