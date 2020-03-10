using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 修改密码
/// </summary>
[ProtoContract]
public class ModifyPwdResponse : Response
{
    public const int ERROR_原始密码错误 = 0;
    public const int ERROR_账号不存在 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

    [ProtoMember(6)]
    public string password;
    public ModifyPwdResponse()
    {
        msgType = MODIFYPWD;
    }
}
