/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_FruitsMachine : GComponent
	{
		public Controller m_enterOrOut;
		public Controller m_scale;
		public GGraph m_n225;
		public GGraph m_bg;
		public GImage m_n199;
		public GImage m_n202;
		public GImage m_n165;
		public UI_btn_letter m_btn_chat;
		public UI_btn_kamisho m_btn_shangZhuang;
		public UI_btn_old m_btn_return;
		public UI_fruitMachine m_fruitMachine;
		public UI_btn_close_g2 m_btn_close;
		public GLoader m_more;
		public GLoader m_clickHide;
		public GImage m_bg_horn;
		public GLoader m_btn_horn;
		public GLoader m_btn_hornReocrd;
		public GGroup m_horn;
		public UI_ReturnPanel m_btnShow;
		public GImage m_movie_win;
		public GLoader m_btn_lottery;
		public GRichTextField m_txt_lotteryTime;
		public GLoader m_n216;
		public GLoader m_btn_more;
		public GImage m_n218;
		public GTextField m_txt_lotteryNum;
		public GGroup m_lotteryNum;
		public GGroup m_lottery;
		public GImage m_addfriends;
		public UI_btn_friend m_btn_friend;
		public GGroup m_friend;
		public Transition m_closeUI;
		public Transition m_t0;

		public const string URL = "ui://l17p56hbnknvt6b";

		public static UI_FruitsMachine CreateInstance()
		{
			return (UI_FruitsMachine)UIPackage.CreateObject("FruitMachine","FruitsMachine");
		}

		public UI_FruitsMachine()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_enterOrOut = this.GetControllerAt(0);
			m_scale = this.GetControllerAt(1);
			m_n225 = (GGraph)this.GetChildAt(0);
			m_bg = (GGraph)this.GetChildAt(1);
			m_n199 = (GImage)this.GetChildAt(2);
			m_n202 = (GImage)this.GetChildAt(3);
			m_n165 = (GImage)this.GetChildAt(4);
			m_btn_chat = (UI_btn_letter)this.GetChildAt(5);
			m_btn_shangZhuang = (UI_btn_kamisho)this.GetChildAt(6);
			m_btn_return = (UI_btn_old)this.GetChildAt(7);
			m_fruitMachine = (UI_fruitMachine)this.GetChildAt(8);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(9);
			m_more = (GLoader)this.GetChildAt(10);
			m_clickHide = (GLoader)this.GetChildAt(11);
			m_bg_horn = (GImage)this.GetChildAt(12);
			m_btn_horn = (GLoader)this.GetChildAt(13);
			m_btn_hornReocrd = (GLoader)this.GetChildAt(14);
			m_horn = (GGroup)this.GetChildAt(15);
			m_btnShow = (UI_ReturnPanel)this.GetChildAt(16);
			m_movie_win = (GImage)this.GetChildAt(17);
			m_btn_lottery = (GLoader)this.GetChildAt(18);
			m_txt_lotteryTime = (GRichTextField)this.GetChildAt(19);
			m_n216 = (GLoader)this.GetChildAt(20);
			m_btn_more = (GLoader)this.GetChildAt(21);
			m_n218 = (GImage)this.GetChildAt(22);
			m_txt_lotteryNum = (GTextField)this.GetChildAt(23);
			m_lotteryNum = (GGroup)this.GetChildAt(24);
			m_lottery = (GGroup)this.GetChildAt(25);
			m_addfriends = (GImage)this.GetChildAt(26);
			m_btn_friend = (UI_btn_friend)this.GetChildAt(27);
			m_friend = (GGroup)this.GetChildAt(28);
			m_closeUI = this.GetTransitionAt(0);
			m_t0 = this.GetTransitionAt(1);
		}
	}
}