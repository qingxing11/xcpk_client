using ProtoBuf;

[ProtoContract]
public class Push_coinsChange : Response
{
    [ProtoMember(5)]
    public long changeNum; // 改变数量

	public Push_coinsChange()
	{
		this.msgType = MsgType.PUSHUSER_金币变化;
	}
 
}
