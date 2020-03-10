using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class KillRoomNoticVO
{
    [ProtoMember(1)]
    public int userId;

    [ProtoMember(2)]
    public string nickName;

    [ProtoMember(3)]
    public long score;
	
	public KillRoomNoticVO()
	{
	}
	 
 
	public override string ToString()
	{
		return "KillRoomNoticVO [userId=" + userId + ", nickName=" + nickName + ", score=" + score + "]";
	}
}
