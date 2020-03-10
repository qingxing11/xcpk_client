using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
public class SendHornInfoRequest : Request
{
    [ProtoMember(3)]
    public string info;

    public SendHornInfoRequest()
    {
        this.msgType = MsgType.Horn_喇叭消息;
    }

    public SendHornInfoRequest(String info)
    {
        this.msgType = MsgType.Horn_喇叭消息;
        this.info = info;
    }

    public override string ToString()
    {
        return "SendHornInfoRequest [info=" + info + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}