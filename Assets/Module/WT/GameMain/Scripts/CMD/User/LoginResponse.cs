using ProtoBuf;

[ProtoContract]
public class LoginResponse : Response
{
    public const int ERROR_NO_USER = 100;
    public const int ERROR_BANNED = 101;
    public const int ERROR_WRONG_PWD = 102;
    public const int ERROR_ALREADY_ONLINE = 103;// 重复登录
    public const int ERROR_证书错误 = 104;
    public const int ERROR_版本过低需要更新 = 105;
    public const int ERROR_服务器重启维护 = 106;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public TokenVO tokenVO;

    [ProtoMember(6)]
    public int antiAddictionCode;
    public override string ToString()
    {
        return "LoginResponse [tokenVO=" + tokenVO + ", msgType=" + msgType + ", code=" + code + "]";
    }
}