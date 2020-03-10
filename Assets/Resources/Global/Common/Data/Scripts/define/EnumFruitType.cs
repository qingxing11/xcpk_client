namespace Config{
public class EnumFruitType {

/// <summary>
///苹果
/// </summary>
        public const int Apple = 1;

/// <summary>
///橘子
/// </summary>
        public const int Orange = 2;

/// <summary>
///星星
/// </summary>
        public const int Star = 3;

/// <summary>
///芒果
/// </summary>
        public const int MangGuo = 4;

/// <summary>
///西瓜
/// </summary>
        public const int XiGua = 5;

/// <summary>
///铃铛
/// </summary>
        public const int LingDang = 6;

/// <summary>
///双七
/// </summary>
        public const int DoubleSeven = 7;

/// <summary>
///Bar
/// </summary>
        public const int Bar = 8;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == Apple) {return "苹果";}
if (value == Orange) {return "橘子";}
if (value == Star) {return "星星";}
if (value == MangGuo) {return "芒果";}
if (value == XiGua) {return "西瓜";}
if (value == LingDang) {return "铃铛";}
if (value == DoubleSeven) {return "双七";}
if (value == Bar) {return "Bar";}

		return "";
	}
    public static int[] Values = { Apple,Orange,Star,MangGuo,XiGua,LingDang,DoubleSeven,Bar };
}}