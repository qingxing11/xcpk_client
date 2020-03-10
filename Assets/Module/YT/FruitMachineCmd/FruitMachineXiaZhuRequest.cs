using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class FruitMachineXiaZhuRequest : Request
{
    [ProtoMember(3)]
    public int fruitMachineType;
    [ProtoMember(4)]
    public int fruitMachineValue;
    public FruitMachineXiaZhuRequest()
    {
        this.msgType = MsgType.FruitMechine;
    }

    public FruitMachineXiaZhuRequest(int fruitMachineType, int fruitMachineValue)
    {
        this.msgType = MsgType.FruitMechine;
        this.fruitMachineType = fruitMachineType;
        this.fruitMachineValue = fruitMachineValue;
    }
    public override string ToString()
    {
        return "FruitMachineXiaZhuRequest [FruitMachineXiaZhuRequest=" + fruitMachineType + ", fruitMachineValue=" + fruitMachineValue
                + ", msgType=" + msgType + "]";
    }
}