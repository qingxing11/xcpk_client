
public class MsgType
{
    public const int TEST = -1000;
    public const int HEARTBEAT = -999;// 心跳包
    public const int HEARTBEAT_RESPONSECLIENT = -998;// 测试RTT
    public const int TEST_LIST = -997;

    public const int CTRL_ROLE = -500;

    /**** 工具 ****/
    public const int UTIL_SERVER_TIME = 100;// 服务器时间
    public const int UTIL_SERVER_LIST = 101;// 服务器列表
    public const int UTIL_CHECK_FILE = 102; // 检查文件是否最新
    public const int UTIL_DOWNLOAD_RES = 103; // 下载文件

    public const int UTIL_GET_NEW_FILE_URL = 108;


    /**定时任务***/
    public const int TIMESTASK = 180;//定时任务消息请求

    /**定时任务***/
    public const int RealNameAuthentication = 190;//身份证验证                                               
    public const int AntiAddictionTips = 191;//防沉迷推送

    public const int USER_LOGIN = 200;         //登录
    public const int USER_REGISTER = 201;      //注册
    public const int USER_GUESTLOGIN = 211;    //游客快速登录

    public const int WECHAT_USER_LOGIN = 220;    //微信登录
    public const int USER_VALIDATION_TOKEN = 221;//验证token
    public const int USER_上传自定义头像 = 223;


    /**********通杀场******/
    public const int KillRoom_同步庄家金币 = 243;
    public const int KillRoom_获取所有红包 = 245;   //获取所有红包
    public const int KillRoom_红包公告 = 246;
    public const int KillRoom_其他玩家下庄 = 247;   //通杀场其他玩家下庄
    public const int KillRoom_其他玩家上庄 = 248;   //其他玩家上庄
    public const int KillRoom_获取奖池 = 249;       //获取奖池
    public const int KillRoom_休息时间 = 250;
    public const int KillRoom_通杀场下注时间 = 251;
    public const int KillRoom_通杀场开奖状态 = 252;    //发牌
    public const int KillRoom_进入通杀场 = 253;
    public const int KillRoom_离开通杀场 = 254;
    public const int KillRoom_通杀场下注 = 255;
    public const int KillRoom_通杀场上庄 = 256;   //申请上庄
    public const int KillRoom_通杀场下庄 = 257;   //申请下庄
    public const int KillRoom_其他玩家下注 = 258;
    public const int KillRoom_其他玩家坐下 = 259;  //其他玩家坐下"),
    public const int KillRoom_选座坐下 = 260;      //选座坐下"),
    public const int KillRoom_从座位站起 = 261;    //从座位站起),
    public const int KillRoom_其他玩家站起 = 262;  //其他玩家站起"),
    public const int KillRoom_庄家列表 = 263;      //庄家列表"),
    public const int KillRoom_更换庄家 = 264;      //更换庄家"),
    public const int KillRoom_发红包 = 266;        //通杀场发红包
    public const int KillRoom_自己下庄 = 265;      //自己下庄
    public const int KillRoom_大赢家 = 267;
    public const int KillRoom_抢红包 = 268;        //通杀场抢红包
    public const int KillRoom_抢红包结束 = 269;    //通杀场抢红包



    public const int classic_进入新手场 = 270;       //进入新手场
    public const int classic_开始发牌 = 271;         //开始发牌 
    public const int classic_其他玩家进入房间 = 272; //其他玩家进入房间
    public const int classic_玩家行动 = 273;         //玩家动作
    public const int classic_玩家弃牌 = 274;         //玩家弃牌自己弃牌
    public const int classic_有玩家弃牌 = 275;       //有玩家弃牌其他玩家弃牌
    public const int classic_玩家看牌 = 276;         //自己看牌
    public const int classic_有玩家看牌 = 277;       //其他玩家看牌
    public const int classic_玩家跟注 = 278;         //自己跟注
    public const int classic_有玩家跟注 = 279;       //有玩家跟注
    public const int classic_玩家加注 = 280;         //玩家加注
    public const int classic_有玩家加注 = 281;       //有玩家加注
    public const int classic_玩家胜利 = 284;         //经典场玩家胜利(结算)
    public const int classic_玩家离开 = 285;         //经典场玩家离开
    public const int classic_其他玩家离开 = 286;     //经典场其他玩家离开
    public const int classic_玩家比牌 = 287;         //玩家比牌
    public const int classic_其他玩家比牌 = 288;     //其他玩家比牌
    public const int classic_玩家全压 = 289;         //经典场全压
    public const int classic_其他玩家全压 = 290;     //经典场其他玩家全压
    public const int classic_等待比赛开始 = 291;     //经典场等待开始
    public const int classic_换桌 = 292;             //经典场换桌
    public const int classic_断线重连 = 293;         //经典场断线重连
    public const int classic_大赢家 = 294;



    public const int manypepol_发牌 = 296;                 //万人场发牌"),
    public const int manypepol_有玩家上桌 = 297;           //万人场有玩家上桌//有可能是自己
    public const int manypepol_申请上桌 = 298;             //万人场申请上桌
    public const int manypepol_玩家进入 = 299;             //玩家进入万人场
    public const int manypepol_玩家行动 = 300;             //万人场玩家行动
    public const int manypepol_有玩家弃牌 = 301;           //万人场其他弃牌
    public const int manypepol_玩家看牌 = 302;             //万人场自己看牌
    public const int manypepol_有玩家看牌 = 303;           //有玩家看牌
    public const int manypepol_玩家跟注 = 304;             //万人场自己跟注     
    public const int manypepol_其他玩家跟注 = 305;         //万人场其他玩家跟注
    public const int manypepol_玩家加注 = 306;             //万人场玩家加注
    public const int manypepol_其他玩家加注 = 307;         //万人场其他玩家加注
    public const int manypepol_闲家下注 = 308;             //万人场闲家下注   //自己下注
    public const int manypepol_有闲家下注 = 309;           //万人有场闲家下注 //别人下注
    public const int manypepol_上桌列表 = 310;             //万人上桌列表
    public const int manypepol_其他玩家比牌 = 311;         //万人场其他玩家比牌
    public const int manypepol_玩家比牌 = 312;             //万人场玩家比牌
    public const int manypepol_玩家弃牌 = 313;             //万人场自己弃牌
    public const int manypepol_玩家全压 = 314;             //万人场玩家全压
    public const int manypepol_申请下桌 = 316;             //万人场申请下桌
    public const int manypepol_玩家下桌 = 317;             //万人场玩家下桌
    public const int manypepol_玩家离开 = 318;             //万人场玩家离开
    public const int manypepol_其他玩家全压 = 319;         //万人场其他玩家弃牌
    public const int manypepol_玩家胜利 = 320;             //万人场玩家胜利
    public const int manypepol_开始下注 = 321;             //万人场开始下注
    public const int manypepol_开始下注_等待比赛开始 = 322;//万人场等待开始
    public const int manypepol_断线重连 = 323;             //万人场断线重连
    public const int manypepol_获取奖池 = 324;             //万人场奖池
    public const int manypepol_其他玩家上庄 = 325;         //万人场其他玩家上庄"),
    public const int manypepol_其他玩家下庄 = 326;         //万人场其他玩家下庄"),
    public const int manypepol_大赢家 = 327;

    public const int GAME_货币变化 = 332;      //货币变化

    public const int GAME_客户端要求断线重连 = 334;



    public const int GGL_单次购买 = 336;//,"购买1张刮刮乐"),
    public const int GGL_自定义购买 = 337;//,"自定义购买任意张"),
    public const int GGL_兑奖 = 338;
   

    public const int BATTLE_回合伤害数据 = 491;
    public const int BATTLE_战斗中撤退 = 492;

    public const int CHAT_收费表情 =506;   //收费表情
    public const int PUSH_收费表情 = 507;

    public const int Chat_快捷回复 = 516;
    public const int Chat_小窗聊天 = 517;
    public const int Horn_喇叭消息 = 518;

    public const int ADDFRIENDS = 520;//添加好友
    public const int ASKFRIENDS = 521;//请求好友列表
    public const int ASK_推送添加好友 = 522;//请求添加好友
    public const int Look_查找好友 = 523;//查找好友
    public const int Agree_同意添加好友 = 524;//同意添加好友
    public const int Info_消息通知 = 525;//消息通知
    public const int Info_消息已读 = 526;//消息通知
    public const int Add_消息已读 = 527;//消息通知
    public const int Delete_删除消息 = 528;//消息通知
    public const int Delete_删除好友 = 529;//删除好友

    public const int ChatInfo_好友聊天消息 = 530;
    public const int ChatInfo_好友聊天状态 = 531;
    public const int ChatInfo_好友聊天 = 532;
    public const int Push_好友玩家状态 = 533;

    public const int Lottery_下注 = 540;
    public const int Lottery_彩票结果 = 541;
    public const int Lottery_自动下注 = 542;
    public const int Lottery_下注时间 = 543;
    public const int Lottery_开奖时间 = 544;
    public const int Lottery_同步时间 = 545;
    public const int Lottery_金钱改变 = 546;
    public const int Lottery_中奖提示 = 547;
   

    public const int EnterFruitMechine = 560;//进入水果机
    public const int LeaveFruitMechine = 561;//离开水果机
    public const int FruitMechine = 562;//水果机下注
    public const int FruitUpBanker = 563;//水果机上庄
    public const int FruitDownBanker = 564;//水果机下庄
    public const int FruitMechine_开始下注 = 565;
    public const int Push_FruitMechine_结算 = 566;//水果机结算
    public const int Fruit_requestBankerList = 567;//请求房间内庄家列表
    public const int Fruit_bankerListChange = 568;//切换庄家时消息推送
    public const int Fruit_bankerWining = 569;//发送庄家结算消息

    public const int Fruit_ContinueXiaZhu = 570;//"请求连续下注",
    public const int Fruit_CancelContinueXiaZhu = 571;//"取消连续下注"
    public const int Fruit_JiangPool = 572;//推送奖池信息
    public const int Fruit_断线重连 = 573;
    public const int Fruit_下注 = 574;
    public const int Fruit_大赢家 = 575;

    public const int Push_TaskInfo = 580;//,"玩家上线时推送玩家任务信息"),
    public const int Push_TaskEveryTimeComplete = 581;//"玩家每次完成任务时推送"),
    public const int ReceiveReward = 582;//,"领取奖励请求"),
    public const int Push_FreeChouJiang = 583;//推送当前玩家是否已经免费抽过奖
    public const int ChouJiangResult = 584;   //抽奖结果
    public const int Push_onLineRewardInfo = 585;//"推送在线奖励信息");
    public const int RequestLingQuOnLineReward = 586;//"请求领取在线奖励");

    public const int PAY_支付宝支付下单 = 600;
    public const int PAY_微信支付下单 = 602;
    public const int PAY_支付宝网页支付下单 = 609;
    public const int PAY_微信网页支付下单 = 610;
    public const int PAY_TestPay = 612;
    public const int PAY_BUYGOLD = 613;
    public const int PAY_BUYITEM = 614;

  
    //----------------------公告,韦喜捷 start---------------------
    public const int NOTICE_服务器准备重启 = 705;
    //----------------------公告,韦喜捷 end----------------------

    public const int PUSHUSER_等级变化 = 803;    //等级变化
    public const int PUSHUSER_金币变化 = 804;
    public const int PUSHTREASURE_皇家礼包 = 880;

    public const int PushFriendsOnLine_好友是否在线 = 910;

    public const int PUSHUSER_VIP = 1043;
    public const int PUSHUSER_另一个设备登录 = 1044;

    public const int SafeBox_存入银行 = 1300;
    public const int SafeBox_游戏币转账 = 1301;
    public const int SafeBox_游戏币转账确认 = 1302;
    public const int SafeBox_取出银行=1303;
    public const int SafeBox_银行记录 = 1304;
    public const int SafeBox_某人转账给玩家=1305;
    public const int Player_进入游戏主界面= 1306;

    public const int MoneyTree_推送产出 = 1400;
    public const int MoneyTree_领取 = 1401;
    public const int MoneyTree_同步= 1402;
    public const int MoneyTree_升级 = 1403;

    public const int Sign_签到数据 = 1500;
    public const int Sign_签到 = 1501;
    public const int Sign_更新签到=1502;


    public const int UPDATENICKNAME = 2100;    //修改昵称
    public const int UPDATESIGN = 2101;        //修改签名
    public const int UPDATEGENDER = 2102;      //修改性别

    public const int RANKING = 2105;           //排行榜
    public const int RANKINGREWARD = 2106;     //领取排行榜奖励

    public const int LUCKY = 2110;             //幸运大转盘

    public const int BINDPHONE_GETCODE = 2120;        // 获取验证码
    public const int BINDPHONE = 2121;      //绑定手机号
    public const int MODIFYPWD = 2122;      //修改密码
    public const int SET_完善账号 = 2124;
    public const int SET_切换账号 = 2125;
    public const int SET_找回密码 = 2126;

    public const int SET_找回密码获取验证码 = 2127;

    public const int MAIL_READ = 2200;       // 读取邮件
    public const int MAIL_GETALL = 2201;     // 请求所有邮件
    public const int MAIL_GETATTACH = 2202;  //领取一封邮件的附件
    public const int MAIL_DELETE = 2203;     //删除一封邮件
    public const int GET_SIMPLEDATA = 2204;  //获取简单数据
    public const int LUCKY_BOX = 2205;       //宝箱
    public const int LOW = 2206;             //低保
}