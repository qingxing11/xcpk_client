namespace Config{
public class EnumSpecialReward {

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dasixi
/// </summary>
        public const int BigFourXi = 1;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dasanyuan
/// </summary>
        public const int BigThreeYuan = 2;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dandian
/// </summary>
        public const int SinglePointSmple = 3;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_xiaosanyuan
/// </summary>
        public const int SmallThreeYuan = 4;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_kaihuoche
/// </summary>
        public const int OnTrain = 5;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dandian
/// </summary>
        public const int SinglePointSpecial = 7;

/// <summary>
///YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_jiulian
/// </summary>
        public const int TheNineTreasureLamp = 6;

/// <summary>
///开火车1
/// </summary>
        public const int OnTrain1 = 1;

/// <summary>
///开火车2
/// </summary>
        public const int OnTrain2 = 2;

/// <summary>
///开火车3
/// </summary>
        public const int OnTrain3 = 3;

/**
	 * 获得常量的显示名称
	 * 
	 * @param value
	 * @return
	 */
	public static string GetTitle(int value) {
		if (value == BigFourXi) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dasixi";}
if (value == BigThreeYuan) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dasanyuan";}
if (value == SinglePointSmple) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dandian";}
if (value == SmallThreeYuan) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_xiaosanyuan";}
if (value == OnTrain) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_kaihuoche";}
if (value == SinglePointSpecial) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_dandian";}
if (value == TheNineTreasureLamp) {return "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_jiulian";}
if (value == OnTrain1) {return "开火车1";}
if (value == OnTrain2) {return "开火车2";}
if (value == OnTrain3) {return "开火车3";}

		return "";
	}
    public static int[] Values = { BigFourXi,BigThreeYuan,SinglePointSmple,SmallThreeYuan,OnTrain,SinglePointSpecial,TheNineTreasureLamp,OnTrain1,OnTrain2,OnTrain3 };
}}