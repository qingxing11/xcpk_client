using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolPush_waiStart : Response
{
    [ProtoMember(4)]
    public int code;
    public ManyPepolPush_waiStart()
    {
        msgType = MsgType.manypepol_开始下注_等待比赛开始;
    }
    public override string ToString()
    {
        return "ManyPepolPush_waiStart [msgType=" + msgType + ", code=" + code + "]";
    }
}