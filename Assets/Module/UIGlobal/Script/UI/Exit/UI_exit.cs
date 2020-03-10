/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Exit
{
	public partial class UI_exit : GComponent
	{
		public GImage m_n21;
		public GImage m_n13;
		public GImage m_n14;
		public GImage m_n15;
		public UI_btn_cancel m_btn_cancel;
		public UI_btn_ok m_btn_ok;
		public GImage m_n18;
		public UI_btn_close m_btn_close;

		public const string URL = "ui://tbio7epwroisd";

		public static UI_exit CreateInstance()
		{
			return (UI_exit)UIPackage.CreateObject("Exit","exit");
		}

		public UI_exit()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n21 = (GImage)this.GetChildAt(0);
			m_n13 = (GImage)this.GetChildAt(1);
			m_n14 = (GImage)this.GetChildAt(2);
			m_n15 = (GImage)this.GetChildAt(3);
			m_btn_cancel = (UI_btn_cancel)this.GetChildAt(4);
			m_btn_ok = (UI_btn_ok)this.GetChildAt(5);
			m_n18 = (GImage)this.GetChildAt(6);
			m_btn_close = (UI_btn_close)this.GetChildAt(7);
		}
	}
}