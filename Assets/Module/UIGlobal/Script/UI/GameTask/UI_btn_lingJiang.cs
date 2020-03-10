/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_btn_lingJiang : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://jbql1kzagjdgv";

		public static UI_btn_lingJiang CreateInstance()
		{
			return (UI_btn_lingJiang)UIPackage.CreateObject("GameTask","btn_lingJiang");
		}

		public UI_btn_lingJiang()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
		}
	}
}