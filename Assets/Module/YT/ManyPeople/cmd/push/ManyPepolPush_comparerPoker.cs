using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]

  public  class ManyPepolPush_comparerPoker:Response
    {
    [ProtoMember(4)]
    public int code;
    /**发起方*/
    [ProtoMember(5)]
    public int pos0;

    /**被比方*/
    [ProtoMember(6)]
    public int pos1;

    /**输方*/
    [ProtoMember(7)]
    public int lossPos;

    [ProtoMember(8)]
    public int subCoins;
    public ManyPepolPush_comparerPoker()
    {
        msgType = MsgType.manypepol_其他玩家比牌;
    }
    public override string ToString()
    {
        return "ManyPepolPush_comparerPoker [pos0=" + pos0 + ", pos1=" + pos1 + ", lossPos=" + lossPos + ", msgType=" + msgType + ", code=" + code + "]";
    }
}
