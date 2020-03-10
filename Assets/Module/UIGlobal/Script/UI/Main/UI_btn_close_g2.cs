/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_close_g2 : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://du637vw1oymbt8z";

		public static UI_btn_close_g2 CreateInstance()
		{
			return (UI_btn_close_g2)UIPackage.CreateObject("Main","btn_close_g2");
		}

		public UI_btn_close_g2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
		}
	}
}