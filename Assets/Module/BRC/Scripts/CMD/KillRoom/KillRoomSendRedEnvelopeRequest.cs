using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

/// <summary>
/// 发红包
/// </summary>
[ProtoContract]
public class KillRoomSendRedEnvelopeRequest : Request
{
    [ProtoMember(3)]
    public int userId;//发红包的玩家
    [ProtoMember(4)]
    public long redEnvelopeValue;//发的红包金额
   


    public KillRoomSendRedEnvelopeRequest(int userId, long redEnvelopeValue)
    {
        this.msgType = MsgType.KillRoom_发红包;
        this.userId = userId;
        this.redEnvelopeValue = redEnvelopeValue;
    }

    public override string ToString()
    {
        return "KillRoomSendRedEnvelopeRequest [userId=" + userId + ", redEnvelopeValue=" + redEnvelopeValue
                + ", msgType=" + msgType + "]";
    }


}