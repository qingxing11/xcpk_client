using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ManyPepolPush_playerSitdown : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public PlayerSimpleData playerSimpleData;

    public ManyPepolPush_playerSitdown()
    {
        msgType = MsgType.manypepol_有玩家上桌;
    }

    public override string ToString()
    {
        return "ManyPepolPush_playerSitdown [playerSimpleData=" + playerSimpleData + ", msgType=" + msgType + "]";
    }
}