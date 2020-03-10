/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_btn_startChouJiang : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://jbql1kzat1m32h";

		public static UI_btn_startChouJiang CreateInstance()
		{
			return (UI_btn_startChouJiang)UIPackage.CreateObject("GameTask","btn_startChouJiang");
		}

		public UI_btn_startChouJiang()
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