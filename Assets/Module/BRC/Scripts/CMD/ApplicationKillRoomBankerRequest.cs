using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;


[ProtoContract]
public class ApplicationKillRoomBankerRequest : Request
{
    public ApplicationKillRoomBankerRequest()
    {
        msgType = KillRoom_通杀场上庄;
    }
}