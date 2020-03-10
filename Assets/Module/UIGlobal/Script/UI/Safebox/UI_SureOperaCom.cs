/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Safebox
{
	public partial class UI_SureOperaCom : GComponent
	{
		public GGraph m_n5;
		public GImage m_n0;
		public GTextField m_txt_sureTitle;
		public UI_btn_sure m_btn_sure;
		public UI_btn_cancel m_btn_cancel;

		public const string URL = "ui://ey7bc1rcrwpf23";

		public static UI_SureOperaCom CreateInstance()
		{
			return (UI_SureOperaCom)UIPackage.CreateObject("Safebox","SureOperaCom");
		}

		public UI_SureOperaCom()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n5 = (GGraph)this.GetChildAt(0);
			m_n0 = (GImage)this.GetChildAt(1);
			m_txt_sureTitle = (GTextField)this.GetChildAt(2);
			m_btn_sure = (UI_btn_sure)this.GetChildAt(3);
			m_btn_cancel = (UI_btn_cancel)this.GetChildAt(4);
		}
	}
}