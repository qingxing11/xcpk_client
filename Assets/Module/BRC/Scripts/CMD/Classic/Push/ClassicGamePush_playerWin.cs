using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class ClassicGamePush_playerWin : Response
{
    [ProtoMember(5)]
    public List<GameRoundDataVO> list_roundData;
    public ClassicGamePush_playerWin()
    {
        msgType = classic_玩家胜利;
    }

}