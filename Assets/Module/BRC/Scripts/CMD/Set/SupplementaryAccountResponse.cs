

using ProtoBuf;

[ProtoContract]
public class SupplementaryAccountResponse : Response 
{
	public const int ERROR_已经是完善账号 = 0;
	public const int ERROR_账号重复 = 1;
	public const int ERROR_昵称重复 = 2;
	public const int ERROR_数据插入失败 = 3;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public string account;
    [ProtoMember(6)]
    public string nickName;
    [ProtoMember(7)]
    public string password;
    [ProtoMember(8)]
    public int userId;
	 public  SupplementaryAccountResponse()
	 {
		 
         msgType = MsgType.SET_完善账号;
	}
	 
	 
	public override string ToString()
	{
		return "SupplementaryAccountResponse [account=" + account + ", nickName=" + nickName + ", password=" + password + ", userId=" + userId + ", msgType=" + msgType + ", code=" + code + "]";
	}
}
