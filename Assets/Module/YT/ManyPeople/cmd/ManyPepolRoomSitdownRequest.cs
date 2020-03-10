using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ManyPepolRoomSitdownRequest : Request
{
    public ManyPepolRoomSitdownRequest()
    {
        msgType = manypepol_申请上桌;
    }
    public override string ToString()
    {
        return "ManyPepolRoomSitdownRequest [msgType=" + msgType + "]";
    }
}