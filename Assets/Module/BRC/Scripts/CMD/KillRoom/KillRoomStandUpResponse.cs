using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ProtoContract]
public class KillRoomStandUpResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;
    public KillRoomStandUpResponse()
    {
        msgType = KillRoom_从座位站起;
    }
}