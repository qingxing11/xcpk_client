/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace TenThousandField
{
	public partial class UI_btn_requestUpDesk : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://efj6gsloenaq35";

		public static UI_btn_requestUpDesk CreateInstance()
		{
			return (UI_btn_requestUpDesk)UIPackage.CreateObject("TenThousandField","btn_requestUpDesk");
		}

		public UI_btn_requestUpDesk()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
		}
	}
}