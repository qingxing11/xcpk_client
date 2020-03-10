/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_SureOperaCom2 : GComponent
	{
		public GGraph m_n9;
		public GImage m_n1;
		public GImage m_n5;
		public UI_btn_close m_btn_close;
		public GTextField m_txt_sureTitle;
		public UI_btn_sure m_btn_sure;
		public UI_btn_cancel m_btn_cancel;

		public const string URL = "ui://ey7bc1rcrwpf24";

		public static UI_SureOperaCom2 CreateInstance()
		{
			return (UI_SureOperaCom2)UIPackage.CreateObject("Safebox","SureOperaCom2");
		}

		public UI_SureOperaCom2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n9 = (GGraph)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n5 = (GImage)this.GetChildAt(2);
			m_btn_close = (UI_btn_close)this.GetChildAt(3);
			m_txt_sureTitle = (GTextField)this.GetChildAt(4);
			m_btn_sure = (UI_btn_sure)this.GetChildAt(5);
			m_btn_cancel = (UI_btn_cancel)this.GetChildAt(6);
		}
	}
}