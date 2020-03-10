using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class ManyPepolRoomTableListResponse:Response
    {
    public const int ERROR_不在比赛中 = 0;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PlayerSimpleData> list_players;
    public ManyPepolRoomTableListResponse()
    {
        msgType = MsgType.manypepol_上桌列表;
    }

    public override string ToString()
    {
        return "ManyPepolRoomTableListResponse [list_players=" + list_players + ", msgType=" + msgType + ", code=" + code + "]";
    }
}
