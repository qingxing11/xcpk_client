using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class SafeBoxRecordVO
{
    [ProtoMember(1)]
    public int userId;//交易方

    [ProtoMember(2)]
    public int otherId;//接受方

    [ProtoMember(3)]
    public long money;

    [ProtoMember(4)]
    public long time;

    [ProtoMember(5)]
    public int type;

    [ProtoMember(6)]
    public float pre;//手续费率

    public SafeBoxRecordVO()
    {

    }
    public SafeBoxRecordVO(int userId, int otherId, long money, long time, int type, float pre)
    {
        this.userId = userId;
        this.otherId = otherId;
        this.money = money;
        this.time = time;
        this.type = type;
        this.pre = pre;
    }

    public override string ToString()
    {
        return "SafeBoxRecordVO [userId=" + userId + ", otherId=" + otherId + ", money=" + money + ", time=" + time
                + ", type=" + type + ", pre=" + pre + "]";
    }
}
