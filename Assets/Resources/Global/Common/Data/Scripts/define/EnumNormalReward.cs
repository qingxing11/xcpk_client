namespace Config{
public class EnumNormalReward {

/// <summary>
///小苹果
/// </summary>
        public const int BigApple = 1;

/// <summary>
///大苹果
/// </summary>
        public const int smallApple = 2;

/// <summary>
///小芒果
/// </summary>
        public const int BigMangGuo = 3;

/// <summary>
///大芒果
/// </summary>
        public const int smallMangGuo = 4;

/// <summary>
///小西瓜
/// </summary>
        public const int BigXiHua = 5;

/// <summary>
///大西瓜
/// </summary>
        public const int smallXiGua = 6;

/// <summary>
///小橘子
/// </summary>
        public const int BigOrange = 7;

/// <summary>
///大橘子
/// </summary>
        public const int smallOrange = 8;

/// <summary>
///小星星
/// </summary>
        public const int BigStar = 9;

/// <summary>
///d大星星
/// </summary>
        public const int smallStar = 10;

/// <summary>
///大双七
/// </summary>
        public const int BigSeven = 12;

/// <summary>
///小双七
/// </summary>
        public const int smallSeven = 11;

/// <summary>
///Bar
/// </summary>
        public const int BigBar = 13;

/// <summary>
///smalBar
/// </summary>
        public const int smallBar = 14;

/// <summary>
///小铃铛
/// </summary>
        public const int BigLingDang = 15;

/// <summary>
///大铃铛
/// </summary>
        public const int smallLingDang = 16;

/// <summary>
///通杀
/// </summary>
        public const int LuckNone = 17;

/// <summary>
///通赔
/// </summary>
        public const int LuckFail = 18;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == BigApple) {return "小苹果";}
if (value == smallApple) {return "大苹果";}
if (value == BigMangGuo) {return "小芒果";}
if (value == smallMangGuo) {return "大芒果";}
if (value == BigXiHua) {return "小西瓜";}
if (value == smallXiGua) {return "大西瓜";}
if (value == BigOrange) {return "小橘子";}
if (value == smallOrange) {return "大橘子";}
if (value == BigStar) {return "小星星";}
if (value == smallStar) {return "d大星星";}
if (value == BigSeven) {return "大双七";}
if (value == smallSeven) {return "小双七";}
if (value == BigBar) {return "Bar";}
if (value == smallBar) {return "smalBar";}
if (value == BigLingDang) {return "小铃铛";}
if (value == smallLingDang) {return "大铃铛";}
if (value == LuckNone) {return "通杀";}
if (value == LuckFail) {return "通赔";}

		return "";
	}
    public static int[] Values = { BigApple,smallApple,BigMangGuo,smallMangGuo,BigXiHua,smallXiGua,BigOrange,smallOrange,BigStar,smallStar,BigSeven,smallSeven,BigBar,smallBar,BigLingDang,smallLingDang,LuckNone,LuckFail };
}}