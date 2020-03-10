using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SafeBoxTransferSureResponse:Response
{
    public const int Error_金额不足 = 0;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long money;

    [ProtoMember(6)]
    public int otherId;

    [ProtoMember(7)]
    public int type;

    [ProtoMember(8)]
    public long time;


    [ProtoMember(9)]
    public float pre;

    public SafeBoxTransferSureResponse()
    {
       
    }
    public override string ToString()
    {
        return "SafeBoxTransferSureResponse [money=" + money + ", otherId=" + otherId + ", type=" + type + ", time="
                     + time + ", pre=" + pre + ", msgType=" + msgType 
                     + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
