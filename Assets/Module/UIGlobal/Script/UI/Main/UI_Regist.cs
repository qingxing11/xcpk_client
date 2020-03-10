/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_Regist : GComponent
	{
		public GImage m_n0;
		public GImage m_n5;
		public GImage m_n4;
		public GImage m_n6;
		public GImage m_n7;
		public GImage m_n12;
		public GTextInput m_text_account;
		public GImage m_n15;
		public GTextInput m_text_nickname;
		public GImage m_n17;
		public GTextInput m_text_pwd;
		public GImage m_n19;
		public GTextInput m_text_pwdcon;
		public UI_btn_RegistOK m_btn_regist;
		public UI_btn_close_g2 m_btn_close;

		public const string URL = "ui://du637vw1am2mt6v";

		public static UI_Regist CreateInstance()
		{
			return (UI_Regist)UIPackage.CreateObject("Main","Regist");
		}

		public UI_Regist()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n5 = (GImage)this.GetChildAt(1);
			m_n4 = (GImage)this.GetChildAt(2);
			m_n6 = (GImage)this.GetChildAt(3);
			m_n7 = (GImage)this.GetChildAt(4);
			m_n12 = (GImage)this.GetChildAt(5);
			m_text_account = (GTextInput)this.GetChildAt(6);
			m_n15 = (GImage)this.GetChildAt(7);
			m_text_nickname = (GTextInput)this.GetChildAt(8);
			m_n17 = (GImage)this.GetChildAt(9);
			m_text_pwd = (GTextInput)this.GetChildAt(10);
			m_n19 = (GImage)this.GetChildAt(11);
			m_text_pwdcon = (GTextInput)this.GetChildAt(12);
			m_btn_regist = (UI_btn_RegistOK)this.GetChildAt(13);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(14);
		}
	}
}