namespace Config{
public class EnumArmyState {

/// <summary>
///正常
/// </summary>
        public const int NORMAL = 6;

/// <summary>
///战斗中
/// </summary>
        public const int FIGHT = 2;

/// <summary>
///逃跑
/// </summary>
        public const int FREE = 3;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == NORMAL) {return "正常";}
if (value == FIGHT) {return "战斗中";}
if (value == FREE) {return "逃跑";}

		return "";
	}
    public static int[] Values = { NORMAL,FIGHT,FREE };
}}