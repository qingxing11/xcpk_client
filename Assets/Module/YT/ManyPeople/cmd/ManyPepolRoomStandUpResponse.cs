using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
  public  class ManyPepolRoomStandUpResponse:Response
    {
    public const int ERROR_还未坐下 = 0;
    public const int ERROR_不在游戏中 = 1;
    [ProtoMember(4)]
    public int code;
    public ManyPepolRoomStandUpResponse()
    {
        msgType = MsgType.manypepol_申请下桌;
    }

    public override string ToString()
    {
        return "ManyPepolRoomStandUpResponse [msgType=" + msgType + ", code=" + code + "]";
    }
}