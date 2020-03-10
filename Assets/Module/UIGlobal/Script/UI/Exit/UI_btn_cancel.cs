/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Exit
{
	public partial class UI_btn_cancel : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;

		public const string URL = "ui://tbio7epwvun8z";

		public static UI_btn_cancel CreateInstance()
		{
			return (UI_btn_cancel)UIPackage.CreateObject("Exit","btn_cancel");
		}

		public UI_btn_cancel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
		}
	}
}