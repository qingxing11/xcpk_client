using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolFollowBetRequest : Request
{
    public ManyPepolFollowBetRequest()
    {
        msgType = MsgType.manypepol_玩家跟注;
    }

    public override string ToString()
    {
        return "ManyPepolFollowBetRequest [msgType=" + msgType + "]";
    }
}