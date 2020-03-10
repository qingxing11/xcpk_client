using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ProtoContract]
public class ChargesEmojiResponse : Response
{
    public const int ERROR_不在游戏中 = 0;
    public const int ERROR_金币不足 = 1;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int emojiId;
    [ProtoMember(6)]
    public int toUserId;
    [ProtoMember(7)]
    public int roomId;
    public ChargesEmojiResponse()
    {
        msgType = CHAT_收费表情;
    }
}
