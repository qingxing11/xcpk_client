using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class ManyPepolPush_payBet:Response
    {
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ManyPepolPush_payBet()
    {
        msgType = MsgType.manypepol_有闲家下注;
    }

    public override string ToString()
    {
        return "ManyPepolPush_payBet [pos=" + pos + ", betNum=" + betNum + ", msgType=" + msgType + ", code=" + code + "]";
    }
}
