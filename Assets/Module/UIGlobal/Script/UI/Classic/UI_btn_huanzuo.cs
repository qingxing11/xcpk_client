/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_huanzuo : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n5;

		public const string URL = "ui://x31qyfggmwxt7i";

		public static UI_btn_huanzuo CreateInstance()
		{
			return (UI_btn_huanzuo)UIPackage.CreateObject("Classic","btn_huanzuo");
		}

		public UI_btn_huanzuo()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_n5 = (GImage)this.GetChildAt(3);
		}
	}
}