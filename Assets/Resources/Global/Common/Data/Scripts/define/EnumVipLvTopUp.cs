namespace Config{
public class EnumVipLvTopUp {

/// <summary>
///vip等级0解锁条件
/// </summary>
        public const int zero = 0;

/// <summary>
///vip等级1解锁条件
/// </summary>
        public const int one = 15;

/// <summary>
///vip等级2解锁条件
/// </summary>
        public const int two = 58;

/// <summary>
///vip等级3解锁条件
/// </summary>
        public const int three = 188;

/// <summary>
///vip等级4解锁条件
/// </summary>
        public const int four = 888;

/// <summary>
///vip等级5解锁条件
/// </summary>
        public const int five = 1888;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == zero) {return "vip等级0解锁条件";}
if (value == one) {return "vip等级1解锁条件";}
if (value == two) {return "vip等级2解锁条件";}
if (value == three) {return "vip等级3解锁条件";}
if (value == four) {return "vip等级4解锁条件";}
if (value == five) {return "vip等级5解锁条件";}

		return "";
	}
    public static int[] Values = { zero,one,two,three,four,five };
}}