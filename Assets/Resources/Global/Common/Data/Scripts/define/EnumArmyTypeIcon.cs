namespace Config{
public class EnumArmyTypeIcon {

/// <summary>
///开拓者
/// </summary>
        public const string PIONEER = "GJC/World/SpritePack/ArmyList/kaituozhe";

/// <summary>
///商人
/// </summary>
        public const string MERCHANT = "GJC/World/SpritePack/ArmyList/Shangren";

/// <summary>
///建造者
/// </summary>
        public const string BUILDER = "GJC/World/SpritePack/ArmyList/jianzaozhe";

/// <summary>
///军事单位(军队)
/// </summary>
        public const string ARMY = "GJC/World/SpritePack/ArmyList/junshidanwei";

/// <summary>
///舰船
/// </summary>
        public const string SHIP = "GJC/World/SpritePack/ArmyList/jianchuan";

/// <summary>
///军团
/// </summary>
        public const string ARMYTUAN = "GJC/World/SpritePack/ArmyList/juntuan";

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(string value) {
		if(value.Equals(PIONEER)) {return "开拓者";}
if(value.Equals(MERCHANT)) {return "商人";}
if(value.Equals(BUILDER)) {return "建造者";}
if(value.Equals(ARMY)) {return "军事单位(军队)";}
if(value.Equals(SHIP)) {return "舰船";}
if(value.Equals(ARMYTUAN)) {return "军团";}

		return "";
	}
    public static string[] Values = { PIONEER,MERCHANT,BUILDER,ARMY,SHIP,ARMYTUAN };
}}