using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendChatInfoResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int friendId;

    public FriendChatInfoResponse()
    {

    }

    public override string ToString()
    {
        return "FriendChatInfoResponse [friendId=" + friendId + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
