using ProtoBuf;

[ProtoContract]
public class GetAliPayWebOrderRespone : Response
{
	public const int ERROR_不存在的订单号 = 0;
	public const int ERROR_插入数据库错误 = 1;
	public const int ERROR_初始化订单信息出错 = 2;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string payOrder;
	
	public GetAliPayWebOrderRespone() {
        this.msgType = MsgType.PAY_支付宝网页支付下单;
    }
 
}
