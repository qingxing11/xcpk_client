/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_btn_systemTask : GButton
	{
		public Controller m_button;
		public GImage m_n2;

		public const string URL = "ui://jbql1kzagjdgz";

		public static UI_btn_systemTask CreateInstance()
		{
			return (UI_btn_systemTask)UIPackage.CreateObject("GameTask","btn_systemTask");
		}

		public UI_btn_systemTask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
		}
	}
}