using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 领取附件
/// </summary>
[ProtoContract]
public class GetAttachResponse : Response
{
    public const int ERROR_邮件不存在 = 0;
    public const int ERROR_附件不存在 = 1;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public string attachString;
    [ProtoMember(6)]
    public int mailId;
    public GetAttachResponse()
    {
        msgType = MAIL_GETATTACH;
    }
}