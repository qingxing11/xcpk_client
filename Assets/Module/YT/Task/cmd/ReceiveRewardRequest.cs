using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ReceiveRewardRequest : Request
{
    [ProtoMember(3)]
    public int taskId;
    public ReceiveRewardRequest()
    {
        this.msgType = MsgType.ReceiveReward;
    }

    public ReceiveRewardRequest(int taskId)
    {
        this.msgType = MsgType.ReceiveReward;
        this.taskId = taskId;
    }
    public override string ToString()
    {
        return "ReceiveRewardRequest [taskId=" + taskId + ", msgType=" + msgType + "]";
    }
}