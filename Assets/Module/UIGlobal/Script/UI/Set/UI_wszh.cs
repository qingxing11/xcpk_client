/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_wszh : GComponent
	{
		public GImage m_n24;
		public GImage m_bg0;
		public GImage m_bg1;
		public GImage m_n7;
		public GImage m_n8;
		public UI_btn_close m_btn_close;
		public GTextInput m_text_acc;
		public GTextInput m_text_nickName;
		public GImage m_n14;
		public GTextInput m_text_pwd;
		public GImage m_n25;
		public GImage m_n26;
		public GTextInput m_text_pwd2;
		public UI_btn_create m_btn_create;
		public GImage m_n30;
		public GImage m_n31;
		public GImage m_n32;
		public GImage m_n33;

		public const string URL = "ui://4f5tb9ztazvv9h";

		public static UI_wszh CreateInstance()
		{
			return (UI_wszh)UIPackage.CreateObject("Set","wszh");
		}

		public UI_wszh()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n24 = (GImage)this.GetChildAt(0);
			m_bg0 = (GImage)this.GetChildAt(1);
			m_bg1 = (GImage)this.GetChildAt(2);
			m_n7 = (GImage)this.GetChildAt(3);
			m_n8 = (GImage)this.GetChildAt(4);
			m_btn_close = (UI_btn_close)this.GetChildAt(5);
			m_text_acc = (GTextInput)this.GetChildAt(6);
			m_text_nickName = (GTextInput)this.GetChildAt(7);
			m_n14 = (GImage)this.GetChildAt(8);
			m_text_pwd = (GTextInput)this.GetChildAt(9);
			m_n25 = (GImage)this.GetChildAt(10);
			m_n26 = (GImage)this.GetChildAt(11);
			m_text_pwd2 = (GTextInput)this.GetChildAt(12);
			m_btn_create = (UI_btn_create)this.GetChildAt(13);
			m_n30 = (GImage)this.GetChildAt(14);
			m_n31 = (GImage)this.GetChildAt(15);
			m_n32 = (GImage)this.GetChildAt(16);
			m_n33 = (GImage)this.GetChildAt(17);
		}
	}
}