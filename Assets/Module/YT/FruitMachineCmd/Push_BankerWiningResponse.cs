using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]
public class Push_BankerWiningResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public PlayerSimpleData playerBanker;
    [ProtoMember(6)]
    public int winingValue;
    public Push_BankerWiningResponse()
    {

    }
    public Push_BankerWiningResponse(int code)
    {
        this.msgType = MsgType.Fruit_bankerWining;
        this.code = code;
    }

    public Push_BankerWiningResponse(int code, int winingValue, PlayerSimpleData playerBanker)
    {
        this.msgType = MsgType.Fruit_bankerWining;
        this.code = code;
        this.winingValue = winingValue;
        this.playerBanker = playerBanker;
    }

    public override string ToString()
    {
        return "Push_BankerWiningResponse [playerBanker=" + playerBanker + ", winingValue=" + winingValue + ", msgType="
                + msgType + ", code=" + code + "]";
    }
}
