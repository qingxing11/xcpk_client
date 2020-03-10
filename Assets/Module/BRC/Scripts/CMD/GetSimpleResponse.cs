using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class GetSimpleResponse : Response
{
    public const int ERROR_玩家为空 = 0;
    public const int ERROR_数据为空 = 1;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public PlayerSimpleData simpleData;
    public GetSimpleResponse()
    {
        msgType = GET_SIMPLEDATA;
    }
}