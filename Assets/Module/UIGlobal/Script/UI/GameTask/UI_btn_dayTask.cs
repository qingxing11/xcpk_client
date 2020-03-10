/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_btn_dayTask : GButton
	{
		public Controller m_button;
		public GImage m_n2;

		public const string URL = "ui://jbql1kzagjdgx";

		public static UI_btn_dayTask CreateInstance()
		{
			return (UI_btn_dayTask)UIPackage.CreateObject("GameTask","btn_dayTask");
		}

		public UI_btn_dayTask()
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