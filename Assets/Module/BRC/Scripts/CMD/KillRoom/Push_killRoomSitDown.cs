using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class Push_killRoomSitDown : Response
{
    [ProtoMember(5)]
    public PlayerSimpleData player;
    public Push_killRoomSitDown()
    {
        this.msgType = KillRoom_其他玩家坐下;
    }

}
