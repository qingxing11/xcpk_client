using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class Push_ChangeBankerListInfoResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public PlayerSimpleData nextBanker;
    [ProtoMember(6)]
    public List<PlayerSimpleData> bankers;
    public Push_ChangeBankerListInfoResponse()
    {

    }

    public Push_ChangeBankerListInfoResponse(int code, List<PlayerSimpleData> bankers,PlayerSimpleData nextBanker)
    {

        this.msgType = MsgType.Fruit_bankerListChange;
        this.code = code;
        this.bankers = bankers;
        this.nextBanker = nextBanker;
    }
    public override string ToString()
    {
        return "Push_ChangeBankerListInfoResponse [nextBanker=" + nextBanker + ", bankers=" + bankers + ", msgType="
                + msgType + ", code=" + code + "]";
    }
}