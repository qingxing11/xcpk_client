using UnityEngine;
using System.Collections;

public class PlayerPauseRequest : Request
{
    public bool isOnline;

    public TokenVO tokenVO;

    public PlayerPauseRequest()
    {
        //msgType = MsgType.GAME_玩家外部事件;
    }
}
