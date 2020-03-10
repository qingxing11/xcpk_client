using ProtoBuf;

[ProtoContract]
public class Push_otherDeviceLogin : Response
{
	 
	public Push_otherDeviceLogin()
	{
		msgType = MsgType.PUSHUSER_另一个设备登录;
	}
	 

 
	public override string ToString()
	{
		return "Push_otherDeviceLogin [msgType=" + msgType + "]";
	}
}
