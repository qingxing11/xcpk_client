using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class Push_killRoomBankerCoins : Response
{
	[ProtoMember(5)]
	public int userId;

	[ProtoMember(6)]
	public long coins;

	
	public Push_killRoomBankerCoins()
	{
		this.msgType = MsgType.KillRoom_同步庄家金币;
	}
	
	 

 
	public override string ToString()
	{
		return "Push_killRoomBigWin [coins=" + coins + ", msgType=" + msgType;
	}
}
