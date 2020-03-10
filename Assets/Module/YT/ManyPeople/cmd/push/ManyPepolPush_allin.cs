using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolPush_allin : Response
{
    [ProtoMember(4)]
    public int code;
    /**
     * 玩家位置
     */
    [ProtoMember(5)]
    public int pos;
    [ProtoMember(6)]
    public int betNum;
    public ManyPepolPush_allin()
    {
        msgType = MsgType.manypepol_其他玩家全压;
    }
    public override string ToString()
    {
        return "ManyPepolPush_allin [pos=" + pos + ", betNum=" + betNum + ", msgType=" + msgType + ", code=" + code + "]";
    }
}