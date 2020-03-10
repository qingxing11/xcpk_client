/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
	public partial class UI_FriendChatCom : GComponent
	{
		public GImage m_n1;
		public UI_btn_close m_btn_close;
		public GList m_list_friend;
		public GList m_list_info;
		public UI_btn_sendChat m_btn_send;
		public GImage m_n7;
		public GTextInput m_txt_input;

		public const string URL = "ui://eqqn9lxmh1lwta2";

		public static UI_FriendChatCom CreateInstance()
		{
			return (UI_FriendChatCom)UIPackage.CreateObject("Common","FriendChatCom");
		}

		public UI_FriendChatCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (GImage)this.GetChildAt(0);
			m_btn_close = (UI_btn_close)this.GetChildAt(1);
			m_list_friend = (GList)this.GetChildAt(2);
			m_list_info = (GList)this.GetChildAt(3);
			m_btn_send = (UI_btn_sendChat)this.GetChildAt(4);
			m_n7 = (GImage)this.GetChildAt(5);
			m_txt_input = (GTextInput)this.GetChildAt(6);
		}
	}
}