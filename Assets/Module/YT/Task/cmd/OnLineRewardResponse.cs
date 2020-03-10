using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public class OnLineRewardResponse:Response
    {
    public const int 该时间段的奖励已领取 = 0;
    public const int 没有找到该时间段的奖励 = 1;
    public const  int 未到领取该时间段的时间 = 2;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int timeId;
    public OnLineRewardResponse()
    {

    }
    public OnLineRewardResponse(int code)
    {
        this.msgType = MsgType.RequestLingQuOnLineReward;
    }
    public override string ToString()
    {
        return "OnLineRewardResponse [timeId=" + timeId + ", msgType=" + msgType + ", code=" + code + "]";
    }
}