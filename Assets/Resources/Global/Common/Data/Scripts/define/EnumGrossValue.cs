namespace Config{
public class EnumGrossValue {

/// <summary>
///概率基数
/// </summary>
        public const int grossvalue = 1000;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == grossvalue) {return "概率基数";}

		return "";
	}
    public static int[] Values = { grossvalue };
}}