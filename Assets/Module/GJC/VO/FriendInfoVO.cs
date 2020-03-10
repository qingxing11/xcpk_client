using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendInfoVO
{
    [ProtoMember(1)]
    public int userId;

    [ProtoMember(2)]
    public string info;

    [ProtoMember(3)]
    public int read;//删除/已读/未读

    public int getUserId()
    {
        return userId;
    }

    public void setUserId(int userId)
    {
        this.userId = userId;
    }

    public string getInfo()
    {
        return info;
    }

    public void setInfo(string info)
    {
        this.info = info;
    }

    public int getRead()
    {
        return read;
    }

    public FriendInfoVO()
    {

    }

    public FriendInfoVO(int userId, string info, int read)
    {
        this.userId = userId;
        this.info = info;
        this.read = read;
    }
}
