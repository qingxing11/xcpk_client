using ProtoBuf;

[ProtoContract]
public class GetAliPayOrderRespone : Response
{
	public const int ERROR_不存在的订单号 = 0;
	public const int ERROR_插入数据库错误 = 1;
	public const int ERROR_初始化订单信息出错 = 2;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public AliPayOrderInfo aliPayOrderInfo;
	
	public GetAliPayOrderRespone() {
	}

	/**
	 * @param code 返回码
	 */
	public GetAliPayOrderRespone(int code) {
		this.msgType = MsgType.PAY_支付宝支付下单;
		this.code = code;
	}
	
	public GetAliPayOrderRespone(int code,AliPayOrderInfo aliPayOrderInfo) {
		this.msgType = MsgType.PAY_支付宝支付下单;
		this.code = code;
		this.aliPayOrderInfo = aliPayOrderInfo;
	}
}
