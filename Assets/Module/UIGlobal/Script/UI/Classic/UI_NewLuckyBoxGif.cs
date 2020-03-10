/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_NewLuckyBoxGif : GComponent
	{
		public Controller m_luckbox_pos;
		public UI_NewLuckyBoxOpen m_pos3;
		public UI_NewLuckyBoxOpen m_pos2;
		public UI_NewLuckyBoxOpen m_pos4;
		public UI_NewLuckyBoxOpen m_pos1;
		public UI_NewLuckyBoxOpen m_pos0;
		public Transition m_t0;

		public const string URL = "ui://x31qyfggvyaedw";

		public static UI_NewLuckyBoxGif CreateInstance()
		{
			return (UI_NewLuckyBoxGif)UIPackage.CreateObject("Classic","NewLuckyBoxGif");
		}

		public UI_NewLuckyBoxGif()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_luckbox_pos = this.GetControllerAt(0);
			m_pos3 = (UI_NewLuckyBoxOpen)this.GetChildAt(0);
			m_pos2 = (UI_NewLuckyBoxOpen)this.GetChildAt(1);
			m_pos4 = (UI_NewLuckyBoxOpen)this.GetChildAt(2);
			m_pos1 = (UI_NewLuckyBoxOpen)this.GetChildAt(3);
			m_pos0 = (UI_NewLuckyBoxOpen)this.GetChildAt(4);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}