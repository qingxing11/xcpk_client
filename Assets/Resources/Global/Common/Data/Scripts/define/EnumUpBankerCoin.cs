namespace Config{
public class EnumUpBankerCoin {

/// <summary>
///上庄条件
/// </summary>
        public const int Up = 50000000;

/// <summary>
///上庄条件
/// </summary>
        public const int Down = 20000000;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == Up) {return "上庄条件";}
if (value == Down) {return "上庄条件";}

		return "";
	}
    public static int[] Values = { Up,Down };
}}