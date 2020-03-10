

using ProtoBuf;
/**
* 进入经典场：
* 房间当前状态
* 当前座位上玩家
* 当前庄家
**/
[ProtoContract]
public class FollowBetResponse : Response
{

    public const int ERROR_金币不足 = 0;
    public const int ERROR_不在比赛中 = 1;
    public const int ERROR_没轮到行动 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int betNum;
    public FollowBetResponse()
    {
        msgType = classic_玩家跟注;
    }
}
