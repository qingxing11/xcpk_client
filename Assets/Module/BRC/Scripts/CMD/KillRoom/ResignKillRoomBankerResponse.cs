using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通杀场申请下庄
/// </summary>
[ProtoContract]
public class ResignKillRoomBankerResponse : Response
{
    public const int ERROR_不是庄家 = 0;
    [ProtoMember(4)]
    public int code;
    public ResignKillRoomBankerResponse()
    {
        msgType = KillRoom_通杀场下庄;
    }
}
