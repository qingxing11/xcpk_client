/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_old : GButton
	{
		public Controller m_button;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://du637vw1dwi1t61";

		public static UI_btn_old CreateInstance()
		{
			return (UI_btn_old)UIPackage.CreateObject("Main","btn_old");
		}

		public UI_btn_old()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
		}
	}
}