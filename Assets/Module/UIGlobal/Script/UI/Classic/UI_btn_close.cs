/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_close : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://x31qyfggkudq9q";

		public static UI_btn_close CreateInstance()
		{
			return (UI_btn_close)UIPackage.CreateObject("Classic","btn_close");
		}

		public UI_btn_close()
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