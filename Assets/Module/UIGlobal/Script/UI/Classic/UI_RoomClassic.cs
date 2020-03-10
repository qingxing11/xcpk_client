/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_RoomClassic : GComponent
	{
		public Controller m_c_raiseBet;
		public Controller m_c1;
		public Controller m_btn_luckBox;
		public GImage m_bg;
		public GImage m_n342;
		public GImage m_bg_horn;
		public GImage m_n204;
		public GImage m_n289;
		public GImage m_n290;
		public GImage m_n291;
		public GImage m_n292;
		public GImage m_n293;
		public GImage m_n345;
		public GGraph m_n373;
		public GLoader m_btn_horn;
		public UI_btn_back m_btn_back;
		public UI_btn_chat m_btn_chat;
		public UI_btn_fastbuy m_btn_fastbuy;
		public UI_selfInfo m_info0;
		public UI_otherInfo m_info1;
		public UI_otherInfo m_info2;
		public UI_otherInfo m_info4;
		public UI_otherInfo m_info3;
		public GGroup m_info;
		public UI_raisebet0 m_raiseBet;
		public UI_Button1 m_btn_compate;
		public UI_Button1 m_btn_fold;
		public UI_Button1 m_btn_see;
		public UI_Button1 m_btn_raise;
		public UI_Button1 m_btn_allin;
		public UI_Button1 m_btn_call;
		public UI_btn_callall m_btn_callall;
		public GImage m_text_compate;
		public GImage m_text_fold;
		public GImage m_text_see;
		public GImage m_text_raise;
		public GImage m_text_allin;
		public GImage m_text_call;
		public GImage m_n226;
		public GGroup m_btns;
		public UI_cards m_cards0;
		public UI_cards m_cards1;
		public UI_cards m_cards2;
		public UI_cards m_cards3;
		public UI_cards m_cards4;
		public GGroup m_cards;
		public GTextField m_text;
		public GTextField m_text_2;
		public GTextField m_text_3;
		public GTextField m_text_oneBet;
		public GTextField m_text_allBet;
		public GTextField m_text_round;
		public UI_Clock m_clock;
		public GTextField m_text_time;
		public GLoader m_state0;
		public GLoader m_state1;
		public GLoader m_state2;
		public GLoader m_state3;
		public GLoader m_state4;
		public GLoader m_btn_hornReocrd;
		public GImage m_movie_win;
		public GLoader m_btn_lottery;
		public GRichTextField m_txt_lotteryTime;
		public GLoader m_n325;
		public GLoader m_btn_more;
		public GImage m_n327;
		public GTextField m_txt_lotteryNum;
		public GGroup m_lotteryNum;
		public GGroup m_lottery;
		public UI_btn_friend m_btn_friend;
		public GTextField m_text_results0Win;
		public GTextField m_text_results0Loss;
		public GTextField m_text_results1Win;
		public GTextField m_text_results1Loss;
		public GTextField m_text_results2Win;
		public GTextField m_text_results2Loss;
		public GTextField m_text_results3Win;
		public GTextField m_text_results3Loss;
		public GTextField m_text_results4Win;
		public GTextField m_text_results4Loss;
		public GImage m_card_back1;
		public GImage m_card_back2;
		public GImage m_card_back3;
		public GImage m_card_back4;
		public GImage m_card_back5;
		public GImage m_card_back6;
		public GImage m_card_back7;
		public GImage m_card_back8;
		public GImage m_card_back9;
		public UI_state1 m_PlayerAction4;
		public UI_state1 m_PlayerAction3;
		public UI_state2 m_PlayerAction2;
		public UI_state2 m_PlayerAction1;
		public UI_btn_lckBox m_btn_luckyBox;
		public GImage m_ready0;
		public GImage m_ready1;
		public GImage m_ready2;
		public GImage m_ready3;
		public GImage m_ready4;
		public UI_btn_lckBox_stop m_n372;
		public Transition m_t_result;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggxezb3";

		public static UI_RoomClassic CreateInstance()
		{
			return (UI_RoomClassic)UIPackage.CreateObject("Classic","RoomClassic");
		}

		public UI_RoomClassic()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c_raiseBet = this.GetControllerAt(0);
			m_c1 = this.GetControllerAt(1);
			m_btn_luckBox = this.GetControllerAt(2);
			m_bg = (GImage)this.GetChildAt(0);
			m_n342 = (GImage)this.GetChildAt(1);
			m_bg_horn = (GImage)this.GetChildAt(2);
			m_n204 = (GImage)this.GetChildAt(3);
			m_n289 = (GImage)this.GetChildAt(4);
			m_n290 = (GImage)this.GetChildAt(5);
			m_n291 = (GImage)this.GetChildAt(6);
			m_n292 = (GImage)this.GetChildAt(7);
			m_n293 = (GImage)this.GetChildAt(8);
			m_n345 = (GImage)this.GetChildAt(9);
			m_n373 = (GGraph)this.GetChildAt(10);
			m_btn_horn = (GLoader)this.GetChildAt(11);
			m_btn_back = (UI_btn_back)this.GetChildAt(12);
			m_btn_chat = (UI_btn_chat)this.GetChildAt(13);
			m_btn_fastbuy = (UI_btn_fastbuy)this.GetChildAt(14);
			m_info0 = (UI_selfInfo)this.GetChildAt(15);
			m_info1 = (UI_otherInfo)this.GetChildAt(16);
			m_info2 = (UI_otherInfo)this.GetChildAt(17);
			m_info4 = (UI_otherInfo)this.GetChildAt(18);
			m_info3 = (UI_otherInfo)this.GetChildAt(19);
			m_info = (GGroup)this.GetChildAt(20);
			m_raiseBet = (UI_raisebet0)this.GetChildAt(21);
			m_btn_compate = (UI_Button1)this.GetChildAt(22);
			m_btn_fold = (UI_Button1)this.GetChildAt(23);
			m_btn_see = (UI_Button1)this.GetChildAt(24);
			m_btn_raise = (UI_Button1)this.GetChildAt(25);
			m_btn_allin = (UI_Button1)this.GetChildAt(26);
			m_btn_call = (UI_Button1)this.GetChildAt(27);
			m_btn_callall = (UI_btn_callall)this.GetChildAt(28);
			m_text_compate = (GImage)this.GetChildAt(29);
			m_text_fold = (GImage)this.GetChildAt(30);
			m_text_see = (GImage)this.GetChildAt(31);
			m_text_raise = (GImage)this.GetChildAt(32);
			m_text_allin = (GImage)this.GetChildAt(33);
			m_text_call = (GImage)this.GetChildAt(34);
			m_n226 = (GImage)this.GetChildAt(35);
			m_btns = (GGroup)this.GetChildAt(36);
			m_cards0 = (UI_cards)this.GetChildAt(37);
			m_cards1 = (UI_cards)this.GetChildAt(38);
			m_cards2 = (UI_cards)this.GetChildAt(39);
			m_cards3 = (UI_cards)this.GetChildAt(40);
			m_cards4 = (UI_cards)this.GetChildAt(41);
			m_cards = (GGroup)this.GetChildAt(42);
			m_text = (GTextField)this.GetChildAt(43);
			m_text_2 = (GTextField)this.GetChildAt(44);
			m_text_3 = (GTextField)this.GetChildAt(45);
			m_text_oneBet = (GTextField)this.GetChildAt(46);
			m_text_allBet = (GTextField)this.GetChildAt(47);
			m_text_round = (GTextField)this.GetChildAt(48);
			m_clock = (UI_Clock)this.GetChildAt(49);
			m_text_time = (GTextField)this.GetChildAt(50);
			m_state0 = (GLoader)this.GetChildAt(51);
			m_state1 = (GLoader)this.GetChildAt(52);
			m_state2 = (GLoader)this.GetChildAt(53);
			m_state3 = (GLoader)this.GetChildAt(54);
			m_state4 = (GLoader)this.GetChildAt(55);
			m_btn_hornReocrd = (GLoader)this.GetChildAt(56);
			m_movie_win = (GImage)this.GetChildAt(57);
			m_btn_lottery = (GLoader)this.GetChildAt(58);
			m_txt_lotteryTime = (GRichTextField)this.GetChildAt(59);
			m_n325 = (GLoader)this.GetChildAt(60);
			m_btn_more = (GLoader)this.GetChildAt(61);
			m_n327 = (GImage)this.GetChildAt(62);
			m_txt_lotteryNum = (GTextField)this.GetChildAt(63);
			m_lotteryNum = (GGroup)this.GetChildAt(64);
			m_lottery = (GGroup)this.GetChildAt(65);
			m_btn_friend = (UI_btn_friend)this.GetChildAt(66);
			m_text_results0Win = (GTextField)this.GetChildAt(67);
			m_text_results0Loss = (GTextField)this.GetChildAt(68);
			m_text_results1Win = (GTextField)this.GetChildAt(69);
			m_text_results1Loss = (GTextField)this.GetChildAt(70);
			m_text_results2Win = (GTextField)this.GetChildAt(71);
			m_text_results2Loss = (GTextField)this.GetChildAt(72);
			m_text_results3Win = (GTextField)this.GetChildAt(73);
			m_text_results3Loss = (GTextField)this.GetChildAt(74);
			m_text_results4Win = (GTextField)this.GetChildAt(75);
			m_text_results4Loss = (GTextField)this.GetChildAt(76);
			m_card_back1 = (GImage)this.GetChildAt(77);
			m_card_back2 = (GImage)this.GetChildAt(78);
			m_card_back3 = (GImage)this.GetChildAt(79);
			m_card_back4 = (GImage)this.GetChildAt(80);
			m_card_back5 = (GImage)this.GetChildAt(81);
			m_card_back6 = (GImage)this.GetChildAt(82);
			m_card_back7 = (GImage)this.GetChildAt(83);
			m_card_back8 = (GImage)this.GetChildAt(84);
			m_card_back9 = (GImage)this.GetChildAt(85);
			m_PlayerAction4 = (UI_state1)this.GetChildAt(86);
			m_PlayerAction3 = (UI_state1)this.GetChildAt(87);
			m_PlayerAction2 = (UI_state2)this.GetChildAt(88);
			m_PlayerAction1 = (UI_state2)this.GetChildAt(89);
			m_btn_luckyBox = (UI_btn_lckBox)this.GetChildAt(90);
			m_ready0 = (GImage)this.GetChildAt(91);
			m_ready1 = (GImage)this.GetChildAt(92);
			m_ready2 = (GImage)this.GetChildAt(93);
			m_ready3 = (GImage)this.GetChildAt(94);
			m_ready4 = (GImage)this.GetChildAt(95);
			m_n372 = (UI_btn_lckBox_stop)this.GetChildAt(96);
			m_t_result = this.GetTransitionAt(0);
			m_t0 = this.GetTransitionAt(1);
		}
	}
}