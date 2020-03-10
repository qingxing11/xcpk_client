using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FruitPush_XiaZhu : Response
{
    [ProtoMember(5)]
    public int userId;
    [ProtoMember(6)]
    public int type;
    [ProtoMember(7)]
    public int value;

    public FruitPush_XiaZhu()
    {
        this.msgType = MsgType.Fruit_下注;
    }
    public override string ToString()
    {
        return "FruitPush_XiaZhu [userId=" + userId + ", type=" + type + ", value=" + value + ", msgType=" + msgType + "]";
    }
}