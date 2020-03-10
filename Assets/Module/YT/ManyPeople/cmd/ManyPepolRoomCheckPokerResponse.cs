using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class ManyPepolRoomCheckPokerResponse:Response
    {
    public const int ERROR_不在比赛中 = 0;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PokerVO> list_poker;
    [ProtoMember(6)]
    public int pokerType;
    public ManyPepolRoomCheckPokerResponse()
    {
        msgType = MsgType.manypepol_玩家看牌;
    }
    public override string ToString()
    {
        return "ManyPepolRoomCheckPokerResponse [msgType=" + msgType + ", code=" + code + "]";
    }

}