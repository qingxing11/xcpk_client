/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_bdsj : GComponent
	{
		public GImage m_n12;
		public GImage m_n13;
		public GImage m_bg;
		public GImage m_title;
		public GImage m_n7;
		public GImage m_n8;
		public UI_btn_ok m_btn_ok;
		public UI_btn_close m_btn_close;
		public GTextInput m_text_phoneNum;
		public GTextInput m_text_code;
		public GImage m_n14;
		public UI_btn_send m_btn_send;
		public GImage m_n16;
		public GTextField m_text_timer;

		public const string URL = "ui://4f5tb9ztdpct9c";

		public static UI_bdsj CreateInstance()
		{
			return (UI_bdsj)UIPackage.CreateObject("Set","bdsj");
		}

		public UI_bdsj()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n12 = (GImage)this.GetChildAt(0);
			m_n13 = (GImage)this.GetChildAt(1);
			m_bg = (GImage)this.GetChildAt(2);
			m_title = (GImage)this.GetChildAt(3);
			m_n7 = (GImage)this.GetChildAt(4);
			m_n8 = (GImage)this.GetChildAt(5);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(6);
			m_btn_close = (UI_btn_close)this.GetChildAt(7);
			m_text_phoneNum = (GTextInput)this.GetChildAt(8);
			m_text_code = (GTextInput)this.GetChildAt(9);
			m_n14 = (GImage)this.GetChildAt(10);
			m_btn_send = (UI_btn_send)this.GetChildAt(11);
			m_n16 = (GImage)this.GetChildAt(12);
			m_text_timer = (GTextField)this.GetChildAt(13);
		}
	}
}