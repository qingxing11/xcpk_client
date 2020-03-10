/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Guaguale
{
	public partial class UI_btn_add : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://rjmn7jeuzq2w6g";

		public static UI_btn_add CreateInstance()
		{
			return (UI_btn_add)UIPackage.CreateObject("Guaguale","btn_add");
		}

		public UI_btn_add()
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