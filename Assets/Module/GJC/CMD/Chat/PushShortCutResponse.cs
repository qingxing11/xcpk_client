using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class PushShortCutResponse:Response
{
    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public int userId;//消息来源Id

    [ProtoMember(6)]
    public string nikeName;

    [ProtoMember(7)]
    public int vipLv;

    [ProtoMember(8)]
    public string info;

    public PushShortCutResponse()
    {
    }

    public override  string ToString()
    {
        return "PushShortCutResponse  快捷回复[消息来源 id=" + userId + ",info=" + info + ", nikeName=" + nikeName + ",vipLv=" + vipLv + "]";
    }
}
