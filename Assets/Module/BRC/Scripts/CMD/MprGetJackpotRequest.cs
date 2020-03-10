using ProtoBuf;

[ProtoContract]
public class MprGetJackpotRequest : Request
{
	public MprGetJackpotRequest()
	{
		msgType =manypepol_获取奖池;
	}
}
