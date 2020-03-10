using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class LowRequest : Request
{
    public LowRequest()
    {
        msgType = LOW;
    }
}