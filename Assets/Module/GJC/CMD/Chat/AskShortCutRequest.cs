using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskShortCutRequest:Request
{
    [ProtoMember(3)]
    public int infoIndex;
    public AskShortCutRequest()
    {
        this.msgType = MsgType.Chat_快捷回复;
    }
    public AskShortCutRequest(int infoIndex)
    {
        this.msgType = MsgType.Chat_快捷回复;
        this.infoIndex = infoIndex;
    }

   
    public override string ToString()
    {
        return "AskShortCutRequest  快捷回复[消息来源 "  + ",infoIndex" + infoIndex + "]";
    }

}
