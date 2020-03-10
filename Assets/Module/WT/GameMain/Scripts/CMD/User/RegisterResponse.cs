using System;
using ProtoBuf;

[ProtoContract]
public class RegisterResponse : Response
{
    public const int ERROR_账号已存在 = 0;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string account;

    [ProtoMember(6)]
    public string password;

    [ProtoMember(7)]
    public TokenVO tokenVO;

    [ProtoMember(8)]
    public string nickName;

    [ProtoMember(9)]
    public int antiAddictionCode;
    public RegisterResponse()
    {
        this.msgType = MsgType.USER_REGISTER;
    }
}