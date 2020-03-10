using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class UpdateSignRequest : Request
{
    [ProtoMember(3)]
    public string sign;
    public UpdateSignRequest()
    {
        msgType = UPDATESIGN;
    }
}
