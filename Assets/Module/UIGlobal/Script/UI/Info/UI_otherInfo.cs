/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_otherInfo : GComponent
	{
		public Controller m_c1;
		public GImage m_n50;
		public GImage m_n1;
		public GImage m_n17;
		public GImage m_n20;
		public GLoader m_head;
		public GTextField m_text_nickname;
		public GTextField m_n4;
		public GTextField m_n5;
		public GImage m_n6;
		public GImage m_n7;
		public UI_btn_close m_btn_close;
		public GTextField m_text_gold;
		public GTextField m_text_masonry;
		public GTextField m_text_shengNum;
		public GTextField m_text_fuNum;
		public GTextField m_n13;
		public GTextField m_n14;
		public GImage m_n15;
		public GImage m_n16;
		public GTextField m_text_sign;
		public GTextField m_n19;
		public GTextField m_n21;
		public GTextField m_n26;
		public GTextField m_n22;
		public GTextField m_n23;
		public GTextField m_n24;
		public GTextField m_n25;
		public UI_btn_flower m_btn_flower;
		public UI_btn_cheers m_btn_cheers;
		public UI_btn_kiss m_btn_kiss;
		public UI_btn_egg m_btn_egg;
		public UI_btn_shoe m_btn_shoe;
		public UI_btn_bomb m_btn_bomb;
		public GTextField m_text_id;
		public GTextField m_text_level;
		public GLoader m_vip;

		public const string URL = "ui://5wbi0yeupd2ctbw";

		public static UI_otherInfo CreateInstance()
		{
			return (UI_otherInfo)UIPackage.CreateObject("Info","otherInfo");
		}

		public UI_otherInfo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n50 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n17 = (GImage)this.GetChildAt(2);
			m_n20 = (GImage)this.GetChildAt(3);
			m_head = (GLoader)this.GetChildAt(4);
			m_text_nickname = (GTextField)this.GetChildAt(5);
			m_n4 = (GTextField)this.GetChildAt(6);
			m_n5 = (GTextField)this.GetChildAt(7);
			m_n6 = (GImage)this.GetChildAt(8);
			m_n7 = (GImage)this.GetChildAt(9);
			m_btn_close = (UI_btn_close)this.GetChildAt(10);
			m_text_gold = (GTextField)this.GetChildAt(11);
			m_text_masonry = (GTextField)this.GetChildAt(12);
			m_text_shengNum = (GTextField)this.GetChildAt(13);
			m_text_fuNum = (GTextField)this.GetChildAt(14);
			m_n13 = (GTextField)this.GetChildAt(15);
			m_n14 = (GTextField)this.GetChildAt(16);
			m_n15 = (GImage)this.GetChildAt(17);
			m_n16 = (GImage)this.GetChildAt(18);
			m_text_sign = (GTextField)this.GetChildAt(19);
			m_n19 = (GTextField)this.GetChildAt(20);
			m_n21 = (GTextField)this.GetChildAt(21);
			m_n26 = (GTextField)this.GetChildAt(22);
			m_n22 = (GTextField)this.GetChildAt(23);
			m_n23 = (GTextField)this.GetChildAt(24);
			m_n24 = (GTextField)this.GetChildAt(25);
			m_n25 = (GTextField)this.GetChildAt(26);
			m_btn_flower = (UI_btn_flower)this.GetChildAt(27);
			m_btn_cheers = (UI_btn_cheers)this.GetChildAt(28);
			m_btn_kiss = (UI_btn_kiss)this.GetChildAt(29);
			m_btn_egg = (UI_btn_egg)this.GetChildAt(30);
			m_btn_shoe = (UI_btn_shoe)this.GetChildAt(31);
			m_btn_bomb = (UI_btn_bomb)this.GetChildAt(32);
			m_text_id = (GTextField)this.GetChildAt(33);
			m_text_level = (GTextField)this.GetChildAt(34);
			m_vip = (GLoader)this.GetChildAt(35);
		}
	}
}