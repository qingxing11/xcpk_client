
//休息 下注 开奖
using System.Collections.Generic;
using UnityEngine;

public class KillRoom
{
    /**下注时间*/
    public const float BET_TIME = 18f;

    public const float LOTTERY_TIME = 15f;

    /**单玩家最大下注*/
    public const int BET_MAX = 2000000;

    /**休息时间*/
    public const int IDLE_TIME = 5;



    /**下注状态*/
    public const int STATE_BET_TIME = 0;
    /**开奖*/
    public const int STATE_LOTTERY_TIME = 1;
    /**休息状态*/
    public const int STATE_IDLE = 2;

    public int state;
    public long stateTime;

    public int[] killRoomPayBet = new int[4];
    public void ClearPayBet()
    {
        //Debug.Log("清理通杀下注.....");
        for (int i = 0; i < 4; i++)
        {
            CacheManager.killRoom.killRoomPayBet[i] = 0;
        }


    }
}