using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class KillRoomGetAllRedResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<RedEnvelopeInfo> redEnvelopeInfo;// 返回具体红包信息
    [ProtoMember(6)]
    public int redEnvelopeState;
    [ProtoMember(7)]
    public int userId;
    public KillRoomGetAllRedResponse()
    {
        msgType = KillRoom_获取所有红包;
    }
}