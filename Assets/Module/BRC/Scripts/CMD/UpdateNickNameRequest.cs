using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class UpdateNickNameRequest : Request
{
    [ProtoMember(3)]
    public string nickName;
    public UpdateNickNameRequest()
    {
        msgType = UPDATENICKNAME;
    }
}