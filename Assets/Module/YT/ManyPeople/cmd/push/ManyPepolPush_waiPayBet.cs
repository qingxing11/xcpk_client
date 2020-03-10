using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using ProtoBuf;

[ProtoContract]
  public   class ManyPepolPush_waiPayBet:Response
    {
    [ProtoMember(4)]
    public int code;
    public ManyPepolPush_waiPayBet()
    {
        msgType = MsgType.manypepol_开始下注;
    }
    public override string ToString()
    {
        return "ManyPepolPush_waiStart [msgType=" + msgType + ", code=" + code + "]";
    }
}