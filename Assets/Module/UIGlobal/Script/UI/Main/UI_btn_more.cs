/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_more : GButton
	{
		public Controller m_button;
		public GImage m_n3;
		public GImage m_n4;

		public const string URL = "ui://du637vw1fdzr45";

		public static UI_btn_more CreateInstance()
		{
			return (UI_btn_more)UIPackage.CreateObject("Main","btn_more");
		}

		public UI_btn_more()
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