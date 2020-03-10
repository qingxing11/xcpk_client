using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
  public   class ManyPepolFollowBetResponse:Response
    {
    public const int ERROR_金币不足 = 0;
    public const int ERROR_不在比赛中 = 1;
    public const int ERROR_没轮到行动 = 2;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int betNum;
    public ManyPepolFollowBetResponse()
    {
        msgType = MsgType.manypepol_玩家跟注;
    }

    public override string ToString()
    {
        return "FollowBetResponse [betNum=" + betNum + ", msgType=" + msgType + ", code=" + code + "]";
    }
}