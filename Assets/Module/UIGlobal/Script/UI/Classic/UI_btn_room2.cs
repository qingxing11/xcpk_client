/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_room2 : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://x31qyfggj9pn1n";

		public static UI_btn_room2 CreateInstance()
		{
			return (UI_btn_room2)UIPackage.CreateObject("Classic","btn_room2");
		}

		public UI_btn_room2()
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