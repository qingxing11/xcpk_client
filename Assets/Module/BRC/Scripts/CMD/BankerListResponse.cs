using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class BankerListResponse :Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PlayerSimpleData> list_bankerList;
    public BankerListResponse()
    {
        msgType = KillRoom_庄家列表;
    }
}
