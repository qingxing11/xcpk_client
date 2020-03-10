using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ReceiveRewardResponse : Response
{
    public const int 当前任务不存在 = 0;
    public const int 当前任务已领取奖励 = 1;
    public const int 当前任务未到领取条件 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public TaskDetailedInfo taskDetailedInfo;
    public ReceiveRewardResponse()
    {
        this.msgType = MsgType.ReceiveReward;
    }

    public override string ToString()
    {
        return "ReceiveRewardResponse [taskDetailedInfo=" + taskDetailedInfo + ", msgType=" + msgType + ", code=" + code
                + "]";
    }
}