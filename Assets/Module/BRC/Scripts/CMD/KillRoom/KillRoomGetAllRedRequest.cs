using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class KillRoomGetAllRedRequest : Request
{
    public KillRoomGetAllRedRequest()
    {
        msgType = KillRoom_获取所有红包;
    }
}