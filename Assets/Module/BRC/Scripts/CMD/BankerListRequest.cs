using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class BankerListRequest : Request
{
    public BankerListRequest()
    {
        msgType = KillRoom_庄家列表;
    }
}