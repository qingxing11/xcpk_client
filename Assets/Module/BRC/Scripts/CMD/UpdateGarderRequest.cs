using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class UpdateGarderRequest : Request
{
    [ProtoMember(3)]
    public int gender;
    public UpdateGarderRequest()
    {
        msgType = UPDATEGENDER;
    }
}