/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lottery
{
	public partial class UI_LotteryCom : GComponent
	{
		public GImage m_n23;
		public GImage m_n21;
		public GList m_list_select;
		public UI_btn_zdtz m_btn_zdtz;
		public GImage m_n14;
		public GImage m_n60;
		public GImage m_n6;
		public GImage m_n31;
		public GImage m_n30;
		public GLoader m_load_card1;
		public GLoader m_load_card2;
		public GLoader m_load_card3;
		public GImage m_n22;
		public GTextField m_txt_allmoney;
		public GImage m_n18;
		public GImage m_n24;
		public GImage m_n25;
		public GImage m_n26;
		public GList m_list_duigou;
		public GImage m_bg_xz;
		public GImage m_bg_xyj;
		public GTextField m_txt_time;
		public UI_btn_close m_btn_close;
		public GImage m_n32;
		public GList m_list_record;
		public GLoader m_btn_left;
		public GLoader m_btn_right;
		public GImage m_n67;
		public GTextField m_txt_title;
		public GLoader m_btn_no;
		public GTextField m_txt_error;
		public GMovieClip m_movi2;
		public GMovieClip m_movi3;
		public GMovieClip m_movi;
		public GImage m_n96;
		public GImage m_n97;
		public GImage m_n98;
		public GImage m_n99;
		public GImage m_n101;
		public GImage m_n102;
		public GImage m_n103;
		public GGroup m_effect3;
		public UI_coin m_coinCom;
		public GImage m_n112;
		public GTextField m_txt_num;
		public Transition m_t0;
		public Transition m_t2;
		public Transition m_t3;
		public Transition m_t03;
		public Transition m_t04;
		public Transition m_t02;
		public Transition m_t01;
		public Transition m_t05;
		public Transition m_t06;

		public const string URL = "ui://czzshd91lt201";

		public static UI_LotteryCom CreateInstance()
		{
			return (UI_LotteryCom)UIPackage.CreateObject("Lottery","LotteryCom");
		}

		public UI_LotteryCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n23 = (GImage)this.GetChildAt(0);
			m_n21 = (GImage)this.GetChildAt(1);
			m_list_select = (GList)this.GetChildAt(2);
			m_btn_zdtz = (UI_btn_zdtz)this.GetChildAt(3);
			m_n14 = (GImage)this.GetChildAt(4);
			m_n60 = (GImage)this.GetChildAt(5);
			m_n6 = (GImage)this.GetChildAt(6);
			m_n31 = (GImage)this.GetChildAt(7);
			m_n30 = (GImage)this.GetChildAt(8);
			m_load_card1 = (GLoader)this.GetChildAt(9);
			m_load_card2 = (GLoader)this.GetChildAt(10);
			m_load_card3 = (GLoader)this.GetChildAt(11);
			m_n22 = (GImage)this.GetChildAt(12);
			m_txt_allmoney = (GTextField)this.GetChildAt(13);
			m_n18 = (GImage)this.GetChildAt(14);
			m_n24 = (GImage)this.GetChildAt(15);
			m_n25 = (GImage)this.GetChildAt(16);
			m_n26 = (GImage)this.GetChildAt(17);
			m_list_duigou = (GList)this.GetChildAt(18);
			m_bg_xz = (GImage)this.GetChildAt(19);
			m_bg_xyj = (GImage)this.GetChildAt(20);
			m_txt_time = (GTextField)this.GetChildAt(21);
			m_btn_close = (UI_btn_close)this.GetChildAt(22);
			m_n32 = (GImage)this.GetChildAt(23);
			m_list_record = (GList)this.GetChildAt(24);
			m_btn_left = (GLoader)this.GetChildAt(25);
			m_btn_right = (GLoader)this.GetChildAt(26);
			m_n67 = (GImage)this.GetChildAt(27);
			m_txt_title = (GTextField)this.GetChildAt(28);
			m_btn_no = (GLoader)this.GetChildAt(29);
			m_txt_error = (GTextField)this.GetChildAt(30);
			m_movi2 = (GMovieClip)this.GetChildAt(31);
			m_movi3 = (GMovieClip)this.GetChildAt(32);
			m_movi = (GMovieClip)this.GetChildAt(33);
			m_n96 = (GImage)this.GetChildAt(34);
			m_n97 = (GImage)this.GetChildAt(35);
			m_n98 = (GImage)this.GetChildAt(36);
			m_n99 = (GImage)this.GetChildAt(37);
			m_n101 = (GImage)this.GetChildAt(38);
			m_n102 = (GImage)this.GetChildAt(39);
			m_n103 = (GImage)this.GetChildAt(40);
			m_effect3 = (GGroup)this.GetChildAt(41);
			m_coinCom = (UI_coin)this.GetChildAt(42);
			m_n112 = (GImage)this.GetChildAt(43);
			m_txt_num = (GTextField)this.GetChildAt(44);
			m_t0 = this.GetTransitionAt(0);
			m_t2 = this.GetTransitionAt(1);
			m_t3 = this.GetTransitionAt(2);
			m_t03 = this.GetTransitionAt(3);
			m_t04 = this.GetTransitionAt(4);
			m_t02 = this.GetTransitionAt(5);
			m_t01 = this.GetTransitionAt(6);
			m_t05 = this.GetTransitionAt(7);
			m_t06 = this.GetTransitionAt(8);
		}
	}
}