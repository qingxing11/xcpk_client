namespace Config{
public class EnumRole {

/// <summary>
///男
/// </summary>
        public const int man = 0;

/// <summary>
///女
/// </summary>
        public const int woman = 1;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == man) {return "男";}
if (value == woman) {return "女";}

		return "";
	}
    public static int[] Values = { man,woman };
}}