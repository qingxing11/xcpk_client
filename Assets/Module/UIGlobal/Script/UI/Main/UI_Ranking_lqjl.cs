/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Ranking_lqjl : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_bg1;
		public GImage m_bg2;
		public GTextField m_n7;
		public GTextField m_n8;
		public GTextField m_n9;
		public GTextField m_n10;
		public GList m_rankList;
		public UI_btn_close_g2 m_btn_close;
		public GImage m_n19;
		public GTextField m_text_paiming;
		public UI_btn_lingqujiangli m_btn_lingqu;
		public GImage m_n24;
		public GImage m_n25;

		public const string URL = "ui://du637vw1ttywy0z";

		public static UI_Ranking_lqjl CreateInstance()
		{
			return (UI_Ranking_lqjl)UIPackage.CreateObject("Main","Ranking_lqjl");
		}

		public UI_Ranking_lqjl()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_bg1 = (GImage)this.GetChildAt(0);
			m_bg2 = (GImage)this.GetChildAt(1);
			m_n7 = (GTextField)this.GetChildAt(2);
			m_n8 = (GTextField)this.GetChildAt(3);
			m_n9 = (GTextField)this.GetChildAt(4);
			m_n10 = (GTextField)this.GetChildAt(5);
			m_rankList = (GList)this.GetChildAt(6);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(7);
			m_n19 = (GImage)this.GetChildAt(8);
			m_text_paiming = (GTextField)this.GetChildAt(9);
			m_btn_lingqu = (UI_btn_lingqujiangli)this.GetChildAt(10);
			m_n24 = (GImage)this.GetChildAt(11);
			m_n25 = (GImage)this.GetChildAt(12);
		}
	}
}