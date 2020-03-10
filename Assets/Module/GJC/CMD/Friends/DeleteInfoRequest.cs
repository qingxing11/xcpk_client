using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class DeleteInfoRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    public DeleteInfoRequest()
    {
        this.msgType = MsgType.Delete_删除消息;
    }
    public DeleteInfoRequest(int userId)
    {
        this.msgType = MsgType.Delete_删除消息;
        this.userId = userId;
    }
    public override string ToString()
    {
        return "DeleteInfoRequest [userId=" + userId + "]";
    }
}
