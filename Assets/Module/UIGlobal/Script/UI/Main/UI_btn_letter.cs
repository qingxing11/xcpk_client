/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_letter : GButton
	{
		public Controller m_button;
		public GImage m_n5;
		public GImage m_n6;

		public const string URL = "ui://du637vw1nknvt7s";

		public static UI_btn_letter CreateInstance()
		{
			return (UI_btn_letter)UIPackage.CreateObject("Main","btn_letter");
		}

		public UI_btn_letter()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n5 = (GImage)this.GetChildAt(0);
			m_n6 = (GImage)this.GetChildAt(1);
		}
	}
}