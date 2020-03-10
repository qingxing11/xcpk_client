using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]

public class FruitDownBankerResponse : Response
{
    public const int 你不是当前庄家_不能申请下庄 = 0;
    [ProtoMember(4)]
    public int code;
    public FruitDownBankerResponse()
    {
        this.msgType = MsgType.FruitDownBanker;
    }
    public FruitDownBankerResponse(int code)
    {
        this.code = code;
        this.msgType = MsgType.FruitDownBanker;
    }
    public override string ToString()
    {
        return "FruitDownBankerResponse [msgType=" + msgType + ", code=" + code
                + "]";
    }
}
