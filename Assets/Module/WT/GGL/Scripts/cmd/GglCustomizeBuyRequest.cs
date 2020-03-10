using ProtoBuf;

[ProtoContract]
public class GglCustomizeBuyRequest  : Request
{
    [ProtoMember(3)]
    public int level;

    [ProtoMember(4)]
    public int num;
	public GglCustomizeBuyRequest()
	{
        msgType = MsgType.GGL_自定义购买;
	}
 
	public override string ToString()
	{
		return "GglCustomizeBuyRequest [level=" + level + ", num=" + num + ", msgType=" + msgType + "]";
	}
}