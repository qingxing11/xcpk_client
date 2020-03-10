using System.Collections.Generic;
using ProtoBuf;

[ProtoContract]
public class GglRewardRespone : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int money;
    public GglRewardRespone() {
    }

    /**
	 * @param code 返回码
	 */
    public GglRewardRespone(int code) {
        this.msgType = MsgType.GGL_兑奖;
        this.code = code;
    }
 
}
