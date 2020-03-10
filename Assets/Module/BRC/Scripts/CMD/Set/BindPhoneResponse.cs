using ProtoBuf;

[ProtoContract]
public class BindPhoneResponse : Response
{
    [ProtoMember(4)]
    public int code;
    public BindPhoneResponse()
    {
        msgType = BINDPHONE;
    }
}