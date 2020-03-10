

using ProtoBuf;

[ProtoContract]
public class Request : MsgType
{
    [ProtoMember(1)]
    public int msgType;

    [ProtoMember(2)]
    public int callBackId;
    public Request()
    { }

     public override string ToString()
    {
        return "MsgType:" + msgType;
    }
}


