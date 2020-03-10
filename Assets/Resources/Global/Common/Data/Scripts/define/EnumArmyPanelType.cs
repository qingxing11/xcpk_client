namespace Config{
public class EnumArmyPanelType {

/// <summary>
///军营
/// </summary>
        public const int BarrackPanel = 1;

/// <summary>
///酒馆
/// </summary>
        public const int PubPanel = 2;

/// <summary>
///船坞
/// </summary>
        public const int ShipPanel = 3;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == BarrackPanel) {return "军营";}
if (value == PubPanel) {return "酒馆";}
if (value == ShipPanel) {return "船坞";}

		return "";
	}
    public static int[] Values = { BarrackPanel,PubPanel,ShipPanel };
}}