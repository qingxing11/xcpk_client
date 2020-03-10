using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

[ProtoContract]
public class KillRoomSitDownResponse : Response
{
    public const int ERROR_桌子有人 = 0;
    public const int ERROR_桌子号错误 = 1;
    public const int ERROR_已经坐下 = 2;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pos;
    public KillRoomSitDownResponse()
    {
        msgType = KillRoom_选座坐下;
    }
}
