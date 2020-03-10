using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class LowResponse : Response
{
    public const int ERROR_金币较多 = 0;
    public const int ERROR_次数不足 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int number;

    public LowResponse()
    {
        msgType = LOW;
    }
}