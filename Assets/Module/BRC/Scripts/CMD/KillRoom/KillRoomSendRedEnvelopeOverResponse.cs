using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class KillRoomSendRedEnvelopeOverResponse :Response
    {
    public KillRoomSendRedEnvelopeOverResponse()
    {
        this.msgType = MsgType.KillRoom_抢红包结束;
    }
    public override string ToString()
    {
        return "KillRoomSendRedEnvelopeOverResponse [msgType=" + msgType  + "]";
    }
}