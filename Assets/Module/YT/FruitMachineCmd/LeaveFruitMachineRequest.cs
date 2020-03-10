using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;
[ProtoContract]
public class LeaveFruitMachineRequest : Request
{
    public LeaveFruitMachineRequest()
    {
        this.msgType = MsgType.LeaveFruitMechine;
    }
}