using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class LookFriendsRequest:Request
{
    [ProtoMember(3)]
    public int userId;
    public LookFriendsRequest()
    {
        this.msgType = MsgType.Look_查找好友;
    }

    public LookFriendsRequest(int userId)
    {
        this.userId = userId;
        this.msgType = MsgType.Look_查找好友;
    }
    public override string ToString()
    {
        return "LookFriendsRequest:查找好友";
    }


}
