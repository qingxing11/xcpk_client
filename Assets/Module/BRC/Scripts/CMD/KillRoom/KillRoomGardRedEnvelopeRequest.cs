using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract ]
public class KillRoomGardRedEnvelopeRequest : Request
{

    [ProtoMember(3)]
    public int redEnvelopeIndex;
    [ProtoMember(4)]
    public long redEnvelopeValue;
    public KillRoomGardRedEnvelopeRequest()
    {
        this.msgType = MsgType.KillRoom_抢红包;
    }

    public KillRoomGardRedEnvelopeRequest(int redEnvelopeIndex, long redEnvelopeValue)
    {
        this.msgType = MsgType.KillRoom_抢红包;
        this.redEnvelopeIndex = redEnvelopeIndex;
        this.redEnvelopeValue = redEnvelopeValue;
    }

    public override string ToString()
    {
        return "KillRoomGardRedEnvelopeRequest [redEnvelopeIndex=" + redEnvelopeIndex + ", redEnvelopeValue="
                + redEnvelopeValue + ", msgType=" + msgType + "]";
    }
}