namespace Config{
public class EnumArmyRaceType {

/// <summary>
///无意义
/// </summary>
        public const int Type0 = 0;

/// <summary>
///船
/// </summary>
        public const int Type1 = 1;

/// <summary>
///人形
/// </summary>
        public const int Type2 = 2;

/// <summary>
///野兽
/// </summary>
        public const int Type3 = 3;

/// <summary>
///水生
/// </summary>
        public const int Type4 = 4;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == Type0) {return "无意义";}
if (value == Type1) {return "船";}
if (value == Type2) {return "人形";}
if (value == Type3) {return "野兽";}
if (value == Type4) {return "水生";}

		return "";
	}
    public static int[] Values = { Type0,Type1,Type2,Type3,Type4 };
}}