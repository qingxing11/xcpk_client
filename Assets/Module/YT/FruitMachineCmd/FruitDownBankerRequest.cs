using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FruitDownBankerRequest : Request
{
    public FruitDownBankerRequest()
    {
        this.msgType = MsgType.FruitDownBanker;
    }
}