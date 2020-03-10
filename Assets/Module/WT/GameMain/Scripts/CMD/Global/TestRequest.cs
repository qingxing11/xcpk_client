
using ProtoBuf;

[ProtoContract]
public class TestRequest : Request
{
    [ProtoMember(3)]
    public string testText;
	public TestRequest()
	{
		this.msgType = TEST;
	}
}
