using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class EnterManyPepolRoomRequest : Request
{
    public EnterManyPepolRoomRequest()
    {
        msgType = MsgType.manypepol_玩家进入;
    }

    public override string ToString()
    {
        return "EnterManyPepolRoomRequest [msgType=" + msgType + "]";
    }
}
