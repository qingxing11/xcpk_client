/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_box5 : GComponent
	{
		public Controller m_c1;
		public GImage m_n0;
		public GImage m_n1;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpiba";

		public static UI_box5 CreateInstance()
		{
			return (UI_box5)UIPackage.CreateObject("Classic","box5");
		}

		public UI_box5()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}