using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushFriendChatInfoResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<FriendChatVO> list;

    public PushFriendChatInfoResponse()
    {

    }

    public override string ToString()
    {
        return "PushFriendChatInfoResponse [list=" + list + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
