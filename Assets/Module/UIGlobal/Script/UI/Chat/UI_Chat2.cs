/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_Chat2 : GComponent
	{
		public Controller m_c1;
		public GLoader m_btn_close;
		public GImage m_n2;
		public GImage m_n10;
		public UI_btn_cut m_btn_shutcut;
		public UI_btn_emjoy2 m_btn_emoji;
		public GList m_list_shortcut;
		public GList m_list_emoji;
		public GList m_list_chat;
		public GTextInput m_txt_input;
		public UI_btn_send2 m_btn_send;

		public const string URL = "ui://kxabpsetptr45xx9";

		public static UI_Chat2 CreateInstance()
		{
			return (UI_Chat2)UIPackage.CreateObject("Chat","Chat2");
		}

		public UI_Chat2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_btn_close = (GLoader)this.GetChildAt(0);
			m_n2 = (GImage)this.GetChildAt(1);
			m_n10 = (GImage)this.GetChildAt(2);
			m_btn_shutcut = (UI_btn_cut)this.GetChildAt(3);
			m_btn_emoji = (UI_btn_emjoy2)this.GetChildAt(4);
			m_list_shortcut = (GList)this.GetChildAt(5);
			m_list_emoji = (GList)this.GetChildAt(6);
			m_list_chat = (GList)this.GetChildAt(7);
			m_txt_input = (GTextInput)this.GetChildAt(8);
			m_btn_send = (UI_btn_send2)this.GetChildAt(9);
		}
	}
}