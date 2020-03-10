using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskFenestraeChatResponse : Response
{
    public const int Error_暂无聊天功能 = 0;
    public const int Error_频繁发送 = 1;
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;//消息来源Id

    [ProtoMember(6)]
    public string nikeName;

    [ProtoMember(7)]
    public int vipLv;

    [ProtoMember(8)]
    public string info;

    [ProtoMember(9)]
    public string headIconUrl;

    [ProtoMember(10)]
    public int lv;

    [ProtoMember(11)]
    public int headId;

    [ProtoMember(12)]
    public int roelId;

    [ProtoMember(13)]
    public bool enjoy;

    [ProtoMember(14)]
    public bool shutCut;

    [ProtoMember(15)]
    public int shutCutIndex;

    [ProtoMember(16)]
    public int curRoom;

    [ProtoMember(17)]
    public int roomType;
    public AskFenestraeChatResponse()
    {
        msgType = Chat_小窗聊天;
    }

    public override string ToString()
    {
        return "AskFenestraeChatResponse [userId=" + userId + ", nikeName=" + nikeName + ", vipLv=" + vipLv + ", info="
                 + info + ", lv=" + lv + ", headId=" + headId + ", roelId=" + roelId + ", enjoy="
                 + enjoy + ", shutCut=" + shutCut + ", shutCutIndex=" + shutCutIndex + ", curRoom=" + curRoom
                 + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code="
                 + code + "]";
    }
}
