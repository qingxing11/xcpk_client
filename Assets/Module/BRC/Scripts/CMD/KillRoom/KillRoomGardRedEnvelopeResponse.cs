using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

/// <summary>
/// 抢红包
/// </summary>
[ProtoContract]
public class KillRoomGardRedEnvelopeResponse : Response
{

    public const int 您的手慢了_当前红包被抢走了 = 0;
    public const int 您的手慢了_红包已被抢完 = 1;
    public const int 请求错误_您当前抢的红包不存在 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int userId;
    [ProtoMember(6)]
    public RedEnvelopeInfo redEnvelope;

    public KillRoomGardRedEnvelopeResponse()
    {
        this.msgType = MsgType.KillRoom_抢红包;
    }

    public override string ToString()
    {
        return "KillRoomGardRedEnvelopeResponse [userId=" + userId + ", redEnvelope=" + redEnvelope
                + ", msgType=" + msgType + ", code=" + code + "]";
    }
}