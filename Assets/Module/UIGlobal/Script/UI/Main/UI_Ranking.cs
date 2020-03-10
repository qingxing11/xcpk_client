/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Ranking : GComponent
	{
		public Controller m_c1;
		public GImage m_n18;
		public GImage m_bg1;
		public GImage m_bg2;
		public UI_btn_rank1 m_btn_wealth;
		public GTextField m_n10;
		public GTextField m_n11;
		public GTextField m_n12;
		public GTextField m_n13;
		public GList m_rankList;
		public GImage m_n15;
		public UI_btn_close_g2 m_btn_close;
		public GImage m_n22;
		public UI_btn_yingJin m_btn_win;
		public UI_btn_chakanjiangli m_btn_chakan;
		public UI_btn_rank3 m_btn_pay;

		public const string URL = "ui://du637vw110z9t4m";

		public static UI_Ranking CreateInstance()
		{
			return (UI_Ranking)UIPackage.CreateObject("Main","Ranking");
		}

		public UI_Ranking()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n18 = (GImage)this.GetChildAt(0);
			m_bg1 = (GImage)this.GetChildAt(1);
			m_bg2 = (GImage)this.GetChildAt(2);
			m_btn_wealth = (UI_btn_rank1)this.GetChildAt(3);
			m_n10 = (GTextField)this.GetChildAt(4);
			m_n11 = (GTextField)this.GetChildAt(5);
			m_n12 = (GTextField)this.GetChildAt(6);
			m_n13 = (GTextField)this.GetChildAt(7);
			m_rankList = (GList)this.GetChildAt(8);
			m_n15 = (GImage)this.GetChildAt(9);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(10);
			m_n22 = (GImage)this.GetChildAt(11);
			m_btn_win = (UI_btn_yingJin)this.GetChildAt(12);
			m_btn_chakan = (UI_btn_chakanjiangli)this.GetChildAt(13);
			m_btn_pay = (UI_btn_rank3)this.GetChildAt(14);
		}
	}
}