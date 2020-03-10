using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AddFriendsResponse:Response
{
    public const int Error_重复请求添加 = 0;
    public const int Error_已经添加好友 = 1;
    public const int Error_超过好友上限 = 2;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public AddFriendsVO vo;

    public AddFriendsResponse()
    {

    }
    public override string ToString()
    {
        return "PushAddFriendsResponse [AddFriendsVO=" + vo + "]";
    }
}
