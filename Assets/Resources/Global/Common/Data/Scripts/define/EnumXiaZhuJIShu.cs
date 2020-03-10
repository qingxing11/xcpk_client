namespace Config{
public class EnumXiaZhuJIShu {

/// <summary>
///下注基数
/// </summary>
        public const int number = 20000;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == number) {return "下注基数";}

		return "";
	}
    public static int[] Values = { number };
}}