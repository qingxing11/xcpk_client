using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
public class GetServerListResponse : Response {
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<ServerInfoVO> list_serverInfo;// 服务器消息

	public GetServerListResponse() {
		this.msgType = MsgType.UTIL_SERVER_LIST;
	}
}
