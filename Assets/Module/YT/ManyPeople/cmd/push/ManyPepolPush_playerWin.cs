using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ManyPepolPush_playerWin : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<GameRoundDataVO> list_roundData;

    [ProtoMember(6)]
    public long jackpotNum;
    public ManyPepolPush_playerWin()
    {
        msgType = MsgType.manypepol_玩家胜利;
    }

    public override string ToString()
    {
        return "ManyPepolPush_playerWin [list_roundData=" + list_roundData + ", msgType=" + msgType + ", code=" + code + "]";
    }
}