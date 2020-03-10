/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Room
{
	public partial class UI_RoomFlower : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GGraph m_n210;
		public GImage m_bg;
		public GImage m_table_left;
		public GImage m_table_right;
		public GImage m_n181;
		public GImage m_bg_horn;
		public GImage m_n214;
		public GImage m_n215;
		public GLoader m_btn_horn;
		public UI_btn_back m_btn_back;
		public GImage m_n179;
		public GLoader m_head;
		public GTextField m_text_nickname;
        public GTextField m_text_time;
        public GImage m_n23;
		public GTextField m_text_gold;
		public GLoader m_vip;
		public GGroup m_n25;
		public UI_infoitem m_info0;
		public UI_infoitem m_info1;
		public UI_infoitem m_info2;
		public UI_infoitem m_info3;
		public UI_infoitem m_info4;
		public UI_infoitem m_info5;
		public UI_infoitem m_info6;
		public UI_infoitem m_info7;
		public UI_btn_out m_btn_out;
		public UI_infoBanker m_infoBanker;
		public GLoader m_index0;
		public GLoader m_index1;
		public GLoader m_index2;
		public GLoader m_index3;
		public GTextField m_table_nickName0;
		public GTextField m_table_nickName1;
		public GTextField m_table_nickName2;
		public GTextField m_table_nickName3;
		public GImage m_n156;
		public GImage m_n154;
		public GImage m_n157;
		public GImage m_n155;
		public GLoader m_table_head0;
		public GLoader m_table_head1;
		public GLoader m_table_head2;
		public GLoader m_table_head3;
		public UI_text_selfCoins m_selfCoins0;
		public UI_text_selfCoins m_selfCoins1;
		public UI_text_selfCoins m_selfCoins2;
		public UI_text_selfCoins m_selfCoins3;
		public GTextField m_n90;
		public GTextField m_n94;
		public GTextField m_n96;
		public GTextField m_n98;
		public UI_btn_gold m_btn_gold10;
		public UI_btn_gold m_btn_gold20;
		public UI_btn_gold m_btn_gold50;
		public GGroup m_n89;
		public UI_btn_upbank m_btn_upbank;
		public UI_btn_jackpot m_btn_jackpot;
		public UI_btn_trend m_btn_trend;
		public UI_btn_chat m_btn_chat;
		public UI_btn_fastbuy m_btn_fastbuy;
		public UI_btn_red m_redEnvelope;
		public GImage m_movie_win;
		public GLoader m_btn_lottery;
		public GRichTextField m_txt_lotteryTime;
		public GLoader m_n190;
		public GLoader m_btn_more;
		public GImage m_n207;
		public GTextField m_txt_lotteryNum;
		public GGroup m_lotteryNum;
		public GGroup m_lottery;
		public UI_btn_friend m_btn_friend;
		public UI_Clock m_clock;
		public GLoader m_btn_hornReocrd;
		public GTextField m_text_num;
		public Transition m_t0;
		public Transition m_t_clock;

		public const string URL = "ui://es6hjd4tcg7fqe";

		public static UI_RoomFlower CreateInstance()
		{
			return (UI_RoomFlower)UIPackage.CreateObject("Room","RoomFlower");
		}

		public UI_RoomFlower()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_n210 = (GGraph)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_table_left = (GImage)this.GetChildAt(2);
			m_table_right = (GImage)this.GetChildAt(3);
			m_n181 = (GImage)this.GetChildAt(4);
			m_bg_horn = (GImage)this.GetChildAt(5);
			m_n214 = (GImage)this.GetChildAt(6);
			m_n215 = (GImage)this.GetChildAt(7);
			m_btn_horn = (GLoader)this.GetChildAt(8);
			m_btn_back = (UI_btn_back)this.GetChildAt(9);
			m_n179 = (GImage)this.GetChildAt(10);
			m_head = (GLoader)this.GetChildAt(11);
			m_text_nickname = (GTextField)this.GetChildAt(12);
			m_n23 = (GImage)this.GetChildAt(13);
			m_text_gold = (GTextField)this.GetChildAt(14);
			m_vip = (GLoader)this.GetChildAt(15);
			m_n25 = (GGroup)this.GetChildAt(16);
			m_info0 = (UI_infoitem)this.GetChildAt(17);
			m_info1 = (UI_infoitem)this.GetChildAt(18);
			m_info2 = (UI_infoitem)this.GetChildAt(19);
			m_info3 = (UI_infoitem)this.GetChildAt(20);
			m_info4 = (UI_infoitem)this.GetChildAt(21);
			m_info5 = (UI_infoitem)this.GetChildAt(22);
			m_info6 = (UI_infoitem)this.GetChildAt(23);
			m_info7 = (UI_infoitem)this.GetChildAt(24);
			m_btn_out = (UI_btn_out)this.GetChildAt(25);
			m_infoBanker = (UI_infoBanker)this.GetChildAt(26);
			m_index0 = (GLoader)this.GetChildAt(27);
			m_index1 = (GLoader)this.GetChildAt(28);
			m_index2 = (GLoader)this.GetChildAt(29);
			m_index3 = (GLoader)this.GetChildAt(30);
			m_table_nickName0 = (GTextField)this.GetChildAt(31);
			m_table_nickName1 = (GTextField)this.GetChildAt(32);
			m_table_nickName2 = (GTextField)this.GetChildAt(33);
			m_table_nickName3 = (GTextField)this.GetChildAt(34);
			m_n156 = (GImage)this.GetChildAt(35);
			m_n154 = (GImage)this.GetChildAt(36);
			m_n157 = (GImage)this.GetChildAt(37);
			m_n155 = (GImage)this.GetChildAt(38);
			m_table_head0 = (GLoader)this.GetChildAt(39);
			m_table_head1 = (GLoader)this.GetChildAt(40);
			m_table_head2 = (GLoader)this.GetChildAt(41);
			m_table_head3 = (GLoader)this.GetChildAt(42);
			m_selfCoins0 = (UI_text_selfCoins)this.GetChildAt(43);
			m_selfCoins1 = (UI_text_selfCoins)this.GetChildAt(44);
			m_selfCoins2 = (UI_text_selfCoins)this.GetChildAt(45);
			m_selfCoins3 = (UI_text_selfCoins)this.GetChildAt(46);
			m_n90 = (GTextField)this.GetChildAt(47);
			m_n94 = (GTextField)this.GetChildAt(48);
			m_n96 = (GTextField)this.GetChildAt(49);
			m_n98 = (GTextField)this.GetChildAt(50);
			m_btn_gold10 = (UI_btn_gold)this.GetChildAt(51);
			m_btn_gold20 = (UI_btn_gold)this.GetChildAt(52);
			m_btn_gold50 = (UI_btn_gold)this.GetChildAt(53);
			m_n89 = (GGroup)this.GetChildAt(54);
			m_btn_upbank = (UI_btn_upbank)this.GetChildAt(55);
			m_btn_jackpot = (UI_btn_jackpot)this.GetChildAt(56);
			m_btn_trend = (UI_btn_trend)this.GetChildAt(57);
			m_btn_chat = (UI_btn_chat)this.GetChildAt(58);
			m_btn_fastbuy = (UI_btn_fastbuy)this.GetChildAt(59);
			m_redEnvelope = (UI_btn_red)this.GetChildAt(60);
			m_movie_win = (GImage)this.GetChildAt(61);
			m_btn_lottery = (GLoader)this.GetChildAt(62);
			m_txt_lotteryTime = (GRichTextField)this.GetChildAt(63);
			m_n190 = (GLoader)this.GetChildAt(64);
			m_btn_more = (GLoader)this.GetChildAt(65);
			m_n207 = (GImage)this.GetChildAt(66);
			m_txt_lotteryNum = (GTextField)this.GetChildAt(67);
			m_lotteryNum = (GGroup)this.GetChildAt(68);
			m_lottery = (GGroup)this.GetChildAt(69);
			m_btn_friend = (UI_btn_friend)this.GetChildAt(70);
			m_clock = (UI_Clock)this.GetChildAt(71);
			m_btn_hornReocrd = (GLoader)this.GetChildAt(72);
			m_text_num = (GTextField)this.GetChildAt(73);
            m_text_time = (GTextField)this.GetChildAt(74);
            m_t0 = this.GetTransitionAt(0);
			m_t_clock = this.GetTransitionAt(1);
		}
	}
}