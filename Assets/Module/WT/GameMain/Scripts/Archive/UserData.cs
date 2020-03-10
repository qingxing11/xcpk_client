using ProtoBuf;
using System;
[Serializable]
public class UserDataPO
{
    [ProtoMember(1)]
    public int userId;// 用户id --平台中的

    [ProtoMember(2)]
    public string account;

    [ProtoMember(3)]
    public string nickName;

    [ProtoMember(4)]
    public int gender;// 性别

    [ProtoMember(5)]
    public string headImgurl = "";

    [ProtoMember(6)]
    public int accountStatus;// 账号状态

    [ProtoMember(7)]
    public string re_user_name;

    [ProtoMember(8)]
    public string mobile_num;

    [ProtoMember(9)]
    public string open_id;
}