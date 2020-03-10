/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_FriendCom2 : GButton
	{
		public Controller m_c1;
		public Controller m_c2;
		public GImage m_bg;
		public GLoader m_icon;
		public GLoader m_lv_icon;
		public GTextField m_txt_lv;
		public GTextField m_txt_ID;
		public GRichTextField m_txt_nike;
		public UI_btn_delete2 m_btn_delete;
		public UI_btn_chatF m_btn_chat;
		public GImage m_n17;
		public GImage m_n18;

		public const string URL = "ui://eqqn9lxmfz63t80";

		public static UI_FriendCom2 CreateInstance()
		{
			return (UI_FriendCom2)UIPackage.CreateObject("Common","FriendCom2");
		}

		public UI_FriendCom2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_c2 = this.GetControllerAt(1);
			m_bg = (GImage)this.GetChildAt(0);
			m_icon = (GLoader)this.GetChildAt(1);
			m_lv_icon = (GLoader)this.GetChildAt(2);
			m_txt_lv = (GTextField)this.GetChildAt(3);
			m_txt_ID = (GTextField)this.GetChildAt(4);
			m_txt_nike = (GRichTextField)this.GetChildAt(5);
			m_btn_delete = (UI_btn_delete2)this.GetChildAt(6);
			m_btn_chat = (UI_btn_chatF)this.GetChildAt(7);
			m_n17 = (GImage)this.GetChildAt(8);
			m_n18 = (GImage)this.GetChildAt(9);
		}
	}
}