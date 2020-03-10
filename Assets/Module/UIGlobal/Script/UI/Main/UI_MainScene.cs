/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_MainScene : GComponent
	{
		public Controller m_c1;
		public Controller m_taskCtrl;
		public GImage m_bg;
		public GImage m_bg_table;
		public GImage m_title_bg;
		public GImage m_n4;
		public GImage m_n17;
		public GTextField m_text_nickname;
		public GImage m_n13;
		public GLoader m_head;
		public GImage m_n28;
		public GImage m_n29;
		public GImage m_n30;
		public GTextField m_text_level;
		public GImage m_n34;
		public UI_btn_buy m_btn_addgold;
		public UI_btn_buy m_btn_addmasonry;
		public GTextField m_text_coins;
		public GTextField m_text_masonry;
		public GImage m_n47;
		public GImage m_n49;
		public GImage m_n6;
		public UI_btn_freemoney m_btn_freeMoney;
		public UI_btn_tree m_btn_tree;
		public UI_btn_safebox m_btn_safebox;
		public UI_btn_task m_btn_task;
		public GImage m_1;
		public GTextField m_taskNum;
		public UI_btn_rank m_btn_rank;
		public UI_btn_more m_btn_more;
		public UI_btn_shop m_btn_shop;
		public UI_btn_room4 m_btn_classic;
		public UI_btn_room3 m_btn_tenThousand;
		public UI_btn_room2 m_btn_allkill;
		public UI_btn_Fruit m_btn_fruit;
		public UI_btn_letter m_btn_mail;
		public UI_btn_old m_btn_select;
		public GImage m_addfriends;
		public UI_btn_friend m_btn_friend;
		public GGroup m_friend;
		public GGroup m_n63;
		public GLoader m_vip_load;
		public GImage m_bg_horn;
		public GLoader m_btn_horn;
		public GLoader m_btn_hornReocrd;
		public GGroup m_horn;

		public const string URL = "ui://du637vw1fdzr0";

		public static UI_MainScene CreateInstance()
		{
			return (UI_MainScene)UIPackage.CreateObject("Main","MainScene");
		}

		public UI_MainScene()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_taskCtrl = this.GetControllerAt(1);
			m_bg = (GImage)this.GetChildAt(0);
			m_bg_table = (GImage)this.GetChildAt(1);
			m_title_bg = (GImage)this.GetChildAt(2);
			m_n4 = (GImage)this.GetChildAt(3);
			m_n17 = (GImage)this.GetChildAt(4);
			m_text_nickname = (GTextField)this.GetChildAt(5);
			m_n13 = (GImage)this.GetChildAt(6);
			m_head = (GLoader)this.GetChildAt(7);
			m_n28 = (GImage)this.GetChildAt(8);
			m_n29 = (GImage)this.GetChildAt(9);
			m_n30 = (GImage)this.GetChildAt(10);
			m_text_level = (GTextField)this.GetChildAt(11);
			m_n34 = (GImage)this.GetChildAt(12);
			m_btn_addgold = (UI_btn_buy)this.GetChildAt(13);
			m_btn_addmasonry = (UI_btn_buy)this.GetChildAt(14);
			m_text_coins = (GTextField)this.GetChildAt(15);
			m_text_masonry = (GTextField)this.GetChildAt(16);
			m_n47 = (GImage)this.GetChildAt(17);
			m_n49 = (GImage)this.GetChildAt(18);
			m_n6 = (GImage)this.GetChildAt(19);
			m_btn_freeMoney = (UI_btn_freemoney)this.GetChildAt(20);
			m_btn_tree = (UI_btn_tree)this.GetChildAt(21);
			m_btn_safebox = (UI_btn_safebox)this.GetChildAt(22);
			m_btn_task = (UI_btn_task)this.GetChildAt(23);
			m_1 = (GImage)this.GetChildAt(24);
			m_taskNum = (GTextField)this.GetChildAt(25);
			m_btn_rank = (UI_btn_rank)this.GetChildAt(26);
			m_btn_more = (UI_btn_more)this.GetChildAt(27);
			m_btn_shop = (UI_btn_shop)this.GetChildAt(28);
			m_btn_classic = (UI_btn_room4)this.GetChildAt(29);
			m_btn_tenThousand = (UI_btn_room3)this.GetChildAt(30);
			m_btn_allkill = (UI_btn_room2)this.GetChildAt(31);
			m_btn_fruit = (UI_btn_Fruit)this.GetChildAt(32);
			m_btn_mail = (UI_btn_letter)this.GetChildAt(33);
			m_btn_select = (UI_btn_old)this.GetChildAt(34);
			m_addfriends = (GImage)this.GetChildAt(35);
			m_btn_friend = (UI_btn_friend)this.GetChildAt(36);
			m_friend = (GGroup)this.GetChildAt(37);
			m_n63 = (GGroup)this.GetChildAt(38);
			m_vip_load = (GLoader)this.GetChildAt(39);
			m_bg_horn = (GImage)this.GetChildAt(40);
			m_btn_horn = (GLoader)this.GetChildAt(41);
			m_btn_hornReocrd = (GLoader)this.GetChildAt(42);
			m_horn = (GGroup)this.GetChildAt(43);
		}
	}
}