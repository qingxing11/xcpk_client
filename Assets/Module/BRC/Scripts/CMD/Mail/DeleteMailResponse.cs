using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 删除邮件
/// </summary>
[ProtoContract]
public class DeleteMailResponse : Response
{
    public const int ERROR_邮件不存在 = 0;
    public const int ERROR_附件未领取 = 1;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int mailId;
    public DeleteMailResponse()
    {
        msgType = MAIL_DELETE;
    }
}