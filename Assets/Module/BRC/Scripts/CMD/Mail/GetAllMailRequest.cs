using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class GetAllMailRequest : Request
{
    public GetAllMailRequest()
    {
        msgType = MAIL_GETALL;
    }
}