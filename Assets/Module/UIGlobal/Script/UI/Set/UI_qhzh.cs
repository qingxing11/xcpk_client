/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Set
{
	public partial class UI_qhzh : GComponent
	{
		public GImage m_n17;
		public GImage m_n20;
		public GImage m_bg;
		public UI_btn_ok m_btn_ok;
		public UI_btn_close m_btn_close;
		public GImage m_n7;
		public GTextInput m_account;
		public GImage m_n8;
		public GTextInput m_password;
		public GImage m_n16;
		public GImage m_n18;
		public GImage m_n19;

		public const string URL = "ui://4f5tb9ztdpct99";

		public static UI_qhzh CreateInstance()
		{
			return (UI_qhzh)UIPackage.CreateObject("Set","qhzh");
		}

		public UI_qhzh()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n17 = (GImage)this.GetChildAt(0);
			m_n20 = (GImage)this.GetChildAt(1);
			m_bg = (GImage)this.GetChildAt(2);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(3);
			m_btn_close = (UI_btn_close)this.GetChildAt(4);
			m_n7 = (GImage)this.GetChildAt(5);
			m_account = (GTextInput)this.GetChildAt(6);
			m_n8 = (GImage)this.GetChildAt(7);
			m_password = (GTextInput)this.GetChildAt(8);
			m_n16 = (GImage)this.GetChildAt(9);
			m_n18 = (GImage)this.GetChildAt(10);
			m_n19 = (GImage)this.GetChildAt(11);
		}
	}
}