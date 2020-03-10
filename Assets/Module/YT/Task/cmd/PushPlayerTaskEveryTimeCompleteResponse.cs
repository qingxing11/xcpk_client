using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushPlayerTaskEveryTimeCompleteResponse : Response
{
    [ProtoMember(4)]
    public int code;
    //推送當前完成的任務信息
    [ProtoMember(5)]
    public TaskDetailedInfo taskDetailInfo;
    public PushPlayerTaskEveryTimeCompleteResponse()
    {
        this.msgType = MsgType.Push_TaskEveryTimeComplete;
    }

    public override string ToString()
    {
        return "PushPlayerTaskEveryTimeCompleteResponse [taskDetailInfo=" + taskDetailInfo + ", msgType=" + msgType
                + ", code=" + code + "]";
    }
}