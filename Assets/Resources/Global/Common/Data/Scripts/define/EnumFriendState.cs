namespace Config{
public class EnumFriendState {

/// <summary>
///无数据
/// </summary>
        public const int 无 = 0;

/// <summary>
///请求添加好友
/// </summary>
        public const int 未处理 = 1;

/// <summary>
///拒绝添加
/// </summary>
        public const int 拒绝 = 2;

/// <summary>
///同意添加
/// </summary>
        public const int 同意 = 3;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == 无) {return "无数据";}
if (value == 未处理) {return "请求添加好友";}
if (value == 拒绝) {return "拒绝添加";}
if (value == 同意) {return "同意添加";}

		return "";
	}
    public static int[] Values = { 无,未处理,拒绝,同意 };
}}