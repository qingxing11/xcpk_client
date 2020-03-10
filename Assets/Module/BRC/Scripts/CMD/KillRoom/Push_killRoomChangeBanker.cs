using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
public class Push_killRoomChangeBanker : Response
{
    [ProtoMember(5)]
    public PlayerSimpleData banker;
    public Push_killRoomChangeBanker()
    {
        msgType = KillRoom_更换庄家;
    }
}