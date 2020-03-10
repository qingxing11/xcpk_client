using ProtoBuf;

[ProtoContract]
public class SupplementaryAccountRequest : Request
{
    [ProtoMember(3)]
    public string account;

    [ProtoMember(4)]
    public string nickName;

    [ProtoMember(5)]
    public string password;

    [ProtoMember(6)]
    public int userId;
	public SupplementaryAccountRequest()
	{
        msgType = MsgType.SET_完善账号;
	}
 
	public override string ToString()
	{
		return "SupplementaryAccountRequest [account=" + account + ", nickName=" + nickName + ", password=" + password + ", userId=" + userId + ", msgType=" + msgType + "]";
	}
}
