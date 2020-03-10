using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public class ManyPepolRoomFoldRequest:Request
    {
    public ManyPepolRoomFoldRequest()
    {
        msgType = MsgType.manypepol_玩家弃牌;
    }

}