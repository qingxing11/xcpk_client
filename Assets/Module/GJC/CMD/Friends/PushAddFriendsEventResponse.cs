using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class PushAddFriendsEventResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<AddFriendsVO> list;

    public PushAddFriendsEventResponse()
    {
    }

    public override string ToString()
    {
        return "PushAddFriendsEventResponse [list=" + list + "]";
    }
}
