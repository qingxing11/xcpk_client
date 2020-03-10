using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 幸运大转盘
/// </summary>
[ProtoContract]
public class LuckyRequest : Request
{
    public LuckyRequest()
    {
        msgType = LUCKY;
    }
}
