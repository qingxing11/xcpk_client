/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_btn_emjoy2 : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://kxabpsetptr45xxb";

		public static UI_btn_emjoy2 CreateInstance()
		{
			return (UI_btn_emjoy2)UIPackage.CreateObject("Chat","btn_emjoy2");
		}

		public UI_btn_emjoy2()
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