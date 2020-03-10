using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class PushFriendsInfoResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<FriendInfoVO> info;

    public PushFriendsInfoResponse()
    {

    }
    public override string ToString()
    {
        return "PushFriendsInfoResponse [info=" + info + "]";
    }
}
