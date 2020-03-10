using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ChargesEmojiRequest : Request
{
    [ProtoMember(3)]
    public int emojiId;
    [ProtoMember(4)]
    public int toUserId;
    [ProtoMember(5)]
    public int roomId;
    public ChargesEmojiRequest()
    {
        msgType = CHAT_收费表情;
    }
}