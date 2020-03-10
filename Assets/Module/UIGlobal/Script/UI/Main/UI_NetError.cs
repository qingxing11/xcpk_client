/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Main
{
	public partial class UI_NetError : GComponent
	{
		public GImage m_n0;
		public GImage m_n1;
		public GTextField m_n2;
		public UI_btn_sure_g1 m_btn_sure;
		public UI_btn_sure_g1 m_btn_cancel;
		public UI_btn_close_g2 m_btn_close;

		public const string URL = "ui://du637vw110z9t4c";

		public static UI_NetError CreateInstance()
		{
			return (UI_NetError)UIPackage.CreateObject("Main","NetError");
		}

		public UI_NetError()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GTextField)this.GetChildAt(2);
			m_btn_sure = (UI_btn_sure_g1)this.GetChildAt(3);
			m_btn_cancel = (UI_btn_sure_g1)this.GetChildAt(4);
			m_btn_close = (UI_btn_close_g2)this.GetChildAt(5);
		}
	}
}