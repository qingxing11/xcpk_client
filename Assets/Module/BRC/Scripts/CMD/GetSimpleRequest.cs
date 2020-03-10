using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class GetSimpleRequest : Request
{
    [ProtoMember(3)]
    public int userId;
    public GetSimpleRequest()
    {
        msgType = GET_SIMPLEDATA;
    }
}