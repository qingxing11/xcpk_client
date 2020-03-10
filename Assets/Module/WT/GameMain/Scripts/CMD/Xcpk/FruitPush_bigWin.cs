using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class FruitPush_bigWin : Response
{
    [ProtoMember(5)]
    public List<KillRoomNoticVO> list_KillRoomNoticVO;
	
	public FruitPush_bigWin() {
		msgType = MsgType.Fruit_大赢家;
	}

 
	public override string ToString()
	{
		return "FruitPush_bigWin [list_KillRoomNoticVO=" + list_KillRoomNoticVO + ", msgType=" + msgType + "]";
	}
}