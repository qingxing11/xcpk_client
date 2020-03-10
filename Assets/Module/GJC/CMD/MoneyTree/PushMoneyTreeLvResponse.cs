using ProtoBuf;

[ProtoContract]
public class PushMoneyTreeLvResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int treeLv;

	public PushMoneyTreeLvResponse() 
	{
		this.msgType= MsgType.MoneyTree_升级;
	}
	
	public PushMoneyTreeLvResponse(int lv) 
	{
		this.msgType= MsgType.MoneyTree_升级;
		this.code=PushMoneyTreeResponse.SUCCESS;
		this.treeLv = lv;
	}

}
