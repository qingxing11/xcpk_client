/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_chatCom : GComponent
	{
		public Controller m_c1;
		public Controller m_c2;
		public Controller m_c3;
		public GImage m_n12;
		public GLoader m_icon;
		public GRichTextField m_nike;
		public GRichTextField m_txt_title;
		public GLoader m_vipLv_icon;
		public GTextField m_nikeName;
		public GGroup m_left;
		public GLoader m_icon_r;
		public GRichTextField m_nike_r;
		public GRichTextField m_txt_title_r;
		public GLoader m_vipLv_icon_r;
		public GTextField m_nikeName_r;
		public GGroup m_right;

		public const string URL = "ui://kxabpsetv1nxvn";

		public static UI_chatCom CreateInstance()
		{
			return (UI_chatCom)UIPackage.CreateObject("Chat","chatCom");
		}

		public UI_chatCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_c3 = this.GetControllerAt(2);
			m_n12 = (GImage)this.GetChildAt(0);
			m_icon = (GLoader)this.GetChildAt(1);
			m_nike = (GRichTextField)this.GetChildAt(2);
			m_txt_title = (GRichTextField)this.GetChildAt(3);
			m_vipLv_icon = (GLoader)this.GetChildAt(4);
			m_nikeName = (GTextField)this.GetChildAt(5);
			m_left = (GGroup)this.GetChildAt(6);
			m_icon_r = (GLoader)this.GetChildAt(7);
			m_nike_r = (GRichTextField)this.GetChildAt(8);
			m_txt_title_r = (GRichTextField)this.GetChildAt(9);
			m_vipLv_icon_r = (GLoader)this.GetChildAt(10);
			m_nikeName_r = (GTextField)this.GetChildAt(11);
			m_right = (GGroup)this.GetChildAt(12);
		}
	}
}