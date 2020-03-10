using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

/// <summary>
/// 万人场其他玩家看牌
/// </summary>
[ProtoContract]
public class ManyPepolPush_checkPoker : Response
{
    [ProtoMember(4)]
    public int code;
    /**
    * 
    */
    [ProtoMember(5)]
    public int pos;
    public ManyPepolPush_checkPoker()
    {
        msgType = MsgType.classic_有玩家看牌;
    }

    public override string ToString()
    {
        return "ClassicGamePush_checkPoker [pos=" + pos + ", msgType=" + msgType + ", code=" + code + "]";
    }
}