using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskFriendsRequest:Request
{
    public AskFriendsRequest()
    {
        this.msgType =ASKFRIENDS;
    }
    public override string ToString()
    {
        return "AskFriendsRequest:请求好友列表 ";
    }
}
