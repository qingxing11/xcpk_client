using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolRoomComparerPokerResponse : Response
{
    public const int ERROR_不在比赛中 = 0;
    public const int ERROR_没轮到行动 = 1;
    public const int ERROR_比牌错误 = 2;


    [ProtoMember(4)]
    public int code;

    public ManyPepolRoomComparerPokerResponse()
    {
        msgType = MsgType.manypepol_玩家比牌;
    }

    public override string ToString()
    {
        return "ManyPepolRoomComparerPokerResponse [msgType=" + msgType + ", code=" + code + "]";
    }
}