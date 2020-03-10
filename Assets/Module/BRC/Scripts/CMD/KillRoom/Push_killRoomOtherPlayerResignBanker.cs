using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class Push_killRoomOtherPlayerResignBanker : Response
{
    [ProtoMember(5)]
    public int userId;
    public Push_killRoomOtherPlayerResignBanker()
    {
        msgType = KillRoom_其他玩家下庄;
    }
}