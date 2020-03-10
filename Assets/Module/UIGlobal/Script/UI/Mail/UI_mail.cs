/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Mail
{
	public partial class UI_mail : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_bg_mask;
		public GImage m_bg;
		public GImage m_bg1;
		public GImage m_title1;
		public GImage m_title2;
		public UI_btn_close m_btn_close;
		public UI_btn_get m_btn_get;
		public UI_btn_delete m_btn_delete;
		public GTextField m_text_title;
		public GTextField m_text_content;
		public GTextField m_n11;
		public GLoader m_icon;
		public GTextField m_text_num;
		public GGroup m_n7;
		public GList m_list_mail;

		public const string URL = "ui://ez7i33lmvet0o";

		public static UI_mail CreateInstance()
		{
			return (UI_mail)UIPackage.CreateObject("Mail","mail");
		}

		public UI_mail()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_bg_mask = (GImage)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_bg1 = (GImage)this.GetChildAt(2);
			m_title1 = (GImage)this.GetChildAt(3);
			m_title2 = (GImage)this.GetChildAt(4);
			m_btn_close = (UI_btn_close)this.GetChildAt(5);
			m_btn_get = (UI_btn_get)this.GetChildAt(6);
			m_btn_delete = (UI_btn_delete)this.GetChildAt(7);
			m_text_title = (GTextField)this.GetChildAt(8);
			m_text_content = (GTextField)this.GetChildAt(9);
			m_n11 = (GTextField)this.GetChildAt(10);
			m_icon = (GLoader)this.GetChildAt(11);
			m_text_num = (GTextField)this.GetChildAt(12);
			m_n7 = (GGroup)this.GetChildAt(13);
			m_list_mail = (GList)this.GetChildAt(14);
		}
	}
}