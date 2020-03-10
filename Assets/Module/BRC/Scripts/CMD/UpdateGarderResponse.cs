using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class UpdateGarderResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int garder;
    public UpdateGarderResponse()
    {
        msgType = UPDATEGENDER;
    }
}