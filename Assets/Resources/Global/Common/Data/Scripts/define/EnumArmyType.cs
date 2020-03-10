namespace Config{
public class EnumArmyType {

/// <summary>
///无意义
/// </summary>
        public const int NULL = 0;

/// <summary>
///船
/// </summary>
        public const int SHIP = 1;

/// <summary>
///步兵
/// </summary>
        public const int FOOTARMY = 2;

/// <summary>
///骑兵
/// </summary>
        public const int SOWAR = 3;

/// <summary>
///弓兵
/// </summary>
        public const int SAPPER = 4;

/// <summary>
///兵器
/// </summary>
        public const int WEAPONE = 5;

/// <summary>
///开拓者
/// </summary>
        public const int PIONEER = 6;

/// <summary>
///商人
/// </summary>
        public const int MERCHANT = 7;

/// <summary>
///建造者
/// </summary>
        public const int BUILDER = 8;

/// <summary>
///陆地boss
/// </summary>
        public const int BOSS = 9;

/// <summary>
///中立怪
/// </summary>
        public const int NEUTRAL = 10;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == NULL) {return "无意义";}
if (value == SHIP) {return "船";}
if (value == FOOTARMY) {return "步兵";}
if (value == SOWAR) {return "骑兵";}
if (value == SAPPER) {return "弓兵";}
if (value == WEAPONE) {return "兵器";}
if (value == PIONEER) {return "开拓者";}
if (value == MERCHANT) {return "商人";}
if (value == BUILDER) {return "建造者";}
if (value == BOSS) {return "陆地boss";}
if (value == NEUTRAL) {return "中立怪";}

		return "";
	}
    public static int[] Values = { NULL,SHIP,FOOTARMY,SOWAR,SAPPER,WEAPONE,PIONEER,MERCHANT,BUILDER,BOSS,NEUTRAL };
}}