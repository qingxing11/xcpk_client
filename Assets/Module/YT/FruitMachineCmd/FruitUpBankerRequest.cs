using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;
[ProtoContract]
public class FruitUpBankerRequest : Request
{
    public FruitUpBankerRequest()
    {
        this.msgType = MsgType.FruitUpBanker;
    }
}