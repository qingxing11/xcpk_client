using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class ChouJiangRequest : Request
{
    [ProtoMember(3)]
    public int isFreeChouJiang; // 1  免费抽奖  2  付费抽奖
    public ChouJiangRequest()
    {
        this.msgType = MsgType.ChouJiangResult;
    }
    public ChouJiangRequest(int isFreeChouJiang)
    {
        this.msgType = MsgType.ChouJiangResult;
        this.isFreeChouJiang = isFreeChouJiang;
    }
    public override string ToString()
    {
        return "ChouJiangRequest [isFreeChouJiang=" + isFreeChouJiang + ", msgType=" + msgType + "]";
    }
}