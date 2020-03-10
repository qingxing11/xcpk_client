using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 幸运大转盘
/// </summary>
[ProtoContract]
public class LuckyResponse : Response
{

    public const int ERROR_当月已经抽取 = 0;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int luckyNum;
    public LuckyResponse()
    {
        msgType = LUCKY;
    }
}