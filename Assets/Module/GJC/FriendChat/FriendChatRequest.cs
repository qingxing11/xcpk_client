using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendChatRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    [ProtoMember(4)]
    public int friendId;

    [ProtoMember(5)]
    public string info;

    public FriendChatRequest()
    {
        this.msgType = MsgType.ChatInfo_好友聊天;
    }

    public FriendChatRequest(int userId, int friendId, string info)
    {
        this.msgType = MsgType.ChatInfo_好友聊天;
        this.userId = userId;
        this.friendId = friendId;
        this.info = info;
    }

    public override string ToString()
    {
        return "FriendChatRequest [userId=" + userId + ", friendId=" + friendId + ", info=" + info + ", msgType="
                 + msgType + ", callBackId=" + callBackId + "]";
    }
}
