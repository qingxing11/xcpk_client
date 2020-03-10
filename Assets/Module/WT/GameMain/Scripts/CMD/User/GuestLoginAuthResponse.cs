using System;
using ProtoBuf;

[ProtoContract]
public class GuestLoginAuthResponse : Response
{
    public const int ERROR_NO_USER = 0;
    public const int ERROR_PASSWORD = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public TokenVO tokenVO;

    [ProtoMember(6)]
    public String device_code;

    [ProtoMember(7)]
    public int antiAddictionCode;
    public override string ToString()
    {
        return "GuestLoingAuthResponse [tokenVO=" + tokenVO + ", device_code=" + device_code + ",antiAddictionCode" + antiAddictionCode + "]";
    }
}