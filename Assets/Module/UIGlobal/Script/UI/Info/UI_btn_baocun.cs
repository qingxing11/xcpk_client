/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_btn_baocun : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://5wbi0yeuvr82tdd";

		public static UI_btn_baocun CreateInstance()
		{
			return (UI_btn_baocun)UIPackage.CreateObject("Info","btn_baocun");
		}

		public UI_btn_baocun()
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