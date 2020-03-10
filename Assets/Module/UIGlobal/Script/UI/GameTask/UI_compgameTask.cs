/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_compgameTask : GComponent
	{
		public Controller m_task;
		public GList m_taskList;
		public GImage m_n29;
		public GImage m_n30;
		public GImage m_n31;
		public UI_btn_dayTask m_btn_dayTask;
		public UI_btn_geRenTask m_btn_geRenTask;
		public UI_btn_systemTask m_btn_system;

		public const string URL = "ui://jbql1kzagjdg10";

		public static UI_compgameTask CreateInstance()
		{
			return (UI_compgameTask)UIPackage.CreateObject("GameTask","compgameTask");
		}

		public UI_compgameTask()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_task = this.GetControllerAt(0);
			m_taskList = (GList)this.GetChildAt(0);
			m_n29 = (GImage)this.GetChildAt(1);
			m_n30 = (GImage)this.GetChildAt(2);
			m_n31 = (GImage)this.GetChildAt(3);
			m_btn_dayTask = (UI_btn_dayTask)this.GetChildAt(4);
			m_btn_geRenTask = (UI_btn_geRenTask)this.GetChildAt(5);
			m_btn_system = (UI_btn_systemTask)this.GetChildAt(6);
		}
	}
}