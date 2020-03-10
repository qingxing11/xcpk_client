/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_box1 : GComponent
	{
		public Controller m_c1;
		public GImage m_n7;
		public GImage m_n8;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpibb";

		public static UI_box1 CreateInstance()
		{
			return (UI_box1)UIPackage.CreateObject("Classic","box1");
		}

		public UI_box1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n7 = (GImage)this.GetChildAt(0);
			m_n8 = (GImage)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}