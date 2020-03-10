using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ManyPepolPush_otherPlayerResignBanker : Response
{
    [ProtoMember(5)]
    public int userId;
    public ManyPepolPush_otherPlayerResignBanker()
    {
        msgType =manypepol_其他玩家下庄;
    }
}