using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SmallChatVO
{
    private int userId;//消息来源Id

    private string nikeName;

    private int vipLv;

    private string info;

    public string headIconUrl;

    private int lv;

    private int headId;

    private int roelId;

    public int roomType;

    public int UserId
    {
        get
        {
            return userId;
        }

        set
        {
            userId = value;
        }
    }

    public string NikeName
    {
        get
        {
            return nikeName;
        }

        set
        {
            nikeName = value;
        }
    }

    public int VipLv
    {
        get
        {
            return vipLv;
        }

        set
        {
            vipLv = value;
        }
    }

    public string Info
    {
        get
        {
            return info;
        }

        set
        {
            info = value;
        }
    }

    public int Lv
    {
        get
        {
            return lv;
        }

        set
        {
            lv = value;
        }
    }

    public int HeadId
    {
        get
        {
            return headId;
        }

        set
        {
            headId = value;
        }
    }

    public int RoelId
    {
        get
        {
            return roelId;
        }

        set
        {
            roelId = value;
        }
    }

    public SmallChatVO()
    {

    }
    public SmallChatVO(AskFenestraeChatResponse response)
    {
        this.UserId = response.userId;
        this.NikeName = response.nikeName;
        this.VipLv = response.vipLv;
        this.Info = response.info;
        this.headIconUrl = response.headIconUrl;
        this.lv = response.lv;
        this.headId = response.headId;
        this.roelId = response.roelId;
        this.roomType = response.roomType;
    }

    public override string ToString()
    {
        return "[SmallChatVO , userId=" + userId + ",nikeName=" + nikeName + ", vipLv=" + vipLv + ",info=" + info + "]";
    }
}