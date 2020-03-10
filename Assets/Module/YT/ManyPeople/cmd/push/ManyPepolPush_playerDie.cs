using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class ManyPepolPush_playerDie:Response
    {
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;

    public ManyPepolPush_playerDie()
    {
        msgType = MsgType.manypepol_有玩家弃牌;
    }

    public override string ToString()
    {
        return "ManyPepolPush_playerDie [pos=" + pos + ", msgType=" + msgType + ", code=" + code + "]";
    }
}