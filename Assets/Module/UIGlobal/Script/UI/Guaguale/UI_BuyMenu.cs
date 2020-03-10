/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_BuyMenu : GComponent
	{
		public Controller m_c1;
		public GGraph m_n22;
		public GImage m_n2;
		public GImage m_n3;
		public GImage m_n4;
		public GImage m_n5;
		public GImage m_n1;
		public UI_btn_sub m_btn_sub;
		public UI_btn_add m_btn_add;
		public UI_btn_bugG m_btn_buy;
		public UI_btn_cancelG m_btn_cancel;
		public GTextField m_txt_money;
		public GTextField m_num;
		public GGroup m_one;
		public GList m_list_history;
		public UI_btn_nextbuy m_btn_NextBuy;
		public GImage m_n20;
		public GTextField m_txtAllReward;
		public GGroup m_Two;
		public UI_btn_close m_btn_close;

		public const string URL = "ui://rjmn7jeuzq2w6e";

		public static UI_BuyMenu CreateInstance()
		{
			return (UI_BuyMenu)UIPackage.CreateObject("Guaguale","BuyMenu");
		}

		public UI_BuyMenu()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n22 = (GGraph)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n3 = (GImage)this.GetChildAt(2);
			m_n4 = (GImage)this.GetChildAt(3);
			m_n5 = (GImage)this.GetChildAt(4);
			m_n1 = (GImage)this.GetChildAt(5);
			m_btn_sub = (UI_btn_sub)this.GetChildAt(6);
			m_btn_add = (UI_btn_add)this.GetChildAt(7);
			m_btn_buy = (UI_btn_bugG)this.GetChildAt(8);
			m_btn_cancel = (UI_btn_cancelG)this.GetChildAt(9);
			m_txt_money = (GTextField)this.GetChildAt(10);
			m_num = (GTextField)this.GetChildAt(11);
			m_one = (GGroup)this.GetChildAt(12);
			m_list_history = (GList)this.GetChildAt(13);
			m_btn_NextBuy = (UI_btn_nextbuy)this.GetChildAt(14);
			m_n20 = (GImage)this.GetChildAt(15);
			m_txtAllReward = (GTextField)this.GetChildAt(16);
			m_Two = (GGroup)this.GetChildAt(17);
			m_btn_close = (UI_btn_close)this.GetChildAt(18);
		}
	}
}