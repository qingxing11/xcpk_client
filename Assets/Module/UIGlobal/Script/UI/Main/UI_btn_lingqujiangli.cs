/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_lingqujiangli : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://du637vw1ttywy10";

		public static UI_btn_lingqujiangli CreateInstance()
		{
			return (UI_btn_lingqujiangli)UIPackage.CreateObject("Main","btn_lingqujiangli");
		}

		public UI_btn_lingqujiangli()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}