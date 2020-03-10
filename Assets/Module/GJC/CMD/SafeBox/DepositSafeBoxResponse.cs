using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class DepositSafeBoxResponse:Response
{
    public const int Error_暂无银行功能 = 0;
    public const int Error_存入超过上线 = 1;

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public long money;

    public DepositSafeBoxResponse()
    {
      
    }

    public override string ToString()
    {
        return "DepositSafeBoxResponse [money=" + money + ", msgType=" + msgType  + ", callBackId=" + callBackId + ", code=" + code + "]";
    }

}
