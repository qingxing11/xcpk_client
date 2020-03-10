using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class Push_killRoomBigWin : Response
{
    [ProtoMember(5)]
    public  List<KillRoomNoticVO> list_noticWin;
	public Push_killRoomBigWin()
	{
        this.msgType = MsgType.KillRoom_大赢家;
	}
	 
	public override string ToString()
	{
		return "Push_killRoomBigWin [list_noticWin=" + list_noticWin + ", msgType=" + msgType + "]";
	}
}
