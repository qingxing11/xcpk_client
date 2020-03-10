/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_task : GButton
	{
		public Controller m_button;
		public GImage m_n7;
		public GImage m_n8;

		public const string URL = "ui://du637vw1fdzr42";

		public static UI_btn_task CreateInstance()
		{
			return (UI_btn_task)UIPackage.CreateObject("Main","btn_task");
		}

		public UI_btn_task()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n7 = (GImage)this.GetChildAt(0);
			m_n8 = (GImage)this.GetChildAt(1);
		}
	}
}