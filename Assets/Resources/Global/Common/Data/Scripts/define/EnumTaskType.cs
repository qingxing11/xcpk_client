namespace Config{
public class EnumTaskType {

/// <summary>
///日常任务
/// </summary>
        public const int DayTask = 1;

/// <summary>
///个人任务
/// </summary>
        public const int PersonSelfTask = 2;

/// <summary>
///系统任务
/// </summary>
        public const int SystemTask = 3;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == DayTask) {return "日常任务";}
if (value == PersonSelfTask) {return "个人任务";}
if (value == SystemTask) {return "系统任务";}

		return "";
	}
    public static int[] Values = { DayTask,PersonSelfTask,SystemTask };
}}