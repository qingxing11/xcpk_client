using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class UpdateSignResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public string sign;
    public UpdateSignResponse()
    {
        msgType = UPDATESIGN;
    }
}
