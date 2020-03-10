using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class FriendChatVO
{
    [ProtoMember(1)]
    public int userId;//发送方

    [ProtoMember(2)]
    public string info;//消息

    [ProtoMember(3)]
    public int receiveUserId;//接收方

    [ProtoMember(4)]
    public bool read;//已读未读


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
    public int ReceiveUserId
    {
        get
        {
            return receiveUserId;
        }

        set
        {
            receiveUserId = value;
        }
    }

    public bool Read
    {
        get
        {
            return read;
        }

        set
        {
            read = value;
        }
    }

    public FriendChatVO()
    {

    }

    public FriendChatVO(int userId, string info, int receiveUserId,bool read)
    {
        this.userId = userId;
        this.info = info;
        this.ReceiveUserId = receiveUserId;
        this.read = read;
    }
}

