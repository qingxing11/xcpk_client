/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameTask
{
	public partial class UI_btn_chouJiang : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://jbql1kzagjdgt";

		public static UI_btn_chouJiang CreateInstance()
		{
			return (UI_btn_chouJiang)UIPackage.CreateObject("GameTask","btn_chouJiang");
		}

		public UI_btn_chouJiang()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
		}
	}
}