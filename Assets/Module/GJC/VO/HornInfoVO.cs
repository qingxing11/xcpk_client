using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class HornInfoVO
{
    [ProtoMember(1)]
    public int userId;

    [ProtoMember(2)]
    public string nikeName;

    [ProtoMember(3)]
    public int vipLv;

    [ProtoMember(4)]
    public string info;

    [ProtoMember(5)]
    public int role;

    public HornInfoVO()
    {

    }
    public HornInfoVO(int userId, string nikeName, int vipLv, string info,int role)
    {
        this.userId = userId;
        this.nikeName = nikeName;
        this.vipLv = vipLv;
        this.info = info;
        this.role = role;
    }

    public override string ToString()
    {
        return "HornInfoVO [userId=" + userId + ", nikeName=" + nikeName + ", vipLv=" + vipLv + ", info=" + info
            + ", role=" + role + "]";
    }
}
