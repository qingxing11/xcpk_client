/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SignIn
{
	public partial class UI_SignInCom : GComponent
	{
		public GImage m_bg;
		public GImage m_bg2;
		public GTextField m_txt_vip;
		public GTextField m_txt_title;
		public GList m_list_sign;
		public UI_btn_close m_btn_close;
		public UI_btn_Vip m_btn_Vip;
		public UI_btn_coin m_btn_coin;

		public const string URL = "ui://ffq58mwnv4v9e";

		public static UI_SignInCom CreateInstance()
		{
			return (UI_SignInCom)UIPackage.CreateObject("SignIn","SignInCom");
		}

		public UI_SignInCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_bg = (GImage)this.GetChildAt(0);
			m_bg2 = (GImage)this.GetChildAt(1);
			m_txt_vip = (GTextField)this.GetChildAt(2);
			m_txt_title = (GTextField)this.GetChildAt(3);
			m_list_sign = (GList)this.GetChildAt(4);
			m_btn_close = (UI_btn_close)this.GetChildAt(5);
			m_btn_Vip = (UI_btn_Vip)this.GetChildAt(6);
			m_btn_coin = (UI_btn_coin)this.GetChildAt(7);
		}
	}
}