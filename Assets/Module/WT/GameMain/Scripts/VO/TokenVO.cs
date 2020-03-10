using ProtoBuf;

[ProtoContract]
public class TokenVO
{
    /**该token的使用者id*/
    [ProtoMember(1)]
    public int uid;

    [ProtoMember(2)]
    public string pwd;
	
	public TokenVO(int uid, string pwd)
	{
		this.uid = uid;
		this.pwd = pwd;
	}
	
	public TokenVO()
	{}
 
	public override string ToString()
	{
		return "TokenVO [uid=" + uid + ", pwd=" + pwd + "]";
	}
}
