/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_Slider1_grip : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://4f5tb9ztdpct95";

		public static UI_Slider1_grip CreateInstance()
		{
			return (UI_Slider1_grip)UIPackage.CreateObject("Set","Slider1_grip");
		}

		public UI_Slider1_grip()
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