using UnityEngine;
using System.Collections;

public class PlayerPauseResponse : Response
{
    public const int ERROR_玩家不在游戏中 = 0;
    public const int ERROR_证书空 = 1;
    public const int ERROR_玩家不在缓存中 = 2;
    public const int STATE_在游戏中 = 3;

    public bool isOnline;
    public UserDataPO userDataPO;
}
