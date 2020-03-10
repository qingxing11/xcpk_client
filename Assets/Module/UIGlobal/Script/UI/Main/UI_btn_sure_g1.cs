/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_sure_g1 : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_title;

		public const string URL = "ui://du637vw110z9t4i";

		public static UI_btn_sure_g1 CreateInstance()
		{
			return (UI_btn_sure_g1)UIPackage.CreateObject("Main","btn_sure_g1");
		}

		public UI_btn_sure_g1()
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