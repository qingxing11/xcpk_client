/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace Lottery
{
	public class LotteryBinder
	{
		public static void BindAll()
		{
			UIObjectFactory.SetPackageItemExtension(UI_coin.URL, typeof(UI_coin));
			UIObjectFactory.SetPackageItemExtension(UI_GglWin.URL, typeof(UI_GglWin));
			UIObjectFactory.SetPackageItemExtension(UI_LotteryWin.URL, typeof(UI_LotteryWin));
            UIObjectFactory.SetPackageItemExtension(UI_LotteryLose.URL, typeof(UI_LotteryLose));
            UIObjectFactory.SetPackageItemExtension(UI_LotteryCom.URL, typeof(UI_LotteryCom));
			UIObjectFactory.SetPackageItemExtension(UI_btn_close.URL, typeof(UI_btn_close));
			UIObjectFactory.SetPackageItemExtension(UI_btn_duigou.URL, typeof(UI_btn_duigou));
			UIObjectFactory.SetPackageItemExtension(UI_btn_zdtz.URL, typeof(UI_btn_zdtz));
			UIObjectFactory.SetPackageItemExtension(UI_btn_select.URL, typeof(UI_btn_select));
			UIObjectFactory.SetPackageItemExtension(UI_btn_record.URL, typeof(UI_btn_record));
		}
	}
}