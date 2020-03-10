/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_btn_regist : GButton
	{
		public Controller m_button;
		public GImage m_n1;

		public const string URL = "ui://du637vw1am2mt6u";

		public static UI_btn_regist CreateInstance()
		{
			return (UI_btn_regist)UIPackage.CreateObject("Main","btn_regist");
		}

		public UI_btn_regist()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n1 = (GImage)this.GetChildAt(0);
		}
	}
}