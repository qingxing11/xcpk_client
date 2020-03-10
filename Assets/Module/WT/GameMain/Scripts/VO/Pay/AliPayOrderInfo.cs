using ProtoBuf;
 

[ProtoContract]
public class AliPayOrderInfo
{
    [ProtoMember(1)]
    public string out_trade_no;

    [ProtoMember(2)]
    public string total_fee;

    [ProtoMember(3)]
    public string orderInfo;

    public AliPayOrderInfo() { }

    public  override string ToString()
    {
        return "AliPayOrderInfo [out_trade_no=" + out_trade_no + ", total_fee=" + total_fee + ", orderInfo=" + orderInfo + "]";
    }
}
