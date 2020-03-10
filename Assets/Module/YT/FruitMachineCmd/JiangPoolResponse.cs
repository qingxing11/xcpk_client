using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
[ProtoContract]
public class JiangPoolResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public long jiangPoolValue;

    public JiangPoolResponse()
    {

    }
    public JiangPoolResponse(int code)
    {
        this.code = code;
        this.msgType = MsgType.Fruit_JiangPool;
    }

    public JiangPoolResponse(int code, long jiangPoolValue)
    {
        this.code = code;
        this.jiangPoolValue = jiangPoolValue;
        this.msgType = MsgType.Fruit_JiangPool;
    }
    public override string ToString()
    {
        return "JiangPoolResponse [jiangPoolValue=" + jiangPoolValue + ", msgType=" + msgType + ", code=" + code + "]";
    }
}