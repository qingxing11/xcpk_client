/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_return : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://du637vw19h1ot9m";

		public static UI_btn_return CreateInstance()
		{
			return (UI_btn_return)UIPackage.CreateObject("Main","btn_return");
		}

		public UI_btn_return()
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