using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
 public    class ManyPepolRoomAllInResponse:Response
    {
    public const int ERROR_不在比赛中 = 0;
    public const int ERROR_没轮到行动 = 1;
    public const int ERROR_不在可全压人数 = 2;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public long betNum;
    public ManyPepolRoomAllInResponse()
    {
        msgType = MsgType.manypepol_玩家全压;
    }
    public override string ToString()
    {
        return "AllInResponse [betNum=" + betNum + ", msgType=" + msgType + ", code=" + code + "]";

    }

}
