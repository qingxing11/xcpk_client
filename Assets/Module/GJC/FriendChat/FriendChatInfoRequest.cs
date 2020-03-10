using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendChatInfoRequest:Request
{
    [ProtoMember(3)]
    public int friendId;

    public FriendChatInfoRequest()
    {
        this.msgType = MsgType.ChatInfo_好友聊天状态;
    }

    public FriendChatInfoRequest(int friendId)
    {
        this.msgType = MsgType.ChatInfo_好友聊天状态;
        this.friendId = friendId;
    }

    public override string ToString()
    {
        return "FriendChatInfoRequest [friendId=" + friendId + ", msgType=" + msgType + ", callBackId=" + callBackId
                 + "]";
    }
}