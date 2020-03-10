using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolPush_playerStandUp : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;
    public ManyPepolPush_playerStandUp()
    {
        msgType = MsgType.manypepol_玩家下桌;
    }

    public override string ToString()
    {
        return "ManyPepolPush_playerStandUp [pos=" + pos + "]";
    }
}