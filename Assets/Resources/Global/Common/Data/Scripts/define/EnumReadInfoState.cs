namespace Config{
public class EnumReadInfoState {

/// <summary>
///未读
/// </summary>
        public const int 未读 = 0;

/// <summary>
///已读
/// </summary>
        public const int 已读 = 1;

/// <summary>
///删除
/// </summary>
        public const int 删除 = 2;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == 未读) {return "未读";}
if (value == 已读) {return "已读";}
if (value == 删除) {return "删除";}

		return "";
	}
    public static int[] Values = { 未读,已读,删除 };
}}