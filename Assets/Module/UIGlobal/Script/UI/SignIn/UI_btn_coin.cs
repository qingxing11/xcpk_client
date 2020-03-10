/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SignIn
{
	public partial class UI_btn_coin : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://ffq58mwnulxep";

		public static UI_btn_coin CreateInstance()
		{
			return (UI_btn_coin)UIPackage.CreateObject("SignIn","btn_coin");
		}

		public UI_btn_coin()
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