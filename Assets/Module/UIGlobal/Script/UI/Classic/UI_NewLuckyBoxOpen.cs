/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_NewLuckyBoxOpen : GComponent
	{
		public Controller m_luckbox_open;
		public GImage m_n3;
		public GRichTextField m_goldNum;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n8;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggvyaedx";

		public static UI_NewLuckyBoxOpen CreateInstance()
		{
			return (UI_NewLuckyBoxOpen)UIPackage.CreateObject("Classic","NewLuckyBoxOpen");
		}

		public UI_NewLuckyBoxOpen()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_luckbox_open = this.GetControllerAt(0);
			m_n3 = (GImage)this.GetChildAt(0);
			m_goldNum = (GRichTextField)this.GetChildAt(1);
			m_n6 = (GImage)this.GetChildAt(2);
			m_n7 = (GImage)this.GetChildAt(3);
			m_n8 = (GImage)this.GetChildAt(4);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}