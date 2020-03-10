using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class UpdateNickNameResponse : Response
{
    public const int ERROR_昵称重复 = 0;
    public const int ERROR_改名卡不足 = 1;


    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public string nickName;
    public UpdateNickNameResponse()
    {
        msgType = UPDATENICKNAME;
    }
}
