using ProtoBuf;

/// <summary>
/// 读取一封邮件
/// </summary>
[ProtoContract]
public class ReadMailResponse : Response
{
    public const int ERROR_邮件不存在 = 0;
    public const int ERROR_已阅读 = 1;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int mailId;
    public ReadMailResponse()
    {
        msgType = MAIL_READ;
    }
}