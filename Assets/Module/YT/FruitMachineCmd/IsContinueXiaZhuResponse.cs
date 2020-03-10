using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]
public class IsContinueXiaZhuResponse : Response
{
    public IsContinueXiaZhuResponse()
    {
        this.msgType = MsgType.Fruit_ContinueXiaZhu;
    }
    public override string ToString()
    {
        return "IsContinueXiaZhuResponse [msgType=" + msgType + "]";
    }

}