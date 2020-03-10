/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_box3 : GComponent
	{
		public Controller m_c1;
		public GImage m_n4;
		public GImage m_n5;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpibg";

		public static UI_box3 CreateInstance()
		{
			return (UI_box3)UIPackage.CreateObject("Classic","box3");
		}

		public UI_box3()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n4 = (GImage)this.GetChildAt(0);
			m_n5 = (GImage)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}