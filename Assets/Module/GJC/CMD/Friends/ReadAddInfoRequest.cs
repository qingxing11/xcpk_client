using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ReadAddInfoRequest:Request
{
    [ProtoMember(3)]
    public int userId;

    public ReadAddInfoRequest()
    {
        this.msgType = MsgType.Add_消息已读;
    }

    public ReadAddInfoRequest(int userId)
    {
        this.msgType = MsgType.Add_消息已读;
        this.userId = userId;
    }
    public override string ToString()
    {
        return "ReadAddInfoRequest [userId=" + userId + "]";
    }
}
