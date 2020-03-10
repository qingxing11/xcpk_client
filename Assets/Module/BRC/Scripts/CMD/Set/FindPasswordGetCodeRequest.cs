using ProtoBuf;
 
[ProtoContract]
public class FindPasswordGetCodeRequest : Request
{
   

	public FindPasswordGetCodeRequest()
	{
        msgType = MsgType.SET_找回密码获取验证码;
	}

 
	public override string ToString()
	{
		return "FindPasswordGetCodeRequest [msgType=" + msgType + "]";
	}
}
