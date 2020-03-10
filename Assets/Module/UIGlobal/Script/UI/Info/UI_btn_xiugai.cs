/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Info
{
	public partial class UI_btn_xiugai : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://5wbi0yeubh6ftcq";

		public static UI_btn_xiugai CreateInstance()
		{
			return (UI_btn_xiugai)UIPackage.CreateObject("Info","btn_xiugai");
		}

		public UI_btn_xiugai()
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