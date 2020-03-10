using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendChatResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public FriendChatVO vo;

    public FriendChatResponse()
    {

    }

    public override string ToString()
    {
        return "FriendChatResponse [vo=" + vo + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
