using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FruitBankerListRequest : Request
{
    public FruitBankerListRequest()
    {
        this.msgType = MsgType.Fruit_requestBankerList;
    }
}
