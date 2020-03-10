using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ManyPepolRoomPayBetRequest : Request
{
    [ProtoMember(3)]
    public int pos;
    [ProtoMember(4)]
    public int betNum;
    public ManyPepolRoomPayBetRequest()
    {
        msgType = MsgType.manypepol_闲家下注;
    }
    public override string ToString()
    {
        return "ManyPepolRoomPayBetRequest [pos=" + pos + ", betNum=" + betNum + ", msgType=" + msgType + "]";
    }
}