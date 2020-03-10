/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_lckBox : GButton
	{
		public Controller m_button;
		public Controller m_c1;
		public GImage m_n2;
		public GImage m_n3;
		public GImage m_n5;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpibh";

		public static UI_btn_lckBox CreateInstance()
		{
			return (UI_btn_lckBox)UIPackage.CreateObject("Classic","btn_lckBox");
		}

		public UI_btn_lckBox()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_c1 = this.GetControllerAt(1);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}