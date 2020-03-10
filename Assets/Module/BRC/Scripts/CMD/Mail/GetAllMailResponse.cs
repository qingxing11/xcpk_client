using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 获取所有邮件
/// </summary>
[ProtoContract]
public class GetAllMailResponse : Response
{
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<MailDataPO> userMailDataPOS;
    public GetAllMailResponse()
    {
        msgType = MAIL_GETALL;
    }
}