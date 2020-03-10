using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[ProtoContract]
public class ResignKillRoomBankerRequest : Request
{
    public ResignKillRoomBankerRequest()
    {
        msgType= KillRoom_通杀场下庄;
    }
}