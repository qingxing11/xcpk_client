using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolRoomStandUpRequest : Request
{
    public ManyPepolRoomStandUpRequest()
    {
        msgType = MsgType.manypepol_申请下桌;
    }
}