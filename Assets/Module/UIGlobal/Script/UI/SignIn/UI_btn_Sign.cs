/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SignIn
{
	public partial class UI_btn_Sign : GButton
	{
		public Controller m_c1;
		public GImage m_n0;
		public GImage m_one;
		public GImage m_two;
		public GImage m_three;
		public GImage m_four;
		public GImage m_five;
		public GImage m_six;
		public GImage m_seven;
		public GImage m_n10;
		public GImage m_n9;
		public GTextField m_txt_number;

		public const string URL = "ui://ffq58mwnv4v9i";

		public static UI_btn_Sign CreateInstance()
		{
			return (UI_btn_Sign)UIPackage.CreateObject("SignIn","btn_Sign");
		}

		public UI_btn_Sign()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_one = (GImage)this.GetChildAt(1);
			m_two = (GImage)this.GetChildAt(2);
			m_three = (GImage)this.GetChildAt(3);
			m_four = (GImage)this.GetChildAt(4);
			m_five = (GImage)this.GetChildAt(5);
			m_six = (GImage)this.GetChildAt(6);
			m_seven = (GImage)this.GetChildAt(7);
			m_n10 = (GImage)this.GetChildAt(8);
			m_n9 = (GImage)this.GetChildAt(9);
			m_txt_number = (GTextField)this.GetChildAt(10);
		}
	}
}