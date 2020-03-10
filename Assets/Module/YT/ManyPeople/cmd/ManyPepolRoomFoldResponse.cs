using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
  public  class ManyPepolRoomFoldResponse:Response
    {
    public const int ERROR_不在比赛中 = 0;
    [ProtoMember(4)]
    public int code;
    public ManyPepolRoomFoldResponse()
    {
        msgType = MsgType.manypepol_玩家弃牌;
    }
    public override string ToString()
    {
        return "FoldResponse [msgType=" + msgType + ", code=" + code + "]";
    }

}