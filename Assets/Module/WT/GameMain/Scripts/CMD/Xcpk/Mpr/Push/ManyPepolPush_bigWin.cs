using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class ManyPepolPush_bigWin : Response
{
    [ProtoMember(5)]
    public KillRoomNoticVO killRoomNoticVO;

    public ManyPepolPush_bigWin()
    {
        msgType = manypepol_大赢家;
    }
     
    public override string ToString()
    {
        return "ManyPepolPush_bigWin [killRoomNoticVO=" + killRoomNoticVO + ", msgType=" + msgType + "]";
    }
}