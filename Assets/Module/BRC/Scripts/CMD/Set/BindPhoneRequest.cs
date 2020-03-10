using ProtoBuf;
 
[ProtoContract]
public class BindPhoneRequest : Request
{
    [ProtoMember(3)]
    public int codeNum;
   
    public BindPhoneRequest()
    {
        msgType = BINDPHONE;
    }
}
