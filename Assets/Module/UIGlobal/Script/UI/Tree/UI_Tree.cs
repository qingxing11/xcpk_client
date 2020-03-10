/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Tree
{
	public partial class UI_Tree : GComponent
	{
		public GGraph m_n11;
		public GImage m_n0;
		public GImage m_n31;
		public GImage m_n20;
		public GImage m_n30;
		public GImage m_n45;
		public UI_btn_treeget m_btn_ok;
		public GImage m_n46;
		public GImage m_n36;
		public UI_btn_close m_btn_close;
		public GTextField m_txt_8;
		public GTextField m_txt_1000;
		public GTextField m_txt_20;
		public GTextField m_txt_100;
		public GTextField m_txt_money;
		public GTextField m_txt_time;
		public GTextField m_txt_coin;
		public GTextField m_txt_lv;
		public GImage m_n35;
		public GImage m_n37;
		public GTextField m_txt_20_1;
		public GTextField m_txt_20_2;
		public GTextField m_txt_20_3;
		public GTextField m_txt_20_4;
		public GTextField m_txt_20_5;
		public GImage m_n47;
		public GImage m_n48;
		public GTextField m_txt_coin_pre;
		public GTextField m_txt_hour;

		public const string URL = "ui://erft97svv6d6u";

		public static UI_Tree CreateInstance()
		{
			return (UI_Tree)UIPackage.CreateObject("Tree","Tree");
		}

		public UI_Tree()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n11 = (GGraph)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_n31 = (GImage)this.GetChildAt(2);
			m_n20 = (GImage)this.GetChildAt(3);
			m_n30 = (GImage)this.GetChildAt(4);
			m_n45 = (GImage)this.GetChildAt(5);
			m_btn_ok = (UI_btn_treeget)this.GetChildAt(6);
			m_n46 = (GImage)this.GetChildAt(7);
			m_n36 = (GImage)this.GetChildAt(8);
			m_btn_close = (UI_btn_close)this.GetChildAt(9);
			m_txt_8 = (GTextField)this.GetChildAt(10);
			m_txt_1000 = (GTextField)this.GetChildAt(11);
			m_txt_20 = (GTextField)this.GetChildAt(12);
			m_txt_100 = (GTextField)this.GetChildAt(13);
			m_txt_money = (GTextField)this.GetChildAt(14);
			m_txt_time = (GTextField)this.GetChildAt(15);
			m_txt_coin = (GTextField)this.GetChildAt(16);
			m_txt_lv = (GTextField)this.GetChildAt(17);
			m_n35 = (GImage)this.GetChildAt(18);
			m_n37 = (GImage)this.GetChildAt(19);
			m_txt_20_1 = (GTextField)this.GetChildAt(20);
			m_txt_20_2 = (GTextField)this.GetChildAt(21);
			m_txt_20_3 = (GTextField)this.GetChildAt(22);
			m_txt_20_4 = (GTextField)this.GetChildAt(23);
			m_txt_20_5 = (GTextField)this.GetChildAt(24);
			m_n47 = (GImage)this.GetChildAt(25);
			m_n48 = (GImage)this.GetChildAt(26);
			m_txt_coin_pre = (GTextField)this.GetChildAt(27);
			m_txt_hour = (GTextField)this.GetChildAt(28);
		}
	}
}