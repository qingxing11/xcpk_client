using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SafeBoxTransferSureRequest:Request
{
    [ProtoMember(3)]
    public int otherId;


    public SafeBoxTransferSureRequest()
    {
        this.msgType = MsgType.SafeBox_游戏币转账确认;
    }

    public SafeBoxTransferSureRequest(int otherId)
    {
        this.msgType = MsgType.SafeBox_游戏币转账确认;
        this.otherId = otherId;
    }


    
    public override  string ToString()
    {
        return "SafeBoxTransferSureRequest [otherId=" + otherId + ", msgType=" + msgType + ", callBackId="+ callBackId + "]";
    }

}
