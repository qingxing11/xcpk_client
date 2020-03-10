/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_UpBanker : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_n4;

		public const string URL = "ui://x31qyfggcgo6br";

		public static UI_btn_UpBanker CreateInstance()
		{
			return (UI_btn_UpBanker)UIPackage.CreateObject("Classic","btn_UpBanker");
		}

		public UI_btn_UpBanker()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n4 = (GTextField)this.GetChildAt(2);
		}
	}
}