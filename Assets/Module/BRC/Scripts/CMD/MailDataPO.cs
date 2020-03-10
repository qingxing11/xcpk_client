using ProtoBuf;


[ProtoContract]
public class MailDataPO
{
    public const int STATE_未读 = 0;
    public const int STATE_已读 = 1;

    public const int ATTACHSTATE_无附件 = 0;
    public const int ATTACHSTATE_未领取 = 1;
    public const int ATTACHSTATE_已领取 = 2;

    /**
	 * 邮件id
	 */
    [ProtoMember(1)]
    public int mailID;

    [ProtoMember(2)]
    public int userId;

    /**
	 * 发件时间
	 */
    [ProtoMember(3)]
    public string sendtime;

    /**
	 * 标题
	 */
    [ProtoMember(4)]
    public string title = "";

    /**
	 * 内容
	 */
    [ProtoMember(5)]
    public string content = "";

    /**
	 * 附件内容
	 * */
    [ProtoMember(6)]
    public string attachContent = "";

    /**
	 * 邮件状态
	 */
    [ProtoMember(7)]
    public int state;

    /**
	 * 附件状态 0无附件，1未领取，2已领取
	 */
    [ProtoMember(8)]
    public int attachState;
}