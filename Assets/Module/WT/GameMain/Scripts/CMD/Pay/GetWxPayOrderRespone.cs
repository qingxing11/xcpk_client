using ProtoBuf;

[ProtoContract]

public class GetWxPayOrderRespone : Response
{
	public const int ERROR_不存在的订单号 = 0;
	public const int ERROR_下单错误 = 1;
	public const int ERROR_插入数据库错误 = 2;
	public const int ERROR_初始化订单信息出错 = 3;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string wxPayOrder;
	
	public GetWxPayOrderRespone() {
	}

	/**
	 * @param code 返回码
	 */
	public GetWxPayOrderRespone(int code) {
		this.msgType = MsgType.PAY_微信支付下单;
		this.code = code;
	}
	 
}
