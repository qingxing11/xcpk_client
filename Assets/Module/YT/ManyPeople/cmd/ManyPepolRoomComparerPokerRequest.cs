using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]

  public   class ManyPepolRoomComparerPokerRequest:Request
    {
    [ProtoMember(3)]
    public int pos;
    public ManyPepolRoomComparerPokerRequest()
    {
        msgType = MsgType.manypepol_玩家比牌;
    }
    
}