using ProtoBuf;

[ProtoContract]
public class TestResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int num;

    [ProtoMember(6)]
    public string name;

    [ProtoMember(7)]
    public byte type;
	public TestResponse() 
	{}
	
	public TestResponse(int code,int num, string name, byte type)
	{
		this.msgType = TEST;
 		this.code = code;
		this.num = num;
		this.name = name;
		this.type = type;
	}
	
	 
	public override string ToString()
	{
		return "TestResponse [code=" + code + ", num=" + num + ", name=" + name + ", type=" + type + "]";
	}
}
