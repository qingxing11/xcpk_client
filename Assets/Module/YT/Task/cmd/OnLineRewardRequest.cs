using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class OnLineRewardRequest:Request
    {
    [ProtoMember(3)]
    public int timeId;
    public OnLineRewardRequest()
    {
        this.msgType = MsgType.RequestLingQuOnLineReward;
    }
    public OnLineRewardRequest(int timeId)
    {
        this.msgType = MsgType.RequestLingQuOnLineReward;
        this.timeId = timeId;
    }
    public override string ToString()
    {
        return "OnLineRewardRequest [timeId=" + timeId + ", msgType=" + msgType + "]";
    }
}