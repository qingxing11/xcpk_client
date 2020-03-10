/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_emjoy : GButton
	{
		public Controller m_button;
		public GLoader m_icon;

		public const string URL = "ui://kxabpsetkouvvq";

		public static UI_emjoy CreateInstance()
		{
			return (UI_emjoy)UIPackage.CreateObject("Chat","emjoy");
		}

		public UI_emjoy()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_icon = (GLoader)this.GetChildAt(0);
		}
	}
}