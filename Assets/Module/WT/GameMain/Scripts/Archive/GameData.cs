using ProtoBuf;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ProtoContract]
public class GameData
{
    [ProtoMember(1)]
    public string nickName = "";// 昵称

    [ProtoMember(2)]
    public int first_pay;

    [ProtoMember(3)]
    public int vip_day;// 剩余天数

    [ProtoMember(4)]
    public int headid;
    /// <summary>
    /// 钻石
    /// </summary>
    [ProtoMember(5)]
    public int crystals; //钻石

    [ProtoMember(6)]
    public long _coins;//金币

    [ProtoMember(7)]
    public int exp;// 玩家经验值

    [ProtoMember(8)]
    public string checkin_status = "";// 本月签到记录

    [ProtoMember(9)]
    public int sign_num_days;// 签到

    [ProtoMember(10)]
    public string last_sign_date;

    [ProtoMember(11)]
    public string serverMail = "";

    [ProtoMember(12)]
    public int win_num;// 胜利次数

    [ProtoMember(13)]
    public int play_game_num;// 总游戏局数

    /// <summary>
    /// 性别
    /// </summary>
    [ProtoMember(14)]
    public int roleId;//选择的性别

    /// <summary>
    /// id
    /// </summary>
    [ProtoMember(15)]
    public int userId;//玩家的id

    /**
	 * 玩家等级
	 */
    [ProtoMember(16)]
    public int playerLevel;

    [ProtoMember(17)]
    public int vipLv;//玩家vip等级

    [ProtoMember(18)]
    public string mobile_num;

    /// <summary>
    /// 银行中金币
    /// </summary>
    [ProtoMember(19)]
    public long bankCoins;

    [ProtoMember(20)]
    public int treeLv;

    /**
	 * 个性签名
	 */
    [ProtoMember(21)]
    public string sign;


    /**
	 * 改名
	 */
    [ProtoMember(22)]
    public int modifyNickName;

    /**
	 * 抢座
	 */
    [ProtoMember(23)]
    public int robPos;

    /**
	 * 增时间
	 */
    [ProtoMember(24)]
    public int addTime;

    /**
	 * 胜场
	 */
    [ProtoMember(25)]
    public int victoryNum;

    /**
	 * 负场
	 */
    [ProtoMember(26)]
    public int failureNum;

    /**
	 * 账号
	 */
    [ProtoMember(27)]
    public string account;

    /**充值金额*/
    [ProtoMember(28)]
    public int topUp;

    /// <summary>
    /// 领取奖励倍数
    /// </summary>
    [ProtoMember(29)]
    public int luckyNum;
    /// <summary>
    /// 单月是否抽奖
    /// </summary>
    [ProtoMember(30)]
    public bool isLucky;

    /**玩家头像*/
    [ProtoMember(31)]
    public string headIconUrl;

    [ProtoMember(32)]
    public bool accountSupplementary;
 
    [ProtoMember(33)]
    public long startOutPutTime;

    public GameData() { }

    public long coins
    {
        get {
            return _coins;
        }
        set
        {
             Debug.Log("更新玩家金币:"+value);
            _coins = value; 
        }
    }

    public override string ToString()
    {
        return "GameData [nickName=" + nickName + ", first_pay=" + first_pay + ", vip_day=" + vip_day + ", headid=" + headid + ", crystals=" + crystals + ", coins=" + coins + ", exp=" + exp + ", checkin_status=" + checkin_status + ", sign_num_days=" + sign_num_days + ", last_sign_date=" + last_sign_date + ", serverMail=" + serverMail + ", win_num=" + win_num + ", play_game_num=" + play_game_num  + ", roleId=" + roleId + ", userId=" + userId + ", playerLevel=" + playerLevel + ", vipLv=" + vipLv + ", mobile_num=" + mobile_num + ", bankCoins=" + bankCoins + ", treeLv=" + treeLv + ", sign=" + sign + ", modifyNickName=" + modifyNickName + ", robPos=" + robPos + ", addTime=" + addTime + ", victoryNum=" + victoryNum + ", failureNum=" + failureNum
                + ", account=" + account + ", topUp=" + topUp + ", luckyNum=" + luckyNum + ", isLucky=" + isLucky + ", headIconUrl=" + headIconUrl + ", accountSupplementary=" + accountSupplementary+ ",startOutPutTime="+ startOutPutTime + "]";
    }
}
