/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_login : GButton
	{
		public Controller m_button;
		public GImage m_n3;
		public GImage m_n4;

		public const string URL = "ui://du637vw1am2mt6s";

		public static UI_btn_login CreateInstance()
		{
			return (UI_btn_login)UIPackage.CreateObject("Main","btn_login");
		}

		public UI_btn_login()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
			m_n4 = (GImage)this.GetChildAt(1);
		}
	}
}