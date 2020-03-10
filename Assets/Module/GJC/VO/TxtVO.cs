using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class TxtVO 
{
    [ProtoMember(1)]
    public int userId;

    [ProtoMember(2)]
    public string nikeName;

    [ProtoMember(3)]
    public long money;

    [ProtoMember(4)]
    public int type;//场次：彩票场0

    public TxtVO()
    {
            
    }

    public override string ToString()
    {
        return "TxtVO [userId=" + userId + ", nikeName=" + nikeName + ", money=" + money + ", type=" + type + "]";
    }
}
