/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_zhmm : GComponent
	{
		public GImage m_n12;
		public GImage m_bg0;
		public GImage m_bg1;
		public GImage m_n7;
		public GImage m_n8;
		public UI_btn_ok m_btn_ok;
		public UI_btn_close m_btn_close;
		public GTextField m_text_acc;
		public GTextInput m_text_pwd1;
		public GImage m_n13;
		public GImage m_n14;
		public GTextInput m_text_code;
		public UI_btn_getCode m_btn_getCode;
		public GImage m_n21;
		public GImage m_n22;
		public GTextField m_n24;
		public GImage m_n25;
		public GTextInput m_text_pwd2;
		public GTextField m_n27;

		public const string URL = "ui://4f5tb9ztrms99f";

		public static UI_zhmm CreateInstance()
		{
			return (UI_zhmm)UIPackage.CreateObject("Set","zhmm");
		}

		public UI_zhmm()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n12 = (GImage)this.GetChildAt(0);
			m_bg0 = (GImage)this.GetChildAt(1);
			m_bg1 = (GImage)this.GetChildAt(2);
			m_n7 = (GImage)this.GetChildAt(3);
			m_n8 = (GImage)this.GetChildAt(4);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(5);
			m_btn_close = (UI_btn_close)this.GetChildAt(6);
			m_text_acc = (GTextField)this.GetChildAt(7);
			m_text_pwd1 = (GTextInput)this.GetChildAt(8);
			m_n13 = (GImage)this.GetChildAt(9);
			m_n14 = (GImage)this.GetChildAt(10);
			m_text_code = (GTextInput)this.GetChildAt(11);
			m_btn_getCode = (UI_btn_getCode)this.GetChildAt(12);
			m_n21 = (GImage)this.GetChildAt(13);
			m_n22 = (GImage)this.GetChildAt(14);
			m_n24 = (GTextField)this.GetChildAt(15);
			m_n25 = (GImage)this.GetChildAt(16);
			m_text_pwd2 = (GTextInput)this.GetChildAt(17);
			m_n27 = (GTextField)this.GetChildAt(18);
		}
	}
}