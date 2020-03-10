/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_titleCom : GButton
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_n9;
		public GImage m_icon_title;
		public GTextField m_txt_info;
		public GTextField m_txt_addFriendInfo;
		public UI_btn_removeFriend m_btn_delete;
		public GLoader m_icon;
		public GLoader m_lv_icon;
		public GTextField m_txt_lv;
		public GTextField m_txt_ID;
		public GRichTextField m_txt_nike;
		public UI_btn_agree m_btn_sure;
		public UI_btn_refuse m_btn_refuse;
		public GGroup m_n1;

		public const string URL = "ui://eqqn9lxmfz639r";

		public static UI_titleCom CreateInstance()
		{
			return (UI_titleCom)UIPackage.CreateObject("Common","titleCom");
		}

		public UI_titleCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_n9 = (GImage)this.GetChildAt(0);
			m_icon_title = (GImage)this.GetChildAt(1);
			m_txt_info = (GTextField)this.GetChildAt(2);
			m_txt_addFriendInfo = (GTextField)this.GetChildAt(3);
			m_btn_delete = (UI_btn_removeFriend)this.GetChildAt(4);
			m_icon = (GLoader)this.GetChildAt(5);
			m_lv_icon = (GLoader)this.GetChildAt(6);
			m_txt_lv = (GTextField)this.GetChildAt(7);
			m_txt_ID = (GTextField)this.GetChildAt(8);
			m_txt_nike = (GRichTextField)this.GetChildAt(9);
			m_btn_sure = (UI_btn_agree)this.GetChildAt(10);
			m_btn_refuse = (UI_btn_refuse)this.GetChildAt(11);
			m_n1 = (GGroup)this.GetChildAt(12);
		}
	}
}