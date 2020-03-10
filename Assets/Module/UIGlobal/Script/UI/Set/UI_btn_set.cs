/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_btn_set : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://4f5tb9ztdpct97";

		public static UI_btn_set CreateInstance()
		{
			return (UI_btn_set)UIPackage.CreateObject("Set","btn_set");
		}

		public UI_btn_set()
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