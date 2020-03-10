using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ReadInfoRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    public ReadInfoRequest()
    {
        this.msgType = MsgType.Info_消息已读;
    }

    public ReadInfoRequest(int userId)
    {
        this.msgType = MsgType.Info_消息已读;
        this.userId = userId;
    }

    public override string ToString()
    {
        return "ReadInfoRequest [userId=" + userId + "]";
    }
}
