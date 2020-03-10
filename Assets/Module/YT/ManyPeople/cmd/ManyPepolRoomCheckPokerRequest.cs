using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public class ManyPepolRoomCheckPokerRequest:Request
    {
    public ManyPepolRoomCheckPokerRequest()
    {
        msgType = MsgType.manypepol_玩家看牌;
    }

}