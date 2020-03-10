/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_btn_sureChange : GButton
	{
		public Controller m_button;
		public GImage m_n3;

		public const string URL = "ui://ey7bc1rcrwpf1y";

		public static UI_btn_sureChange CreateInstance()
		{
			return (UI_btn_sureChange)UIPackage.CreateObject("Safebox","btn_sureChange");
		}

		public UI_btn_sureChange()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
		}
	}
}