/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_state1 : GComponent
	{
		public Controller m_c_state;
		public GImage m_n0;
		public GImage m_n7;
		public GLoader m_n6;
		public Transition m_t_anim;

		public const string URL = "ui://x31qyfggpgxy7q";

		public static UI_state1 CreateInstance()
		{
			return (UI_state1)UIPackage.CreateObject("Classic","state1");
		}

		public UI_state1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c_state = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n7 = (GImage)this.GetChildAt(1);
			m_n6 = (GLoader)this.GetChildAt(2);
			m_t_anim = this.GetTransitionAt(0);
		}
	}
}