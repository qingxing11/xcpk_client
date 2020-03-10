using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class ReadMailRequest : Request
{
    [ProtoMember(3)]
    public int mailId;
    public ReadMailRequest()
    {
        msgType = MAIL_READ;
    }
}
