using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class Push_killRoomOtherPlayerApplicationBanker : Response
{
    [ProtoMember(5)]
    public PlayerSimpleData bankerRequest;
    public Push_killRoomOtherPlayerApplicationBanker()
    {
        msgType = KillRoom_其他玩家上庄;
    }
}