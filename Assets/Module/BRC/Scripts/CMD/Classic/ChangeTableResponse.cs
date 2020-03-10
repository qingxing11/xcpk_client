using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 经典场换桌
/// </summary>
[ProtoContract]
public class ChangeTableResponse : Response
{

    public const int ERROR_不在比赛中 = 0;
    public const int ERROR_换桌错误 = 1;

    [ProtoMember(4)]
    public int code;
    public ChangeTableResponse()
    {
        msgType = classic_换桌;
    }
}