using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
public class AddFriendsRequest:Request
{
    [ProtoMember(3)]
    public int id;

    public AddFriendsRequest()
    {
        this.msgType = MsgType.ADDFRIENDS;
    }

    public AddFriendsRequest(int id)
    {
        this.msgType = MsgType.ADDFRIENDS;
        this.id = id;
    }

    public override string ToString()
    {
        return "AddFriendsRequest  添加好友[好友id=" + id + "]";
    }
}
