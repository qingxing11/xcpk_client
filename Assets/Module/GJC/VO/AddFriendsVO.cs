using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AddFriendsVO
{
    [ProtoMember(1)]
    public int id;//玩家id
    [ProtoMember(2)]
    public string nickName;//玩家昵称
    [ProtoMember(3)]
    public string icon;//玩家头像
    [ProtoMember(4)]
    public int lv;//玩家等级
    [ProtoMember(5)]
    public int state;//请求状态
    [ProtoMember(6)]
    public bool readState;//请求添加消息状态

    [ProtoMember(7)]
    public int roleId;

    [ProtoMember(8)]
    public int vipLv;


    public override string ToString()
    {
        return "AddFriendsVO [id=" + id + ", nickName=" + nickName + ", icon=" + icon + ", lv=" + lv + ", state="
                 + state + ", readState=" + readState + ", roleId=" + roleId + ", vipLv=" + vipLv + "]";
    }
}
