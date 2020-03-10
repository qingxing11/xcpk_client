using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
  public   class ManyPepolRoomAllInRequest:Request
    {
    public ManyPepolRoomAllInRequest()
    {
        msgType = MsgType.manypepol_玩家全压;
    }
}