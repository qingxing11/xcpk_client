using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]
public class Push_FruitMachineStartXiaZhuResponse : Response
{
    public Push_FruitMachineStartXiaZhuResponse()
    {
        this.msgType = MsgType.FruitMechine_开始下注;
    }
}