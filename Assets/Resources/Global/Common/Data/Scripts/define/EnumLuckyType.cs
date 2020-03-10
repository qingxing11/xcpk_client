namespace Config{
public class EnumLuckyType {

/// <summary>
///获得VIP1
/// </summary>
        public const int VIP1 = 1;

/// <summary>
///获得VIP2
/// </summary>
        public const int VIP2 = 2;

/// <summary>
///获得VIP3
/// </summary>
        public const int VIP3 = 3;

/// <summary>
///获得VIP4
/// </summary>
        public const int VIP4 = 4;

/// <summary>
///获得VIP5
/// </summary>
        public const int VIP5 = 5;

/// <summary>
///增时卡
/// </summary>
        public const int 增时卡 = 6;

/// <summary>
///抢座卡
/// </summary>
        public const int 抢座卡 = 7;

/// <summary>
///改名卡
/// </summary>
        public const int 改名卡 = 8;

/// <summary>
///获得功能卡
/// </summary>
        public const int 金币 = 9;

/// <summary>
///获得金币
/// </summary>
        public const int 钻石 = 10;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == VIP1) {return "获得VIP1";}
if (value == VIP2) {return "获得VIP2";}
if (value == VIP3) {return "获得VIP3";}
if (value == VIP4) {return "获得VIP4";}
if (value == VIP5) {return "获得VIP5";}
if (value == 增时卡) {return "增时卡";}
if (value == 抢座卡) {return "抢座卡";}
if (value == 改名卡) {return "改名卡";}
if (value == 金币) {return "获得功能卡";}
if (value == 钻石) {return "获得金币";}

		return "";
	}
    public static int[] Values = { VIP1,VIP2,VIP3,VIP4,VIP5,增时卡,抢座卡,改名卡,金币,钻石 };
}}