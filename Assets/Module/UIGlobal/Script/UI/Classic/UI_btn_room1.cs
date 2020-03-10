/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_room1 : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://x31qyfggj9pn1m";

		public static UI_btn_room1 CreateInstance()
		{
			return (UI_btn_room1)UIPackage.CreateObject("Classic","btn_room1");
		}

		public UI_btn_room1()
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