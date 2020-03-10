using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ClassicGamePush_waiStart : Response
{
    [ProtoMember(5)]
    public int waitPlayerTime;

    public ClassicGamePush_waiStart()
    {
        msgType = classic_等待比赛开始;
    }
}