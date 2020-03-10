
using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class SendMsg_ChargesEmoji : Response
{
    /**发送方id*/
    [ProtoMember(5)]   
    public int userId;
    
    /**表情id*/
    [ProtoMember(6)]
    public int emojiId;

    /**目标玩家id,目标玩家应添加相应金币*/
    [ProtoMember(7)]
    public int toUserId;

    [ProtoMember(8)]
    public int roomId;
    public SendMsg_ChargesEmoji()
    {
        msgType = PUSH_收费表情;
    }
}
