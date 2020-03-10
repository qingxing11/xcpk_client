using System;
using ProtoBuf;
 
[ProtoContract]
public class RegisterRequest : Request{
    [ProtoMember(3)]
    public string account;

    [ProtoMember(4)]
    public string password;
    [ProtoMember(5)]
    public string nickName;

    public RegisterRequest()
    {
        this.msgType = MsgType.USER_REGISTER;
    }

    public RegisterRequest(string account,string password,string nickName)
    {
        this.msgType = MsgType.USER_REGISTER;
        this.account = account;
        this.password = password;
        this.nickName = nickName;
    }
     
}
