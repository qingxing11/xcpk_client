using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ChangeTableRequest : Request
{
    public ChangeTableRequest()
    {
        msgType = classic_换桌;
    }
}