
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class EnterFruitMachineResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public PlayerSimpleData playerBankerData;//庄家信息

    [ProtoMember(6)]
    public int roomState;

    [ProtoMember(7)]
    public long stateTime;

    [ProtoMember(8)]
    public long jiangPoolCoins;// 奖池金额
    [ProtoMember(9)]
    public List<int> list_xiaZhuKey;
    [ProtoMember(10)]
    public List<int> list_xiaZhuValue;
    [ProtoMember(11)]
    public List<string> list_history;
    [ProtoMember(12)]
    public int roundIndex;
    public EnterFruitMachineResponse()
    {
    }
    public EnterFruitMachineResponse(int code)
    {
        this.code = code;
        this.msgType = MsgType.EnterFruitMechine;
    }
}