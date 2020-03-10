
using ProtoBuf;

[ProtoContract]
public class ClassicGamePush_bigWin : Response
{
    [ProtoMember(5)]
    public KillRoomNoticVO killRoomNoticVO;
	
	public ClassicGamePush_bigWin() {
		msgType = MsgType.classic_大赢家;
	}

 
	public override string ToString()
	{
		return "ClassicGamePush_bigWin [killRoomNoticVO=" + killRoomNoticVO + ", msgType=" + msgType + "]";
	}
}
