/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Chat
{
	public partial class UI_Chat3 : GComponent
	{
		public Controller m_c1;
		public GImage m_n11;
		public GImage m_n13;
		public GImage m_n12;
		public GLoader m_btn_close;
		public UI_btn_cut3 m_btn_shutcut;
		public UI_btn_emoji3 m_btn_emoji;
		public UI_btn_voice m_btn_voice;
		public GList m_list_shortcut;
		public GList m_list_emoji;
		public GList m_list_chat;
		public GTextInput m_txt_input;
		public UI_btn_send3 m_btn_send;

		public const string URL = "ui://kxabpsetotjz5xxh";

		public static UI_Chat3 CreateInstance()
		{
			return (UI_Chat3)UIPackage.CreateObject("Chat","Chat3");
		}

		public UI_Chat3()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_c1 = this.GetControllerAt(0);
			m_n11 = (GImage)this.GetChildAt(0);
			m_n13 = (GImage)this.GetChildAt(1);
			m_n12 = (GImage)this.GetChildAt(2);
			m_btn_close = (GLoader)this.GetChildAt(3);
			m_btn_shutcut = (UI_btn_cut3)this.GetChildAt(4);
			m_btn_emoji = (UI_btn_emoji3)this.GetChildAt(5);
			m_btn_voice = (UI_btn_voice)this.GetChildAt(6);
			m_list_shortcut = (GList)this.GetChildAt(7);
			m_list_emoji = (GList)this.GetChildAt(8);
			m_list_chat = (GList)this.GetChildAt(9);
			m_txt_input = (GTextInput)this.GetChildAt(10);
			m_btn_send = (UI_btn_send3)this.GetChildAt(11);
		}
	}
}