using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
  public  class ManyPepolRoomSitdownResponse :Response
    {
    public const int ERROR_金币不足 = 0;
    public const int ERROR_已经坐下 = 1;
    public const int ERROR_列表满 = 2;
    public const int ERROR_已在列表 = 3;

    [ProtoMember(4)]
    public int code;

    public ManyPepolRoomSitdownResponse()
    {
        msgType = MsgType.manypepol_申请上桌;
    }
    public override string ToString()
    {
        return "ManyPepolRoomSitdownResponse [msgType=" + msgType + ", code=" + code + "]";
    }
}