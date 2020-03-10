using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class DeleteFriendRequest:Request
{
    [ProtoMember(3)]
    public int userId;


    public DeleteFriendRequest()
    {
        this.msgType = MsgType.Delete_删除好友;
    }
    public DeleteFriendRequest(int userId)
    {
        this.msgType = MsgType.Delete_删除好友;
        this.userId = userId;
    }


    public override string ToString()
    {
        return "DeleteFriendRequest [userId=" + userId + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
