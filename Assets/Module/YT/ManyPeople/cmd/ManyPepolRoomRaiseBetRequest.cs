using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
  public  class ManyPepolRoomRaiseBetRequest :Request
    {
    [ProtoMember(3)]
    public int betNum;
    public ManyPepolRoomRaiseBetRequest()
    {
        msgType = MsgType.manypepol_玩家加注;
    }
    public override string ToString()
    {
        return "ManyPepolRoomRaiseBetRequest [betNum=" + betNum + ", msgType=" + msgType + "]";
    }
}