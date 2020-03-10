using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;
[ProtoContract]
public class FruitUpBankerResponse : Response
{
    public const int 未达到上装条件 = 0;
    public const int 您已是当前房间庄家 = 1;
    public const int 申请上庄失败 = 2;
    public const int 申请人数已达上限 = 3;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public PlayerSimpleData requestPlayer;
    public FruitUpBankerResponse()
    {
        this.msgType = MsgType.FruitUpBanker;
    }

    public override string ToString()
    {
        return "FruitUpBankerResponse [requestPlayer=" + requestPlayer + ", msgType=" + msgType + ", code=" + code
                + "]";
    }
}