using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SafeBoxTransferResponse:Response
{
    public const int Error_暂无转账功能 = 0;
    public const int Error_转给自己 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public string otherNike;

    [ProtoMember(6)]
    public int otherId;

    [ProtoMember(7)]
    public long transferCoins;

    public SafeBoxTransferResponse()
    {
       
    }

    public override  string ToString()
    {
        return "SafeBoxTransferResponse [otherNike=" + otherNike + ", otherId=" + otherId+ ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
