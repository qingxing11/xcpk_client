/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_btn_voice : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://kxabpsetotjz5xxw";

		public static UI_btn_voice CreateInstance()
		{
			return (UI_btn_voice)UIPackage.CreateObject("Chat","btn_voice");
		}

		public UI_btn_voice()
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