/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_btn_ok : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://4f5tb9ztdpct9a";

		public static UI_btn_ok CreateInstance()
		{
			return (UI_btn_ok)UIPackage.CreateObject("Set","btn_ok");
		}

		public UI_btn_ok()
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