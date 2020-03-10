using System;
using ProtoBuf;

[ProtoContract]
public class GetServerListRequest : Request {

	public GetServerListRequest() {
		this.msgType = MsgType.UTIL_SERVER_LIST;
	}
}
