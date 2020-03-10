using UnityEngine;
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class PlayerSimpleData
{
    /// <summary>
    /// 唯一id
    /// </summary>
    [ProtoMember(1)]
    public int userId;
    /// <summary>
    /// 昵称
    /// </summary>
    [ProtoMember(2)]
    public string nickName;
    /// <summary>
    /// 头像
    /// </summary>
    [ProtoMember(3)]
    public string headIconUrl;
    /// <summary>
    /// 金币
    /// </summary>
    [ProtoMember(4)]
    public long coins;
    /// <summary>
    /// 经典场位置
    /// </summary>
    [ProtoMember(5)]
    public int classicGamepos;
    /// <summary>
    /// 万人场位置
    /// </summary>
    [ProtoMember(6)]
    public int manyGamepos;
    /// <summary>
    /// 水果机位置
    /// </summary>
    [ProtoMember(7)]
    public int fruitGamepos;
    /// <summary>
    /// 通杀场位置
    /// </summary>
    [ProtoMember(8)]
    public int killRoomPos;
    /// <summary>
    /// 性别
    /// </summary>
    [ProtoMember(9)]
    public int roleId;
    /// <summary>
    /// vip等级
    /// </summary>
    [ProtoMember(10)]
    public int vipLv;
    /// <summary>
    /// 玩家等级
    /// </summary>
    [ProtoMember(11)]
    public int lv;
    /// <summary>
    /// 砖石
    /// </summary>
    [ProtoMember(12)]
    public int crystals; //钻石
    /// <summary>
    /// 签名
    /// </summary>
    [ProtoMember(13)]
    public string sign;
    /// <summary>
    /// 胜场
    /// </summary>
    [ProtoMember(14)]
    public int victoryNum;

    /// <summary>
    /// 负场
    /// </summary>
    [ProtoMember(15)]
    public int failureNum;

    /**
    *再当前游戏中的下注数(这局游戏中下注数)
    */
    [ProtoMember(16)]
    public long betNum;

    /**是否看牌*/
    [ProtoMember(17)]
    public bool isCheckPoker;

    /**0,待机   1:普通()  2:失败 3:等待开始*/
    [ProtoMember(18)]
    public int gameState;

    //[ProtoMember(16)]
    //public byte[] headImgIcon;

    /// <summary>
    /// 需要显示的icon
    /// </summary>
    public List<Sprite> sprites = new List<Sprite>();

    /// <summary>
    /// 
    /// </summary>
    public Sprite headIcon;

    public override string ToString()
    {
        return "PlayerSimpleData [userId=" + userId + ", nickName=" + nickName + ", coins=" + coins + ", classicGamepos=" + classicGamepos + ", manyGamepos=" + manyGamepos + ", fruitGamepos=" + fruitGamepos + ",killRoomPos:"+ killRoomPos+"]";
    }
}