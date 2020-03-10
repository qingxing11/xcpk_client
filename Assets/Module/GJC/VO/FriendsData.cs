using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendsData
{
    [ProtoMember(1)]
    public int id;

    [ProtoMember(2)]
    public string nickName;

    [ProtoMember(3)]
    public string icon;

    [ProtoMember(4)]
    public int lv;

    [ProtoMember(5)]
    public int roleId;

    [ProtoMember(6)]
    public int vipLv;

    [ProtoMember(7)]
    public string headIconUrl;
    public override string ToString()
    {
        return "FriendsData [id=" + id + ", nickName=" + nickName + ", icon=" + icon + ", lv=" + lv + ", roleId="
              + roleId + ", vipLv=" + vipLv + "]";
    }
}
