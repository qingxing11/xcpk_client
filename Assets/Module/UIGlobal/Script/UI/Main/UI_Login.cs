/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Login : GComponent
	{
		public GImage m_bg;
		public GImage m_n19;
		public GImage m_n13;
		public GTextInput m_text_account;
		public UI_btn_login m_btn_login;
		public GImage m_n14;
		public GTextInput m_text_pwd;
		public UI_btn_regist m_btn_regist;
		public GTextField m_n20;
		public GTextField m_n21;

		public const string URL = "ui://du637vw1am2mt62";

		public static UI_Login CreateInstance()
		{
			return (UI_Login)UIPackage.CreateObject("Main","Login");
		}

		public UI_Login()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_n19 = (GImage)this.GetChildAt(1);
			m_n13 = (GImage)this.GetChildAt(2);
			m_text_account = (GTextInput)this.GetChildAt(3);
			m_btn_login = (UI_btn_login)this.GetChildAt(4);
			m_n14 = (GImage)this.GetChildAt(5);
			m_text_pwd = (GTextInput)this.GetChildAt(6);
			m_btn_regist = (UI_btn_regist)this.GetChildAt(7);
			m_n20 = (GTextField)this.GetChildAt(8);
			m_n21 = (GTextField)this.GetChildAt(9);
		}
	}
}