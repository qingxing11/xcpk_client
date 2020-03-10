using System;
using ProtoBuf;
using UnityEngine;

[ProtoContract]
public class LoginRequest : Request{

    [ProtoMember(3)]
    public string account;

    [ProtoMember(4)]
    public string password;

    [ProtoMember(5)]
    public string asdasdsd;
    public LoginRequest()
    {
        this.msgType = MsgType.USER_LOGIN;
      
    }

    public LoginRequest(string account,string password)
    {
        this.msgType = MsgType.USER_LOGIN;
        this.account = account;
        this.password = password;
    }

    public override string ToString()
    {
        return "actionLoginRequest [account=" + account + ", password=" + password + ", msgType=" + msgType + "]";
    }
}
