using ProtoBuf;
using System.Collections.Generic;

/// <summary>
/// 宝箱
/// </summary>
[ProtoContract]
public class LuckyBoxResponse : Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;

    [ProtoMember(6)]
    public List<Attach> attachs;
    public LuckyBoxResponse()
    {
        msgType = LUCKY_BOX;
    }

    public override string ToString()
    {
        return "LuckyBoxResponse [userId=" + userId + ", attachs=" + attachs.GetString() + ", msgType=" + msgType + ", code=" + code + "]";
    }
}
