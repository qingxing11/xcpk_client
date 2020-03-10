using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
   public  class PushTodayIsFreeChouJiangResponse:Response
    {

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public int freeChouJiang;/// 1 为今天未免费抽奖 2 为今天已经免费抽过奖

    public PushTodayIsFreeChouJiangResponse()
    {
        this.msgType = MsgType.Push_FreeChouJiang;
    }


    public override string ToString()
    {
        return "PushTodayIsFreeChouJiangResponse [freeChouJiang=" + freeChouJiang + ", msgType=" + msgType + ", code="
                + code + "]";
    }
    }
