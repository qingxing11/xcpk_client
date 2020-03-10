using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SafeBoxTransferRequest:Request
{
    [ProtoMember(3)]
    public int otherId;

    [ProtoMember(4)]
    public int userId;

    [ProtoMember(5)]
    public long money;

    public SafeBoxTransferRequest()
    {
        this.msgType = MsgType.SafeBox_游戏币转账;
    }
    public SafeBoxTransferRequest(int otherId, int userId, long money)
    {
        this.msgType = MsgType.SafeBox_游戏币转账;
        this.otherId = otherId;
        this.userId = userId;
        this.money = money;
    }

    public override string ToString()
    {
        return "SafeBoxTransferRequest [otherId=" + otherId + ", userId=" + userId + ", money=" + money + ", msgType=" + msgType + ", callBackId=" + callBackId + "]";
    }
}
