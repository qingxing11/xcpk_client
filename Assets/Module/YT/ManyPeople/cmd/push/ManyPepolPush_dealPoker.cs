using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;


[ProtoContract]
public class ManyPepolPush_dealPoker : Response
{
    [ProtoMember(4)]
    public int code;
    /**
   * 庄家位置
   */
    [ProtoMember(5)]
    public int bankerPos;

    /**
	 * 扣底注数
	 */
    [ProtoMember(6)]
    public int betNum;

    [ProtoMember(7)]
    public int playPos;
    public ManyPepolPush_dealPoker()
    {
        msgType = MsgType.manypepol_发牌;
    }


    public override string ToString()
    {
        return "ManyPepolPush_dealPoker [bankerPos=" + bankerPos + ", betNum=" + betNum + ", msgType=" + msgType +  "]";
    }


}