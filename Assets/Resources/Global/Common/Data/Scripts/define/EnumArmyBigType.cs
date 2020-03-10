namespace Config{
public class EnumArmyBigType {

/// <summary>
///无意义
/// </summary>
        public const int NULL = 0;

/// <summary>
///海上单位
/// </summary>
        public const int Ship = 1;

/// <summary>
///军事单位
/// </summary>
        public const int Military  = 2;

/// <summary>
///市民单位
/// </summary>
        public const int Citizen  = 3;

/// <summary>
///野怪
/// </summary>
        public const int WILDMONSTER = 4;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == NULL) {return "无意义";}
if (value == Ship) {return "海上单位";}
if (value == Military ) {return "军事单位";}
if (value == Citizen ) {return "市民单位";}
if (value == WILDMONSTER) {return "野怪";}

		return "";
	}
    public static int[] Values = { NULL,Ship,Military ,Citizen ,WILDMONSTER };
}}