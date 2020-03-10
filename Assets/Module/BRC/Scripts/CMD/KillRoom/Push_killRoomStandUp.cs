using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]

public class Push_killRoomStandUp : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;

    public Push_killRoomStandUp()
    {
        this.msgType =KillRoom_其他玩家站起;
    }
}
