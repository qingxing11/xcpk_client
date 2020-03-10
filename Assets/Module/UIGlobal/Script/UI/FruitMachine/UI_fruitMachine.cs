/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FruitMachine
{
	public partial class UI_fruitMachine : GComponent
	{
		public Controller m_zhuangJia;
		public Controller m_speical;
		public Controller m_gouPos;
		public GImage m_n218;
		public GImage m_n194;
		public UI_btnBar m_btnBar;
		public UI_btnQiQi m_btnQiQi;
		public UI_btnStar m_btnStar;
		public UI_btnXiGua m_btnXiGua;
		public UI_btnLingDang m_btnLingDang;
		public UI_btnMangGuo m_btnMangGuo;
		public UI_btnOrange m_btnOrange;
		public UI_btnApple m_btnApple;
		public GTextField m_txt_bar;
		public GTextField m_txt_qiqi;
		public GTextField m_txt_star;
		public GTextField m_txt_xiGua;
		public GTextField m_txt_lingDang;
		public GTextField m_txt_mangGuo;
		public GTextField m_txt_orange;
		public GTextField m_txt_apple;
		public GRichTextField m_txt_downBar;
		public GRichTextField m_txt_downQiQi;
		public GRichTextField m_txt_downStar;
		public GRichTextField m_txt_downXiGua;
		public GRichTextField m_txt_downLingDang;
		public GRichTextField m_txt_downMangGuo;
		public GRichTextField m_txt_downOrange;
		public GRichTextField m_txt_downApple;
		public UI_btn_dd m_btn_dd;
		public UI_btn_khc m_btn_khc;
		public UI_btn_dsx m_btn_dsx;
		public UI_btn_dsy m_btn_dsy;
		public UI_btn_xsy m_btn_xsy;
		public UI_btn_jbld m_btn_jbld;
		public GImage m_n222;
		public GImage m_n223;
		public GImage m_n224;
		public GImage m_n225;
		public GImage m_n226;
		public GImage m_n227;
		public GGroup m_btn_mid;
		public GRichTextField m_txt_time;
		public UI_btn_return_g1 m_btn_left;
		public UI_btn_return_g1 m_btn_right;
		public GList m_history;
		public GImage m_btn1;
		public GImage m_btn2;
		public GImage m_btn3;
		public GImage m_btn4;
		public GImage m_btn5;
		public GImage m_btn6;
		public GImage m_btn7;
		public GImage m_btn8;
		public GImage m_btn9;
		public GImage m_btn10;
		public GImage m_btn11;
		public GImage m_btn12;
		public GImage m_btn13;
		public GImage m_btn14;
		public GImage m_btn15;
		public GImage m_btn16;
		public GImage m_btn17;
		public GImage m_btn18;
		public GImage m_btn19;
		public GImage m_btn20;
		public GImage m_btn21;
		public GImage m_btn22;
		public GImage m_btn23;
		public GImage m_btn24;
		public GImage m_n124;
		public GImage m_n143;
		public GImage m_n144;
		public GImage m_n145;
		public GImage m_n132;
		public GImage m_n131;
		public GImage m_n128;
		public GImage m_n126;
		public GImage m_n127;
		public GImage m_n217;
		public GImage m_n135;
		public GImage m_n136;
		public GImage m_n137;
		public GImage m_n148;
		public GImage m_n147;
		public GImage m_n146;
		public GImage m_n134;
		public GImage m_n130;
		public GImage m_n129;
		public GImage m_n125;
		public GImage m_n138;
		public GImage m_n216;
		public GImage m_n133;
		public GImage m_n141;
		public GImage m_mask1;
		public GImage m_mask2;
		public GImage m_mask3;
		public UI_mask m_m1;
		public UI_mask m_m2;
		public UI_mask m_m3;
		public UI_mask m_m4;
		public UI_mask m_m5;
		public UI_mask m_m6;
		public UI_mask m_m7;
		public UI_mask m_m8;
		public UI_mask m_m9;
		public UI_mask m_m10;
		public UI_mask m_m11;
		public UI_mask m_m12;
		public UI_mask m_m13;
		public UI_mask m_m14;
		public UI_mask m_m15;
		public UI_mask m_m16;
		public UI_mask m_m17;
		public UI_mask m_m18;
		public UI_mask m_m19;
		public UI_mask m_m20;
		public UI_mask m_m21;
		public UI_mask m_m22;
		public GGroup m_mSum;
		public GImage m_n182;
		public GLoader m_load_icon;
		public GTextField m_txt_nike;
		public GImage m_n183;
		public GTextField m_txt_coins;
		public GRichTextField m_txt_userMoney;
		public GImage m_n195;
		public UI_bankerInfo m_bankerInfo;
		public GRichTextField m_txt_Win;
		public GImage m_n228;
		public UI_one m_one;
		public UI_twoFive m_twoFive;
		public UI_fiveTen m_fiveTen;
		public GImage m_n235;
		public UI_xuya m_xuYa;
		public GLoader m_vip;
		public Transition m_showTips;

		public const string URL = "ui://l17p56hbao42tf0";

		public static UI_fruitMachine CreateInstance()
		{
			return (UI_fruitMachine)UIPackage.CreateObject("FruitMachine","fruitMachine");
		}

		public UI_fruitMachine()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_zhuangJia = this.GetControllerAt(0);
			m_speical = this.GetControllerAt(1);
			m_gouPos = this.GetControllerAt(2);
			m_n218 = (GImage)this.GetChildAt(0);
			m_n194 = (GImage)this.GetChildAt(1);
			m_btnBar = (UI_btnBar)this.GetChildAt(2);
			m_btnQiQi = (UI_btnQiQi)this.GetChildAt(3);
			m_btnStar = (UI_btnStar)this.GetChildAt(4);
			m_btnXiGua = (UI_btnXiGua)this.GetChildAt(5);
			m_btnLingDang = (UI_btnLingDang)this.GetChildAt(6);
			m_btnMangGuo = (UI_btnMangGuo)this.GetChildAt(7);
			m_btnOrange = (UI_btnOrange)this.GetChildAt(8);
			m_btnApple = (UI_btnApple)this.GetChildAt(9);
			m_txt_bar = (GTextField)this.GetChildAt(10);
			m_txt_qiqi = (GTextField)this.GetChildAt(11);
			m_txt_star = (GTextField)this.GetChildAt(12);
			m_txt_xiGua = (GTextField)this.GetChildAt(13);
			m_txt_lingDang = (GTextField)this.GetChildAt(14);
			m_txt_mangGuo = (GTextField)this.GetChildAt(15);
			m_txt_orange = (GTextField)this.GetChildAt(16);
			m_txt_apple = (GTextField)this.GetChildAt(17);
			m_txt_downBar = (GRichTextField)this.GetChildAt(18);
			m_txt_downQiQi = (GRichTextField)this.GetChildAt(19);
			m_txt_downStar = (GRichTextField)this.GetChildAt(20);
			m_txt_downXiGua = (GRichTextField)this.GetChildAt(21);
			m_txt_downLingDang = (GRichTextField)this.GetChildAt(22);
			m_txt_downMangGuo = (GRichTextField)this.GetChildAt(23);
			m_txt_downOrange = (GRichTextField)this.GetChildAt(24);
			m_txt_downApple = (GRichTextField)this.GetChildAt(25);
			m_btn_dd = (UI_btn_dd)this.GetChildAt(26);
			m_btn_khc = (UI_btn_khc)this.GetChildAt(27);
			m_btn_dsx = (UI_btn_dsx)this.GetChildAt(28);
			m_btn_dsy = (UI_btn_dsy)this.GetChildAt(29);
			m_btn_xsy = (UI_btn_xsy)this.GetChildAt(30);
			m_btn_jbld = (UI_btn_jbld)this.GetChildAt(31);
			m_n222 = (GImage)this.GetChildAt(32);
			m_n223 = (GImage)this.GetChildAt(33);
			m_n224 = (GImage)this.GetChildAt(34);
			m_n225 = (GImage)this.GetChildAt(35);
			m_n226 = (GImage)this.GetChildAt(36);
			m_n227 = (GImage)this.GetChildAt(37);
			m_btn_mid = (GGroup)this.GetChildAt(38);
			m_txt_time = (GRichTextField)this.GetChildAt(39);
			m_btn_left = (UI_btn_return_g1)this.GetChildAt(40);
			m_btn_right = (UI_btn_return_g1)this.GetChildAt(41);
			m_history = (GList)this.GetChildAt(42);
			m_btn1 = (GImage)this.GetChildAt(43);
			m_btn2 = (GImage)this.GetChildAt(44);
			m_btn3 = (GImage)this.GetChildAt(45);
			m_btn4 = (GImage)this.GetChildAt(46);
			m_btn5 = (GImage)this.GetChildAt(47);
			m_btn6 = (GImage)this.GetChildAt(48);
			m_btn7 = (GImage)this.GetChildAt(49);
			m_btn8 = (GImage)this.GetChildAt(50);
			m_btn9 = (GImage)this.GetChildAt(51);
			m_btn10 = (GImage)this.GetChildAt(52);
			m_btn11 = (GImage)this.GetChildAt(53);
			m_btn12 = (GImage)this.GetChildAt(54);
			m_btn13 = (GImage)this.GetChildAt(55);
			m_btn14 = (GImage)this.GetChildAt(56);
			m_btn15 = (GImage)this.GetChildAt(57);
			m_btn16 = (GImage)this.GetChildAt(58);
			m_btn17 = (GImage)this.GetChildAt(59);
			m_btn18 = (GImage)this.GetChildAt(60);
			m_btn19 = (GImage)this.GetChildAt(61);
			m_btn20 = (GImage)this.GetChildAt(62);
			m_btn21 = (GImage)this.GetChildAt(63);
			m_btn22 = (GImage)this.GetChildAt(64);
			m_btn23 = (GImage)this.GetChildAt(65);
			m_btn24 = (GImage)this.GetChildAt(66);
			m_n124 = (GImage)this.GetChildAt(67);
			m_n143 = (GImage)this.GetChildAt(68);
			m_n144 = (GImage)this.GetChildAt(69);
			m_n145 = (GImage)this.GetChildAt(70);
			m_n132 = (GImage)this.GetChildAt(71);
			m_n131 = (GImage)this.GetChildAt(72);
			m_n128 = (GImage)this.GetChildAt(73);
			m_n126 = (GImage)this.GetChildAt(74);
			m_n127 = (GImage)this.GetChildAt(75);
			m_n217 = (GImage)this.GetChildAt(76);
			m_n135 = (GImage)this.GetChildAt(77);
			m_n136 = (GImage)this.GetChildAt(78);
			m_n137 = (GImage)this.GetChildAt(79);
			m_n148 = (GImage)this.GetChildAt(80);
			m_n147 = (GImage)this.GetChildAt(81);
			m_n146 = (GImage)this.GetChildAt(82);
			m_n134 = (GImage)this.GetChildAt(83);
			m_n130 = (GImage)this.GetChildAt(84);
			m_n129 = (GImage)this.GetChildAt(85);
			m_n125 = (GImage)this.GetChildAt(86);
			m_n138 = (GImage)this.GetChildAt(87);
			m_n216 = (GImage)this.GetChildAt(88);
			m_n133 = (GImage)this.GetChildAt(89);
			m_n141 = (GImage)this.GetChildAt(90);
			m_mask1 = (GImage)this.GetChildAt(91);
			m_mask2 = (GImage)this.GetChildAt(92);
			m_mask3 = (GImage)this.GetChildAt(93);
			m_m1 = (UI_mask)this.GetChildAt(94);
			m_m2 = (UI_mask)this.GetChildAt(95);
			m_m3 = (UI_mask)this.GetChildAt(96);
			m_m4 = (UI_mask)this.GetChildAt(97);
			m_m5 = (UI_mask)this.GetChildAt(98);
			m_m6 = (UI_mask)this.GetChildAt(99);
			m_m7 = (UI_mask)this.GetChildAt(100);
			m_m8 = (UI_mask)this.GetChildAt(101);
			m_m9 = (UI_mask)this.GetChildAt(102);
			m_m10 = (UI_mask)this.GetChildAt(103);
			m_m11 = (UI_mask)this.GetChildAt(104);
			m_m12 = (UI_mask)this.GetChildAt(105);
			m_m13 = (UI_mask)this.GetChildAt(106);
			m_m14 = (UI_mask)this.GetChildAt(107);
			m_m15 = (UI_mask)this.GetChildAt(108);
			m_m16 = (UI_mask)this.GetChildAt(109);
			m_m17 = (UI_mask)this.GetChildAt(110);
			m_m18 = (UI_mask)this.GetChildAt(111);
			m_m19 = (UI_mask)this.GetChildAt(112);
			m_m20 = (UI_mask)this.GetChildAt(113);
			m_m21 = (UI_mask)this.GetChildAt(114);
			m_m22 = (UI_mask)this.GetChildAt(115);
			m_mSum = (GGroup)this.GetChildAt(116);
			m_n182 = (GImage)this.GetChildAt(117);
			m_load_icon = (GLoader)this.GetChildAt(118);
			m_txt_nike = (GTextField)this.GetChildAt(119);
			m_n183 = (GImage)this.GetChildAt(120);
			m_txt_coins = (GTextField)this.GetChildAt(121);
			m_txt_userMoney = (GRichTextField)this.GetChildAt(122);
			m_n195 = (GImage)this.GetChildAt(123);
			m_bankerInfo = (UI_bankerInfo)this.GetChildAt(124);
			m_txt_Win = (GRichTextField)this.GetChildAt(125);
			m_n228 = (GImage)this.GetChildAt(126);
			m_one = (UI_one)this.GetChildAt(127);
			m_twoFive = (UI_twoFive)this.GetChildAt(128);
			m_fiveTen = (UI_fiveTen)this.GetChildAt(129);
			m_n235 = (GImage)this.GetChildAt(130);
			m_xuYa = (UI_xuya)this.GetChildAt(131);
			m_vip = (GLoader)this.GetChildAt(132);
			m_showTips = this.GetTransitionAt(0);
		}
	}
}