using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ChouJiangResponse : Response
{
    public const int 您今天已经免费抽过奖了 = 0;
    public const int 没找到该奖项 = 1;
    public const int 您当前可以免费抽奖一次 = 2;
    public const int 您的钻石不足了 = 3;
    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int pathId;
    public ChouJiangResponse()
    {
        this.msgType = MsgType.ChouJiangResult;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}