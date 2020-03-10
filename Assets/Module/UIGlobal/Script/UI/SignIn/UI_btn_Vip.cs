/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SignIn
{
	public partial class UI_btn_Vip : GButton
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;

		public const string URL = "ui://ffq58mwnv4v9h";

		public static UI_btn_Vip CreateInstance()
		{
			return (UI_btn_Vip)UIPackage.CreateObject("SignIn","btn_Vip");
		}

		public UI_btn_Vip()
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