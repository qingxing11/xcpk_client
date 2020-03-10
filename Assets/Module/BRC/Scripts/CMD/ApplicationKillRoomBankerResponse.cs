using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ProtoContract]
public class ApplicationKillRoomBankerResponse :Response
{
    public const int ERROR_金币不足 = 0;
    public const int ERROR_上庄人数太多 = 1;
    public const int ERROR_申请上庄时已是庄家 = 2;
    public const int ERROR_申请上庄时人数太多 = 3;
    public const int ERROR_申请上庄时已在列表 = 4;



    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public List<PlayerSimpleData> list_bankerList;
    public ApplicationKillRoomBankerResponse()
    {

        msgType = KillRoom_通杀场上庄;
    }
}