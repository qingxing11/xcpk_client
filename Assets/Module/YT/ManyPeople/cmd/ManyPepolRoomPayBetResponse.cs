using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolRoomPayBetResponse : Response
{
    public const int ERROR_金币不足 = 0;
    public const int ERROR_不在下注时间 = 1;
    public const int ERROR_下注位置错误 = 2;
    public const int ERROR_不在比赛中 = 3;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ManyPepolRoomPayBetResponse()
    {
        msgType = MsgType.manypepol_闲家下注;
    }

    public override string ToString()
    {
        return "ManyPepolRoomPayBetResponse [betNum=" + betNum + ", msgType=" + msgType + ", code=" + code + "]";
    }
}