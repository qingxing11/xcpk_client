using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushAddFriendsResponse:Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public AddFriendsVO vo;

    public PushAddFriendsResponse()
    {
    }

    public override string ToString()
    {
        return "PushAddFriendsResponse [AddFriendsVO=" + vo + "]";
    }
}
