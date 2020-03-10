using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通杀场奖池
/// </summary>
[ProtoContract]
public class GetJackpotRequest : Request
{
    public GetJackpotRequest()
    {
        msgType = KillRoom_获取奖池;
    }
}