using ProtoBuf;
using System.Collections.Generic;
/**
* 进入经典场：
* 房间当前状态
* 当前座位上玩家
* 当前庄家
*/
[ProtoContract]
public class EnterBeginnerResponse : Response
{
    public const int ERROR_金币不足 = 0;
    public const int ERROR_金币过多 = 1;
    public const int ERROR_进入房间错误 = 2;


    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int state;
    [ProtoMember(6)]
    public List<PlayerSimpleData> list_tablePlayer;
    [ProtoMember(7)]
    public int bankerPos;
    [ProtoMember(8)]
    public int pos;
    [ProtoMember(9)]
    public int roundNum;
    [ProtoMember(10)]
    public List<int> list_allBet;
   

    /// <summary>
    /// 当前行动玩家
    /// </summary>
    [ProtoMember(11)]
    public int actionPos;

    /// <summary>
    /// 当前状态剩余时间
    /// </summary>
    [ProtoMember(12)]
    public int actionTime;
    [ProtoMember(13)]
    public int type;
    public EnterBeginnerResponse()
    {
        msgType = classic_进入新手场;
    }
}