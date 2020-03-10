using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class KillRoomBigWinVO
{
    [ProtoMember(1)]
    public int userId;
    [ProtoMember(2)]
    public string nickName;
    [ProtoMember(3)]
    public int roleId;
    [ProtoMember(4)]
    public string headIconUrl;
    [ProtoMember(5)]
    private long score;

    public override string ToString()
    {
        return "KillRoomBigWinVO [userId=" + userId + ", nickName=" + nickName + ", roleId=" + roleId + ", score=" + score + "]";
    }
}