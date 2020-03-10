using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class TaskInfo
{
    [ProtoMember(1)]
    public int userId;
    [ProtoMember(2)]
    public List<TaskDetailedInfo> list_dayTaskInfo;
    [ProtoMember(3)]
    public List<TaskDetailedInfo> list_personSelfTaskInfo;
    [ProtoMember(4)]
    public List<TaskDetailedInfo> list_systemTaskInfo;
    [ProtoMember(5)]
    public List<int> list_onLineReward;
    [ProtoMember(6)]
    public int freeChouJiang;
    public TaskInfo()
    {

    }
    public override string ToString()
    {
        return "TaskInfo [list_dayTaskInfo=" + list_dayTaskInfo + ", list_personSelfTaskInfo=" + list_personSelfTaskInfo
                + "]";
    }
}