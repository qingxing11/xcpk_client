/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_btn_shutCut : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://kxabpsetsa12e";

		public static UI_btn_shutCut CreateInstance()
		{
			return (UI_btn_shutCut)UIPackage.CreateObject("Chat","btn_shutCut");
		}

		public UI_btn_shutCut()
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