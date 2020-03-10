using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolRoomTableListRequest : Request
{
    public ManyPepolRoomTableListRequest()
    {
        msgType = MsgType.manypepol_上桌列表;
    }
}