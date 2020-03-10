namespace Config{
public class EnumArmySixProperty {

/// <summary>
///防御力
/// </summary>
        public const int DEFENSIVEPOWER = 1;

/// <summary>
///攻击力
/// </summary>
        public const int AGGRESSIVITY = 2;

/// <summary>
///破坏值
/// </summary>
        public const int DAMAGEVALUE = 3;

/// <summary>
///移动速度
/// </summary>
        public const int ARMYSPEED = 4;

/// <summary>
///军队士气
/// </summary>
        public const int ARMYMORALE = 5;

/// <summary>
///军队熟练度
/// </summary>
        public const int ARMYPROFICIENCY = 6;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == DEFENSIVEPOWER) {return "防御力";}
if (value == AGGRESSIVITY) {return "攻击力";}
if (value == DAMAGEVALUE) {return "破坏值";}
if (value == ARMYSPEED) {return "移动速度";}
if (value == ARMYMORALE) {return "军队士气";}
if (value == ARMYPROFICIENCY) {return "军队熟练度";}

		return "";
	}
    public static int[] Values = { DEFENSIVEPOWER,AGGRESSIVITY,DAMAGEVALUE,ARMYSPEED,ARMYMORALE,ARMYPROFICIENCY };
}}