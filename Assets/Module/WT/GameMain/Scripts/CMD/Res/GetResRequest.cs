
using ProtoBuf;

[ProtoContract]
public class GetResRequest : Request
{
    [ProtoMember(3)]
    public int clientVersion;

    /// <summary>
    /// 0:android
    /// 1:ios
    /// 2:pc
    /// </summary>
    /// 
    [ProtoMember(4)]
    public int clientPlatform;
    [ProtoMember(5)]
    public int bigVersion;
    public GetResRequest()
	{
		msgType = MsgType.UTIL_GET_NEW_FILE_URL;
	}
	
	public GetResRequest(int clientVersion,int clientPlatform,int bigVersion)
	{
		msgType = MsgType.UTIL_GET_NEW_FILE_URL;
		this.clientVersion = clientVersion;
		this.clientPlatform = clientPlatform;
        this.bigVersion = bigVersion;
    }
}
