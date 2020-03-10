using ProtoBuf;

[ProtoContract]
public class BuyGoldRespone : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int reward;
	public BuyGoldRespone() {
		msgType = MsgType.PAY_BUYGOLD;
	}

	/**
	 * @param code 返回码
	 */
	public BuyGoldRespone(int code,int reward) {
		msgType = MsgType.PAY_BUYGOLD;
		this.code = code;
		this.reward = reward;
	}
}