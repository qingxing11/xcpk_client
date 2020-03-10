/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_Friend : GComponent
	{
		public Controller m_c1;
		public GLoader m_btn_hide;
		public GImage m_bg;
		public GImage m_n25;
		public GImage m_n27;
		public UI_btn_myfriend m_btn_friend;
		public UI_btn_addFriend m_btn_addFriend;
		public UI_btn_askFriend m_btn_info;
		public UI_btn_addFriend3 m_btn_addfriend2;
		public GImage m_n24;
		public GList m_list_info;
		public GList m_list_friend;
		public GTextField m_txt_fri_title;
		public GImage m_friendsIcon;
		public GImage m_infoIcon;
		public GImage m_n33;
		public GImage m_n34;
		public GTextInput m_txt_input;
		public UI_FriendCom m_friendcom;
		public UI_btn_look m_btn_look;
		public UI_btn_close m_btn_close;
		public GImage m_n45;
		public GTextField m_txt_info;
		public GGroup m_info;
		public Transition m_t0;

		public const string URL = "ui://eqqn9lxmg7lk9j";

		public static UI_Friend CreateInstance()
		{
			return (UI_Friend)UIPackage.CreateObject("Common","Friend");
		}

		public UI_Friend()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_btn_hide = (GLoader)this.GetChildAt(0);
			m_bg = (GImage)this.GetChildAt(1);
			m_n25 = (GImage)this.GetChildAt(2);
			m_n27 = (GImage)this.GetChildAt(3);
			m_btn_friend = (UI_btn_myfriend)this.GetChildAt(4);
			m_btn_addFriend = (UI_btn_addFriend)this.GetChildAt(5);
			m_btn_info = (UI_btn_askFriend)this.GetChildAt(6);
			m_btn_addfriend2 = (UI_btn_addFriend3)this.GetChildAt(7);
			m_n24 = (GImage)this.GetChildAt(8);
			m_list_info = (GList)this.GetChildAt(9);
			m_list_friend = (GList)this.GetChildAt(10);
			m_txt_fri_title = (GTextField)this.GetChildAt(11);
			m_friendsIcon = (GImage)this.GetChildAt(12);
			m_infoIcon = (GImage)this.GetChildAt(13);
			m_n33 = (GImage)this.GetChildAt(14);
			m_n34 = (GImage)this.GetChildAt(15);
			m_txt_input = (GTextInput)this.GetChildAt(16);
			m_friendcom = (UI_FriendCom)this.GetChildAt(17);
			m_btn_look = (UI_btn_look)this.GetChildAt(18);
			m_btn_close = (UI_btn_close)this.GetChildAt(19);
			m_n45 = (GImage)this.GetChildAt(20);
			m_txt_info = (GTextField)this.GetChildAt(21);
			m_info = (GGroup)this.GetChildAt(22);
			m_t0 = this.GetTransitionAt(0);
		}
	}
}