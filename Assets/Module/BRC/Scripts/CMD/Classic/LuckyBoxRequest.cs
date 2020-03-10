using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 宝箱
/// </summary>
[ProtoContract]
public class LuckyBoxRequest : Request
{
    [ProtoMember(3)]
    public int index;
    public LuckyBoxRequest()
    {
        msgType = LUCKY_BOX;
    }
}