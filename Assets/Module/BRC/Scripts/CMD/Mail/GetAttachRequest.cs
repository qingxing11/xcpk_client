using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 领取附件
/// </summary>
[ProtoContract]
public class GetAttachRequest : Request
{
    
    [ProtoMember(3)]
    public int mailId;
    public GetAttachRequest()
    {
        msgType = MAIL_GETATTACH;
    } 
}