/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_luckyBoxGif : GComponent
	{
		public Controller m_c1;
		public Controller m_luckbox_money;
		public GImage m_n2;
		public GImage m_n0;
		public GLoader m_n1;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggan62bi";

		public static UI_luckyBoxGif CreateInstance()
		{
			return (UI_luckyBoxGif)UIPackage.CreateObject("Classic","luckyBoxGif");
		}

		public UI_luckyBoxGif()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_luckbox_money = this.GetControllerAt(1);
			m_n2 = (GImage)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_n1 = (GLoader)this.GetChildAt(2);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}