using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class KillRoomSitDownRequest : Request
{
    [ProtoMember(3)]
    public int pos;
    public KillRoomSitDownRequest()
    {
        msgType = KillRoom_选座坐下;
    }
}
