using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]
public class EnterFruitMachineRequest : Request
{
    public EnterFruitMachineRequest()
    {
        this.msgType = MsgType.EnterFruitMechine;
    }
}