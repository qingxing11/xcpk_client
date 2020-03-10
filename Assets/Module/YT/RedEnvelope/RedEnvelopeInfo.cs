using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class RedEnvelopeInfo
{

    //红包索引
    [ProtoMember(1)]
    public int redEnvelopeIndex;

    //红包额度
    [ProtoMember(2)]
    public long redEnvelopeValue;

    [ProtoMember(3)]
    public int userId;

    public override string ToString()
    {
        return "RedEnvelopeInfo [redEnvelopeIndex=" + redEnvelopeIndex + ", redEnvelopeValue=" + redEnvelopeValue + "]";
    }
}