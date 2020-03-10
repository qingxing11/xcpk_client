using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class AskPlayerInGameRequest:Request
{
    public AskPlayerInGameRequest()
    {
        this.msgType = MsgType.Player_进入游戏主界面;
    }

    
    public override string ToString()
    {
        return "AskPlayerInGameRequest [msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
