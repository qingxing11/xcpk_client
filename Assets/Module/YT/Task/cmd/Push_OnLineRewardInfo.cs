using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class Push_OnLineRewardInfo:Response
    {
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<int> list_onLineRewardInfo;
    public Push_OnLineRewardInfo()
    {
        this.msgType = MsgType.Push_onLineRewardInfo;
    }

    public override string ToString()
    {
        return "Push_OnLineRewardInfo [list_onLineRewardInfo=" + list_onLineRewardInfo + ", msgType=" + msgType
                + ", code=" + code + "]";
    }
}