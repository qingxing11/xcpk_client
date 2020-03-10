/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_Chat : GComponent
	{
		public Controller m_c1;
		public GImage m_n25;
		public GImage m_n27;
		public GLoader m_btn_close;
		public GList m_list_emoji;
		public GList m_list_shortcut;
		public GList m_list_chat;
		public GTextInput m_txt_input;
		public UI_btn_emjoy m_btn_emoji;
		public UI_btn_shutCut m_btn_shutcut;
		public UI_btn_chat m_btn_chat;
		public UI_btn_send m_btn_send;

		public const string URL = "ui://kxabpsetv1nxvm";

		public static UI_Chat CreateInstance()
		{
			return (UI_Chat)UIPackage.CreateObject("Chat","Chat");
		}

		public UI_Chat()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n25 = (GImage)this.GetChildAt(0);
			m_n27 = (GImage)this.GetChildAt(1);
			m_btn_close = (GLoader)this.GetChildAt(2);
			m_list_emoji = (GList)this.GetChildAt(3);
			m_list_shortcut = (GList)this.GetChildAt(4);
			m_list_chat = (GList)this.GetChildAt(5);
			m_txt_input = (GTextInput)this.GetChildAt(6);
			m_btn_emoji = (UI_btn_emjoy)this.GetChildAt(7);
			m_btn_shutcut = (UI_btn_shutCut)this.GetChildAt(8);
			m_btn_chat = (UI_btn_chat)this.GetChildAt(9);
			m_btn_send = (UI_btn_send)this.GetChildAt(10);
		}
	}
}