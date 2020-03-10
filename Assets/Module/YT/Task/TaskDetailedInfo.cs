using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class TaskDetailedInfo
{
    [ProtoMember(1)]
    public int taskId;//任务id
    [ProtoMember(2)]
    public int taskBigType;//任务大类型 日常任务/终极任务
    [ProtoMember(3)]
    public int taskSmallType;//任务小类型  日常任务之一/终极任务之一
    [ProtoMember(4)]
    public int currentValue;//任务当前达到的值
    [ProtoMember(5)]
    public int completeValue;//任务完成的值
    [ProtoMember(6)]
    public bool isGetReward;//是否可以领奖励
    [ProtoMember(7)]
    public bool isLingQu;//是否已经领取过奖励 
    public TaskDetailedInfo()
    {
    }

    public override string ToString()
    {
        return "TaskDetailedInfo [taskId=" + taskId + ", taskBigType=" + taskBigType + ", taskSmallType="
                + taskSmallType + ", currentValue=" + currentValue + ", completeValue=" + completeValue
                + ", isGetReward=" + isGetReward + ", isLingQu=" + isLingQu + "]";

    }
}