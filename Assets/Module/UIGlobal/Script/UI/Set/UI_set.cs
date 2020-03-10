/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_set : GComponent
	{
		public Controller m_c_sound;
		public Controller m_c_music;
		public Controller m_c1;
		public Controller m_c_bullet;
		public GImage m_n33;
		public GImage m_bg;
		public GImage m_n71;
		public GImage m_bg_2;
		public GImage m_bg_3;
		public UI_Slider1 m_Slider_sound;
		public UI_Slider1 m_Slider_music;
		public GImage m_n41;
		public GImage m_n42;
		public GImage m_n48;
		public UI_btn_set m_btn_sound;
		public UI_btn_set m_btn_music;
		public UI_btn_close m_btn_close;
		public GImage m_bg_4;
		public GImage m_bg_5;
		public GImage m_n45;
		public GImage m_n47;
		public UI_Button1 m_btn_BDSJ;
		public UI_Button1 m_btn_QHZH;
		public UI_Button1 m_btn_WSZH;
		public UI_Button1 m_btn_ZHMM;
		public UI_Button1 m_btn_XGMM;
		public GImage m_n57;
		public GImage m_n58;
		public GImage m_n59;
		public GImage m_n60;
		public GImage m_n61;
		public GTextField m_text_phoneNum;
		public GTextField m_text_accound;
		public GGroup m_n66;
		public UI_btn_kai m_btn_bulltkai;
		public UI_btn_guan m_btn_bulltguan;
		public GImage m_n74;
		public GImage m_n75;
		public GGroup m_n76;
		public GTextField m_n77;

		public const string URL = "ui://4f5tb9ztka6x8y";

		public static UI_set CreateInstance()
		{
			return (UI_set)UIPackage.CreateObject("Set","set");
		}

		public UI_set()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c_sound = this.GetControllerAt(0);
			m_c_music = this.GetControllerAt(1);
			m_c1 = this.GetControllerAt(2);
			m_c_bullet = this.GetControllerAt(3);
			m_n33 = (GImage)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_n71 = (GImage)this.GetChildAt(2);
			m_bg_2 = (GImage)this.GetChildAt(3);
			m_bg_3 = (GImage)this.GetChildAt(4);
			m_Slider_sound = (UI_Slider1)this.GetChildAt(5);
			m_Slider_music = (UI_Slider1)this.GetChildAt(6);
			m_n41 = (GImage)this.GetChildAt(7);
			m_n42 = (GImage)this.GetChildAt(8);
			m_n48 = (GImage)this.GetChildAt(9);
			m_btn_sound = (UI_btn_set)this.GetChildAt(10);
			m_btn_music = (UI_btn_set)this.GetChildAt(11);
			m_btn_close = (UI_btn_close)this.GetChildAt(12);
			m_bg_4 = (GImage)this.GetChildAt(13);
			m_bg_5 = (GImage)this.GetChildAt(14);
			m_n45 = (GImage)this.GetChildAt(15);
			m_n47 = (GImage)this.GetChildAt(16);
			m_btn_BDSJ = (UI_Button1)this.GetChildAt(17);
			m_btn_QHZH = (UI_Button1)this.GetChildAt(18);
			m_btn_WSZH = (UI_Button1)this.GetChildAt(19);
			m_btn_ZHMM = (UI_Button1)this.GetChildAt(20);
			m_btn_XGMM = (UI_Button1)this.GetChildAt(21);
			m_n57 = (GImage)this.GetChildAt(22);
			m_n58 = (GImage)this.GetChildAt(23);
			m_n59 = (GImage)this.GetChildAt(24);
			m_n60 = (GImage)this.GetChildAt(25);
			m_n61 = (GImage)this.GetChildAt(26);
			m_text_phoneNum = (GTextField)this.GetChildAt(27);
			m_text_accound = (GTextField)this.GetChildAt(28);
			m_n66 = (GGroup)this.GetChildAt(29);
			m_btn_bulltkai = (UI_btn_kai)this.GetChildAt(30);
			m_btn_bulltguan = (UI_btn_guan)this.GetChildAt(31);
			m_n74 = (GImage)this.GetChildAt(32);
			m_n75 = (GImage)this.GetChildAt(33);
			m_n76 = (GGroup)this.GetChildAt(34);
			m_n77 = (GTextField)this.GetChildAt(35);
		}
	}
}