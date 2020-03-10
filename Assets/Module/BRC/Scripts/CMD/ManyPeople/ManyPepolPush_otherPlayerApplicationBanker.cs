using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ManyPepolPush_otherPlayerApplicationBanker : Response
{
    [ProtoMember(5)]
    public PlayerSimpleData bankerRequest;
    public ManyPepolPush_otherPlayerApplicationBanker()
    {
        msgType = manypepol_其他玩家上庄;
    }
}