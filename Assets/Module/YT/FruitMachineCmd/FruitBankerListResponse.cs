using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FruitBankerListResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PlayerSimpleData> list_bankerPlayers;
    public FruitBankerListResponse()
    {
        this.msgType = MsgType.Fruit_requestBankerList;
    }

    public override string ToString()
    {
        return "FruitBankerListResponse =list_bankerPlayers :" + list_bankerPlayers + ",code:" + code;
    }
}