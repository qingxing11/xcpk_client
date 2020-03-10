using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class DeleteFriendResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

    [ProtoMember(6)]
    public int askUserId;//主动删除方
    public DeleteFriendResponse()
    {

    }
    public override string ToString()
    {
        return "DeleteFriendResponse [userId=" + userId + ", askUserId=" + askUserId + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
