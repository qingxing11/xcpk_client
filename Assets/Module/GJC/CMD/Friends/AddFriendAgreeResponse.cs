using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AddFriendAgreeResponse: Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public FriendsDataVO vo;

    [ProtoMember(6)]
    public FriendInfoVO info;
    public AddFriendAgreeResponse()
    {
    }

    public override string ToString()
    {
        return "AddFriendAgreeResponse [FriendsDataVO=" + vo + ",info="+ info+ "]";
    }
}
