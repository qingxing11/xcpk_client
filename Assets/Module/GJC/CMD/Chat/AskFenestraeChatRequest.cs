using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskFenestraeChatRequest : Request
{
    [ProtoMember(3)]
    public string info;

    [ProtoMember(4)]
    public bool enjoy;

    [ProtoMember(5)]
    public bool shutCut;

    [ProtoMember(6)]
    public int shutCutIndex;

    [ProtoMember(7)]
    public int curRoom;

    [ProtoMember(8)]
    public int roomType;

    public AskFenestraeChatRequest(string info, bool shutCut, int shutCutIndex,int curRoom,int roomType)
    {
        this.msgType = MsgType.Chat_小窗聊天;
        this.info = info;
        this.enjoy = false;
        this.shutCut = shutCut;
        this.shutCutIndex = shutCutIndex;
        this.curRoom = curRoom;
        this.roomType = roomType;
    }

    public AskFenestraeChatRequest(string info,int curRoom)
    {
        this.msgType = MsgType.Chat_小窗聊天;
        this.info = info;
        this.enjoy = false;
        this.shutCut = false;
        this.shutCutIndex = -1;
        this.curRoom = curRoom;
        this.roomType = CacheManager.RunRoomId;
    }

    public AskFenestraeChatRequest(string info, bool enjoy, int curRoom)
    {
        this.msgType = MsgType.Chat_小窗聊天;
        this.info = info;
        this.enjoy = enjoy;
        this.shutCut = false;
        this.shutCutIndex = -1;
        this.curRoom = curRoom;
        this.roomType = CacheManager.RunRoomId;
    }

    public override string ToString()
    {
        return "AskFenestraeChatRequest [info=" + info + ", enjoy=" + enjoy + ", shutCut=" + shutCut + ", shutCutIndex="
         + shutCutIndex + ", curRoom=" + curRoom + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }

}
