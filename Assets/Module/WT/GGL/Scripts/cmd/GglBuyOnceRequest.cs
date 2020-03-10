
using ProtoBuf;

[ProtoContract]
public class GglBuyOnceRequest : Request
{
    [ProtoMember(3)]
    public int level;
    public GglBuyOnceRequest()
    {
        msgType = MsgType.GGL_单次购买;
    }
}
