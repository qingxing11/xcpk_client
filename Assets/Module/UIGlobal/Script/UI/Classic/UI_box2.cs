/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_box2 : GComponent
	{
		public Controller m_c1;
		public GImage m_n2;
		public GImage m_n3;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggunpibc";

		public static UI_box2 CreateInstance()
		{
			return (UI_box2)UIPackage.CreateObject("Classic","box2");
		}

		public UI_box2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n3 = (GImage)this.GetChildAt(1);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}