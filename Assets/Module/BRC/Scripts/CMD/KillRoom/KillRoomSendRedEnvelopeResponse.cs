using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]

public class KillRoomSendRedEnvelopeResponse : Response
{
    public const int 玩家金币不足 = 0;
    public const int 您不是当前庄家_不能发红包 = 1;
    public const int 本轮红包未结束_不能发红包 = 2;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<RedEnvelopeInfo> redEnvelopeInfo;// 返回具体红包信息
    [ProtoMember(6)]
    public int redEnvelopeState;
    [ProtoMember(7)]
    public int userId;
    public KillRoomSendRedEnvelopeResponse()
    {

    }
    public KillRoomSendRedEnvelopeResponse(int code)
    {
        this.msgType = MsgType.KillRoom_发红包;
        this.code = code;
    }

    public KillRoomSendRedEnvelopeResponse(int code, List<RedEnvelopeInfo> redEnvelopeInfo, int redEnvelopeState,int userId)
    {
        this.msgType = MsgType.KillRoom_发红包;
        this.code = code;
        this.redEnvelopeInfo = redEnvelopeInfo;
        this.redEnvelopeState = redEnvelopeState;
        this.userId = userId;
    }


    public override string ToString()
    {
        return "KillRoomSendRedEnvelopeResponse [redEnvelopeInfo=" + redEnvelopeInfo + ", redEnvelopeState="
                + redEnvelopeState + ", userId=" + userId + ", msgType=" + msgType + ", code=" + code + "]";
    }

}