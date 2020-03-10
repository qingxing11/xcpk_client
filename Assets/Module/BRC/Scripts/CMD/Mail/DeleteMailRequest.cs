using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 删除邮件
/// </summary>
[ProtoContract]
public class DeleteMailRequest : Request
{
    [ProtoMember(3)]
    public int mailId;
    public DeleteMailRequest()
    {
        msgType = MAIL_DELETE;
    }
}
