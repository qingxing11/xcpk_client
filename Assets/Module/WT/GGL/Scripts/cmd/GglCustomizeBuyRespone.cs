
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class GglCustomizeBuyRespone : Response
{
	public const int ERROR_金币不足 = 0;
	public const int ERROR_购买场次错误 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<int> list_money;

    [ProtoMember(6)]
    public int costMoney;
	public GglCustomizeBuyRespone() {
        msgType = MsgType.GGL_自定义购买;
	}

 
	public override string ToString()
	{
		return "GglCustomizeBuyRespone [list_money=" + list_money + ", msgType=" + msgType + ", code=" + code + "]";
	}
}
