using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FruitMachineXiaZhuResponse : Response
{
    [ProtoMember(4)]
    public int code;
    public FruitMachineXiaZhuResponse()
    {
        this.msgType = MsgType.FruitMechine;
    }
    public FruitMachineXiaZhuResponse(int code)
    {
        this.code = code;
        this.msgType = MsgType.FruitMechine;
    }
}