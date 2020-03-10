/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_kamisho : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_title;

		public const string URL = "ui://du637vw1nknvt7x";

		public static UI_btn_kamisho CreateInstance()
		{
			return (UI_btn_kamisho)UIPackage.CreateObject("Main","btn_kamisho");
		}

		public UI_btn_kamisho()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_title = (GTextField)this.GetChildAt(2);
		}
	}
}