using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
public class Push_FruitSettlementRewardResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int fruitType; // 当中奖类型不是单点和开火车时  与 fruitNoramlOrSpecialType 相同
    [ProtoMember(6)]
    public int fruitRewardType;// 水果中奖类型  包含普通类型和特殊类型
    [ProtoMember(7)]
    public int isSpecialRewardType;//1  特殊奖励  0 普通奖励
    [ProtoMember(8)]
    public int fruitNum;//用于开火车 爆出个数
    [ProtoMember(9)]
    public int playerwining;
    [ProtoMember(10)]
    public int zhuangJiaWinging;
    [ProtoMember(11)]
    public int roundIndex;
    public Push_FruitSettlementRewardResponse()
    {
        this.msgType = MsgType.Push_FruitMechine_结算;
    }
    public override string ToString()
    {
        return "Push_FruitSettlementRewardResponse [fruitType=" + fruitType + ", fruitRewardType=" + fruitRewardType + ", isSpecialRewardType=" + isSpecialRewardType + ", fruitNum=" + fruitNum + ", playerwining=" + playerwining + ", zhuangJiaWinging=" + zhuangJiaWinging + "]";
    }
}