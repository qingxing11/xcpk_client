using Config;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 从服务器获取的玩家存档信息，数据表等数据缓存类
/// </summary>
public class CacheManager
{


    private static bool isDebug = false;


    #region 本地保存
    /// <summary>
    /// 最后选择的服务器名字，保存到本地
    /// </summary>
    public static string lastLoginServerName;

    /// <summary>
    /// 最后选择的服务器地址，保存到本地。该值不为空时默认不读取服务器列表
    /// </summary>
    public static string lastLoginServerHost;
    #endregion

    public CacheManager()
    {
    }
    /// <summary>
    /// 音效(1:false  0:true)
    /// </summary>
    public static bool PlaySound = true;
    /// <summary>
    /// 音乐
    /// </summary>
    public static bool PlayMusic = true;
    /// <summary>
    /// 音乐大小
    /// </summary>
    public static float musicValue = 1;
    /// <summary>
    /// 音效大小
    /// </summary>
    public static float soundValue = 1;
    /// <summary>
    /// 弹幕开关
    /// </summary>
    public static bool Bullte = true;

    public static TokenVO tokenVO;

    public static int lastSelectServerIndex;
    public static List<ServerInfoVO> list_serverInfo;
    /// <summary>
    /// 玩家信息
    /// </summary>
    public static GameData gameData;

    /// <summary>
    /// 是否领取充值榜
    /// </summary>
    public static bool isGetPay = false;

    /// <summary>
    /// 是否领取赢金榜
    /// </summary>
    public static bool isGetWin = false;

    public static long serverAndClientTimeDifference;

    public static KillRoom killRoom = new KillRoom();

    public static bool initRanking;


    /*key:对应PropertyType枚举中的私人领地选项，value:数量。取用可调用DisposeHomeBuildData中给定的方法*/
    public static Dictionary<int, int> functionalBuildTypes;

    public static List<AddFriendsVO> dicAddFriends = new List<AddFriendsVO>();
    public static List<FriendInfoVO> dicFriendsInfo = new List<FriendInfoVO>();
    public static List<FriendsDataVO> dicFriendsList = new List<FriendsDataVO>();

    public static List<SmallChatVO> chat_small = new List<SmallChatVO>();
    public static List<SmallChatVO> chat_classic = new List<SmallChatVO>();
    public static List<SmallChatVO> chat_ten = new List<SmallChatVO>();
    public static List<SmallChatVO> chat_FruitMechine = new List<SmallChatVO>();

    private static Sprite headSprite;  //存放头像
    private static string spriteString;

    public static LoadSeceneMsg loadSeceneMsg;
    /// <summary>
    /// 金币名字
    /// </summary>
    public static int coinsIndex;
    //private static List<UIGold> uIGolds;


    /// <summary>
    /// 转账手续费
    /// </summary>
    public static float transferAccountsPer;

    /// <summary>
    /// 是否可以签到
    /// </summary>
    public static bool todayIsSign;
    /// <summary>
    /// 玩家的昵称
    /// key:userId,value:nickname
    /// </summary>
    public static Dictionary<int, string> map_playersNickname = new Dictionary<int, string>();
    /// <summary>
    /// 充值榜
    /// </summary>
    private static List<RankVO> payRank;
    /// <summary>
    /// 土豪榜：显示前20名账号金币最多的玩家
    /// </summary>
    private static List<RankVO> coinsRank;
    /// <summary>
    /// 赢金榜：显示赢金榜最多的前20名。奖励规则参考友乐
    /// </summary>
    private static List<RankVO> bigWinRank;


    #region 通杀场房间数据

    /// <summary>
    ///  -1:没有打开通杀场 0 正常打开通杀场 1 在电视机中打开通杀场 2在MainScene场景打开
    /// </summary>
    public static int KillRoomTV = 0;

    /// <summary>
    /// 当前局数
    /// </summary>
    public static int bankerRound = 0;
    /// <summary>
    /// 房间状态
    /// </summary>
    public static int state;
    /// <summary>
    /// 通杀场庄家数据
    /// </summary>
    public static PlayerSimpleData banker;
    /// <summary>
    /// 座位玩家数据
    /// </summary>
    private static PlayerSimpleData[] tablePlayers;
    /// <summary>
    /// 奖池
    /// </summary>
    public static long jackpot;
    /// <summary>
    /// 进入通杀场状态时间
    /// </summary>
    public static long stateTime;
    /// <summary>
    /// 上庄列表
    /// </summary>
    private static List<PlayerSimpleData> list_bankerList;
    /// <summary>
    /// 通杀场走势
    /// </summary>
    private static List<bool> list_bankerWin = new List<bool>();
    private static List<bool> list_dongWin = new List<bool>();
    private static List<bool> list_xiWin = new List<bool>();
    private static List<bool> list_nanWin = new List<bool>();
    private static List<bool> list_beiWin = new List<bool>();

    #endregion

    #region 经典场房间数据
    /// <summary>
    /// 经典场类型 0：初级场 1：中级场 2：高级场 3：土豪场
    /// </summary>
    public static int classicType = 0;
    /// <summary>
    /// 房间状态
    /// </summary>
    public static int classRoomState;
    /// <summary>
    /// 庄家坐标
    /// </summary>
    public static int classRoomBankerPos;
    /// <summary>
    /// 自己的坐标(绝对位置)
    /// </summary>
    public static int selfPos;      //自己的坐标
    /// <summary>
    /// 座位玩家数据
    /// </summary>
    private static PlayerSimpleData[] classRoomPlayers;
    /// <summary>
    /// 座位玩家性别
    /// </summary>
    private static int[] classRoomRoleId;
    /// <summary>
    /// 已经下的金币数
    /// </summary>
    public static List<int> list_allBet = new List<int>();
    /// <summary>
    /// 房间状态 0：游戏中 1：结算 2：准备
    /// </summary>
    public static int classicRoomState = 0;
    /// <summary>
    /// 当前行动玩家
    /// </summary>
    public static int actionPos = 0;
    /// <summary>
    /// 当前状态剩余时间
    /// </summary>
    public static int actionTime = 0;
    /// <summary>
    /// 自己手牌 断线重连的时候用到
    /// </summary>
    public static List<PokerVO> list_pokers;

    public static int classicRoundNum;

    public static List<string> Helper_list = new List<string>() { "看牌后每一次投注额将会加倍，闷牌才能赢大钱！", "押注高频彩，轻松赢得巨额奖励！", "完成任务就能获得大量金币！",
    "昨日充值榜冠亚季军可获得充值数100%，50%，20%奖励哦！","连续登录多天可获高额奖励","发送快速聊天和表情可以给你的对手造成无形的压力","大转盘能获得大量金币 VIP 道具哦！",
        "跟注三轮以后就可以比牌了哦！","可通过个人信息界面上传你喜欢的头像！","转动轮盘，赢取首充返利大礼，最高6倍返利 " ,"VIP等级越高，签到励越高"};
    #endregion


    #region 万人场房间数据
    /// <summary>
    /// 万人场自己的绝对位置
    /// </summary>
    public static int selfPosThous;

    /// <summary>
    /// 万人场座位玩家数据
    /// </summary>
    private static PlayerSimpleData[] manyPeopleRoomPlayers;
    /// <summary>
    ///  万人场庄家位置
    /// </summary>
    public static int bankerPos;
    /// <summary>
    /// 打开万人场状态 0:正常打开万人 1:电视机中打开万人场
    /// </summary>
    public static int _manyPeopleId;

    public static int manyPeopleId
    {
        get
        {
            return _manyPeopleId;
        }
        set
        {
            Debug.Log("manyPeopleId赋值:"+value);
            _manyPeopleId = value;
        }
    }

    /// <summary>
    /// 自己手牌（断线重连的时候用到）
    /// </summary>
    public static List<PokerVO> list_pokersManyPeople;

    /// <summary>
    /// 已经下的金币数
    /// </summary>
    public static List<int> list_allBetManyPeople = new List<int>();
    /// <summary>
    /// 当前行动玩家的位置
    /// </summary>
    public static int manyPeopleActionPos = 0;
    /// <summary>
    /// 万人场房间状态 0:待机  1:等待开始 2:发牌  3:等待玩家思考
    /// </summary>
    public static int stateManypeople = 0;
    /// <summary>
    /// 当前状态时间
    /// </summary>
    public static float manyPeopleActionTime = 0;
    /// <summary>
    /// 万人场奖池
    /// </summary>
    public static long manyPeopleJackpot = 0;
    #endregion

    public static List<int> wintype = new List<int>();//彩票记录

    public static List<SafeBoxRecordVO> sbrList = new List<SafeBoxRecordVO>();

    public static List<bool> signList = new List<bool>();//签到列表

    public static List<HornInfoVO> list_hornVO = new List<HornInfoVO>();//大喇叭消息

    public static int killRoomRoundIndex = 0;


    private static Dictionary<string, Texture2D> map_allHeadIcon = new Dictionary<string, Texture2D>();

    public static void AddHeadIcon(string url, Texture2D t2d)
    {
        if (!map_allHeadIcon.ContainsKey(url))
            map_allHeadIcon.Add(url, t2d);
    }

    public static Texture2D GetHeadIcon(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            if (CacheManager.gameData.roleId == 0)
                return FileIO.LoadSprite(R.SpritePack.HEAD_MAN).texture;
            else
                return FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN).texture;
        }
        Texture2D t2d = map_allHeadIcon.GetValue(url);
        if (t2d == null)
        {
            byte[] data = NetworkIO.HttpGet(url);
            t2d = data.DecodeTexture2d(128,128);
            map_allHeadIcon[url] = t2d;
        }

        return t2d;
    }

    public static void Init()
    {
        InitHeadImgIcon();
    }

    private static void InitHeadImgIcon()
    {
        //Debug.Log("登陆时初始化头像 --->  CacheManager.gameData.headIcon:" + CacheManager.gameData.headIcon);
        //if (string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        //{
        //    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
        //if (string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        //{
        //    Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
        //    Debug.Log("有自定义头像，登陆时设置成自定义头像,头像大小:" + CacheManager.gameData.headIcon.Length);
        //    Texture2D t2d = new Texture2D(100, 100);
        //    t2d.LoadImage(CacheManager.gameData.headIcon);


        //    CacheManager.headImgIcon = t2d;
        //}
    }

    public static Dictionary<int, List<FriendChatVO>> dic_UserChatInfo = new Dictionary<int, List<FriendChatVO>>();//私人聊天

    //public static Texture2D headImgIcon = null;

    /// <summary>
    /// 添加大喇叭消息
    /// </summary>
    /// <param name="vo"></param>
    public static void AddHorn(HornInfoVO vo)
    {
        if (vo == null)
        {
            return;
        }

        foreach (var item in list_hornVO)
        {
            if (item.info.Equals(vo.info))
            {
                return;
            }
        }

        if (list_hornVO.Count >= 25)
        {
            list_hornVO.RemoveAt(0);
        }
        list_hornVO.Add(vo);
    }


    public static void LeaveKillRoom()
    {
 
        KillRoomTV = -1;
    }

    /// <summary>
    /// 0 其他情况 1 在通杀场打开水果机
    /// </summary>
    public static int FruitRoomTV = 0;

    /// <summary>
    /// 当前运行的游戏场景 0(默认)大厅，2 通杀场   1：经典场 5:万人场  6:水果机
    /// </summary>
    public static int RunRoomId = 0;

    /// <summary>
    /// 初始化签到数据
    /// </summary>
    /// <param name="list"></param>
    public static void InitSignList(List<bool> list)
    {
        if (list == null)
        {
            return;
        }

        signList = list;
    }

    /// <summary>
    /// 添加好友聊天消息
    /// </summary>
    /// <param name="list"></param>
    public static void AddFriendChatInfo(List<FriendChatVO> list)
    {
        if (list == null)
        {
            return;
        }
        foreach (var item in list)
        {
            AddFriendChatInfo(item);
        }
    }

    /// <summary>
    /// 改变好友在线状态
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="state"></param>
    public static void FriendStateChange(int userId, bool state)
    {
        if (dicFriendsList == null)
        {
            return;
        }
        foreach (var item in dicFriendsList)
        {
            if (item.friendsData.id == userId)
            {
                item.stateOnLine = state;
                break;
            }
        }
    }

    /// <summary>
    /// 添加好友聊天消息
    /// </summary>
    /// <param name="vo"></param>
    /// <param name="friendKey"></param>
    public static void AddFriendChatInfo(FriendChatVO vo)
    {
        if (vo == null)
        {
            return;
        }
        int friendKey = vo.userId;
        if (vo.userId == CacheManager.gameData.userId)
        {
            friendKey = vo.receiveUserId;
        }
        if (dic_UserChatInfo.ContainsKey(friendKey))
        {
            List<FriendChatVO> listVO = dic_UserChatInfo[friendKey];
            listVO.Add(vo);
        }
        else
        {
            List<FriendChatVO> listVO = new List<FriendChatVO>();
            listVO.Add(vo);
            dic_UserChatInfo.Add(friendKey, listVO);
        }
    }

    /// <summary>
    /// 设置某天签到成功
    /// </summary>
    /// <param name="day"></param>
    public static void setSign(int day)
    {
        signList[day - 1] = true;
    }

    public static void AddSafeBoxRecord(SafeBoxRecordVO vo)
    {
        if (vo == null)
        {
            return;
        }
        sbrList.Insert(0,vo);
    }
    public static void AddSafeBoxRecord(List<SafeBoxRecordVO> list)
    {
        if (list == null)
        {
            return;
        }
        sbrList.Clear();
        sbrList.AddRange(list);
    }

    private static int recordNum = 20;
    public static void AddWinRecord(int type)
    {
        if (wintype.Count >= recordNum)
        {
            int removeNum = wintype.Count - recordNum + 1;
            for (int i = 0; i < removeNum; i++)
            {
                wintype.Remove(0);
            }
        }
        wintype.Add(type);
    }

    public static int unitCoin = 10000;

    public static long GetUnitNum(long num)
    {
        return num / unitCoin;
    }

    public static long GetCoin()
    {
        if (gameData == null)
        {
            return 0;
        }
        long coin = gameData.coins;
        return coin / unitCoin;
    }

    public static long GetBankCoin()
    {
        if (gameData == null)
        {
            return 0;
        }
        long coin = gameData.bankCoins;
        Debug.Log("保险箱金币：" + gameData.bankCoins);
        return coin / unitCoin;
    }



    public static bool ShowIcon()
    {
        bool info = false;
        List<AddFriendsVO> addFriendsVOs = dicAddFriends;
        if (addFriendsVOs == null)
        {
            return info;
        }
        foreach (AddFriendsVO vo in addFriendsVOs)
        {
            if (vo.state == EnumFriendState.未处理)
            {
                info = true;
                return info;
            }
        }
        return info;
    }




    public static void SetInfoState(int userId, int state)
    {
        foreach (var item in dicFriendsInfo)
        {
            if (item.userId == userId)
            {
                item.read = state;
            }
        }
    }

    /// <summary>
    /// 添加好友列表
    /// </summary>
    /// <param name="vo"></param>
    public static void AddFriendsList(FriendsDataVO vo)
    {
        if (dicFriendsList != null)
        {
            foreach (var item in dicFriendsList)
            {
                if (item.friendsData.id == vo.friendsData.id)
                {
                    return;
                }
            }
        }
        dicFriendsList.Add(vo);
    }

    /// <summary>
    /// 删除好友列表
    /// </summary>
    /// <param name="vo"></param>
    public static void RemoveFriendsList(int userId)
    {
        FriendsDataVO vo = null;
        foreach (var item in dicFriendsList)
        {
            if (item.friendsData.id == userId)
            {
                vo = item;
            }
        }
        if (vo != null)
        {
            dicFriendsList.Remove(vo);
        }
    }

    /// <summary>
    /// 添加好友
    /// </summary>
    /// <param name="vo">对方简要信息</param>
    public static void AddFriendEvent(AddFriendsVO vo)
    {
        foreach (AddFriendsVO friendsVO in dicAddFriends)
        {
            if (friendsVO.id == vo.id)
            {
                return;
            }
        }
        dicAddFriends.Add(vo);
    }

    /// <summary>
    /// 移除添加好友
    /// </summary>
    /// <param name="key">对方Id</param>
    public static void RemoveAddFriendEvent(int key)
    {
        AddFriendsVO vo = null;
        foreach (AddFriendsVO friendsVO in dicAddFriends)
        {
            if (friendsVO.id == key)
            {
                vo = friendsVO;
            }
        }
        if (vo != null)
        {
            dicAddFriends.Remove(vo);
        }
    }

    /// <summary>
    /// 添加好友消息
    /// </summary>
    /// <param name="vo">好友消息</param>
    public static void AddFriendsInfo(FriendInfoVO vo)
    {
        foreach (FriendInfoVO friendsInfoVO in dicFriendsInfo)
        {
            if (friendsInfoVO.userId == vo.userId)
            {
                return;
            }
        }
        dicFriendsInfo.Add(vo);
    }

    /// <summary>
    /// 移除好友消息
    /// </summary>
    /// <param name="userId">对方玩家Id</param>
    public static void RemoveFriendsInfo(int userId)
    {
        FriendInfoVO vo = null;
        foreach (FriendInfoVO friendsInfoVO in dicFriendsInfo)
        {
            if (friendsInfoVO.userId == userId)
            {
                vo = friendsInfoVO;
            }
        }
        if (vo != null)
        {
            dicFriendsInfo.Remove(vo);
        }
    }


    public static void ComputationTimeDifference(long currentServerTime)
    {
        long sun = currentServerTime - MyTimeUtil.GetCurrTimeMM;
        if (isDebug)
        {
            Debug.Log("服务器与客户端时间差 ：" + sun);
        }

        serverAndClientTimeDifference = sun;
    }



    /// <summary>  
    /// 苹果过审核出包 标志
    /// </summary>
    public static bool IsIOSAudit =
#if UNITY_IOS && IOSAUDIT
        true;
#else
        false;
#endif




    //本地和下载的语言文件地址
    public static string RecordPath_Voice
    {
        get
        {
            return FileIO.PathURL + "/recording.dat";
        }
    }

    public static string DownLoadPath_Voice
    {
        get
        {
            return FileIO.PathURL + "/download.dat";
        }
    }

    public static string Account
    {
        set;
        get;
    }

    public static PlayerSimpleData[] TablePlayers
    {
        get
        {
            if (tablePlayers == null)
                tablePlayers = new PlayerSimpleData[8];
            return tablePlayers;
        }

        set
        {
            tablePlayers = value;
        }
    }

    public static List<PlayerSimpleData> List_bankerList
    {
        get
        {
            if (list_bankerList == null)
                list_bankerList = new List<PlayerSimpleData>();
            return list_bankerList;
        }

        set
        {
            list_bankerList = value;
        }
    }

    public static List<bool> List_bankerWin
    {
        get
        {
            if (list_bankerWin == null)
                list_bankerWin = new List<bool>();
            return list_bankerWin;
        }

        set
        {
            list_bankerWin = value;
        }
    }

    public static List<bool> List_dongWin
    {
        get
        {
            if (list_dongWin == null)
                list_dongWin = new List<bool>();
            return list_dongWin;
        }

        set
        {
            list_dongWin = value;
        }
    }

    public static List<bool> List_xiWin
    {
        get
        {
            if (list_xiWin == null)
                list_xiWin = new List<bool>();
            return list_xiWin;
        }

        set
        {
            list_xiWin = value;
        }
    }

    public static List<bool> List_nanWin
    {
        get
        {
            if (list_nanWin == null)
                list_nanWin = new List<bool>();
            return list_nanWin;
        }

        set
        {
            list_nanWin = value;
        }
    }

    public static List<bool> List_beiWin
    {
        get
        {
            if (list_beiWin == null)
                list_beiWin = new List<bool>();
            return list_beiWin;
        }

        set
        {
            list_beiWin = value;
        }
    }
    /// <summary>
    /// 充值榜
    /// </summary>
    public static List<RankVO> PayRank
    {
        get
        {
            if (payRank == null)
                payRank = new List<RankVO>();
            return payRank;
        }

        set
        {
            payRank = value;
        }
    }
    /// <summary>
    /// 土豪榜
    /// </summary>
    public static List<RankVO> CoinsRank
    {
        get
        {
            if (coinsRank == null)
                coinsRank = new List<RankVO>();
            return coinsRank;
        }

        set
        {
            coinsRank = value;
        }
    }
    /// <summary>
    /// 赢金榜
    /// </summary>
    public static List<RankVO> BigWinRank
    {
        get
        {
            if (bigWinRank == null)
                bigWinRank = new List<RankVO>();
            return bigWinRank;
        }

        set
        {
            bigWinRank = value;
        }
    }

    public static PlayerSimpleData[] ClassRoomPlayers
    {
        get
        {
            if (classRoomPlayers == null)
                classRoomPlayers = new PlayerSimpleData[5];
            return classRoomPlayers;
        }

        set
        {
            classRoomPlayers = value;
        }
    }

    public static int[] ClassRoomRoleId
    {
        get
        {
            if (classRoomRoleId == null)
                classRoomRoleId = new int[5];
            return classRoomRoleId;
        }

        set
        {
            classRoomRoleId = value;
        }
    }

    public static PlayerSimpleData[] ManyPeopleRoomPlayers
    {
        get
        {
            if (manyPeopleRoomPlayers == null)
                manyPeopleRoomPlayers = new PlayerSimpleData[5];
            return manyPeopleRoomPlayers;
        }

        set
        {
            manyPeopleRoomPlayers = value;
        }
    }

    public static UIGold GetUIGold()
    {
        string name = "coins" + CacheManager.coinsIndex++;
        UIGold uIGold = BaseCanvas.GetController<GoldCtrl>().Show(name);
        //BaseCanvas.GetController<RoomCtrl>().ShowPokersUI();
        return uIGold;
    }

    public static void ClearChat()
    {
        if (chat_small != null && chat_small.Count > 0)
        {
            Debug.Log("清空缓存聊天数据！");
            chat_small.Clear();
        }
    }

    private static int chatNum = 100;
    public static void AddSmallChat(SmallChatVO smallChatVO, int curRoom)
    {
        switch (curRoom)
        {
            case 1:
                if (chat_small.Count > chatNum)
                {
                    RemoveSmallChat(0);
                }
                chat_small.Add(smallChatVO);
                break;
            case 3:
                if (chat_classic.Count > chatNum)
                {
                    chat_classic.RemoveAt(0);
                }
                chat_classic.Add(smallChatVO);
                break;
            case 2:
                if (chat_ten.Count > chatNum)
                {
                    chat_ten.RemoveAt(0);
                }
                chat_ten.Add(smallChatVO);
                break;
            case 4:
                if (chat_FruitMechine.Count > chatNum)
                {
                    chat_FruitMechine.RemoveAt(0);
                }
                chat_FruitMechine.Add(smallChatVO);
                break;
            default:
                break;
        }

    }

    public static void RemoveSmallChat(SmallChatVO smallChatVO)
    {
        chat_small.Remove(smallChatVO);
    }
    public static void RemoveSmallChat(int index)
    {
        chat_small.RemoveAt(index);
    }

    /// <summary>
    /// 上线时检测是否有苹果的未完成订单
    /// </summary>
    public static void CheckAppleOrderExits()
    {
        string order = PlayerPrefs.GetString("receiptOrder");
        if (!string.IsNullOrEmpty(order))
        {
            TipsManager.Alert("你有未完成的苹果支付订单正在处理");


            //TODO
            //ApplePayVerifyRequest request = new ApplePayVerifyRequest (order);

            //NetWorkClient.sendRequest(request);
        }

    }
    public static void AddAppleOrder(string s)
    {
        PlayerPrefs.SetString("receiptOrder", s);
    }
    public static void ClearAppleOrder()
    {
        PlayerPrefs.SetString("receiptOrder", "");
    }
    /// <summary>
    /// 是否在苹果支付中
    /// </summary>
    public static bool mIsApplePaying = false;

    public static bool IsMineUserId(int userId)
    {
        return userId == gameData.userId;
    }

    /// <summary>
    /// 获取当前等级升级需要的经验值
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int getCostExp(int level)
    {
        if (level < 1)
        {

            return 0;
        }
        int a = (int)Mathf.Pow(level - 1, 3);

        int exp = (a + 35) / 3 * ((level - 1) * 3 + 35) + 35;
        return exp;
    }
}

public struct LoadSeceneMsg
{
    public const int TYPE_NULL = 0;//什么都不做
    public const int TYPE_CHANGEPOS = 2;//改变摄机位置


    public int type;//信息类型
    public Vector2 position;//跳转位置
}

