using ProtoBuf;

[ProtoContract]
public class GuestLoginAuthRequest : Request{
    [ProtoMember(3)]
    public string device_code;
     
   
    public GuestLoginAuthRequest()
    {
        this.msgType = MsgType.USER_GUESTLOGIN;
    }
     
    public override string ToString()
    {
        return "actionLoginRequest [device_code=" + device_code + ", msgType=" + msgType + "]";
    }
}
