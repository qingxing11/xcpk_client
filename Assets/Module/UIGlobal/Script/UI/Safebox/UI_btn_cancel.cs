/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_btn_cancel : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://ey7bc1rcrwpf22";

		public static UI_btn_cancel CreateInstance()
		{
			return (UI_btn_cancel)UIPackage.CreateObject("Safebox","btn_cancel");
		}

		public UI_btn_cancel()
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