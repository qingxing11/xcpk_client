using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 修改密码
/// </summary>
[ProtoContract]
public class ModifyPwdRequest : Request
{
    [ProtoMember(3)]
    public string oldPwd;
    [ProtoMember(4)]
    public string newPwd;
    [ProtoMember(5)]
    public int userId;

    public ModifyPwdRequest()
    {
        msgType = MsgType.MODIFYPWD;
    }
}
