/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_btn_emoji3 : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://kxabpsetotjz5xxu";

		public static UI_btn_emoji3 CreateInstance()
		{
			return (UI_btn_emoji3)UIPackage.CreateObject("Chat","btn_emoji3");
		}

		public UI_btn_emoji3()
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