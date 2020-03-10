using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushSafeBoxToOtherResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<SafeBoxRecordVO> po;

    [ProtoMember(6)]
    public bool show;//仅显示

    [ProtoMember(7)]
    public float transferAccountsPer;//转账手续费
    public PushSafeBoxToOtherResponse()
    {
        msgType = MsgType.SafeBox_某人转账给玩家;
    }

    public override string ToString()
    {
        return "PushSafeBoxToOtherResponse [po=" + po + ".show="+ show + ", transferAccountsPer="+ transferAccountsPer + ", msgType=" + msgType + ", callBackId=" + callBackId + ", code=" + code + "]";
    }
}
