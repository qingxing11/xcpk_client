using ProtoBuf;

[ProtoContract]
public class GetResResponse : Response
{
    public const int ERROR_平台非法 = 0;
    public const int ERROR_版本非法 = 1;
    public const int ERROR_不需要更新 = 2;
    public const int SUCCESS_需要大版本更新 = 3;

  


    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public HotfixUpdateFileVO updateFileVO;

    [ProtoMember(6)]
    public string install_pack_url;

    [ProtoMember(7)]
    public int bigVersion;
    public GetResResponse()
    {
        msgType = MsgType.UTIL_GET_NEW_FILE_URL;
    }

}
