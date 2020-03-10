using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushPlayerTaskInfoResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public TaskInfo taskInfo;
    public PushPlayerTaskInfoResponse()
    {
        this.msgType = MsgType.Push_TaskInfo;
    }
    public override string ToString()
    {
        return "PushPlayerTaskInfoResponse [taskInfo=" + taskInfo + ", msgType=" + msgType + ", code=" + code + "]";
    }
}