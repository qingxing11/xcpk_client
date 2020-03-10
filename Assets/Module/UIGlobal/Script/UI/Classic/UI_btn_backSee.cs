/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Classic
{
	public partial class UI_btn_backSee : GButton
	{
		public Controller m_button;
		public GImage m_n0;

		public const string URL = "ui://x31qyfggete2d2";

		public static UI_btn_backSee CreateInstance()
		{
			return (UI_btn_backSee)UIPackage.CreateObject("Classic","btn_backSee");
		}

		public UI_btn_backSee()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GImage)this.GetChildAt(0);
		}
	}
}