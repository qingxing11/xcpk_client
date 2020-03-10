using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class FollowBetRequest : Request
{
    public FollowBetRequest()
    {
        msgType = classic_玩家跟注;
    }
}