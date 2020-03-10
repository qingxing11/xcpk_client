/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_luckyBox : GComponent
	{
		public Controller m_c1;
		public GImage m_n14;
		public GImage m_n20;
		public GImage m_n15;
		public GImage m_n16;
		public GImage m_n17;
		public GImage m_n18;
		public GImage m_n19;
		public UI_box1 m_box1;
		public UI_box2 m_box2;
		public UI_box3 m_box3;
		public UI_box4 m_box4;
		public UI_box5 m_box5;
		public GTextField m_coins1;
		public GTextField m_coins2;
		public GTextField m_coins3;
		public GTextField m_coins4;
		public GTextField m_coins5;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpib9";

		public static UI_luckyBox CreateInstance()
		{
			return (UI_luckyBox)UIPackage.CreateObject("Classic","luckyBox");
		}

		public UI_luckyBox()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n14 = (GImage)this.GetChildAt(0);
			m_n20 = (GImage)this.GetChildAt(1);
			m_n15 = (GImage)this.GetChildAt(2);
			m_n16 = (GImage)this.GetChildAt(3);
			m_n17 = (GImage)this.GetChildAt(4);
			m_n18 = (GImage)this.GetChildAt(5);
			m_n19 = (GImage)this.GetChildAt(6);
			m_box1 = (UI_box1)this.GetChildAt(7);
			m_box2 = (UI_box2)this.GetChildAt(8);
			m_box3 = (UI_box3)this.GetChildAt(9);
			m_box4 = (UI_box4)this.GetChildAt(10);
			m_box5 = (UI_box5)this.GetChildAt(11);
			m_coins1 = (GTextField)this.GetChildAt(12);
			m_coins2 = (GTextField)this.GetChildAt(13);
			m_coins3 = (GTextField)this.GetChildAt(14);
			m_coins4 = (GTextField)this.GetChildAt(15);
			m_coins5 = (GTextField)this.GetChildAt(16);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}